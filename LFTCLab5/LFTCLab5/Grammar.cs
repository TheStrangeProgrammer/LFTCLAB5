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

            
            string text = File.ReadAllText(@"grammar.txt");
          
            text = text.Replace("\r", "");
            string[] splits = text.Split('\n');

            for (int i = 0; i < splits.Length; i++)
            {
                if (splits[i].Contains("->"))
                {
                    string[] splitGrammar = splits[i].Split(new char[] { '-', '>'}) ;
                    nonterminals.Add(splitGrammar[0]);
                    string[] splitProductions = splitGrammar[1].Split('|');
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
            System.Console.Write("Nonterminals:");
            foreach (string x in this.nonterminals)
                System.Console.Write(x+ " ");
        }
        public void print_terminals()
        {
            System.Console.Write("terminals:");
            foreach (string x in this.terminals)
                System.Console.Write(x + " ");
        }
        public void print_productions()
        {
            System.Console.Write("Productions:");
            foreach (string x in this.productions)
                System.Console.Write(x + " ");
        }
    }
}
