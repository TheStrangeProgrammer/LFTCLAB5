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

        public void Expand(Configuration configuration)
        {
            Production production = grammar.GetProductionsForNonTerminal((Nonterminal)configuration.beta.Peek()).First();
            configuration.beta.Pop();
            foreach (Token token in production.tokens)
            {
                configuration.alpha.Push(new KeyValuePair<int, Token>(1, token));
                configuration.beta.Push(token);
            }
            
            
            
        }
        public void Advance(Configuration configuration)
        {
            configuration.position += 1;
            configuration.alpha.Push(new KeyValuePair<int, Token>(configuration.alpha.Peek().Key, configuration.beta.Pop()));
        }
        public void MomentaryInsuccess(Configuration configuration)
        {
            configuration.state = "b";
        }
        public void Back(Configuration configuration)
        {
            configuration.position -= 1;
            configuration.beta.Push(configuration.alpha.Pop().Value);
        }
        public void AnotherTry(Configuration configuration)
        {
            
            if (grammar.GetProductionsForNonTerminal((Nonterminal)configuration.beta.Peek()).ElementAtOrDefault(configuration.alpha.Peek().Key + 1) != null) 
            {
                configuration.state = "q";
                configuration.alpha.Pop();
                configuration.beta.Pop();

                Production production = grammar.GetProductionsForNonTerminal((Nonterminal)configuration.beta.Peek())[configuration.alpha.Peek().Key + 1];
                foreach (Token token in production.tokens)
                {
                    configuration.alpha.Push(new KeyValuePair<int, Token>(configuration.alpha.Peek().Key + 1, token));
                    configuration.beta.Push(token);
                }
                
            }
            else
            {
                if (configuration.position == 1&& configuration.alpha.Peek().Value.Equals(new Token("S")))
                {
                    configuration.state = "e";
                }
                else
                {
                    configuration.beta.Push(configuration.alpha.Pop().Value);
                }
            }

            
        }
        public void Success(Configuration configuration)
        {
            configuration.state = "f";
        }
    }
}
