using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbreBinaire_LibrairieClasses
{
    public class ArbreBinaireRecherche<TypeElement>
    where TypeElement : IComparable<TypeElement>
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public NoeudArbreBinaire<TypeElement> NoeudRacine { get; set; }
        public TypeElement ValeurNoeud { get; set; }

        // ** Constructeurs ** //
        public ArbreBinaireRecherche(NoeudArbreBinaire<TypeElement> p_noeudRacine = null)
        {
            this.NoeudRacine = p_noeudRacine;
        }

        // ** Méthodes ** //
            // Minimum
        public TypeElement Minimum()
        {
            return Minimum_rec(this.NoeudRacine);
        }
        private TypeElement Minimum_rec(NoeudArbreBinaire<TypeElement> p_noeud)
        {
            if(p_noeud.NoeudGauche is null)
            {
                return p_noeud.ValeurNoeud;
            }

            return Minimum_rec(p_noeud.NoeudGauche);
        }

            // Maximum
        public TypeElement Maximum()
        {
            return Maximum_rec(this.NoeudRacine);
        }
        private TypeElement Maximum_rec(NoeudArbreBinaire<TypeElement> p_noeud)
        {
            if (p_noeud.NoeudDroite is null)
            {
                return p_noeud.ValeurNoeud;
            }

            return Maximum_rec(p_noeud.NoeudDroite);
        }

            // AjouterNoeud
        public void AjouterNoeud(TypeElement p_valeurAAjouter)
        {
            // Précondition
            if(p_valeurAAjouter is null)
            {
                throw new ArgumentNullException(nameof(p_valeurAAjouter), "La valeur passé en paramètre ne peut pas être null");
            }

            NoeudArbreBinaire<TypeElement> nouveauNoeud = new NoeudArbreBinaire<TypeElement>(p_valeurAAjouter);
            if (NoeudRacine is null)
            {
                this.NoeudRacine = nouveauNoeud;
            }
            else
            {
                AjouterNoeud_rec(nouveauNoeud, NoeudRacine);
            }
        }
        private void AjouterNoeud_rec(NoeudArbreBinaire<TypeElement> p_noeudAAjouter, NoeudArbreBinaire<TypeElement> p_noeudCourant)
        {
            if (p_noeudAAjouter.ValeurNoeud.CompareTo(p_noeudCourant.ValeurNoeud) <= 0)
            {
                if (p_noeudCourant.NoeudGauche is null)
                {
                    p_noeudCourant.NoeudGauche = p_noeudAAjouter;
                }
                else
                {
                    AjouterNoeud_rec(p_noeudAAjouter, p_noeudCourant.NoeudGauche);
                }
            }
            else if (p_noeudAAjouter.ValeurNoeud.CompareTo(p_noeudCourant.ValeurNoeud) > 0)
            {
                if (p_noeudCourant.NoeudDroite is null)
                {
                    p_noeudCourant.NoeudDroite = p_noeudAAjouter;
                }
                else
                {
                    AjouterNoeud_rec(p_noeudAAjouter, p_noeudCourant.NoeudDroite);
                }
            }
        }

            // RechercherValeur
        public bool RechercherValeur(TypeElement p_valeurAChercher)
        {
            if(this.NoeudRacine is null)
            {
                return false;
            }

            return RechercherValeur_rec(p_valeurAChercher, this.NoeudRacine);
        }
        private bool RechercherValeur_rec(TypeElement p_valeurAChercher, NoeudArbreBinaire<TypeElement> p_noeudCourant)
        {
            NoeudArbreBinaire<TypeElement> noeudSuivant = p_valeurAChercher.CompareTo(p_noeudCourant.ValeurNoeud) < 0 ? p_noeudCourant.NoeudGauche : p_noeudCourant.NoeudDroite;

            if (p_valeurAChercher.CompareTo(p_noeudCourant.ValeurNoeud) == 0)
            {
                return true;
            }

            if(noeudSuivant is null)
            {
                return false;
            }

            return RechercherValeur_rec(p_valeurAChercher, noeudSuivant);
        }
    }
}
