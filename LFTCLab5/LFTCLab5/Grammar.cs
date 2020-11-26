using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;

namespace LFTCLab5
{
   
    class Grammar
    {
            private List<string> nonterminals= new List<string>();
            private List<string> terminals = new List<string>();
            private List<string> productions = new List<string>();
       
       public void ReadFile()
        {

            
            string text = File.ReadAllText(@"../../grammar.txt");
          
            text = text.Replace("\r", "");
            string[] splits = text.Split('\n');

            for (int i = 0; i < splits.Length; i++)
            {
                if (splits[i].Contains("->"))
                {
                    string[] splitGrammar = splits[i].Split(new char[] { '-', '>'}) ;
                    nonterminals.Add(splitGrammar[0]);
                    string[] splitProductions = splitGrammar[2].Split('|');
                    productions.AddRange(splitProductions);
                    foreach(string splitProduction in splitProductions)
                    {
                        foreach(char character in splitProduction.ToCharArray())
                        {
                            if(!terminals.Contains(character.ToString())&& char.IsLower(character))
                                terminals.Add(character.ToString());
                        }
                    }

                }
                //if (splits[i].Contains("="))
               
            }

        }



        public void print_nonterminals()
        {
           Console.WriteLine("Nonterminals:");
            foreach (string x in this.nonterminals)
                Console.Write(x+ " ");
        }
        public void print_terminals()
        {
            Console.WriteLine("terminals:");
            foreach (string x in this.terminals)
                Console.Write(x + " ");
        }
        public void print_productions()
        {
            Console.WriteLine("Productions:");
            foreach (string x in this.productions)
                Console.Write(x + " ");
        }
    }
}
