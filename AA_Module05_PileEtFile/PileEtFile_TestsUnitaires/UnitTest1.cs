using System;
using System.Collections.Generic;
using Xunit;
using PileEtFile_LibrairieClasses;

namespace PileEtFile_TestsUnitaires
{
    public class UnitTest1
    {
        #region Pile
        [Fact]
        public void Constructeur_Precondition_LanceException()
        {
            // Arrange
            List<int> listeNull = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { Pile<int> pile = new Pile<int>(listeNull); });
        }
        [Fact]
        public void Constructeur_CreerPileAvecListeTailleZero_CreePileTailleZero()
        {
            // Arrange
            List<int> listeTailleZero = new List<int>();
            int countAttendu = 0;

            // Act
            Pile<int> pileCountZero = new Pile<int>(listeTailleZero);

            // Assert
            Assert.Equal(countAttendu, pileCountZero.Count);
        }
        [Fact]
        public void Constructeur_CreerPileAvecDonnees_CreePileAvecBonnesDonnees()
        {
        //    Arrange
        //    List<int> listeDonnees = new List<int>() { 1, 4, 2 };
        //    int countAttendu = 3;
        //    List<int> pileAttendue = new List<int>() { 1, 4, 2 };

        //    Act
        //    Pile<int> pileObtenue = new Pile<int>(listeDonnees);

        //    Assert
        //    Assert.Equal(countAttendu, pileObtenue.Count);
        //    Assert.Equal(pileAttendue[0], pileObtenue[0]);
        //    Assert.Equal();
        //    Assert.Equal();
        }

        // EstPileVide
        [Fact]
        public void EstPileVide_PileEstVide_RetourneTrue()
        {
            // Arrange
            List<int> listeVide = new List<int>();
            Pile<int> pileVide = new Pile<int>(listeVide);

            // Act
            bool valeurObtenue = pileVide.EstPileVide;

            // Assert
            Assert.True(valeurObtenue);
        }
        [Fact]
        public void EstPileVide_PileNonVide_RetourneFalse()
        {
            // Arrange
            List<int> liste = new List<int>() { 1, 2, 3 };
            Pile<int> pileVide = new Pile<int>(liste);

            // Act
            bool valeurObtenue = pileVide.EstPileVide;

            // Assert
            Assert.False(valeurObtenue);
        }

        // Empiler
        [Fact]
        public void Empiler_EmpilerValeurPileVide_PileContientBonneValeurSommet()
        {
            // Arrange
            List<int> listeVide = new List<int>();
            Pile<int> pile = new Pile<int>(listeVide);
            int valeurAEmpiler = 5;
            int countAttendu = 1;
            int valeurSommetAttendu = 5;

            // Act
            pile.Empiler(valeurAEmpiler);

            // Assert
            Assert.Equal(pile.Count, countAttendu);
            Assert.Equal(valeurSommetAttendu, pile.Sommet());
        }
        [Fact]
        public void Empiler_EmpilerValeurPileNonVide_PileContientBonneValeurSommet()
        {
            // Arrange
            List<int> listeNonVide = new List<int>() { 1, 5, 4 };
            Pile<int> pile = new Pile<int>(listeNonVide);
            int valeurAEmpiler = 5;
            int countAttendu = 4;
            int valeurSommetAttendu = 5;

            // Act
            pile.Empiler(valeurAEmpiler);

            // Assert
            Assert.Equal(pile.Count, countAttendu);
            Assert.Equal(valeurSommetAttendu, pile.Sommet());
        }

        // Sommet
        [Fact]
        public void Sommet_PreconditionPileVide_LanceException()
        {
            // Arrange
            List<int> listeVide = new List<int>();
            Pile<int> pile = new Pile<int>(listeVide);

            // Act and Assert
            Assert.Throws<PileVideException>(() => { pile.Sommet(); });
        }
        [Fact]
        public void Sommet_ObtenirSommetListeNonVide_RetourneValeurDernierElement()
        {
            // Arrange
            List<int> listeNonVide = new List<int>() { 1, 7, 3 };
            Pile<int> pile = new Pile<int>(listeNonVide);
            int sommetAttendu = 3;

            // Act
            int sommetObtenu = pile.Sommet();

            // Assert
            Assert.Equal(sommetAttendu, sommetObtenu);

        }

        // Depiler
        [Fact]
        public void Depiler_PreconditionPileVide_LanceException()
        {
            // Arrange
            List<int> listeVide = new List<int>();
            Pile<int> pile = new Pile<int>(listeVide);

            // Act and Assert
            Assert.Throws<PileVideException>(() => { pile.Depiler(); });
        }

        [Fact]
        public void Depiler_DepilerPileNonVide_RetourneBonneValeurEtCountDecremente()
        {
            // Arrange
            List<int> listeNonVide = new List<int>() { 1, 5, 4};
            Pile<int> pile = new Pile<int>(listeNonVide);
            int sommetAttendu = 4;
            int countAttendu = 2;
            // Act
            int sommetObtenu = pile.Depiler();

            //Assert
            Assert.Equal(sommetAttendu, sommetObtenu);
            Assert.Equal(countAttendu, pile.Count);
        }
        #endregion

        #region File

        // Constructeur
        [Fact]
        public void Constructeur_PreconditionNull_LanceException()
        {
            // Arrange
            List<int> listeNull = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { File<int> file = new File<int>(listeNull); });
        }

        // EstFileVide
        [Fact]
        public void EstFileVide_FileEstVide_RetourneTrue()
        {
            // Arrange
            List<int> listeVide = new List<int>();
            File<int> pileVide = new File<int>(listeVide);

            // Act
            bool valeurObtenue = pileVide.EstFileVide;

            // Assert
            Assert.True(valeurObtenue);
        }
        [Fact]
        public void EstFileVide_FileNonVide_RetourneFalse()
        {
            // Arrange
            List<int> liste = new List<int>() { 1, 2, 3 };
            File<int> pileVide = new File<int>(liste);

            // Act
            bool valeurObtenue = pileVide.EstFileVide;

            // Assert
            Assert.False(valeurObtenue);
        }

        // Enfiler
        [Fact]
        public void Enfiler_AjouterElementPileVide_AjouteBonneValeurEtCountIncremente()
        {
            // Arrange
            List<int> listeVide = new List<int>();
            File<int> file = new File<int>(listeVide);
            int valeurAAjouter = 5;
            int countAttendu = 1;
            int valeurAttendu = 5;

            // Act
            file.Enfiler(valeurAAjouter);

            // Assert
            Assert.Equal(countAttendu, file.Count);
            Assert.Equal(valeurAttendu, file.Tete());
        }
        [Fact]
        public void Enfiler_AjouterElementPileNonVide_AjouteBonneValeurEtCountIncremente()
        {
            // Arrange
            List<int> listeNonVide = new List<int>() { 1, 3 };
            File<int> file = new File<int>(listeNonVide);
            int valeurAAjouter = 5;
            int countAttendu = 3;
            int valeurAttendu = 3;

            // Act
            file.Enfiler(valeurAAjouter);

            // Assert
            Assert.Equal(countAttendu, file.Count);
            Assert.Equal(valeurAttendu, file.Tete());
        }

        // Tete
        [Fact]
        public void Tete_PreconditionFileVide_LanceException()
        {
            // Arrange
            List<int> listeVide = new List<int>();
            File<int> file = new File<int>(listeVide);

            // Act and Assert
            Assert.Throws<FileVideException>(() => { file.Tete(); });
        }
        [Fact]
        public void Tete_ObtenirTeteFileNonVide_LanceException()
        {
            // Arrange
            List<int> listeVide = new List<int>() { 1, 2, 3 };
            File<int> file = new File<int>(listeVide);

            int teteAttendue = 3;

            // Act
            int teteObtenue = file.Tete();

            // Assert
            Assert.Equal(teteAttendue, teteObtenue);
        }

        // Defiler
        [Fact]
        public void Defiler_PreconditionFileVide_LanceException()
        {
            // Arrange
            List<int> listeVide = new List<int>();
            File<int> file = new File<int>(listeVide);

            // Act and Assert
            Assert.Throws<FileVideException>(() => { file.Defiler(); });
        }
        [Fact]
        public void Defiler_DefilerFileNonVide_LanceException()
        {
            // Arrange
            List<int> listeVide = new List<int>() { 1, 2, 3 };
            File<int> file = new File<int>(listeVide);

            int valeurAttendue = 3;
            int countAttendu = 2;

            // Act
            int valeurObtenue = file.Defiler();

            // Assert
            Assert.Equal(valeurAttendue, valeurObtenue);
            Assert.Equal(countAttendu, file.Count);
        }
        #endregion
    }
}
