using AbreNAire_LibrairieClasses;
using System;
using System.Collections.Generic;

namespace ArbreNAire_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ArbreAutoCompletion arbre = AjouterMotsDictionnaire();

            List<String> listeMots = arbre.CompleterPrefixe("amo");
            foreach(String mot in listeMots)
            {
                Console.WriteLine(mot);
            }

            
            ArbreExpression arbre2 = GenerateurArbreExpression.ExempleExpression2();
            Console.WriteLine(arbre2.Calculer().ToString());

        }

        // Ajouter tous les mots du dictionnaire dans un arbre
        public static ArbreAutoCompletion AjouterMotsDictionnaire()
        {
            String[] motsDictionnaire = System.IO.File.ReadAllLines("C:\\info\\S3\\Algorithme avancée\\CSFOY_S3_Algorithme\\AA_Module09_ArbreNAire\\dictionnaire.txt");
            ArbreAutoCompletion arbre = new ArbreAutoCompletion();
            for (int index = 0; index < motsDictionnaire.Length; index++)
            {
                arbre.AjouterMot(motsDictionnaire[index]);
            }

            return arbre;
        }
    }
}
