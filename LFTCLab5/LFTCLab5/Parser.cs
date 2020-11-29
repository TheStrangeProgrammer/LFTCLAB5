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
            Production production = grammar.GetProductionsForNonTerminal(configuration.beta.Peek()).First();
            configuration.alpha.Push(new KeyValuePair<int, string> ( 1, production ));
            configuration.beta.Pop();
            configuration.beta.Push(production);
        }
        public void Advance(Configuration configuration)
        {
            configuration.position += 1;
            configuration.alpha.Push(new KeyValuePair<int, string>(configuration.alpha.Peek().Key, configuration.beta.Pop()));
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
            
            if (grammar.GetProductionsForNonTerminal(configuration.beta.Peek()).ElementAtOrDefault(configuration.alpha.Peek().Key + 1) != null) 
            {
                configuration.state = "q";
                configuration.alpha.Pop();
                configuration.beta.Pop();

                string production = grammar.GetProductionsForNonTerminal(configuration.beta.Peek())[configuration.alpha.Peek().Key + 1];

                configuration.alpha.Push(new KeyValuePair<int, string>(configuration.alpha.Peek().Key, production));
                configuration.beta.Push(production);
            }
            else
            {
                if (configuration.position == 1&& configuration.alpha.Peek()=="S")
                {
                    configuration.state = "e";
                }
                else
                {
                    configuration.beta.Push(configuration.alpha.Pop());
                }
            }

            
        }
        public void Success(Configuration configuration)
        {
            configuration.state = "f";
        }
    }
}
