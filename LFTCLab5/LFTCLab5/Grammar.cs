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
        Nonterminal source;
        public List<Nonterminal> nonterminals= new List<Nonterminal>();
        public List<Terminal> terminals = new List<Terminal>();
        public List<Production> productions = new List<Production>();
       
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
                    nonterminals.Add(new Nonterminal(splitGrammar[0]));
                    string[] splitProductions = splitGrammar[2].Split('|');
                    List<Token> tokens = new List<Token>();
                    foreach(string production in splitProductions)
                    {
                        foreach (char token in production.ToCharArray())
                        {
                            if(char.IsUpper(token))
                                tokens.Add(new Nonterminal(token.ToString()));
                            else if(char.IsLower(token))
                                tokens.Add(new Terminal(token.ToString()));
                        }

                    }
                    productions.Add(new Production(new Nonterminal(splitGrammar[0]), tokens));
                    foreach (string splitProduction in splitProductions)
                    {
                        foreach(char character in splitProduction.ToCharArray())
                        {
                            if(!terminals.Contains(new Terminal(character.ToString()))&& char.IsLower(character))
                                terminals.Add(new Terminal(character.ToString()));
                        }
                    }

                }
                //if (splits[i].Contains("="))
               
            }

        }

        public List<Production> GetProductionsForNonTerminal(string nonTerminal)
        {
            return productions.Where(production => production.source == new Nonterminal(nonTerminal)).ToList();
        }


    }
}
