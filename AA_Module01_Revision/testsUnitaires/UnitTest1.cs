using System;
using Xunit;
using Revision_algo;
using System.Collections.Generic;

namespace testsUnitaires
{
    public class UnitTest1
    {
        // *** EXERCICE 1 *** //
        // TriABulle
        [Fact]
        public void TriABulle_PreconditionNull_LanceException()
        {
            // Arrange
            int[] tableauNull = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { Program.TriABulle(tableauNull); });
        }

        [Fact]
        public void TriABulle_TrierTableauNonOrdonne_AssertEqual()
        {
            // Arrange
            int[] tableauNonOrdonne = new int[] { 2, 1, 6, 4, 9, 2 };
            int[] tableauAttendu = new int[] { 1, 2, 2, 4, 6, 9 };

            // Act
            int[] tableauObtenu = Program.TriABulle(tableauNonOrdonne);

            // Assert
            Assert.Equal(tableauObtenu, tableauAttendu);
        }

        [Fact]
        public void TriABulle_TrierTableauOrdonne_AssertEqual()
        {
            // Arrange
            int[] tableauOrdonne = new int[] { 1, 2, 2, 4, 6, 9 };
            int[] tableauAttendu = new int[] { 1, 2, 2, 4, 6, 9 };

            // Act
            int[] tableauObtenu = Program.TriABulle(tableauOrdonne);

            // Assert
            Assert.Equal(tableauObtenu, tableauAttendu);
        }


        // CopierTableau
        [Fact]
        public void CopierTableau_PreconditionNull_LanceException()
        {
            // Arrange
            int[] tableauNull = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { Program.CopierTableau(tableauNull); });
        }
       
        [Fact]
        public void CopierTableau_CopieDuTableauExactitude_AssertEqual()
        {
            // Arrange
            int[] tableauACopier = new int[] { 1, 2, 3, 4, 5 };

            // Act
            int[] tableauObtenu = Program.CopierTableau(tableauACopier);

            // Assert
            Assert.Equal(tableauACopier, tableauObtenu);
        }

        [Fact]
        public void CopierTableau_TableauCopierDifferent_AssertNotSame()
        {
            // Arrange
            int[] tableauACopier = new int[] { 1, 2, 3, 4, 5 };

            // Act
            int[] tableauObtenu = Program.CopierTableau(tableauACopier);

            // Assert
            Assert.NotSame(tableauACopier, tableauObtenu);
        }

        // TriRapide
        [Fact]
        public void TriRapide_PreconditionNull_LanceException()
        {
            // Arrange
            int[] tableauNull = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { Program.TriRapide(tableauNull); });
        }
        
        // TriRapide_Rec
        [Fact]
        public void TriRapide_Rec_PreconditionNull_LanceException()
        {
            // Arrange
            int[] tableauNull = null;
            int indicePremier = 0;
            int indiceDernier = 5;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { Program.TriRapide_rec(tableauNull, indicePremier, indiceDernier); });
        }

        [Fact]
        public void TriRapide_Rec_PreconditionIndicePremierHorsLimiteInferieur_LanceException()
        {
            // Arrange
            int[] tableau = new int[] { 1, 2, 3, 4, 5};
            int indicePremier = -1;
            int indiceDernier = 4;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { Program.TriRapide_rec(tableau, indicePremier, indiceDernier); });
        }

        [Fact]
        public void TriRapide_Rec_PreconditionIndicePremierHorsLimiteSuperieur_LanceException()
        {
            // Arrange
            int[] tableau = new int[] { 1, 2, 3, 4, 5 };
            int indicePremier = 5;
            int indiceDernier = 4;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { Program.TriRapide_rec(tableau, indicePremier, indiceDernier); });
        }

        [Fact]
        public void TriRapide_Rec_PreconditionIndiceDernierHorsLimiteInferieur_LanceException()
        {
            // Arrange
            int[] tableau = new int[] { 1, 2, 3, 4, 5 };
            int indicePremier = 0;
            int indiceDernier = -1;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { Program.TriRapide_rec(tableau, indicePremier, indiceDernier); });
        }

        [Fact]
        public void TriRapide_Rec_PreconditionIndiceDernierHorsLimiteSuperieur_LanceException()
        {
            // Arrange
            int[] tableau = new int[] { 1, 2, 3, 4, 5 };
            int indicePremier = 0;
            int indiceDernier = 6;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { Program.TriRapide_rec(tableau, indicePremier, indiceDernier); });
        }

        [Fact]
        public void TriRapide_Rec_PreconditionIndicePremierPlusGrandIndiceDernier_LanceException()
        {
            // Arrange
            int[] tableau = new int[] { 1, 2, 3, 4, 5 };
            int indicePremier = 2;
            int indiceDernier = 1;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => { Program.TriRapide_rec(tableau, indicePremier, indiceDernier); });
        }

        // ChoixPivot
        [Fact]
        public void ChoixPivot_Rec_PreconditionNull_LanceException()
        {
            // Arrange
            int[] tableauNull = null;
            int indicePremier = 0;
            int indiceDernier = 5;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { Program.ChoixPivot(tableauNull, indicePremier, indiceDernier); });
        }

        [Fact]
        public void ChoixPivot_Rec_PreconditionIndicePremierHorsLimiteInferieur_LanceException()
        {
            // Arrange
            int[] tableau = new int[] { 1, 2, 3, 4, 5 };
            int indicePremier = -1;
            int indiceDernier = 4;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { Program.ChoixPivot(tableau, indicePremier, indiceDernier); });
        }

        [Fact]
        public void ChoixPivot_Rec_PreconditionIndicePremierHorsLimiteSuperieur_LanceException()
        {
            // Arrange
            int[] tableau = new int[] { 1, 2, 3, 4, 5 };
            int indicePremier = 5;
            int indiceDernier = 4;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { Program.ChoixPivot(tableau, indicePremier, indiceDernier); });
        }

        [Fact]
        public void ChoixPivot_Rec_PreconditionIndiceDernierHorsLimiteInferieur_LanceException()
        {
            // Arrange
            int[] tableau = new int[] { 1, 2, 3, 4, 5 };
            int indicePremier = 0;
            int indiceDernier = -1;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { Program.ChoixPivot(tableau, indicePremier, indiceDernier); });
        }

        [Fact]
        public void ChoixPivot_Rec_PreconditionIndiceDernierHorsLimiteSuperieur_LanceException()
        {
            // Arrange
            int[] tableau = new int[] { 1, 2, 3, 4, 5 };
            int indicePremier = 0;
            int indiceDernier = 6;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { Program.ChoixPivot(tableau, indicePremier, indiceDernier); });
        }

        [Fact]
        public void ChoixPivot_Rec_PreconditionIndicePremierPlusGrandIndiceDernier_LanceException()
        {
            // Arrange
            int[] tableau = new int[] { 1, 2, 3, 4, 5 };
            int indicePremier = 2;
            int indiceDernier = 1;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => { Program.ChoixPivot(tableau, indicePremier, indiceDernier); });
        }

        // Partionner
        [Fact]
        public void Partionner_PreconditionNull_LanceException()
        {
            // Arrange
            int[] tableauNull = null;
            int indicePremier = 0;
            int indiceDernier = 5;
            int indicePivot = 0;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { Program.Partionner(tableauNull, indicePremier, indiceDernier, indicePivot); });
        }

        [Fact]
        public void Partionner_PreconditionIndicePremierHorsLimiteInferieur_LanceException()
        {
            // Arrange
            int[] tableau = new int[] { 1, 2, 3, 4, 5 };
            int indicePremier = -1;
            int indiceDernier = 4;
            int indicePivot = 0;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { Program.Partionner(tableau, indicePremier, indiceDernier, indicePivot); });
        }

        [Fact]
        public void Partionner_PreconditionIndicePremierHorsLimiteSuperieur_LanceException()
        {
            // Arrange
            int[] tableau = new int[] { 1, 2, 3, 4, 5 };
            int indicePremier = 5;
            int indiceDernier = 4;
            int indicePivot = 0;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { Program.Partionner(tableau, indicePremier, indiceDernier, indicePivot); });
        }

        [Fact]
        public void Partionner_PreconditionIndiceDernierHorsLimiteInferieur_LanceException()
        {
            // Arrange
            int[] tableau = new int[] { 1, 2, 3, 4, 5 };
            int indicePremier = 0;
            int indiceDernier = -1;
            int indicePivot = 0;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { Program.Partionner(tableau, indicePremier, indiceDernier, indicePivot); });
        }

        [Fact]
        public void Partionner_PreconditionIndiceDernierHorsLimiteSuperieur_LanceException()
        {
            // Arrange
            int[] tableau = new int[] { 1, 2, 3, 4, 5 };
            int indicePremier = 0;
            int indiceDernier = 6;
            int indicePivot = 0;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { Program.Partionner(tableau, indicePremier, indiceDernier, indicePivot); });
        }

        [Fact]
        public void Partionner_PreconditionIndicePivotHorsLimiteInferieur_LanceException()
        {
            // Arrange
            int[] tableau = new int[] { 1, 2, 3, 4, 5 };
            int indicePremier = -1;
            int indiceDernier = 4;
            int indicePivot = -1;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { Program.Partionner(tableau, indicePremier, indiceDernier, indicePivot); });
        }

        [Fact]
        public void Partionner_PreconditionIndicePivotHorsLimiteSuperieur_LanceException()
        {
            // Arrange
            int[] tableau = new int[] { 1, 2, 3, 4, 5 };
            int indicePremier = 5;
            int indiceDernier = 4;
            int indicePivot = 6;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { Program.Partionner(tableau, indicePremier, indiceDernier, indicePivot); });
        }

        [Fact]
        public void Partionner_PreconditionIndicePremierPlusGrandIndiceDernier_LanceException()
        {
            // Arrange
            int[] tableau = new int[] { 1, 2, 3, 4, 5 };
            int indicePremier = 2;
            int indiceDernier = 1;
            int indicePivot = 0;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => { Program.Partionner(tableau, indicePremier, indiceDernier, indicePivot); });
        }


        // ***EXERCICE 2 *** //

        // RechercherValeur
        [Fact]
        public void RechercherValeur_PreconditionNull_LanceException()
        {
            // Arrange
            int[] tableauNull = null;
            int chiffreAChercher = 2;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { Program.RechercherValeur(tableauNull, chiffreAChercher); });
        }

        [Fact]
        public void RechercherValeur_ValeurExistante_AssertTrue()
        {
            // Arrange
            int chiffreAChercher = 2;
            int[] tableauRecherche = new int[] { 2, 1, 3, 4, 5 };

            // Act
            bool valeurObtenu = Program.RechercherValeur(tableauRecherche, chiffreAChercher);

            // Assert
            Assert.True(valeurObtenu);
        }

        [Fact]
        public void RechercherValeur_ValeurNonExistante_AssertFalse()
        {
            // Arrange
            int chiffreAChercher = 10;
            int[] tableauRecherche = new int[] { 2, 1, 3, 4, 5 };

            // Act
            bool valeurObtenu = Program.RechercherValeur(tableauRecherche, chiffreAChercher);

            // Assert
            Assert.False(valeurObtenu);
        }

        [Fact]
        public void RechercherValeur_ValeurExistanteDebutTableau_AssertTrue()
        {
            // Arrange
            int chiffreAChercher = 2;
            int[] tableauRecherche = new int[] { 2, 1, 3, 4, 5 };

            // Act
            bool valeurObtenu = Program.RechercherValeur(tableauRecherche, chiffreAChercher);

            // Assert
            Assert.True(valeurObtenu);
        }

        [Fact]
        public void RechercherValeur_ValeurExistanteFinTableau_AssertTrue()
        {
            // Arrange
            int chiffreAChercher = 2;
            int[] tableauRecherche = new int[] { 0, 1, 3, 4, 2 };

            // Act
            bool valeurObtenu = Program.RechercherValeur(tableauRecherche, chiffreAChercher);

            // Assert
            Assert.True(valeurObtenu);
        }


        // RechercherValeurDichotomie
        [Fact]
        public void RechercherValeurDichotomie_PreconditionNull_LanceException()
        {
            // Arrange
            int[] tableauNull = null;
            int chiffreAChercher = 2;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { Program.RechercherValeurDichotomie(tableauNull, chiffreAChercher); });
        }

        [Fact]
        public void RechercherValeurDichotomie_ValeurExistante_AssertTrue()
        {
            // Arrange
            int chiffreAChercher = 2;
            int[] tableauRecherche = new int[] { 2, 1, 3, 4, 5 };

            // Act
            bool valeurObtenu = Program.RechercherValeurDichotomie(tableauRecherche, chiffreAChercher);

            // Assert
            Assert.True(valeurObtenu);
        }

        [Fact]
        public void RechercherValeurDichotomie_ValeurNonExistante_AssertFalse()
        {
            // Arrange
            int chiffreAChercher = 10;
            int[] tableauRecherche = new int[] { 2, 1, 3, 4, 5 };

            // Act
            bool valeurObtenu = Program.RechercherValeurDichotomie(tableauRecherche, chiffreAChercher);

            // Assert
            Assert.False(valeurObtenu);
        }

        [Fact]
        public void RechercherValeurDichotomie_ValeurExistanteDebutTableau_AssertTrue()
        {
            // Arrange
            int chiffreAChercher = 2;
            int[] tableauRecherche = new int[] { 2, 1, 3, 4, 5 };

            // Act
            bool valeurObtenu = Program.RechercherValeurDichotomie(tableauRecherche, chiffreAChercher);

            // Assert
            Assert.True(valeurObtenu);
        }

        [Fact]
        public void RechercherValeurDichotomie_ValeurExistanteFinTableau_AssertTrue()
        {
            // Arrange
            int chiffreAChercher = 2;
            int[] tableauRecherche = new int[] { 0, 1, 3, 4, 2 };

            // Act
            bool valeurObtenu = Program.RechercherValeur(tableauRecherche, chiffreAChercher);

            // Assert
            Assert.True(valeurObtenu);
        }


        // ** EXERCICE 3 ** //

        // TriABulleLamda
        [Fact]
        public void TriABulleLambda_PreconditionTableauNull_LanceException()
        {
            // Arrange
            int[] tableauNull = null;
            Func<int, int, bool> fonctionLambda = (x, y) => x > y; 

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { Program.TriABulleLambda(tableauNull, fonctionLambda); });
        }

        [Fact]
        public void TriABulleLambda_PreconditionFonctionLambdaNull_LanceException()
        {
            // Arrange
            int[] tableauNull = null;
            Func<int, int, bool> fonctionLambda = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { Program.TriABulleLambda(tableauNull, fonctionLambda); });
        }

        [Fact]
        public void TriABulleLambda_TrierTableauNonOrdonne_AssertEqual()
        {
            // Arrange
            int[] tableauNonOrdonne = new int[] { 2, 1, 6, 4, 9, 2 };
            int[] tableauAttendu = new int[] { 1, 2, 2, 4, 6, 9 };
            Func<int, int, bool> fonctionLambda = (x, y) => x > y;

            // Act
            int[] tableauObtenu = Program.TriABulleLambda(tableauNonOrdonne, fonctionLambda);

            // Assert
            Assert.Equal(tableauObtenu, tableauAttendu);
        }

        [Fact]
        public void TriABulleLambda_TrierTableauOrdonne_AssertEqual()
        {
            // Arrange
            int[] tableauOrdonne = new int[] { 1, 2, 2, 4, 6, 9 };
            int[] tableauAttendu = new int[] { 1, 2, 2, 4, 6, 9 };
            Func<int, int, bool> fonctionLambda = (x, y) => x > y;

            // Act
            int[] tableauObtenu = Program.TriABulleLambda(tableauOrdonne, fonctionLambda);

            // Assert
            Assert.Equal(tableauObtenu, tableauAttendu);
        }

        // TriRapideLamda
        [Fact]
        public void TriRapideLambda_PreconditionTableauNull_LanceException()
        {
            // Arrange
            int[] tableauNull = null;
            Func<int, int, bool> fonctionLambda = (x, y) => x > y;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { Program.TriRapideLambda(tableauNull, fonctionLambda); });
        }

        [Fact]
        public void TriRapideLambda_PreconditionFonctionComparaisonNull_LanceException()
        {
            // Arrange
            int[] tableauNull = { 1, 2, 2, 4, 6, 9 };
            Func<int, int, bool> fonctionLambda = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { Program.TriRapideLambda(tableauNull, fonctionLambda); });
        }

        // TriRapide_recLambda

        [Fact]
        public void TriRapide_RecLambda_PreconditionTableauNull_LanceException()
        {
            // Arrange
            int[] tableauNull = null;
            int indicePremier = 0;
            int indiceDernier = 5;
            Func<int, int, bool> fonctionLambda = (x, y) => x > y;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { Program.TriRapide_recLambda(tableauNull, indicePremier, indiceDernier, fonctionLambda); });
        }

        [Fact]
        public void TriRapide_RecLambda_PreconditionIndicePremierHorsLimiteInferieur_LanceException()
        {
            // Arrange
            int[] tableau = new int[] { 1, 2, 3, 4, 5 };
            int indicePremier = -1;
            int indiceDernier = 4;
            Func<int, int, bool> fonctionLambda = (x, y) => x > y;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { Program.TriRapide_recLambda(tableau, indicePremier, indiceDernier, fonctionLambda); });
        }

        [Fact]
        public void TriRapide_RecLambda_PreconditionIndicePremierHorsLimiteSuperieur_LanceException()
        {
            // Arrange
            int[] tableau = new int[] { 1, 2, 3, 4, 5 };
            int indicePremier = 5;
            int indiceDernier = 4;
            Func<int, int, bool> fonctionLambda = (x, y) => x > y;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { Program.TriRapide_recLambda(tableau, indicePremier, indiceDernier, fonctionLambda); });
        }

        [Fact]
        public void TriRapide_RecLambda_PreconditionIndiceDernierHorsLimiteInferieur_LanceException()
        {
            // Arrange
            int[] tableau = new int[] { 1, 2, 3, 4, 5 };
            int indicePremier = 0;
            int indiceDernier = -1;
            Func<int, int, bool> fonctionLambda = (x, y) => x > y;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { Program.TriRapide_recLambda(tableau, indicePremier, indiceDernier, fonctionLambda); });
        }

        [Fact]
        public void TriRapide_RecLambda_PreconditionIndiceDernierHorsLimiteSuperieur_LanceException()
        {
            // Arrange
            int[] tableau = new int[] { 1, 2, 3, 4, 5 };
            int indicePremier = 0;
            int indiceDernier = 6;
            Func<int, int, bool> fonctionLambda = (x, y) => x > y;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { Program.TriRapide_recLambda(tableau, indicePremier, indiceDernier, fonctionLambda); });
        }

        [Fact]
        public void TriRapide_RecLambda_PreconditionIndicePremierPlusGrandIndiceDernier_LanceException()
        {
            // Arrange
            int[] tableau = new int[] { 1, 2, 3, 4, 5 };
            int indicePremier = 2;
            int indiceDernier = 1;
            Func<int, int, bool> fonctionLambda = (x, y) => x > y;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => { Program.TriRapide_recLambda(tableau, indicePremier, indiceDernier, fonctionLambda); });
        }

        [Fact]
        public void TriRapide_RecLambda_PreconditionIndiceFonctionLambdaNull_LanceException()
        {
            // Arrange
            int[] tableau = new int[] { 1, 2, 3, 4, 5 };
            int indicePremier = 2;
            int indiceDernier = 1;
            Func<int, int, bool> fonctionLambda = null;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => { Program.TriRapide_recLambda(tableau, indicePremier, indiceDernier, fonctionLambda); });
        }

        // ChoixPivotLambda (identique à ChoixPivot)

        // PartionnerLambda
        [Fact]
        public void PartionnerLambda_PreconditionNull_LanceException()
        {
            // Arrange
            int[] tableauNull = null;
            int indicePremier = 0;
            int indiceDernier = 5;
            int indicePivot = 0;
            Func<int, int, bool> fonctionLambda = (x, y) => x > y;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { Program.PartionnerLambda(tableauNull, indicePremier, indiceDernier, indicePivot, fonctionLambda); });
        }

        [Fact]
        public void PartionnerLambda_PreconditionIndicePremierHorsLimiteInferieur_LanceException()
        {
            // Arrange
            int[] tableau = new int[] { 1, 2, 3, 4, 5 };
            int indicePremier = -1;
            int indiceDernier = 4;
            int indicePivot = 0;
            Func<int, int, bool> fonctionLambda = (x, y) => x > y;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { Program.PartionnerLambda(tableau, indicePremier, indiceDernier, indicePivot, fonctionLambda); });
        }

        [Fact]
        public void PartionnerLambda_PreconditionIndicePremierHorsLimiteSuperieur_LanceException()
        {
            // Arrange
            int[] tableau = new int[] { 1, 2, 3, 4, 5 };
            int indicePremier = 5;
            int indiceDernier = 4;
            int indicePivot = 0;
            Func<int, int, bool> fonctionLambda = (x, y) => x > y;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { Program.PartionnerLambda(tableau, indicePremier, indiceDernier, indicePivot, fonctionLambda); });
        }

        [Fact]
        public void PartionnerLambda_PreconditionIndiceDernierHorsLimiteInferieur_LanceException()
        {
            // Arrange
            int[] tableau = new int[] { 1, 2, 3, 4, 5 };
            int indicePremier = 0;
            int indiceDernier = -1;
            int indicePivot = 0;
            Func<int, int, bool> fonctionLambda = (x, y) => x > y;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { Program.PartionnerLambda(tableau, indicePremier, indiceDernier, indicePivot, fonctionLambda); });
        }

        [Fact]
        public void PartionnerLambda_PreconditionIndiceDernierHorsLimiteSuperieur_LanceException()
        {
            // Arrange
            int[] tableau = new int[] { 1, 2, 3, 4, 5 };
            int indicePremier = 0;
            int indiceDernier = 6;
            int indicePivot = 0;
            Func<int, int, bool> fonctionLambda = (x, y) => x > y;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { Program.PartionnerLambda(tableau, indicePremier, indiceDernier, indicePivot, fonctionLambda); });
        }

        [Fact]
        public void PartionnerLambda_PreconditionIndicePivotHorsLimiteInferieur_LanceException()
        {
            // Arrange
            int[] tableau = new int[] { 1, 2, 3, 4, 5 };
            int indicePremier = -1;
            int indiceDernier = 4;
            int indicePivot = -1;
            Func<int, int, bool> fonctionLambda = (x, y) => x > y;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { Program.PartionnerLambda(tableau, indicePremier, indiceDernier, indicePivot, fonctionLambda); });
        }

        [Fact]
        public void PartionnerLambda_PreconditionIndicePivotHorsLimiteSuperieur_LanceException()
        {
            // Arrange
            int[] tableau = new int[] { 1, 2, 3, 4, 5 };
            int indicePremier = 5;
            int indiceDernier = 4;
            int indicePivot = 6;
            Func<int, int, bool> fonctionLambda = (x, y) => x > y;

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { Program.PartionnerLambda(tableau, indicePremier, indiceDernier, indicePivot, fonctionLambda); });
        }

        [Fact]
        public void PartionnerLambda_PreconditionIndicePremierPlusGrandIndiceDernier_LanceException()
        {
            // Arrange
            int[] tableau = new int[] { 1, 2, 3, 4, 5 };
            int indicePremier = 2;
            int indiceDernier = 1;
            int indicePivot = 0;
            Func<int, int, bool> fonctionLambda = (x, y) => x > y;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => { Program.PartionnerLambda(tableau, indicePremier, indiceDernier, indicePivot, fonctionLambda); });
        }

        [Fact]
        public void PartionnerLambda_PreconditionFonctionLambdaNull_LanceException()
        {
            // Arrange
            int[] tableau = new int[] { 1, 2, 3, 4, 5 };
            int indicePremier = 2;
            int indiceDernier = 1;
            int indicePivot = 0;
            Func<int, int, bool> fonctionLambda = null;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => { Program.PartionnerLambda(tableau, indicePremier, indiceDernier, indicePivot, fonctionLambda); });
        }


        // *** EXERCICE 4 *** //
        // RechercherValeur

        [Fact]
        public void RechercherValeurLambda_PreconditionTableauNull_LanceException()
        {
            // Arrange
            int[] tableauNull = null;
            int chiffreAChercher = 2;
            Func<int, int, bool> fonctionLambda = (x, y) => x == y;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { Program.RechercherValeurLambda(tableauNull, chiffreAChercher, fonctionLambda); });
        }

        [Fact]
        public void RechercherValeurLambda_PreconditionFonctionLambdaNull_LanceException()
        {
            // Arrange
            int[] tableauNull = { 2, 1, 3, 4, 5 };
            int chiffreAChercher = 2;
            Func<int, int, bool> fonctionLambda = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { Program.RechercherValeurLambda(tableauNull, chiffreAChercher, fonctionLambda); });
        }

        [Fact]
        public void RechercherValeurLambda_ValeurExistante_AssertTrue()
        {
            // Arrange
            int chiffreAChercher = 2;
            int[] tableauRecherche = new int[] { 2, 1, 3, 4, 5 };
            Func<int, int, bool> fonctionLambda = (x, y) => x == y;

            // Act
            bool valeurObtenu = Program.RechercherValeurLambda(tableauRecherche, chiffreAChercher, fonctionLambda);

            // Assert
            Assert.True(valeurObtenu);
        }

        [Fact]
        public void RechercherValeurLambda_ValeurNonExistante_AssertFalse()
        {
            // Arrange
            int chiffreAChercher = 10;
            int[] tableauRecherche = new int[] { 2, 1, 3, 4, 5 };
            Func<int, int, bool> fonctionLambda = (x, y) => x == y;

            // Act
            bool valeurObtenu = Program.RechercherValeurLambda(tableauRecherche, chiffreAChercher, fonctionLambda);

            // Assert
            Assert.False(valeurObtenu);
        }

        [Fact]
        public void RechercherValeurLambda_ValeurExistanteDebutTableau_AssertTrue()
        {
            // Arrange
            int chiffreAChercher = 2;
            int[] tableauRecherche = new int[] { 2, 1, 3, 4, 5 };
            Func<int, int, bool> fonctionLambda = (x, y) => x == y;

            // Act
            bool valeurObtenu = Program.RechercherValeurLambda(tableauRecherche, chiffreAChercher, fonctionLambda);

            // Assert
            Assert.True(valeurObtenu);
        }

        [Fact]
        public void RechercherValeurLambda_ValeurExistanteFinTableau_AssertTrue()
        {
            // Arrange
            int chiffreAChercher = 2;
            int[] tableauRecherche = new int[] { 0, 1, 3, 4, 2 };
            Func<int, int, bool> fonctionLambda = (x, y) => x == y;

            // Act
            bool valeurObtenu = Program.RechercherValeurLambda(tableauRecherche, chiffreAChercher, fonctionLambda);

            // Assert
            Assert.True(valeurObtenu);
        }


        // RechercherValeurDichotomie
        [Fact]
        public void RechercherValeurDichotomieLambda_PreconditionTableauNull_LanceException()
        {
            // Arrange
            int[] tableauNull = null;
            int chiffreAChercher = 2;
            Func<int, int, bool> fonctionLambdaComparaison = (x, y) => x <= y;
            Func<int, int, bool> fonctionLambdaValidationEgalite = (x, y) => x == y;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { Program.RechercherValeurDichotomieLambda(tableauNull, chiffreAChercher, fonctionLambdaValidationEgalite, fonctionLambdaComparaison); });
        }

        [Fact]
        public void RechercherValeurDichotomieLambda_PreconditionLambdaValidationEgaliteNull_LanceException()
        {
            // Arrange
            int[] tableauNull = null;
            int chiffreAChercher = 2;
            Func<int, int, bool> fonctionLambdaComparaison = (x, y) => x <= y;
            Func<int, int, bool> fonctionLambdaValidationEgalite = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { Program.RechercherValeurDichotomieLambda(tableauNull, chiffreAChercher, fonctionLambdaValidationEgalite, fonctionLambdaComparaison); });
        }

        [Fact]
        public void RechercherValeurDichotomieLambda_PreconditionLambdaComparaisonNull_LanceException()
        {
            // Arrange
            int[] tableauNull = null;
            int chiffreAChercher = 2;
            Func<int, int, bool> fonctionLambdaComparaison = null;
            Func<int, int, bool> fonctionLambdaValidationEgalite = (x, y) => x == y;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { Program.RechercherValeurDichotomieLambda(tableauNull, chiffreAChercher, fonctionLambdaValidationEgalite, fonctionLambdaComparaison); });
        }

        [Fact]
        public void RechercherValeurDichotomieLambda_ValeurExistante_AssertTrue()
        {
            // Arrange
            int chiffreAChercher = 2;
            int[] tableauRecherche = new int[] { 2, 1, 3, 4, 5 };
            Func<int, int, bool> fonctionLambdaComparaison = (x, y) => x <= y;
            Func<int, int, bool> fonctionLambdaValidationEgalite = (x, y) => x == y;

            // Act
            bool valeurObtenu = Program.RechercherValeurDichotomieLambda(tableauRecherche, chiffreAChercher, fonctionLambdaValidationEgalite, fonctionLambdaComparaison);

            // Assert
            Assert.True(valeurObtenu);
        }

        [Fact]
        public void RechercherValeurDichotomieLambda_ValeurNonExistante_AssertFalse()
        {
            // Arrange
            int chiffreAChercher = 10;
            int[] tableauRecherche = new int[] { 2, 1, 3, 4, 5 };
            Func<int, int, bool> fonctionLambdaComparaison = (x, y) => x <= y;
            Func<int, int, bool> fonctionLambdaValidationEgalite = (x, y) => x == y;

            // Act
            bool valeurObtenu = Program.RechercherValeurDichotomieLambda(tableauRecherche, chiffreAChercher, fonctionLambdaValidationEgalite, fonctionLambdaComparaison);

            // Assert
            Assert.False(valeurObtenu);
        }

        [Fact]
        public void RechercherValeurDichotomieLambda_ValeurExistanteDebutTableau_AssertTrue()
        {
            // Arrange
            int chiffreAChercher = 2;
            int[] tableauRecherche = new int[] { 2, 1, 3, 4, 5 };
            Func<int, int, bool> fonctionLambdaComparaison = (x, y) => x <= y;
            Func<int, int, bool> fonctionLambdaValidationEgalite = (x, y) => x == y;

            // Act
            bool valeurObtenu = Program.RechercherValeurDichotomieLambda(tableauRecherche, chiffreAChercher, fonctionLambdaValidationEgalite, fonctionLambdaComparaison);

            // Assert
            Assert.True(valeurObtenu);
        }

        // ** EXERCICE 5 *** //

        // Where
        [Fact]
        public void Where_PreconditionTableauNull_LanceException()
        {
            // Arrange
            int[] tableauNull = null;
            Func<int, bool> Lambda = x => x > 5;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { Program.Where(tableauNull, Lambda); });
        }
        [Fact]
        public void Where_PreconditionLambdaNull_LanceException()
        {
            // Arrange
            int[] tableauNull = new int[] { 1, 2, 3, 4, 5, 6 };
            Func<int, bool> Lambda = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { Program.Where(tableauNull, Lambda); });
        }
        [Fact]
        public void Where_FiltreLesBonschiffres_AssertEqual()
        {
            // Arrange
            int[] tableauAFiltrer = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Func<int, bool> filtre = x => x > 5;
            List<int> listeAttendue = new List<int>() { 6, 7, 8, 9 };

            // ACt
            List<int> listeObtenue = Program.Where(tableauAFiltrer, filtre);

            // Assert
            Assert.Equal(listeAttendue, listeObtenue);
        }

        // Select
        [Fact]
        public void Select_PreconditionTableauNull_LanceException()
        {
            // Arrange
            int[] tableauNull = null;
            Func<int, bool> Lambda = x => x > 5;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { Program.Where(tableauNull, Lambda); });
        }
        [Fact]
        public void Select_PreconditionLambdaNull_LanceException()
        {
            // Arrange
            int[] tableauNull = new int[] { 1, 2, 3, 4, 5, 6 };
            Func<int, bool> Lambda = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { Program.Where(tableauNull, Lambda); });
        }
        [Fact]
        public void Select_AppliqueBonneTransformation_AssertEqual()
        {
            // Arrange
            int[] tableauAFiltrer = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Func<int, int> select = x => x + 10;
            List<int> listeAttendue = new List<int>() { 11, 12, 13, 14, 15, 16, 17, 18, 19 };

            // ACt
            List<int> listeObtenue = Program.Select(tableauAFiltrer, select);

            // Assert
            Assert.Equal(listeAttendue, listeObtenue);
        }

        // *** EXERCICE 6 *** //
        [Fact]
        public void Histogramme_PreconditionNull_LanceException()
        {
            // Arrange
            List<int> listeNull = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { Program.Histogramme(listeNull); });
        }


        // *** EXERCICE 7 *** //
        [Fact]
        public void TemoinCrime_PreconditionNull_LanceException()
        {
            // Arrange
            List<int> listeNull = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { Program.Histogramme(listeNull); });
        }

        [Fact]
        public void TemoinCrime_UnSeulTemoinVoitLeCrime_AssertEqual()
        {
            // Arrange
            List<int> listeTemoin = new List<int>() { 2, 2, 2, 3 };
            List<int> listeTemoinAttendue = new List<int> { 3 };

            // Act
            List<int> listeTemoinObtenu = Program.TemoinCrime(listeTemoin);

            // Assert
            Assert.Equal(listeTemoinAttendue, listeTemoinObtenu);
        }

        [Fact]
        public void TemoinCrime_DeuxTemoinsMemeGrandeurColle_AssertEqual()
        {
            // Arrange
            List<int> listeTemoin = new List<int>() { 2, 2, 3, 3 };
            List<int> listeTemoinAttendue = new List<int> { 3 };

            // Act
            List<int> listeTemoinObtenu = Program.TemoinCrime(listeTemoin);

            // Assert
            Assert.Equal(listeTemoinAttendue, listeTemoinObtenu);
        }

        [Fact]
        public void TemoinCrime_DeuxTemoinsMemeGrandeurNonColle_AssertEqual()
        {
            // Arrange
            List<int> listeTemoin = new List<int>() { 3, 2, 1, 3 };
            List<int> listeTemoinAttendue = new List<int> { 3 };

            // Act
            List<int> listeTemoinObtenu = Program.TemoinCrime(listeTemoin);

            // Assert
            Assert.Equal(listeTemoinAttendue, listeTemoinObtenu);
        }

        [Fact]
        public void TemoinCrime_TousLesTemoinsVoientLeCrime_AssertEqual()
        {
            // Arrange
            List<int> listeTemoin = new List<int>() { 4, 3, 2, 1 };
            List<int> listeTemoinAttendue = new List<int> { 4, 3, 2, 1 };

            // Act
            List<int> listeTemoinObtenu = Program.TemoinCrime(listeTemoin);

            // Assert
            Assert.Equal(listeTemoinAttendue, listeTemoinObtenu);
        }


        // *** EXERCICE 8 *** //
        [Fact]
        public void PremiereLettreRecurrente_PreconditionNull_LanceException()
        {
            // Arrange
            string chaineNull = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { Program.PremiereLettreRecurrente(chaineNull); });
        }
        
        [Fact]
        public void PremiereLettreRecurrente_PremiereLettreReccurenteAuDebut_AssertEqual()
        {
            // Arrange
            string ChaineAEvaluer = "ssalut";
            char caractereAttendu = 's';

            // Act
            char? caractereObtenu = Program.PremiereLettreRecurrente(ChaineAEvaluer);

            // Assert
            Assert.Equal(caractereObtenu, caractereAttendu);
        }

        [Fact]
        public void PremiereLettreRecurrente_PremiereLettreReccurenteAuMilieu_AssertEqual()
        {
            // Arrange
            string ChaineAEvaluer = "sallut";
            char caractereAttendu = 'l';

            // Act
            char? caractereObtenu = Program.PremiereLettreRecurrente(ChaineAEvaluer);

            // Assert
            Assert.Equal(caractereObtenu, caractereAttendu);
        }

        [Fact]
        public void PremiereLettreRecurrente_PremiereLettreReccurenteALaFin_AssertEqual()
        {
            // Arrange
            string ChaineAEvaluer = "salutt";
            char caractereAttendu = 't';

            // Act
            char? caractereObtenu = Program.PremiereLettreRecurrente(ChaineAEvaluer);

            // Assert
            Assert.Equal(caractereObtenu, caractereAttendu);
        }

        [Fact]
        public void PremiereLettreRecurrente_AucuneLettreRecurrente_AssertEqual()
        {
            // Arrange
            string ChaineAEvaluer = "salut";

            // Act
            char? caractereObtenu = Program.PremiereLettreRecurrente(ChaineAEvaluer);

            // Assert
            Assert.Null(caractereObtenu);
        }


        // *** EXERCICE 9 *** //
        [Fact]
        public void SommeNombre_PreconditionListeANull_LanceException()
        {
            // Arrange
            List<int> listeNull = null;
            List<int> listeNonNull = new List<int>() { 1, 2, 3, 4 };
            int valeurCible = 20;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { Program.SommeNombre(listeNull, listeNonNull, valeurCible); });
        }

        [Fact]
        public void SommeNombre_PreconditionListeBNull_LanceException()
        {
            // Arrange
            List<int> listeNull = null;
            List<int> listeNonNull = new List<int>() { 1, 2, 3, 4 };
            int valeurCible = 20;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { Program.SommeNombre(listeNonNull, listeNull, valeurCible); });
        }

        [Fact]
        public void SommeNombre_UneBonneReponse_AssertEqual()
        {
            // Arrange
            List<int> listeA = new List<int>() { 1, 2, 3, 4 };
            List<int> listeB = new List<int>() { 1, 1, 5, 2 };
            int valeurCible = 8;

            List < (int, int)> valeurAttendue = new List<(int, int)>() { (3, 5) };

            // Act
            List<(int, int)> valeurObtenu = Program.SommeNombre(listeA, listeB, valeurCible);

            // Assert
            Assert.Equal(valeurAttendue, valeurObtenu);
        }

        [Fact]
        public void SommeNombre_PlusieursBonnesReponses_AssertEqual()
        {
            // Arrange
            List<int> listeA = new List<int>() { 1, 2, 3, 4 };
            List<int> listeB = new List<int>() { 1, 4, 5, 2 };
            int valeurCible = 8;

            List<(int, int)> valeurAttendue = new List<(int, int)>() { (3, 5), (4, 4) };

            // Act
            List<(int, int)> valeurObtenu = Program.SommeNombre(listeA, listeB, valeurCible);

            // Assert
            Assert.Equal(valeurAttendue, valeurObtenu);
        }

        [Fact]
        public void SommeNombre_CombinaisonsEnDouble_AssertEqual()
        {
            // Arrange
            List<int> listeA = new List<int>() { 1, 2, 3, 4 };
            List<int> listeB = new List<int>() { 1, 4, 5, 1 };
            int valeurCible = 8;

            List<(int, int)> valeurAttendue = new List<(int, int)>() { (3, 5), (4, 4) };

            // Act
            List<(int, int)> valeurObtenu = Program.SommeNombre(listeA, listeB, valeurCible);

            // Assert
            Assert.Equal(valeurAttendue, valeurObtenu);
        }

        [Fact]
        public void SommeNombre_ValeurCibleHorsLimite_AssertEqual()
        {
            // Arrange
            List<int> listeA = new List<int>() { 1, 2, 3, 4 };
            List<int> listeB = new List<int>() { 1, 4, 5, 1 };
            int valeurCible = 30;

            List<(int, int)> valeurAttendue = new List<(int, int)>() { (4, 5) };

            // Act
            List<(int, int)> valeurObtenu = Program.SommeNombre(listeA, listeB, valeurCible);

            // Assert
            Assert.Equal(valeurAttendue, valeurObtenu);
        }


    }
}
