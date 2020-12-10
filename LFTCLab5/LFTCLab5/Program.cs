using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LFTCLab5
{
    class Program
    {
        private static Grammar grammar;
        private static Parser parser;
        static void Help()
        {

        }
        static void Main(string[] args)
        {
            grammar = new Grammar();
            grammar.ReadFile();
            parser = new Parser(grammar);
            bool run=true;
            string input;
            while (run)
            {
                input = Console.ReadLine();
                switch (input)
                {
                    case "print":
                        GetTypeOfPrint();
                        break;
                    case "parse":
                        ParsePhrase();
                        break;
                    case "5":
                        break;
                    case "help":
                        Help();
                        break;
                    case "exit":
                        run = false;
                        break;
                }

            }
        }

        private static void ParsePhrase()
        {
            string input;
            input = Console.ReadLine();
            List<Configuration> configs = parser.Parse(input);
            Configuration config = configs[configs.Count-1];
            if (config.state == "f")
            {
                Console.WriteLine("Accepted");
                File.WriteAllText(@"D:\faculta\s1\Limbaje formale si tehnici de compilare\LFTCLAB5\LFTCLab5\LFTCLab5\out.txt",config.AlphaToString());
            }
            else
            {
                Console.WriteLine("Rejected");
            }
        }

        private static void GetTypeOfPrint()
        {
            string input;
            input = Console.ReadLine();
            if (input == "nt")
            {
                Console.WriteLine(string.Join(",", grammar.nonterminals));
            }
            else if (input == "t")
            {
                Console.WriteLine(string.Join(",", grammar.terminals));

            }
            else if (input == "p")
            {
                Console.WriteLine(string.Join(",", grammar.productions));
            }
            else {
                Console.WriteLine(string.Join(",", grammar.GetProductionsForNonTerminal(new Nonterminal(input))));
            }
        }
    }
}
