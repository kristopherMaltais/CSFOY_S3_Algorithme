using System;
using Xunit;
using ArbreBinaire_LibrairieClasses;
using System.Collections.Generic;

namespace ArbreBinaire_TestsUnitaires
{
    public class UnitTest1
    {
        [Fact]
        public void ParcoursInfixeIteratif_testUnitaire()
        {
            // Arrange
            ArbreBinaire<int> arbre1 = GenerateurArbreBinaire.ExempleArbre1();
            ArbreBinaire<int> arbre2 = GenerateurArbreBinaire.ExempleArbre1();

            // Act
            bool valeurObtenue = arbre1.Comparer(arbre2);

            // Assert
            Assert.True(valeurObtenue);
        }
    }
}
