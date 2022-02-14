using System;
using ArbreBinaire_LibrairieClasses;

namespace ArbreBinaire_console
{
    class Program
    {
        static void Main(string[] args)
        {
            // Arrange
            ArbreBinaire<int> arbre1 = GenerateurArbreBinaire.ExempleArbre1();

            // Act
            arbre1.ParcoursProfondeur();
            
        }
    }
}
