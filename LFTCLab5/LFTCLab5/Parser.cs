using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFTCLab5
{
    class Parser
    {
        private Grammar grammar;
        public Parser(Grammar grammar)
        {
            this.grammar = grammar;
        }
        public bool Parse(string toParse)
        {
            Configuration config = new Configuration(grammar.startingSymbol);
            while (config.state !="f"&& config.state != "e")
            {
                if(config.state == "q")
                {
                    if (config.beta.Count == 0&&config.position==toParse.Length)
                    {
                        Success(config);
                    }
                    else
                    {
                        if (config.beta.Peek().GetType()==typeof(Nonterminal))
                            Expand(config);
                        else if (config.beta.Peek().ToString()==toParse[config.position].ToString())
                            Advance(config);
                        else
                            MomentaryInsuccess(config);
                    }
                }
                else
                {
                    if (config.state == "b")
                    {
                        if (config.alpha.Peek().Value is Terminal)
                        {
                            Back(config);
                        }
                        else
                        {
                            AnotherTry(config);
                        }

                    }
                        

                }
            }

            if (config.state == "e")
                return false;
            return true;
        }
        private void Expand(Configuration configuration)
        {
            Production production = grammar.GetProductionsForNonTerminal((Nonterminal)configuration.beta.Peek()).First();
            configuration.beta.Pop();
            foreach (Token token in production.GetReverseTokens())
            {
                configuration.alpha.Push(new KeyValuePair<int, Token>(0, production.source));
                configuration.beta.Push(token);
            }
            
            
            
        }
        private void Advance(Configuration configuration)
        {
            configuration.position += 1;
            configuration.alpha.Push(new KeyValuePair<int, Token>(configuration.alpha.Peek().Key, configuration.beta.Pop()));
        }
        private void MomentaryInsuccess(Configuration configuration)
        {
            configuration.state = "b";
        }
        private void Back(Configuration configuration)
        {
            configuration.position -= 1;
            configuration.beta.Push(configuration.alpha.Pop().Value);
        }
        private void AnotherTry(Configuration configuration)
        {
            
            if (grammar.GetProductionsForNonTerminal((Nonterminal)configuration.alpha.Peek().Value).ElementAtOrDefault(configuration.alpha.Peek().Key + 1) != null) 
            {
                

                Production production = grammar.GetProductionsForNonTerminal((Nonterminal)configuration.alpha.Peek().Value)[configuration.alpha.Peek().Key + 1];
                configuration.state = "q";
                configuration.alpha.Pop();
                for(int i=0;i< production.tokens.Count;i++)
                    configuration.beta.Pop();
                foreach (Token token in production.GetReverseTokens())
                {
                    configuration.alpha.Push(new KeyValuePair<int, Token>(configuration.alpha.Peek().Key + 1, production.source));
                    configuration.beta.Push(token);
                }
                
            }
            else
            {
                if (configuration.position == 1&& configuration.alpha.Peek().Value.Equals(grammar.startingSymbol))
                {
                    configuration.state = "e";
                }
                else
                {
                    configuration.beta.Push(configuration.alpha.Pop().Value);
                }
            }

            
        }
        private void Success(Configuration configuration)
        {
            configuration.state = "f";
        }
    }
}
