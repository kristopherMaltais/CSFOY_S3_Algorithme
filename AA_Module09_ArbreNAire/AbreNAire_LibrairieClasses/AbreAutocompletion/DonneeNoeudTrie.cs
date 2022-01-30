using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbreNAire_LibrairieClasses
{
    public class DonneeNoeudTrie
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public char Lettre { get; set; }
        public string MotForme { get; set; }
        public bool EstMotLegal { get; set; }
        public List<DonneeNoeudTrie> NoeudsEnfants { get; set; }

        // ** Constructeurs ** //
        public DonneeNoeudTrie(char p_lettre, string p_motForme, bool p_estMotLegal)
        {
            this.Lettre = p_lettre;
            this.MotForme = p_motForme;
            this.EstMotLegal = p_estMotLegal;
            NoeudsEnfants = new List<DonneeNoeudTrie>();
        }

        // ** Méthodes ** //
    }
}
