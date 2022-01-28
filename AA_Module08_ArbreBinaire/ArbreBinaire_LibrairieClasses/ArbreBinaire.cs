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

        // ** Méthodes ** //
        private int Hauteur_rec(NoeudArbreBinaire<TypeElement> p_noeud)
        {
            if(p_noeud is null)
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
            if(p_noeud is not null)
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

            while(file.Count != 0)
            {
                if(file.Peek().NoeudGauche is not null)
                {
                    file.Enqueue(file.Peek().NoeudGauche);
                }

                if(file.Peek().NoeudDroite is not null)
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
            pile.Push(this.NoeudRacine);
            NoeudArbreBinaire<TypeElement> noeudCourant = pile.Peek();
         

            while (pile.Count > 0)
            {
                noeudCourant = pile.Pop();
                Console.WriteLine(noeudCourant.ValeurNoeud.ToString());
                if (noeudCourant.NoeudDroite is not null)
                {
                    pile.Push(noeudCourant.NoeudDroite);
                }

                if(pile.Peek().NoeudGauche is not null)
                {
                    pile.Push(pile.Peek().NoeudGauche);
                }
            }

            
        }

        
        

    }
}
