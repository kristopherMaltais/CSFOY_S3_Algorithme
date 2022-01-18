using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbreNAire_LibrairieClasses
{
    public class ArbreAutoCompletion
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public DonneeNoeudTrie NoeudRacine;

        // ** Constructeurs ** //
        public ArbreAutoCompletion()
        {
            NoeudRacine = new DonneeNoeudTrie(' ', "", false);
        }

        // ** Méthodes ** //

            // AjouterMot
        public void AjouterMot(string p_motAjoute)
        {
            // Précondition
            if(p_motAjoute is null)
            {
                throw new ArgumentNullException(nameof(p_motAjoute), "Le mot à ajouter ne peut pas être null");
            }

            AjouterMot_rec(this.NoeudRacine, p_motAjoute);
        }
        private void AjouterMot_rec(DonneeNoeudTrie p_noeudCourant, string p_motAVerifier)
        {
            int indexNoeudEnfant = p_noeudCourant.NoeudsEnfants.FindIndex(noeud => noeud.Lettre == p_motAVerifier[0]);
            if (p_motAVerifier.Length > 0)
            {
                if (indexNoeudEnfant == -1)
                {
                    p_noeudCourant.NoeudsEnfants.Add(new DonneeNoeudTrie(p_motAVerifier[0], p_noeudCourant.MotForme + p_motAVerifier[0], p_motAVerifier.Length == 1));
                    indexNoeudEnfant = p_noeudCourant.NoeudsEnfants.Count - 1;
                }
                AjouterMot_rec(p_noeudCourant.NoeudsEnfants[indexNoeudEnfant], p_motAVerifier.Substring(1));
            }
        }

            // CompleterPrefixe
        public List<string> CompleterPrefixe(string p_prefixe)
        {
            // Préconditions
            if(p_prefixe is null)
            {
                throw new ArgumentNullException(nameof(p_prefixe), "Le préfixe ne peut pas être null");
            }

            List<String> motsValides = new List<string>();
            DonneeNoeudTrie noeudPrefixe = TrouverNoeud(NoeudRacine, p_prefixe);
            
                return CollecterMots(noeudPrefixe, motsValides);

        }
        private DonneeNoeudTrie? TrouverNoeud(DonneeNoeudTrie p_noeudCourant, string p_prefixe)
        {
            if (p_prefixe.Length > 0)
            {
                int indexNoeudEnfant = p_noeudCourant.NoeudsEnfants.FindIndex(noeud => noeud.Lettre == p_prefixe[0]);

                if (indexNoeudEnfant != -1)
                {
                    return TrouverNoeud(p_noeudCourant.NoeudsEnfants[indexNoeudEnfant], p_prefixe.Substring(1));
                }
                else
                {
                    return null;
                }
            }

            return p_noeudCourant;

        }
        private List<string> CollecterMots(DonneeNoeudTrie p_noeudCourrant, List<string> p_motsValides)
        {
            if(p_noeudCourrant.EstMotLegal)
            {
                p_motsValides.Add(p_noeudCourrant.MotForme);
            }

            foreach(DonneeNoeudTrie noeud in p_noeudCourrant.NoeudsEnfants)
            {
                CollecterMots(noeud, p_motsValides);
            }

            return p_motsValides;
        }
        
    }
}
