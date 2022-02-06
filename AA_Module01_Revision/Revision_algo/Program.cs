using System;
using System.Collections.Generic;
using System.Linq;

namespace Revision_algo
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] valeurs = new int[] { 4, 3, 6, 1 };
            int[] resultat = TriRapide<int>(valeurs);

            foreach(int element in resultat)
            {
                Console.WriteLine(element);
            }


        }

        // Exercice 1
        public static typeElement[] TriABulle<typeElement>(typeElement[] p_valeurs)
        where typeElement : IComparable<typeElement>
        {
            // Préconditions
            if(p_valeurs == null)
            {
                throw new ArgumentNullException("Le tableau ne peut pas être null", "p_valeurs");
            }

            typeElement ancienneValeur = default(typeElement);
            bool permutationAuDernierTour = true;
            int indiceMax = p_valeurs.Length;
            typeElement[] valeursCopiees = CopierTableau(p_valeurs);

            while (permutationAuDernierTour)
            {
                permutationAuDernierTour = false;

                for(int indiceCourant = 0; indiceCourant < indiceMax - 1; indiceCourant++)
                {
                    if(valeursCopiees[indiceCourant + 1].CompareTo(valeursCopiees[indiceCourant]) < 0)
                    {
                        ancienneValeur = valeursCopiees[indiceCourant + 1];
                        valeursCopiees[indiceCourant + 1] = valeursCopiees[indiceCourant];
                        valeursCopiees[indiceCourant] = ancienneValeur;
                        permutationAuDernierTour = true;

                    }
                }
                indiceMax = indiceMax - 1;
            }

            return valeursCopiees;
        }
        public static typeElement[] CopierTableau<typeElement>(typeElement[] p_tableau)
        {
            // Préconditions
            if(p_tableau == null)
            {
                throw new ArgumentNullException("Le tableau en paramètre ne peut pas être null", "p_tableau");
            }

            typeElement[] nouveauTableau = new typeElement[p_tableau.Length];
            for (int index = 0; index < p_tableau.Length; index++)
            {
                nouveauTableau[index] = p_tableau[index];
            }

            return nouveauTableau;
        }
        public static typeElement[] TriRapide<typeElement>(typeElement[] p_valeurs)
        where typeElement : IComparable<typeElement>
        {
            // Préconditions
            if(p_valeurs == null)
            {
                throw new ArgumentNullException("Le tableau en paramètre ne peut pas être null", "p_valeurs");
            }

            typeElement[] valeurCopiees = CopierTableau(p_valeurs);
            TriRapide_rec(valeurCopiees, 0, valeurCopiees.Length - 1);

            return valeurCopiees;
        }
        public static void TriRapide_rec<typeElement>(typeElement[] p_valeurs, int p_indicePremier, int p_indiceDernier)
        where typeElement : IComparable<typeElement>
        {
            // Préconditions
            if(p_valeurs == null)
            {
                throw new ArgumentNullException("Le tableau en paramètre ne peut pas être null", "p_valeurs");
            }

            if(p_indicePremier < 0 || p_indicePremier >= p_valeurs.Length)
            {
                throw new ArgumentOutOfRangeException("L'indicePremier doit être plus grand que 0 et inférieur à la taille du tableau passé en paramètre", "p_indicePremier");
            }

            if (p_indiceDernier < 0 || p_indiceDernier >= p_valeurs.Length)
            {
                throw new ArgumentOutOfRangeException("L'indiceDernier doit être plus grand que 0 et inférieur à la taille du tableau passé en paramètre", "p_indiceDernier");
            }

            if(p_indicePremier > p_indiceDernier)
            {
                throw new ArgumentException("IndicePremier doit être inférieur à indiceDernier");
            }


            int indicePivot = 0;
            if(p_indicePremier < p_indiceDernier)
            {
                indicePivot = ChoixPivot(p_valeurs, p_indicePremier, p_indiceDernier);
                indicePivot = Partionner(p_valeurs, p_indicePremier, p_indiceDernier, indicePivot);
                TriRapide_rec(p_valeurs, p_indicePremier, indicePivot - 1);
                TriRapide_rec(p_valeurs, indicePivot + 1, p_indiceDernier);
            }
        }
        public static int ChoixPivot<typeElement>(typeElement[] p_valeurs, int p_indicePremier, int p_indiceDernier)
        {
            // Préconditions
            if (p_valeurs == null)
            {
                throw new ArgumentNullException("Le tableau en paramètre ne peut pas être null", "p_valeurs");
            }

            if (p_indicePremier < 0 || p_indicePremier >= p_valeurs.Length)
            {
                throw new ArgumentOutOfRangeException("L'indicePremier doit être plus grand que 0 et inférieur à la taille du tableau passé en paramètre", "p_indicePremier");
            }

            if (p_indiceDernier < 0 || p_indiceDernier >= p_valeurs.Length)
            {
                throw new ArgumentOutOfRangeException("L'indiceDernier doit être plus grand que 0 et inférieur à la taille du tableau passé en paramètre", "p_indiceDernier");
            }

            if (p_indicePremier > p_indiceDernier)
            {
                throw new ArgumentException("IndicePremier doit être inférieur à indiceDernier");
            }

            return p_indicePremier;
        }
        public static int Partionner<typeElement>(typeElement[] p_valeurs, int p_indicePremier, int p_indiceDernier, int p_indicePivot)
        where typeElement : IComparable<typeElement>
        {
            // Préconditions
            if (p_valeurs == null)
            {
                throw new ArgumentNullException("Le tableau en paramètre ne peut pas être null", "p_valeurs");
            }

            if (p_indicePremier < 0 || p_indicePremier >= p_valeurs.Length)
            {
                throw new ArgumentOutOfRangeException("L'indicePremier doit être plus grand que 0 et inférieur à la taille du tableau passé en paramètre", "p_indicePremier");
            }

            if (p_indiceDernier < 0 || p_indiceDernier >= p_valeurs.Length)
            {
                throw new ArgumentOutOfRangeException("L'indiceDernier doit être plus grand que 0 et inférieur à la taille du tableau passé en paramètre", "p_indiceDernier");
            }

            if (p_indicePivot < 0 || p_indicePivot >= p_valeurs.Length)
            {
                throw new ArgumentOutOfRangeException("L'indicePivot doit être plus grand que 0 et inférieur à la taille du tableau passé en paramètre", "p_indicePivot");
            }

            if (p_indicePremier > p_indiceDernier)
            {
                throw new ArgumentException("IndicePremier doit être inférieur à indiceDernier");
            }

            typeElement ancienneValeur = default(typeElement);
            int futurIndicePivot = p_indicePremier;

            ancienneValeur = p_valeurs[p_indicePivot];
            p_valeurs[p_indicePivot] = p_valeurs[p_indiceDernier];
            p_valeurs[p_indiceDernier] = ancienneValeur;

            for(int indiceValeurARanger = p_indicePremier; indiceValeurARanger < p_indiceDernier; indiceValeurARanger++)
            {
                if(p_valeurs[indiceValeurARanger].CompareTo(p_valeurs[p_indiceDernier]) <= 0)
                {
                    ancienneValeur = p_valeurs[futurIndicePivot];
                    p_valeurs[futurIndicePivot] = p_valeurs[indiceValeurARanger];
                    p_valeurs[indiceValeurARanger] = ancienneValeur;
                    futurIndicePivot = futurIndicePivot + 1;
                }
            }

            ancienneValeur = p_valeurs[futurIndicePivot];
            p_valeurs[futurIndicePivot] = p_valeurs[p_indiceDernier];
            p_valeurs[p_indiceDernier] = ancienneValeur;

            return futurIndicePivot;
        }

        // Exercice 2
        public static bool RechercherValeur<typeElement>(typeElement[] p_collection, typeElement p_valeurAChercher)
        {
            // Préconditions
            if(p_collection == null)
            {
                throw new ArgumentNullException("Le tableau ne peut pas être null", "p_collection");
            }


            bool estTrouve = false;

            for(int indiceValeurCourante = 0; indiceValeurCourante < p_collection.Length; indiceValeurCourante++)
            {
                if(p_collection[indiceValeurCourante].Equals(p_valeurAChercher))
                {
                    estTrouve = true;
                }
            }

            return estTrouve;
        }
        public static bool RechercherValeurDichotomie<typeElement>(typeElement[] p_collection, typeElement p_valeurAChercher)
        where typeElement : IComparable<typeElement>
        {
            // Préconditions
            if(p_collection == null)
            {
                throw new ArgumentNullException("Le tableau ne peut pas être null", "p_collection");
            }
            
            bool estTrouve = false;
            int indicePremier = 0;
            int indiceDernier = p_collection.Length - 1;
            int indiceMilieu = 0;

            while (!estTrouve && indicePremier <= indiceDernier)
            {
                indiceMilieu = (indicePremier + indiceDernier) / 2;
                if (p_collection[indiceMilieu].Equals(p_valeurAChercher))
                {
                    estTrouve = true;
                }

                else if(p_collection[indiceMilieu].CompareTo(p_valeurAChercher) < 0)
                {
                    indicePremier = indiceMilieu + 1;
                }

                else
                {
                    indiceDernier = indiceMilieu - 1;
                }
            }

            return estTrouve;
        }

        // Exercice 3
        public static typeElement[] TriABulleLambda<typeElement>(typeElement[] p_valeurs, Func<typeElement, typeElement, bool> p_fonctionComparaision)
        where typeElement : IComparable<typeElement>
        {
            // Préconditions
            if (p_valeurs == null)
            {
                throw new ArgumentNullException("Le tableau ne peut pas être null", "p_valeurs");
            }

            if(p_fonctionComparaision == null)
            {
                throw new ArgumentNullException("La fonction lambda ne peut pas être null", "p_fonctionComparaison");
            }

            typeElement ancienneValeur = default(typeElement);
            bool permutationAuDernierTour = true;
            int indiceMax = p_valeurs.Length;
            typeElement[] valeursCopiees = CopierTableau(p_valeurs);

            while (permutationAuDernierTour)
            {
                permutationAuDernierTour = false;

                for (int indiceCourant = 0; indiceCourant < indiceMax - 1; indiceCourant++)
                {
                    if (p_fonctionComparaision(valeursCopiees[indiceCourant], valeursCopiees[indiceCourant + 1]))
                    {
                        ancienneValeur = valeursCopiees[indiceCourant + 1];
                        valeursCopiees[indiceCourant + 1] = valeursCopiees[indiceCourant];
                        valeursCopiees[indiceCourant] = ancienneValeur;
                        permutationAuDernierTour = true;

                    }
                }
                indiceMax = indiceMax - 1;
            }

            return valeursCopiees;

        }
        public static typeElement[] TriRapideLambda<typeElement>(typeElement[] p_valeurs, Func<typeElement, typeElement, bool> p_fonctionComparaison)
        where typeElement : IComparable<typeElement>
        {
            // Préconditions
            if (p_valeurs == null)
            {
                throw new ArgumentNullException("Le tableau en paramètre ne peut pas être null", "p_valeurs");
            }

            if (p_fonctionComparaison == null)
            {
                throw new ArgumentNullException("La fonction lambda ne peut pas être null", "p_fonctionComparaison");
            }


            typeElement[] valeurCopiees = CopierTableau(p_valeurs);
            TriRapide_recLambda(valeurCopiees, 0, valeurCopiees.Length - 1, p_fonctionComparaison);

            return valeurCopiees;
        }
        public static void TriRapide_recLambda<typeElement>(typeElement[] p_valeurs, int p_indicePremier, int p_indiceDernier, Func<typeElement, typeElement, bool> p_fonctionComparaison)
        where typeElement : IComparable<typeElement>
        {
            // Préconditions
            if (p_valeurs == null)
            {
                throw new ArgumentNullException("Le tableau en paramètre ne peut pas être null", "p_valeurs");
            }

            if (p_indicePremier < 0 || p_indicePremier >= p_valeurs.Length)
            {
                throw new ArgumentOutOfRangeException("L'indicePremier doit être plus grand que 0 et inférieur à la taille du tableau passé en paramètre", "p_indicePremier");
            }

            if (p_indiceDernier < 0 || p_indiceDernier >= p_valeurs.Length)
            {
                throw new ArgumentOutOfRangeException("L'indiceDernier doit être plus grand que 0 et inférieur à la taille du tableau passé en paramètre", "p_indiceDernier");
            }

            if (p_indicePremier > p_indiceDernier)
            {
                throw new ArgumentException("IndicePremier doit être inférieur à indiceDernier");
            }

            if (p_fonctionComparaison == null)
            {
                throw new ArgumentNullException("La fonction lambda ne peut pas être null", "p_fonctionComparaison");
            }

            int indicePivot = 0;
            if (p_indicePremier < p_indiceDernier)
            {
                indicePivot = ChoixPivotLambda(p_valeurs, p_indicePremier, p_indiceDernier);
                indicePivot = PartionnerLambda(p_valeurs, p_indicePremier, p_indiceDernier, indicePivot, p_fonctionComparaison);
                TriRapide_rec(p_valeurs, p_indicePremier, indicePivot - 1);
                TriRapide_rec(p_valeurs, indicePivot + 1, p_indiceDernier);
            }
        }
        public static int ChoixPivotLambda<typeElement>(typeElement[] p_valeurs, int p_indicePremier, int p_indiceDernier)
        {
            // Préconditions
            if (p_valeurs == null)
            {
                throw new ArgumentNullException("Le tableau en paramètre ne peut pas être null", "p_valeurs");
            }

            if (p_indicePremier < 0 || p_indicePremier >= p_valeurs.Length)
            {
                throw new ArgumentOutOfRangeException("L'indicePremier doit être plus grand que 0 et inférieur à la taille du tableau passé en paramètre", "p_indicePremier");
            }

            if (p_indiceDernier < 0 || p_indiceDernier >= p_valeurs.Length)
            {
                throw new ArgumentOutOfRangeException("L'indiceDernier doit être plus grand que 0 et inférieur à la taille du tableau passé en paramètre", "p_indiceDernier");
            }

            if (p_indicePremier > p_indiceDernier)
            {
                throw new ArgumentException("IndicePremier doit être inférieur à indiceDernier");
            }

            return p_indicePremier;
        }
        public static int PartionnerLambda<typeElement>(typeElement[] p_valeurs, int p_indicePremier, int p_indiceDernier, int p_indicePivot, Func<typeElement, typeElement, bool> p_fonctionComparaison)
        where typeElement : IComparable<typeElement>
        {
            // Préconditions
            if (p_valeurs == null)
            {
                throw new ArgumentNullException("Le tableau en paramètre ne peut pas être null", "p_valeurs");
            }

            if (p_indicePremier < 0 || p_indicePremier >= p_valeurs.Length)
            {
                throw new ArgumentOutOfRangeException("L'indicePremier doit être plus grand que 0 et inférieur à la taille du tableau passé en paramètre", "p_indicePremier");
            }

            if (p_indiceDernier < 0 || p_indiceDernier >= p_valeurs.Length)
            {
                throw new ArgumentOutOfRangeException("L'indiceDernier doit être plus grand que 0 et inférieur à la taille du tableau passé en paramètre", "p_indiceDernier");
            }

            if (p_indicePivot < 0 || p_indicePivot >= p_valeurs.Length)
            {
                throw new ArgumentOutOfRangeException("L'indicePivot doit être plus grand que 0 et inférieur à la taille du tableau passé en paramètre", "p_indicePivot");
            }

            if (p_indicePremier > p_indiceDernier)
            {
                throw new ArgumentException("IndicePremier doit être inférieur à indiceDernier");
            }

            if (p_fonctionComparaison == null)
            {
                throw new ArgumentNullException("La fonction lambda ne peut pas être null", "p_fonctionComparaison");
            }

            typeElement ancienneValeur = default(typeElement);
            int futurIndicePivot = p_indicePremier;

            ancienneValeur = p_valeurs[p_indicePivot];
            p_valeurs[p_indicePivot] = p_valeurs[p_indiceDernier];
            p_valeurs[p_indiceDernier] = ancienneValeur;

            for (int indiceValeurARanger = p_indicePremier; indiceValeurARanger <= p_indiceDernier - 1; indiceValeurARanger++)
            {
                if (p_fonctionComparaison(p_valeurs[indiceValeurARanger], p_valeurs[p_indiceDernier]))
                {
                    ancienneValeur = p_valeurs[futurIndicePivot];
                    p_valeurs[futurIndicePivot] = p_valeurs[indiceValeurARanger];
                    p_valeurs[indiceValeurARanger] = ancienneValeur;
                    futurIndicePivot = futurIndicePivot + 1;
                }
            }

            ancienneValeur = p_valeurs[futurIndicePivot];
            p_valeurs[futurIndicePivot] = p_valeurs[p_indiceDernier];
            p_valeurs[p_indiceDernier] = ancienneValeur;

            return futurIndicePivot;
        }

        // Exercice 4
        public static bool RechercherValeurLambda<typeElement>(typeElement[] p_collection, typeElement p_valeurAChercher, Func<typeElement, typeElement, bool> p_validationEgalite)
        {
            // Préconditions
            if(p_collection == null)
            {
                throw new ArgumentNullException("Le tableau passé en paramètre ne peut pas être null", "p_collection");
            }

            if(p_validationEgalite == null)
            {
                throw new ArgumentNullException("La fonction lambda ne peut pas être null", "p_validationEgalite");
            }


            bool estTrouve = false;

            for (int indiceValeurCourante = 0; indiceValeurCourante < p_collection.Length; indiceValeurCourante++)
            {
                if (p_validationEgalite(p_collection[indiceValeurCourante], p_valeurAChercher))
                {
                    estTrouve = true;
                }
            }

            return estTrouve;
        }
        public static bool RechercherValeurDichotomieLambda<typeElement>(typeElement[] p_collection, typeElement p_valeurAChercher, Func<typeElement, typeElement, bool> p_validationEgalite, Func<int, int, bool> p_comparaison)
        where typeElement : IComparable<typeElement>
        {
            // Préconditions
            if(p_collection == null)
            {
                throw new ArgumentNullException("Le tableau ne peut pas être null", "p_collection");
            }

            if (p_validationEgalite == null)
            {
                throw new ArgumentNullException("La fonction Lambda ne peut pas être null", "p_validationEgalite");
            }

            if (p_comparaison == null)
            {
                throw new ArgumentNullException("La fonction lambda ne peut pas être null", "p_comparaison");
            }


            bool estTrouve = false;
            int indicePremier = 0;
            int indiceDernier = p_collection.Length - 1;
            int indiceMilieu = 0;

            while (!estTrouve && p_comparaison(indicePremier, indiceDernier))
            {
                indiceMilieu = (indicePremier + indiceDernier) / 2;
                if (p_validationEgalite(p_collection[indiceMilieu], p_valeurAChercher))
                {
                    estTrouve = true;

                }

                else if (p_collection[indiceMilieu].CompareTo(p_valeurAChercher) < 0)
                {
                    indicePremier = indiceMilieu + 1;
                }

                else
                {
                    indiceDernier = indiceMilieu - 1;
                }
            }

            return estTrouve;
        }

        // Exercice 5
        public static List<typeElement> Where<typeElement>(typeElement[] p_collection, Func<typeElement, bool> p_filtre)
        {
            // Préconditions
            if(p_collection == null)
            {
                throw new ArgumentNullException("Le tableau ne peut pas être null", "p_collection");
            }

            if(p_filtre == null)
            {
                throw new ArgumentNullException("La fonction lambda ne peut pas être null", "p_filtre");
            }

            List<typeElement> listeARetourner = new List<typeElement>();
            for (int indiceValeurCourante = 0; indiceValeurCourante < p_collection.Length; indiceValeurCourante++)
            {
                if (p_filtre(p_collection[indiceValeurCourante]))
                {
                    listeARetourner.Add(p_collection[indiceValeurCourante]);
                }
            }

            return listeARetourner;
        }
        public static List<typeElement> Select<typeElement>(typeElement[] p_collection, Func<typeElement, typeElement> p_select)
        {
            if(p_collection == null)
            {
                throw new ArgumentNullException("Le tableau ne peut pas être null", "p_collection");
            }

            if(p_select == null)
            {
                throw new ArgumentNullException("La fonction lambda ne peut pas être null", "p_select");
            }

            List<typeElement> listeTransformee = new List<typeElement>();

            foreach(typeElement element in p_collection)
            {
                listeTransformee.Add(p_select(element));
            }

            return listeTransformee;
        }

        // Exercice 6
        public static void Histogramme(List<int> p_ListeEntier)
        {
            // Préconditions
            if(p_ListeEntier == null)
            {
                throw new ArgumentNullException("La liste ne peut pas être null", "p_ListeEntier");
            }

            int chiffreMaximum = p_ListeEntier.Max();
            char[,] matrice = new char[chiffreMaximum, p_ListeEntier.Count];
            var compteurCaseVide = p_ListeEntier.Select(x => chiffreMaximum - x).ToList();

            for(int y = 0; y < chiffreMaximum; y++)
            {
                for(int x = 0; x < p_ListeEntier.Count; x++)
                {
                    matrice[y, x] = compteurCaseVide[x] > 0 ? ' ' : '#';
                    compteurCaseVide[x]--;
                    Console.Write(matrice[y, x]);
                }
                Console.WriteLine();
            }
        }

        // Exercice 7
        public static List<int> TemoinCrime(List<int> p_ListeEntier)
        {
            //Préconditions
            if (p_ListeEntier == null)
            {
                throw new ArgumentNullException("La liste ne peut pas être null", "p_ListeEntier");
            }

            if (p_ListeEntier.Count == 0)
            {
                throw new ArgumentException("La liste ne peut pas être vide", "p_ListeEntier");
            }

            List<int> temoins = new List<int>();
            List<int> sousListeEvaluation = new List<int>();

            if (p_ListeEntier.Max() == p_ListeEntier[p_ListeEntier.Count - 1])
            {
                temoins.Add(p_ListeEntier[p_ListeEntier.Count - 1]);
                return temoins;
            }

            for (int index = 0; index < p_ListeEntier.Count; index++)
            {
                sousListeEvaluation = p_ListeEntier.GetRange(index, p_ListeEntier.Count - index);

                if(sousListeEvaluation.Max() == sousListeEvaluation[0] && !temoins.Contains(sousListeEvaluation[0]))
                {
                    temoins.Add(sousListeEvaluation[0]);
                }
            }

            return temoins;
        }

        // Exercice 8
        public static Nullable<char> PremiereLettreRecurrente(string p_chaineCaractere)
        {
            if(p_chaineCaractere == null)
            {
                throw new ArgumentNullException("La chaine de caractère ne peut pas être null", "p_chaineCaractere");
            }

            for(int index = 0; index < p_chaineCaractere.Length - 1; index++)
            {
                if(p_chaineCaractere[index] == p_chaineCaractere[index + 1])
                {
                    return Convert.ToChar(p_chaineCaractere[index]);
                }
            }
            return null;
        }

        // Exercice 9
        public static List<(int, int)> SommeNombre(List<int> p_listeA, List<int> p_listeB, int p_valeurCible)
        {
            // Préconditions
            if(p_listeA == null)
            {
                throw new ArgumentNullException("La liste ne peut pas être null", "p_ListeA");
            }

            if (p_listeB == null)
            {
                throw new ArgumentNullException("La liste ne peut pas être null", "p_ListeB");
            }
            
            Dictionary<(int, int), int> dictionnairePairsAddition = new Dictionary<(int, int), int>();

            for(int indexA = 0; indexA < p_listeA.Count; indexA++)
            {
                for(int indexB = 0; indexB < p_listeB.Count; indexB++)
                {
                    int differencePairs = Math.Abs(p_valeurCible - (p_listeA[indexA] + p_listeB[indexB]));
                    if(!dictionnairePairsAddition.ContainsKey((p_listeA[indexA], p_listeB[indexB])))
                    {
                        dictionnairePairsAddition.Add((p_listeA[indexA], p_listeB[indexB]), differencePairs);
                    }
                    
                }
            }

            var dictionnaire = dictionnairePairsAddition.Where(x => x.Value == dictionnairePairsAddition.Min(a => a.Value)).ToDictionary(x => x.Key, x => x.Value);
            return dictionnaire.Keys.ToList();
        }



    }
}
