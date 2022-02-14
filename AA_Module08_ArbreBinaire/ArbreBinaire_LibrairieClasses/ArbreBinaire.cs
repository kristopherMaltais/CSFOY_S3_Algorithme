using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbreBinaire_LibrairieClasses
{
    public class ArbreBinaire<TypeElement>
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public NoeudArbreBinaire<TypeElement> NoeudRacine { get; set; }
        public int Hauteur { get => Hauteur_rec(this.NoeudRacine); }

        // ** Constructeurs ** //
        public ArbreBinaire(NoeudArbreBinaire<TypeElement> p_noeudRacine)
        {
            this.NoeudRacine = p_noeudRacine;
        }

        public List<int> ParcoursInfixeIteratif(ArbreBinaire<int> arbre)
        {
            Stack<NoeudArbreBinaire<int>> stack = new Stack<NoeudArbreBinaire<int>>();
            List<int> listeARetourner = new List<int>();
            NoeudArbreBinaire<int> noeudCourant = arbre.NoeudRacine;
            stack.Push(arbre.NoeudRacine);

            while (noeudCourant is not null)
            {

                noeudCourant = stack.Peek();

                while (noeudCourant.NoeudGauche is not null)
                {
                    stack.Push(noeudCourant.NoeudGauche);
                    noeudCourant = noeudCourant.NoeudGauche;
                }

                listeARetourner.Add(stack.Peek().ValeurNoeud);
                stack.Pop();

            }
               


            return listeARetourner;
        }

        // ** Méthodes ** //
        private int Hauteur_rec(NoeudArbreBinaire<TypeElement> p_noeud)
        {
            if (p_noeud is null)
            {
                return 0;
            }

            return 1 + Math.Max(Hauteur_rec(p_noeud.NoeudGauche), Hauteur_rec(p_noeud.NoeudDroite));
        }

        // Parcours Prefixe
        public void ParcoursPrefixe(Action<TypeElement> p_traitement)
        {
            ParcoursPrefixe_rec(this.NoeudRacine, p_traitement);
        }
        private void ParcoursPrefixe_rec(NoeudArbreBinaire<TypeElement> p_noeud, Action<TypeElement> p_traitement)
        {
            if (p_noeud is not null)
            {
                p_traitement(p_noeud.ValeurNoeud);
                ParcoursPrefixe_rec(p_noeud.NoeudGauche, p_traitement);
                ParcoursPrefixe_rec(p_noeud.NoeudDroite, p_traitement);
            }
        }

        // Parcours Infixe
        public void ParcoursInfixe(Action<TypeElement> p_traitement)
        {
            ParcoursInfixe_rec(this.NoeudRacine, p_traitement);
        }
        private void ParcoursInfixe_rec(NoeudArbreBinaire<TypeElement> p_noeud, Action<TypeElement> p_traitement)
        {
            if (p_noeud is not null)
            {
                ParcoursInfixe_rec(p_noeud.NoeudGauche, p_traitement);
                p_traitement(p_noeud.ValeurNoeud);
                ParcoursInfixe_rec(p_noeud.NoeudDroite, p_traitement);
            }
        }

        // Parcours Infixe
        public void ParcoursPostfixe(Action<TypeElement> p_traitement)
        {
            ParcoursPostfixe_rec(this.NoeudRacine, p_traitement);
        }
        private void ParcoursPostfixe_rec(NoeudArbreBinaire<TypeElement> p_noeud, Action<TypeElement> p_traitement)
        {
            if (p_noeud is not null)
            {
                ParcoursPostfixe_rec(p_noeud.NoeudGauche, p_traitement);
                ParcoursPostfixe_rec(p_noeud.NoeudDroite, p_traitement);
                p_traitement(p_noeud.ValeurNoeud);
            }
        }

        // Parcours Largeur Non récursif QUEUE
        public void ParcoursLargeur()
        {
            Queue<NoeudArbreBinaire<TypeElement>> file = new Queue<NoeudArbreBinaire<TypeElement>>();

            file.Enqueue(this.NoeudRacine);

            while (file.Count != 0)
            {
                if (file.Peek().NoeudGauche is not null)
                {
                    file.Enqueue(file.Peek().NoeudGauche);
                }

                if (file.Peek().NoeudDroite is not null)
                {
                    file.Enqueue(file.Peek().NoeudDroite);
                }

                Console.WriteLine(file.Dequeue().ValeurNoeud.ToString());
            }
        }

        // Parcours Profondeur Non récursif STACK
        public void ParcoursProfondeur()
        {
            Stack<NoeudArbreBinaire<TypeElement>> pile = new Stack<NoeudArbreBinaire<TypeElement>>();
            NoeudArbreBinaire<TypeElement> noeudCourant = this.NoeudRacine;

            while(pile.Count > 0 || noeudCourant is not null)
            {
                if(noeudCourant is not null)
                {
                    pile.Push(noeudCourant);
                    noeudCourant = noeudCourant.NoeudGauche;
                }
                else
                {
                    noeudCourant = pile.Peek().NoeudDroite;
                    Console.WriteLine(pile.Pop().ValeurNoeud.ToString());
                }
            }

        }

        // Comparer deux arbres
        public bool Comparer(ArbreBinaire<TypeElement> p_arbre)
        {
            bool arbreIdentique = true;

            List<TypeElement> liste1 = new List<TypeElement>();
            List<TypeElement> liste2 = new List<TypeElement>();

            Comparer_rec(this.NoeudRacine, liste1);
            Comparer_rec(p_arbre.NoeudRacine, liste2);

            if(liste1.Count == liste2.Count)
            {
                for (int index = 0; index < liste1.Count; index++)
                {
                    if(!liste1[index].Equals(liste2[index]))
                    {
                        arbreIdentique = false;
                    }
                }
            }
            else
            {
                arbreIdentique = false;
            }


            return arbreIdentique;
        }
        private void Comparer_rec(NoeudArbreBinaire<TypeElement> p_noeud, List<TypeElement> p_liste)
        {
            if (p_noeud is not null)
            {
                Comparer_rec(p_noeud.NoeudGauche, p_liste);

                p_liste.Add(p_noeud.ValeurNoeud);

                Comparer_rec(p_noeud.NoeudDroite, p_liste);
            }
            else
            {
                p_liste.Add(default);
            }
        }




    }
}
