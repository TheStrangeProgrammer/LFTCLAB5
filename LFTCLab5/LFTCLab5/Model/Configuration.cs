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

        public Configuration(Nonterminal startingSymbol)
        {
            state = "q";
            position = 0;
            alpha = new Stack<KeyValuePair<int, Token>>();
            beta = new Stack<Token>(); 
            beta.Push(startingSymbol);
        }
        public Configuration(Configuration config)
        {
            state = config.state;
            position = config.position;
            alpha = config.alpha;
            beta = config.beta;
        }
        public string AlphaToString()
        {
            string toPrint = "";
            foreach(KeyValuePair<int, Token> pair in alpha)
            {
                toPrint += pair.Value.ToString();
                if(pair.Value.GetType()==typeof(Nonterminal))
                    toPrint += pair.Key.ToString();
            }
            return toPrint;
        }
    }
}
