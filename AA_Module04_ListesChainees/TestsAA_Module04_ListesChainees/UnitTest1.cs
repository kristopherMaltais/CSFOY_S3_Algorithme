using System;
using Xunit;
using AA_Module04_ListesChainees;
using System.Collections.Generic;

namespace TestsAA_Module04_ListesChainees
{
    public class UnitTest1
    {
        #region Constructeurs
        [Fact]
        public void Ctr1_CreeationCorrecteListeChaine_ValeurParDefautTousLesChamps()
        {
            // Arrange
            int CountAttendu = 0;
            NoeudListeChainee<int> premierNoeudAttendu = null;
            NoeudListeChainee<int> dernierNoeudAttendu = null;

            // Act
            ListeChainee<int> listeChaine = new ListeChainee<int>();

            // Assert
            Assert.Equal(CountAttendu, listeChaine.Count);
            Assert.Equal(premierNoeudAttendu, listeChaine.PremierNoeud);
            Assert.Equal(dernierNoeudAttendu, listeChaine.DernierNoeud);
        }

        [Fact]
        public void Ctr2_PreconditionCollectionNulle_LanceUneException()
        {
            // Arrange
            List<int> listeEntierNull = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntierNull); });
        }

        [Fact]
        public void Ctr2_CreeListeChaineeUnElement_CreeListeChaineeAvecBonnesValeurs()
        {
            // Arrange
            List<int> listeEntierUnElement = new List<int>() { 5 };
            int countAttendu = 1;
            int valeurPremierNoeudAttendue = 5;
            int valeurDernierNoeudAttendue = 5;

            // Act
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntierUnElement);

            // Assert
            Assert.Equal(valeurPremierNoeudAttendue, listeChainee.PremierNoeud.Valeur);
            Assert.Equal(valeurDernierNoeudAttendue, listeChainee.DernierNoeud.Valeur);
            Assert.Equal(countAttendu, listeChainee.Count);
        }

        [Fact]
        public void Ctr2_CreeListeChaineePlusieursElements_CreeListeChaineeAvecBonnesValeurs()
        {
            // Arrange
            List<int> listePlusieursElements = new List<int>() { 5, 6, 4 };
            int countAttendu = 3;
            int valeurPremierNoeudAttendue = 5;
            int valeurDernierNoeudAttendue = 4;
            List<int> valeursAttendues = new List<int>() { 5, 6, 4 };

            // Act
            ListeChainee<int> listeChainee = new ListeChainee<int>(listePlusieursElements);

            // Assert
            Assert.Equal(valeursAttendues[0], listeChainee[0]);
            Assert.Equal(valeursAttendues[1], listeChainee[1]);
            Assert.Equal(valeursAttendues[2], listeChainee[2]);
            Assert.Equal(countAttendu, listeChainee.Count);
            Assert.Equal(valeurPremierNoeudAttendue, listeChainee.PremierNoeud.Valeur);
            Assert.Equal(valeurDernierNoeudAttendue, listeChainee.DernierNoeud.Valeur);
        }

        [Fact]
        public void Ctr2_CreeListeChaineeAucunElement_CreeListeChaineeAvecBonnesValeurs()
        {
            // Arrange
            List<int> listeEntierUnElement = new List<int>();
            int countAttendu = 0;

            // Act
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntierUnElement);

            // Assert
            Assert.Equal(countAttendu, listeChainee.Count);
            Assert.Null(listeChainee.PremierNoeud);
            Assert.Null(listeChainee.DernierNoeud);
        }
        #endregion

        #region Méthodes
        // OpérateurCrochet
        [Fact]
        public void OperateurCrochetGet_PreconditionIndexInferieurZero_LanceException()
        {
            // Arrange
            List<int> listeEntier = new List<int>() { 1, 2, 3, 4};
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);
            int indexNegatif = -1;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { int valeur = listeChainee[indexNegatif]; });
        }

        [Fact]
        public void OperateurCrochetGet_PreconditionIndexSuperieurTailleCollection_LanceException()
        {
            // Arrange
            List<int> listeEntier = new List<int>() { 1, 2, 3, 4 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);
            int indexSuperieurTailleCollection = 4;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { int valeur = listeChainee[indexSuperieurTailleCollection]; });
        }

        [Fact]
        public void OperateurCrochetGet_AccederValeurAIndex_RenvoieLaBonneValeur()
        {
            // Arrange
            List<int> listeEntier = new List<int>() { 1, 2, 3, 4 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);
            int valeurAttendu = 1;
            int indexDemande = 0;

            // Act
            int valeurObtenue = listeChainee[indexDemande];

            // Assert
            Assert.Equal(valeurAttendu, valeurObtenue);
        }

        [Fact]
        public void OperateurCrochetSet_PreconditionIndexInferieurZero_LanceException()
        {
            // Arrange
            List<int> listeEntier = new List<int>() { 1, 2, 3, 4 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);
            int indexNegatif = -1;
            int valeurAInserer = 2;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { listeChainee[indexNegatif] = valeurAInserer; });
        }

        [Fact]
        public void OperateurCrochetSet_PreconditionIndexSuperieurTailleCollection_LanceException()
        {
            // Arrange
            List<int> listeEntier = new List<int>() { 1, 2, 3, 4 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);
            int indexSuperieurTailleCollection = 4;
            int valeurAInserer = 2;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { listeChainee[indexSuperieurTailleCollection] = valeurAInserer; });
        }

        [Fact]
        public void OperateurCrochetSet_AccederValeurAIndex_RenvoieLaBonneValeur()
        {
            // Arrange
            List<int> listeEntier = new List<int>() { 1, 2, 3, 4 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);
            int valeurAInserer = 2;
            int indexDemande = 0;
            int valeurAttendue = 2;

            // Act
            listeChainee[indexDemande] = valeurAInserer;

            // Assert
            Assert.Equal(valeurAttendue, listeChainee[indexDemande]);
        }


        // Add
        [Fact]
        public void Add_AjouterNoeudListeVide_AjouteLesBonnesValeurs()
        {
            // Arrange
            List<int> listeEntier = new List<int>();
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);
            int valeurAAjouter = 5;
            int countAttendu = 1;
            int valeurPremierNoeudAttendue = 5;
            int valeurDernierNoeudAttendue = 5;
            List<int> valeursAttendues = new List<int>() { 5 };
            
            // Act 
            listeChainee.Add(valeurAAjouter);

            // Assert
            Assert.Equal(countAttendu, listeChainee.Count);
            Assert.Equal(valeurPremierNoeudAttendue, listeChainee.PremierNoeud.Valeur);
            Assert.Equal(valeurDernierNoeudAttendue, listeChainee.DernierNoeud.Valeur);
            Assert.Equal(valeursAttendues[0], listeChainee[0]);
        }

        [Fact]
        public void Add_AjouterNoeudListeNonVide_AjouteLesBonnesValeurs()
        {
            // Arrange
            List<int> listeEntier = new List<int>() { 2 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);
            int valeurAAjouter = 5;
            int countAttendu = 2;
            int valeurPremierNoeudAttendue = 2;
            int valeurDernierNoeudAttendue = 5;
            List<int> valeursAttendues = new List<int>() { 2, 5 };

            // Act 
            listeChainee.Add(valeurAAjouter);

            // Assert
            Assert.Equal(countAttendu, listeChainee.Count);
            Assert.Equal(valeurPremierNoeudAttendue, listeChainee.PremierNoeud.Valeur);
            Assert.Equal(valeurDernierNoeudAttendue, listeChainee.DernierNoeud.Valeur);
            Assert.Equal(valeursAttendues[0], listeChainee[0]);
            Assert.Equal(valeursAttendues[1], listeChainee[1]);
        }

        [Fact]
        public void Add_AjouterUnElementListeTailleUn_AjouteLesBonnesValeurs()
        {
            // Arrange
            ListeChainee<int> listeChainee = new ListeChainee<int>() { 1 };
            int elementAjout = 2;

            // Act
            listeChainee.Add(elementAjout);

            // Assert
            Assert.Equal(elementAjout, listeChainee.DernierNoeud.Valeur);
            Assert.Null(listeChainee.DernierNoeud.Suivant);
            Assert.NotNull(listeChainee.PremierNoeud.Suivant);
        }

        // AddFirst
        [Fact]
        public void AddFirst_AjouterNoeudListeVide_AjouteLesBonnesValeurs()
        {
            // Arrange
            List<int> listeEntier = new List<int>();
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);
            int valeurAAjouter = 5;
            int countAttendu = 1;
            int valeurPremierNoeudAttendue = 5;
            int valeurDernierNoeudAttendue = 5;
            List<int> valeursAttendues = new List<int>() { 5 };

            // Act 
            listeChainee.AddFirst(valeurAAjouter);

            // Assert
            Assert.Equal(countAttendu, listeChainee.Count);
            Assert.Equal(valeurPremierNoeudAttendue, listeChainee.PremierNoeud.Valeur);
            Assert.Equal(valeurDernierNoeudAttendue, listeChainee.DernierNoeud.Valeur);
            Assert.Equal(valeursAttendues[0], listeChainee[0]);
        }

        [Fact]
        public void AddFirst_AjouterNoeudListeNonVide_AjouteLesBonnesValeurs()
        {
            // Arrange
            List<int> listeEntier = new List<int>() { 2 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);
            int valeurAAjouter = 5;
            int countAttendu = 2;
            int valeurPremierNoeudAttendue = 5;
            int valeurDernierNoeudAttendue = 2;
            List<int> valeursAttendues = new List<int>() { 5, 2 };

            // Act 
            listeChainee.AddFirst(valeurAAjouter);

            // Assert
            Assert.Equal(countAttendu, listeChainee.Count);
            Assert.Equal(valeurPremierNoeudAttendue, listeChainee.PremierNoeud.Valeur);
            Assert.Equal(valeurDernierNoeudAttendue, listeChainee.DernierNoeud.Valeur);
            Assert.Equal(valeursAttendues[0], listeChainee[0]);
            Assert.Equal(valeursAttendues[1], listeChainee[1]);
        }


        // Contains
        [Fact]
        public void Contains_ValeurPasPresente_RetourneFalse()
        {
            // Arrange
            List<int> listeEntier = new List<int>() { 2, 1, 6, 4 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);
            int valeurAChercher = 9;

            // Act
            bool valeurObtenue = listeChainee.Contains(valeurAChercher);

            // Assert
            Assert.False(valeurObtenue);
        }

        [Fact]
        public void Contains_ValeurPresente_RetourneTrue()
        {
            // Arrange
            List<int> listeEntier = new List<int>() { 2, 4, 6, 1 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);
            int valeurAChercher = 1;

            // Act
            bool valeurObtenue = listeChainee.Contains(valeurAChercher);

            // Assert
            Assert.True(valeurObtenue);
        }

        [Fact]
        public void Contains_ValeurPresentePlusieursFois_RetourneTrue()
        {
            // Arrange
            List<int> listeEntier = new List<int>() { 2, 1, 4, 4 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);
            int valeurAChercher = 4;

            // Act
            bool valeurObtenue = listeChainee.Contains(valeurAChercher);

            // Assert
            Assert.True(valeurObtenue);
        }


        // CopyTo
        [Fact]
        public void CopyTo_PreconditionIndexInferieurZero_LanceException()
        {
            // Arrange
            int[] tableauDestination = new int[] { 1, 2, 3, 4 };
            int indexNegatif = -1;
            List<int> listeEntier = new List<int>() { 2, 1, 6, 4 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { listeChainee.CopyTo(tableauDestination, indexNegatif); });
        }

        [Fact]
        public void CopyTo_PreconditionIndexSuperieurTailleTableau_LanceException()
        {
            // Arrange
            int[] tableauDestination = new int[] { 1, 2, 3, 4 };
            int indexSuperieurTailleTableau = 4;
            List<int> listeEntier = new List<int>() { 2, 1, 6, 4 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { listeChainee.CopyTo(tableauDestination, indexSuperieurTailleTableau); });
        }

        [Fact]
        public void CopyTo_PreconditionTableauNull_LanceException()
        {
            // Arrange
            int[] tableauNull = null;
            int indexOuCopier = 2;
            List<int> listeEntier = new List<int>() { 2, 1, 6, 4 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);

            // Act and Assert
            Assert.Throws<NullReferenceException>(() => { listeChainee.CopyTo(tableauNull, indexOuCopier); });
        }

        [Fact]
        public void CopyTo_PreconditionCopierTableauHorsLimite_LanceException()
        {
            // Arrange
            int[] tableau = new int[] { 1, 2, 3, 4 };
            int indexOuCopier = 2;
            List<int> listeEntier = new List<int>() { 2, 1, 6, 4 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { listeChainee.CopyTo(tableau, indexOuCopier); });
        }

        [Fact]
        public void CopyTo_CopierListePrendTouteLesEspaces_TableauDestinationContientToutesLesValeurs()
        {
            // Arrange
            int[] tableauDestination = new int[] { 1, 2, 3, 4 };
            int indexOuCopier = 0;
            List<int> listeEntier = new List<int>() { 2, 1, 6, 4 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);

            // Act
            listeChainee.CopyTo(tableauDestination, indexOuCopier);

            // Assert
            Assert.Equal(listeEntier[0], tableauDestination[0]);
            Assert.Equal(listeEntier[1], tableauDestination[1]);
            Assert.Equal(listeEntier[2], tableauDestination[2]);
            Assert.Equal(listeEntier[3], tableauDestination[3]);
        }

        [Fact]
        public void CopyTo_CopierTableauPrendPasToutesLesEspaces_TableauDestinationContientToutesLesValeurs()
        {
            // Arrange
            int[] tableauDestination = new int[] { 1, 2, 3, 4, 5 };
            int indexOuCopier = 0;
            List<int> listeEntier = new List<int>() { 2, 1, 6, 4 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);
            int[] tableauAttendu = new int[] { 2, 1, 6, 4, 5 };

            // Act
            listeChainee.CopyTo(tableauDestination, indexOuCopier);

            // Assert
            Assert.Equal(tableauAttendu[0], tableauDestination[0]);
            Assert.Equal(tableauAttendu[1], tableauDestination[1]);
            Assert.Equal(tableauAttendu[2], tableauDestination[2]);
            Assert.Equal(tableauAttendu[3], tableauDestination[3]);
            Assert.Equal(tableauAttendu[4], tableauDestination[4]);
        }


        // IndexOf
        [Fact]
        public void IndexOf_ListeChaineeNeContientPasLaValeur_RetourneMoinsUn()
        {
            // Arrange
            List<int> listeEntier = new List<int>() { 2, 1, 6, 4 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);
            int valeurAChercher = 9;
            int valeurAttendue = -1;

            // Act
            int valeurObtenue = listeChainee.IndexOf(valeurAChercher);

            // Assert
            Assert.Equal(valeurAttendue, valeurObtenue);
        }

        [Fact]
        public void IndexOf_ListeChaineeContientLaValeur_RetourneIndexCorrect()
        {
            // Arrange
            List<int> listeEntier = new List<int>() { 2, 1, 6, 4 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);
            int valeurAChercher = 4;
            int valeurAttendue = 3;

            // Act
            int valeurObtenue = listeChainee.IndexOf(valeurAChercher);

            // Assert
            Assert.Equal(valeurAttendue, valeurObtenue);
        }

        [Fact]
        public void IndexOf_ListeChaineeContientLaValeurEnDouble_RetourneIndexPremierTrouve()
        {
            // Arrange
            List<int> listeEntier = new List<int>() { 2, 1, 4, 4 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);
            int valeurAChercher = 4;
            int valeurAttendue = 2;

            // Act
            int valeurObtenue = listeChainee.IndexOf(valeurAChercher);

            // Assert
            Assert.Equal(valeurAttendue, valeurObtenue);
        }

        [Fact]
        public void IndexOf_ListeChaineeContientLaValeurCasNull_RetourneIndexCorrect()
        {
            // Arrange
            List<string> listeString = new List<string>() { "abc", null, "asq", "rty" };
            ListeChainee<string> listeChainee = new ListeChainee<string>(listeString);
            string valeurAChercher = null;
            int valeurAttendue = 1;

            // Act
            int valeurObtenue = listeChainee.IndexOf(valeurAChercher);

            // Assert
            Assert.Equal(valeurAttendue, valeurObtenue);
        }


        // Insert
        [Fact]
        public void Insert_PreconditionIndexInferieurZero_LanceException()
        {
            // Arrange
            List<int> listeEntier = new List<int>() { 1, 2, 3, 4 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);
            int indexNegatif = -1;
            int itemAAjouter = 3;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { listeChainee.Insert(indexNegatif, itemAAjouter); });
        }

        [Fact]
        public void Insert_PreconditionIndexSuperieurTailleCollection_LanceException()
        {
            // Arrange
            List<int> listeEntier = new List<int>() { 1, 2, 3, 4 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);
            int indexSuperieurTailleCollection = 5;
            int itemAAjouter = 3;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { listeChainee.Insert(indexSuperieurTailleCollection, itemAAjouter); });
        }

        [Fact]
        public void Insert_AjoutAuPremierIndex_AjouteValeurPremierIndex()
        {
            // Arrange
            List<int> listeEntier = new List<int>() { 2, 1, 7 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);
            int index = 0;
            int valeurAjoute = 4;

            List<int> resultatAttendu = new List<int>() { 4, 2, 1, 7 };
            int countAttendu = 4;
            int premierNoeudValeurAttendue = 4;

            // Act
            listeChainee.Insert(index, valeurAjoute);

            // Assert
            Assert.Equal(listeChainee[0], resultatAttendu[0]);
            Assert.Equal(listeChainee[1], resultatAttendu[1]);
            Assert.Equal(listeChainee[2], resultatAttendu[2]);
            Assert.Equal(listeChainee[3], resultatAttendu[3]);
            Assert.Equal(countAttendu, listeChainee.Count);
            Assert.Equal(premierNoeudValeurAttendue, listeChainee.PremierNoeud.Valeur);
        }

        [Fact]
        public void Insert_AjoutAIndexEgalAuCount_RetourneIndexPremierTrouve()
        {
            // Arrange
            List<int> listeEntier = new List<int>() { 2, 1, 7 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);
            int index = 3;
            int valeurAjoute = 4;

            List<int> resultatAttendu = new List<int>() {2, 1, 7, 4 };
            int countAttendu = 4;
            int dernierNoeudValeurAttendue = 4;

            // Act
            listeChainee.Insert(index, valeurAjoute);

            // Assert
            Assert.Equal(listeChainee[0], resultatAttendu[0]);
            Assert.Equal(listeChainee[1], resultatAttendu[1]);
            Assert.Equal(listeChainee[2], resultatAttendu[2]);
            Assert.Equal(listeChainee[3], resultatAttendu[3]);
            Assert.Equal(countAttendu, listeChainee.Count);
            Assert.Equal(dernierNoeudValeurAttendue, listeChainee.DernierNoeud.Valeur);
        }

        [Fact]
        public void Insert_AjoutAIndexAuCentre_AjouteLesBonnesValeurs()
        {
            // Arrange
            List<int> listeEntier = new List<int>() { 2, 1, 7 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);
            int index = 1;
            int valeurAjoute = 4;

            List<int> resultatAttendu = new List<int>() { 2, 4, 1, 7 };
            int countAttendu = 4;
            int dernierNoeudValeurAttendue = 7;
            int premierNoeudValeurAttendue = 2;

            // Act
            listeChainee.Insert(index, valeurAjoute);

            // Assert
            Assert.Equal(listeChainee[0], resultatAttendu[0]);
            Assert.Equal(listeChainee[1], resultatAttendu[1]);
            Assert.Equal(listeChainee[2], resultatAttendu[2]);
            Assert.Equal(listeChainee[3], resultatAttendu[3]);
            Assert.Equal(countAttendu, listeChainee.Count);
            Assert.Equal(dernierNoeudValeurAttendue, listeChainee.DernierNoeud.Valeur);
            Assert.Equal(premierNoeudValeurAttendue, listeChainee.PremierNoeud.Valeur);
        }

        [Fact]
        public void Insert_AjoutAIndexAuDernierIndex_AjouteLesBonnesValeurs()
        {
            // Arrange
            List<int> listeEntier = new List<int>() { 2, 1, 7 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);
            int index = 2;
            int valeurAjoute = 4;

            List<int> resultatAttendu = new List<int>() { 2, 1, 4, 7 };
            int countAttendu = 4;
            int dernierNoeudValeurAttendue = 7;
            int premierNoeudValeurAttendue = 2;

            // Act
            listeChainee.Insert(index, valeurAjoute);

            // Assert
            Assert.Equal(listeChainee[0], resultatAttendu[0]);
            Assert.Equal(listeChainee[1], resultatAttendu[1]);
            Assert.Equal(listeChainee[2], resultatAttendu[2]);
            Assert.Equal(listeChainee[3], resultatAttendu[3]);
            Assert.Equal(countAttendu, listeChainee.Count);
            Assert.Equal(dernierNoeudValeurAttendue, listeChainee.DernierNoeud.Valeur);
            Assert.Equal(premierNoeudValeurAttendue, listeChainee.PremierNoeud.Valeur);
        }

        // Remove
        [Fact]
        public void Remove_SupprimerElementInexistant_RetourneFalse()
        {
            // Arrange
            List<int> listeEntier = new List<int>() { 2, 1, 7 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);

            // Act
            bool valeurObtenue = listeChainee.Remove(8);

            // Assert
            Assert.False(valeurObtenue);
        }

        [Fact]
        public void Remove_SupprimerElementExistantPremierIndex_RetourneTruePremierNoeudChange()
        {
            // Arrange
            List<int> listeEntier = new List<int>() { 2, 1, 7 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);

            int countAttendu = 2;
            List<int> valeursAttendues = new List<int>() { 1, 7 };
            int valeurPremierNoeud = 1;

            // Act
            bool valeurObtenue = listeChainee.Remove(2);

            // Assert
            Assert.True(valeurObtenue);
            Assert.Equal(valeursAttendues[0], listeChainee[0]);
            Assert.Equal(valeursAttendues[1], listeChainee[1]);
            Assert.Equal(countAttendu, listeChainee.Count);
            Assert.Equal(valeurPremierNoeud, listeChainee.PremierNoeud.Valeur);
        }

        [Fact]
        public void Remove_SupprimerElementExistantDernierIndex_RetourneTrueDernierChange()
        {
            // Arrange
            List<int> listeEntier = new List<int>() { 2, 1, 7 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);

            int countAttendu = 2;
            List<int> valeursAttendues = new List<int>() { 2, 1 };
            int valeurDernierNoeud = 1;

            // Act
            bool valeurObtenue = listeChainee.Remove(7);

            // Assert
            Assert.True(valeurObtenue);
            Assert.Equal(valeursAttendues[0], listeChainee[0]);
            Assert.Equal(valeursAttendues[1], listeChainee[1]);
            Assert.Equal(countAttendu, listeChainee.Count);
            Assert.Equal(valeurDernierNoeud, listeChainee.DernierNoeud.Valeur);
        }

        [Fact]
        public void Remove_SupprimerElementExistantIndexCentre_RetourneTruePremierEtDernierNoeudInchanges()
        {
            // Arrange
            List<int> listeEntier = new List<int>() { 2, 1, 7 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);

            int countAttendu = 2;
            List<int> valeursAttendues = new List<int>() { 2, 7 };
            int valeurPremierNoeudAttendue = 2;
            int valeurDernierNoeudAttendue = 7;

            // Act
            bool valeurObtenue = listeChainee.Remove(1);

            // Assert
            Assert.True(valeurObtenue);
            Assert.Equal(valeursAttendues[0], listeChainee[0]);
            Assert.Equal(valeursAttendues[1], listeChainee[1]);
            Assert.Equal(countAttendu, listeChainee.Count);
            Assert.Equal(valeurPremierNoeudAttendue, listeChainee.PremierNoeud.Valeur);
            Assert.Equal(valeurDernierNoeudAttendue, listeChainee.DernierNoeud.Valeur);
        }


        // RemoveAt
        [Fact]
        public void RemoveAt_PreconditionIndexInferieurZero_LanceException()
        {
            // Arrange
            List<int> listeEntier = new List<int>() { 1, 2, 3, 4 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);
            int indexNegatif = -1;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { listeChainee.RemoveAt(indexNegatif); });
        }

        [Fact]
        public void RemoveAt_PreconditionIndexHorsLimiteTableauVide_LanceException()
        {
            // Arrange
            List<int> listeEntier = new List<int>();
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);
            int index = 0;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { listeChainee.RemoveAt(index); });
        }

        [Fact]
        public void RemoveAt_PreconditionIndexSuperieurTailleCollection_LanceException()
        {
            // Arrange
            List<int> listeEntier = new List<int>() { 1, 2, 3, 4 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);
            int indexSuperieurTailleCollection = 5;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { listeChainee.RemoveAt(indexSuperieurTailleCollection); });
        }

        [Fact]
        public void RemoveAt_SupprimerElementExistantPremierIndex_RetourneTruePremierNoeudChange()
        {
            // Arrange
            List<int> listeEntier = new List<int>() { 2, 1, 7 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);

            int countAttendu = 2;
            List<int> valeursAttendues = new List<int>() { 1, 7 };
            int valeurPremierNoeud = 1;

            // Act
            listeChainee.RemoveAt(0);

            // Assert
            Assert.Equal(valeursAttendues[0], listeChainee[0]);
            Assert.Equal(valeursAttendues[1], listeChainee[1]);
            Assert.Equal(countAttendu, listeChainee.Count);
            Assert.Equal(valeurPremierNoeud, listeChainee.PremierNoeud.Valeur);
        }

        [Fact]
        public void RemoveAt_SupprimerElementExistantDernierIndex_RetourneTrueDernierChange()
        {
            // Arrange
            List<int> listeEntier = new List<int>() { 2, 1, 7 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);

            int countAttendu = 2;
            List<int> valeursAttendues = new List<int>() { 2, 1 };
            int valeurDernierNoeud = 1;
            int indexARetirer = 2;

            // Act
            listeChainee.RemoveAt(indexARetirer);

            // Assert
            Assert.Equal(valeursAttendues[0], listeChainee[0]);
            Assert.Equal(valeursAttendues[1], listeChainee[1]);
            Assert.Equal(countAttendu, listeChainee.Count);
            Assert.Equal(valeurDernierNoeud, listeChainee.DernierNoeud.Valeur);
        }

        [Fact]
        public void RemoveAt_SupprimerElementExistantIndexCentre_RetourneTruePremierEtDernierNoeudInchanges()
        {
            // Arrange
            List<int> listeEntier = new List<int>() { 2, 1, 7 };
            ListeChainee<int> listeChainee = new ListeChainee<int>(listeEntier);

            int countAttendu = 2;
            List<int> valeursAttendues = new List<int>() { 2, 7 };
            int valeurPremierNoeudAttendue = 2;
            int valeurDernierNoeudAttendue = 7;

            // Act
            listeChainee.RemoveAt(1);

            // Assert
            Assert.Equal(valeursAttendues[0], listeChainee[0]);
            Assert.Equal(valeursAttendues[1], listeChainee[1]);
            Assert.Equal(countAttendu, listeChainee.Count);
            Assert.Equal(valeurPremierNoeudAttendue, listeChainee.PremierNoeud.Valeur);
            Assert.Equal(valeurDernierNoeudAttendue, listeChainee.DernierNoeud.Valeur);
        }
        #endregion
    }
}
