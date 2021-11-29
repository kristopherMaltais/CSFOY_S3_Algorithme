using System;
using System.Collections.Generic;
using PileEtFile_LibrairieClasses;

namespace PileEtFile_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = "(ab + sdf dsd (sdf))";

            Console.WriteLine(ValiderParenthese(test));
        }

        public static bool ValiderParenthese(string p_chaineAVerifier)
        {
            // Préconditions
            if (p_chaineAVerifier == null)
            {
                throw new ArgumentNullException("La chaine à vérifier ne peut pas être null");
            }

            bool chaineEstValide = true;
            Pile<char> caracteres = new Pile<char>();

            foreach(char caractere in p_chaineAVerifier)
            {
                if (caractere == '(')
                {
                    caracteres.Empiler(caractere);
                }
                else if (!caracteres.EstPileVide && caractere == ')')
                {
                    caracteres.Depiler();
                }
                else if(caracteres.EstPileVide && caractere == ')')
                {
                    chaineEstValide = false;
                    break;
                }
            }

            if(!caracteres.EstPileVide)
            {
                chaineEstValide = false;
            }

            return chaineEstValide;
        }
    }
}
