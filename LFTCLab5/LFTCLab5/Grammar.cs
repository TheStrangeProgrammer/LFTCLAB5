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
        public List<string> nonterminals= new List<string>();
        public List<string> terminals = new List<string>();
        public Dictionary<string,List<string>> productions = new Dictionary<string, List<string>>();
       
       public void ReadFile()
        {

            
            string text = File.ReadAllText(@"../../grammar.txt");
          
            text = text.Replace("\r", "");
            string[] splits = text.Split('\n');

            for (int i = 0; i < splits.Length; i++)
            {
                if (splits[i].Contains("->"))
                {
                    string[] splitGrammar = splits[i].Split(new char[] { '-', '>'});
                    nonterminals.Add(splitGrammar[0]);
                    string[] splitProductions = splitGrammar[2].Split('|');
                    productions.Add(splitGrammar[0], splitProductions.ToList());
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

        public List<string> GetProductionsForNonTerminal(string nonTerminal)
        {
            return productions[nonTerminal];
        }


    }
}
