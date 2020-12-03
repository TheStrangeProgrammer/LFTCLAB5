using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFTCLab5
{
    public class Nonterminal : Token
    {
        public Nonterminal(string name) : base(name)
        {
        }
        public override bool isTerminal()
        {
            return false;
        }
        public override bool isNonterminal()
        {
            return true;
        }
    }
}
