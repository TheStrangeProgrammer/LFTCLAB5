using System;
using System.Collections.Generic;
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
            Console.WriteLine(parser.Parse(input));
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
