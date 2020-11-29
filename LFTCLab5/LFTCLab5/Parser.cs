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
            string production = grammar.GetProductionsForNonTerminal(configuration.beta.Peek()).First();
            configuration.alpha.Push(production);
            configuration.beta.Pop();
            configuration.beta.Push(production);
        }
        public void Advance(Configuration configuration)
        {
            configuration.position += 1;
            configuration.alpha.Push(configuration.beta.Pop());
        }
        public void MomentaryInsuccess(Configuration configuration)
        {
            configuration.state = "b";
        }
        public void Back(Configuration configuration)
        {
            configuration.position -= 1;
            configuration.beta.Push(configuration.alpha.Pop());
        }
        public void AnotherTry(Configuration configuration)
        {
            configuration.state = "q";
            configuration.alpha.Pop();
            configuration.beta.Pop();
            configuration.currentProduction += 1;
            string production = grammar.GetProductionsForNonTerminal(configuration.beta.Peek())[configuration.currentProduction];
            configuration.beta.Push(production);
        }
        public void Success(Configuration configuration)
        {

        }
    }
}
