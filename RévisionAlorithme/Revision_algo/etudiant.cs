using System;
using System.Collections.Generic;
using System.Text;

namespace Revision_algo
{
    public class etudiant : IComparable<etudiant>
    {

        public string nom { get; set; }
        public int age { get; set; }

        public etudiant(string nom, int age)
        {
            this.nom = nom;
            this.age = age;
        }

        public int CompareTo(etudiant p_etudiant)
        {
            if(p_etudiant.age < this.age)
            {
                return 1;
            }

            if (p_etudiant.age == this.age)
            {
                return 0;
            }

            else
            {
                return -1;
            }
        }
    }
}
