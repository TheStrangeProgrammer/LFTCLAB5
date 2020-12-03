using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFTCLab5
{
    public class Terminal : Token
    {
        public Terminal(string name) : base(name)
        {
        }
        public override bool isTerminal()
        {
            return true;
        }
        public override bool isNonterminal()
        {
            return false;
        }
    }
}
