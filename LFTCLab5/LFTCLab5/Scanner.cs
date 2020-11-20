using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFTCLab5
{
   
    class Scanner
    {
       
        void ReadFile()
        {
            List<string> terminals= new List<string>();
            List<string> nonTerminals = new List<string>();
            List<string> productions = new List<string>();

            string text = File.ReadAllText(@"LFTCLab4\grammar.in");
            text = text.Replace("\r", "");
            string[] splits = text.Split('\n');

            for (int i = 0; i < splits.Length; i++)
            {
                if (splits[i].Contains("->"))
                {
                    string[] splitGrammar = splits[i].Split(new char[] { '-', '>'}) ;
                    terminals.Add(splitGrammar[0]);
                    string[] splitProductions = splitGrammar[1].Split('|');
                    productions.AddRange(splitProductions);
                    foreach(string splitProduction in splitProductions)
                    {
                        foreach(char character in splitProduction.ToCharArray())
                        {
                            if(!nonTerminals.Contains(character.ToString())&& char.IsLower(character))
                                nonTerminals.Add(character.ToString());
                        }
                    }

                }
                if (splits[i].Contains("="))
                {

                }
            }

        }
    }
}
