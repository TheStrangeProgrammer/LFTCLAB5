using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LFTCLab5
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int input = 0;

                if (input == 0)
                {
                    Grammar gramatik = new Grammar { };
                    gramatik.ReadFile();
                    gramatik.print_nonterminals();
                    gramatik.print_terminals();
                    gramatik.print_productions();
                }
                else break;

                input = System.Console.Read();


            }
        }
        
    }
}
