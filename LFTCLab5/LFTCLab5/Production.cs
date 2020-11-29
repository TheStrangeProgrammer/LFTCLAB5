using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFTCLab5
{
    public class Production
    {
        public Nonterminal source;
        public List<Token> tokens;

        public Production(Nonterminal source, List<Token> tokens)
        {
            this.source = source;
            this.tokens = tokens;
        }
    }
}
