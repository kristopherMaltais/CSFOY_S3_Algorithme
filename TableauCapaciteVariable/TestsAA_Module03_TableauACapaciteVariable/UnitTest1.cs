using System;
using Xunit;
using AA_Module03_TableauACapaciteVariable;
using System.Collections.Generic;
namespace TestsAA_Module03_TableauACapaciteVariable
{
    public class UnitTest1
    {
        
        // Constructeur A
        [Fact]
        public void ConstructeurA_PreconditionInferieurAZero_ExceptionLancee()
        {
            // Arrange
            int nombreInferieurAZero = -1;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => {new TableauCapaciteVariable<int>(nombreInferieurAZero); });
        }

        [Fact]
        public void ConstructeurA_ValeurParDefaut_CreeTCVTailleUn()
        {
            // Arrange
            TableauCapaciteVariable<int> nouveauTableau;
            int capaciteAttendue = 1;
            int countAttendu = 0;

            // Act
            nouveauTableau = new TableauCapaciteVariable<int>();

            // Assert
            Assert.Equal(capaciteAttendue, nouveauTableau.Capacity);
            Assert.Equal(countAttendu, nouveauTableau.Count);
        }

        [Fact]
        public void ConstructeurA_CreationTCV_CreeTCVBonneCapacite()
        {
            // Arrange
            TableauCapaciteVariable<int> nouveauTableau;
            int tailleTableau = 3;
            int capaciteAttendue = 3;
            int countAttendu = 0;

            // Act
            nouveauTableau = new TableauCapaciteVariable<int>(tailleTableau);

            // Assert
            Assert.Equal(capaciteAttendue, nouveauTableau.Capacity);
            Assert.Equal(countAttendu, nouveauTableau.Count);
        }


        // Constructeur B
        [Fact]
        public void ConstructeurB_PreconditionIEnumerableNull_ExceptionLancee()
        {
            // Arrange
            List<int> listeNull = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { new TableauCapaciteVariable<int>(listeNull); });
        }

        [Fact]
        public void ConstructeurB_CreationTCVTailleUn_CreeTableauBonneCapacite()
        {
            // Arrange
            List<int> listeUnElement = new List<int>() { 1 };
            int countAttendu = 1;

            // Act
            TableauCapaciteVariable<int> collectionCree = new TableauCapaciteVariable<int>(listeUnElement);

            // Assert
            Assert.Equal(countAttendu, collectionCree.Count);
            Assert.Equal(1, collectionCree[0]);
            Assert.NotSame(listeUnElement, collectionCree);
        }

        [Fact]
        public void ConstructeurB_CreationTCVTailleSuperieurUn_CreeTableaubonneCapacite()
        {
            // Arrange
            List<int> listePlusieursElements = new List<int>() { 1, 5, 6, 4, 2 };
            int countAttendu = 5;

            // Act
            TableauCapaciteVariable<int> collectionCree = new TableauCapaciteVariable<int>(listePlusieursElements);

            // Assert
            Assert.Equal(countAttendu, collectionCree.Count);
            Assert.Equal(1, collectionCree[0]);
            Assert.Equal(5, collectionCree[1]);
            Assert.Equal(6, collectionCree[2]);
            Assert.Equal(4, collectionCree[3]);
            Assert.Equal(2, collectionCree[4]);
            Assert.NotSame(listePlusieursElements, collectionCree);
        }


        // OperateurCrochet
        [Fact]
        public void OperateurCrochet_PreconditionOutOfRange_LanceException()
        {
            // Arrange
            int indiceInferieurAZero = -1;
            int[] tableau = new int[] { 1, 2, 3 };

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => tableau[indiceInferieurAZero]);
        }

        [Fact]
        public void OperateurCrochet_RetourneValeurIndexDemande_AssertEqual()
        {
            // Arrange
            TableauCapaciteVariable<int> tableau = new TableauCapaciteVariable<int>() { 1, 2, 3, 4 };
            int indice = 2;
            int valeurAttendue = 3;
            // Act
            int valeurObtenue = tableau[indice];

            // Assert
            Assert.Equal(valeurAttendue, valeurObtenue);
        }

        [Fact]
        public void OperateurCrochet_AttribuBonneValeurAIndicevoulu_AssertEqual()
        {
            // Arrange
            TableauCapaciteVariable<int> tableau = new TableauCapaciteVariable<int>() { 1, 2, 3, 4 };
            int indice = 2;
            int valeurAInserer = 10;
            int valeurAttendue = 10;
            // Act
            tableau[0] = valeurAInserer;
            int valeurObtenue = tableau[0];

            // Assert
            Assert.Equal(valeurObtenue, valeurAttendue);
        }

        
        // Add
        [Fact]
        public void Add_AjouterValeur_AssertEqual()
        {
            // Arrange
            List<int> liste = new List<int>() { 1, 2, 3 };
            TableauCapaciteVariable<int> tableau = new TableauCapaciteVariable<int>(liste);
            int capaciteAttendue = 6;
            int valeurAjouteeAttendue = 4;

            // Act
            tableau.Add(4);

            // Assert
            Assert.Equal(capaciteAttendue, tableau.Capacity);
            Assert.Equal(valeurAjouteeAttendue, tableau[3]);

        }

        [Fact]
        public void Add_AjouterValeurTableauVide_AssertEqual()
        {
            // Arrange
            TableauCapaciteVariable<int> tableau = new TableauCapaciteVariable<int>();
            int capaciteAttendue = 1;
            int valeurAjouteeAttendue = 4;

            // Act
            tableau.Add(4);

            // Assert
            Assert.Equal(capaciteAttendue, tableau.Capacity);
            Assert.Equal(valeurAjouteeAttendue, tableau[0]);
        }


        // Clear
        [Fact]
        public void Clear_SupprimerTableauMetCountAZero_AssertEqual()
        {
            // Arrange
            List<int> liste = new List<int>() { 1, 2, 3 };
            TableauCapaciteVariable<int> tableau = new TableauCapaciteVariable<int>(liste);
            int countAttendu = 0;

            // Act
            tableau.Clear();

            // Assert
            Assert.Equal(countAttendu, tableau.Count);
            
        }

        [Fact]
        public void Clear_SupprimerTableauCapaciteInchangee_AssertEqual()
        {
            // Arrange
            List<int> liste = new List<int>() { 1, 2, 3 };
            TableauCapaciteVariable<int> tableau = new TableauCapaciteVariable<int>(liste);
            int capaciteAttendue = 3;

            // Act
            tableau.Clear();

            // Assert
            Assert.Equal(capaciteAttendue, tableau.Capacity);

        }

        [Fact]
        public void Clear_SupprimerTableauValeurADefault_AssertEqual()
        {
            // Arrange
            List<int> liste = new List<int>() { 1, 2, 3 };
            TableauCapaciteVariable<int> tableau = new TableauCapaciteVariable<int>(liste);
            int valeurAttendue = 0;

            // Act
            tableau.Clear();

            // Assert
            Assert.Equal(valeurAttendue, tableau[0]);
            Assert.Equal(valeurAttendue, tableau[1]);
            Assert.Equal(valeurAttendue, tableau[2]);

        }


        // Contains
        [Fact]
        public void Contains_ElementATrouveDebutTableau_AssertTrue()
        {
            // Arrange
            TableauCapaciteVariable<int> tableau = new TableauCapaciteVariable<int>() { 1, 2, 3, 4, 5 };
            int valeurPresente = 1;
            // Act
            bool valeurObtenue = tableau.Contains(valeurPresente);

            // Assert
            Assert.True(valeurObtenue);
        }

        [Fact]
        public void Contains_ElementATrouveFinTableau_AssertTrue()
        {
            // Arrange
            TableauCapaciteVariable<int> tableau = new TableauCapaciteVariable<int>() { 5, 2, 3, 4, 1 };
            int valeurPresente = 1;
            // Act
            bool valeurObtenue = tableau.Contains(valeurPresente);

            // Assert
            Assert.True(valeurObtenue);
        }

        [Fact]
        public void Contains_ElementATrouveNonPresent_AssertFalse()
        {
            // Arrange
            TableauCapaciteVariable<int> tableau = new TableauCapaciteVariable<int>() { 1, 2, 3, 4, 5 };
            int valeurNonPresente = 6;

            // Act
            bool valeurObtenue = tableau.Contains(valeurNonPresente);

            // Assert
            Assert.False(valeurObtenue);
        }

        [Fact]
        public void Contains_ElementATrouveDoublon_AssertTrue()
        {
            // Arrange
            TableauCapaciteVariable<int> tableau = new TableauCapaciteVariable<int>() { 1, 1, 3, 4, 5 };
            int valeurPrensente = 1;

            // Act
            bool valeurObtenue = tableau.Contains(valeurPrensente);

            // Assert
            Assert.True(valeurObtenue);
        }


        // CopyTo
        [Fact]
        public void CopyTo_PreconditionTableauNull_LanceException()
        {
            // Arrange
            TableauCapaciteVariable<int> tableauSource = new TableauCapaciteVariable<int>(){ 1, 2, 3, 4, 5};
            int[] tableauNull = null;

            // Act and assert
            Assert.Throws<ArgumentNullException>(() => { tableauSource.CopyTo(tableauNull, 0); });

        }

        [Fact]
        public void CopyTo_PreconditionIndexInferieurZero_LanceException()
        {
            // Arrange
            TableauCapaciteVariable<int> tableauSource = new TableauCapaciteVariable<int>() { 1, 2, 3, 4, 5 };
            int[] tableau = new int[] { 1, 2, 3, 4, 5 };
            int indexInferieurZero = -1;

            // Act and assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { tableauSource.CopyTo(tableau, indexInferieurZero); });

        }

        [Fact]
        public void CopyTo_PreconditionIndexSuperieurCapaciteTableauDestination_LanceException()
        {
            // Arrange
            TableauCapaciteVariable<int> tableauSource = new TableauCapaciteVariable<int>() { 1, 2, 3, 4, 5 };
            int[] tableau = new int[] { 1, 2, 3, 4, 5 };
            int indexInferieurZero = 5;

            // Act and assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { tableauSource.CopyTo(tableau, indexInferieurZero); });

        }
        [Fact]
        public void CopyTo_PreconditionCopierTableauDepasseLimite_LanceException()
        {
            // Arrange
            TableauCapaciteVariable<int> tableauSource = new TableauCapaciteVariable<int>() { 1, 2, 3, 4, 5 };
            int[] tableauDestination = new int[5];

            // Act and assert
            Assert.Throws<ArgumentException>(() => { tableauSource.CopyTo(tableauDestination, 1); });

        }

        [Fact]
        public void CopyTo_CopieTableauSourceDansDestinationVideIndexZero_AssertEqual()
        {
            // Arrange
            TableauCapaciteVariable<int> tableauSource = new TableauCapaciteVariable<int>() { 1, 2, 3, 4, 5 };
            int[] tableauDestination = new int[5];
            int[] tableauAttendu = new int[] { 1, 2, 3, 4, 5 };

            // Act
            tableauSource.CopyTo(tableauDestination, 0);

            // assert
            Assert.Equal(tableauAttendu, tableauDestination);
        }

        [Fact]
        public void CopyTo_CopieTableauSourceDansDestinationNonVideIndexPasZero_AssertEqual()
        {
            // Arrange
            TableauCapaciteVariable<int> tableauSource = new TableauCapaciteVariable<int>() { 1, 2, 3, 4, 5 };
            int[] tableauDestination = new int[] { 9, 8, 7, 6, 5, 4, 3};
            int[] tableauAttendu = new int[] { 9, 8, 1, 2, 3, 4, 5};

            // Act
            tableauSource.CopyTo(tableauDestination, 2);

            // assert
            Assert.Equal(tableauAttendu, tableauDestination);
        }


        // IndexOf
        [Fact]
        public void IndexOf_ValeurTrouveDebutTableau_AssertEqual()
        {
            // Arrange
            TableauCapaciteVariable<int> tableau = new TableauCapaciteVariable<int>() { 5, 4, 6, 2, 7 };
            int valeurAChercher = 5;
            int valeurAttendue = 0;

            // Act
            int valeurObtenue = tableau.IndexOf(valeurAChercher);

            // Assert
            Assert.Equal(valeurAttendue, valeurObtenue);
        }

        [Fact]
        public void IndexOf_ValeurTrouveFinTableau_AssertEqual()
        {
            // Arrange
            TableauCapaciteVariable<int> tableau = new TableauCapaciteVariable<int>() { 5, 4, 6, 2, 7 };
            int valeurAChercher = 7;
            int valeurAttendue = 4;

            // Act
            int valeurObtenue = tableau.IndexOf(valeurAChercher);

            // Assert
            Assert.Equal(valeurAttendue, valeurObtenue);
        }

        [Fact]
        public void IndexOf_ValeurATrouverDoublon_RenvoiePremiereValeur()
        {
            // Arrange
            TableauCapaciteVariable<int> tableau = new TableauCapaciteVariable<int>() { 5, 6, 6, 2, 7 };
            int valeurAChercher = 6;
            int valeurAttendue = 1;

            // Act
            int valeurObtenue = tableau.IndexOf(valeurAChercher);

            // Assert
            Assert.Equal(valeurAttendue, valeurObtenue);
        }

        [Fact]
        public void IndexOf_ValeurATrouverNonPresente_RenvoiePremiereValeur()
        {
            // Arrange
            TableauCapaciteVariable<int> tableau = new TableauCapaciteVariable<int>() { 5, 6, 6, 2, 7 };
            int valeurAChercher = 9;
            int valeurAttendue = -1;

            // Act
            int valeurObtenue = tableau.IndexOf(valeurAChercher);

            // Assert
            Assert.Equal(valeurAttendue, valeurObtenue);
        }


        // Insert
        [Fact]
        public void Insert_PreconditionOutOfRangeExceptionMoinsQueZero_LanceException()
        {
            // Arrange
            List<int> listeEntiers = new List<int>() { 1, 2, 3, 4 };
            TableauCapaciteVariable<int> tableau = new TableauCapaciteVariable<int>(listeEntiers);

            //Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { tableau.Insert(-1, 2); });
        }

        [Fact]
        public void Insert_PreconditionOutOfRangeExceptionPLusQueCount_LanceException()
        {
            // Arrange
            List<int> listeEntiers = new List<int>() { 1, 2, 3, 4 };
            TableauCapaciteVariable<int> tableau = new TableauCapaciteVariable<int>(listeEntiers);

            //Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { tableau.Insert(5, 2); });
        }

        [Fact]
        public void Insert_AjouterElementIndexEgalAuCount_AgirCommeLaMethodeAdd()
        {
            // Arrange
            List<int> listeEntiers = new List<int>() { 1, 2, 3, 4 };
            TableauCapaciteVariable<int> tableau = new TableauCapaciteVariable<int>(listeEntiers);
            int CountAttendu = 5;
            TableauCapaciteVariable<int> tableauAttendu = new TableauCapaciteVariable<int>() { 1, 2, 3, 4, 8 };


            //Act
            int valeurAAjouter = 8;
            tableau.Insert(4, valeurAAjouter);

            // Assert
            Assert.Equal(CountAttendu, tableau.Count);
            Assert.Equal(tableauAttendu, tableau);
        }

        [Fact]
        public void Insert_AjouterElementIndexInferieurACount_AjouteElementBonIndexAugmenteCount()
        {
            // Arrange
            List<int> listeEntiers = new List<int>() { 1, 2, 3, 4 };
            TableauCapaciteVariable<int> tableau = new TableauCapaciteVariable<int>(listeEntiers);
            int CountAttendu = 5;
            TableauCapaciteVariable<int> tableauAttendu = new TableauCapaciteVariable<int>() { 1, 8, 2, 3, 4, };


            //Act
            int valeurAAjouter = 8;
            tableau.Insert(1, valeurAAjouter);

            // Assert
            Assert.Equal(CountAttendu, tableau.Count);
            Assert.Equal(tableauAttendu, tableau);
        }


        // Remove
        [Fact]
        public void Remove_EnleverElementExistantPremierIndex_AssertEqual()
        {
            // Arrange
            List<int> listeEntiers = new List<int>() { 1, 2, 3, 4, 5 };
            TableauCapaciteVariable<int> tableau = new TableauCapaciteVariable<int>(listeEntiers);

            List<int> listeEntiersAttendue = new List<int>() { 2, 3, 4, 5 };
            TableauCapaciteVariable<int> tableauAttendu = new TableauCapaciteVariable<int>(listeEntiersAttendue);

            int countAttendu = 4;

            // Act
            int elementAEnlever = 1;
            tableau.Remove(elementAEnlever);

            // Assert
            Assert.Equal(countAttendu, tableau.Count);
            Assert.Equal(tableauAttendu, tableau);
        }

        [Fact]
        public void Remove_EnleverElementExistantDernierIndex_AssertEqual()
        {
            // Arrange
            List<int> listeEntiers = new List<int>() { 1, 2, 3, 4, 5 };
            TableauCapaciteVariable<int> tableau = new TableauCapaciteVariable<int>(listeEntiers);

            List<int> listeEntiersAttendue = new List<int>() { 1, 2, 3, 4 };
            TableauCapaciteVariable<int> tableauAttendu = new TableauCapaciteVariable<int>(listeEntiersAttendue);

            int countAttendu = 4;

            // Act
            int elementAEnlever = 5;
            tableau.Remove(elementAEnlever);

            // Assert
            Assert.Equal(countAttendu, tableau.Count);
            Assert.Equal(tableauAttendu, tableau);
        }

        [Fact]
        public void Remove_EnleverElementNonPresent_TableauInchange()
        {
            // Arrange
            List<int> listeEntiers = new List<int>() { 1, 2, 3, 4, 5 };
            TableauCapaciteVariable<int> tableau = new TableauCapaciteVariable<int>(listeEntiers);

            List<int> listeEntiersAttendue = new List<int>() { 1, 2, 3, 4, 5 };
            TableauCapaciteVariable<int> tableauAttendu = new TableauCapaciteVariable<int>(listeEntiersAttendue);

            int countAttendu = 5;

            // Act
            int elementAEnlever = 9;
            tableau.Remove(elementAEnlever);

            // Assert
            Assert.Equal(countAttendu, tableau.Count);
            Assert.Equal(tableauAttendu, tableau);
        }


        // RemoveAt
        [Fact]
        public void RemoveAt_PreConditionInferieurAZero_LanceEXception()
        {
            // Arrange
            List<int> listeEntiers = new List<int>() { 1, 2, 3, 4, 5 };
            TableauCapaciteVariable<int> tableau = new TableauCapaciteVariable<int>(listeEntiers);
            int indexInferieurAZero = -1;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { tableau.RemoveAt(indexInferieurAZero); });
        }

        [Fact]
        public void RemoveAt_PreConditionSuperieurAuCount_LanceEXception()
        {
            // Arrange
            List<int> listeEntiers = new List<int>() { 1, 2, 3, 4, 5 };
            TableauCapaciteVariable<int> tableau = new TableauCapaciteVariable<int>(listeEntiers);
            int indexSuperieurAuCount = tableau.Count + 1;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { tableau.RemoveAt(indexSuperieurAuCount); });
        }

        [Fact]
        public void RemoveAt_EnleverElementExistantPremierIndex_ElementEnleveEtCountDiminueDeUn()
        {
            // Arrange
            List<int> listeEntiers = new List<int>() { 1, 2, 3, 4, 5 };
            TableauCapaciteVariable<int> tableau = new TableauCapaciteVariable<int>(listeEntiers);

            List<int> listeEntiersAttendue = new List<int>() { 2, 3, 4, 5 };
            TableauCapaciteVariable<int> tableauAttendu = new TableauCapaciteVariable<int>(listeEntiersAttendue);

            int countAttendu = 4;

            // Act
            int elementAEnlever = 0;
            tableau.RemoveAt(elementAEnlever);

            // Assert
            Assert.Equal(countAttendu, tableau.Count);
            Assert.Equal(tableauAttendu, tableau);
        }

        [Fact]
        public void RemoveAt_EnleverElementExistantDernierIndex_ElementEnleveEtCountDiminueDeUn()
        {
            // Arrange
            List<int> listeEntiers = new List<int>() { 1, 2, 3, 4, 5 };
            TableauCapaciteVariable<int> tableau = new TableauCapaciteVariable<int>(listeEntiers);

            List<int> listeEntiersAttendue = new List<int>() { 1, 2, 3, 4 };
            TableauCapaciteVariable<int> tableauAttendu = new TableauCapaciteVariable<int>(listeEntiersAttendue);

            int countAttendu = 4;

            // Act
            int elementAEnlever = 4;
            tableau.RemoveAt(elementAEnlever);

            // Assert
            Assert.Equal(countAttendu, tableau.Count);
            Assert.Equal(tableauAttendu, tableau);
        }
    }
}
