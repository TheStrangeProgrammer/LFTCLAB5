using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFTCLab5
{
    public class Token
    {
        public Token(string name)
        {
            this.name = name;
        }
        public string name;

        public override bool Equals(object obj)
        {
            return name == ((Token)obj).name;
        }
        public override string ToString()
        {
            return name;
        }
    }
}
