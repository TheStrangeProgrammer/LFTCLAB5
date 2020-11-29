using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFTCLab5
{
    public class Configuration
    {
        public string state;
        public int position;
        public Stack<KeyValuePair<int,Token>> alpha;
        public Stack<Token> beta;
    }
}
