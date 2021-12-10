using System;
using Xunit;
using Dictionnaire_LibrairieClasses;
using System.Collections.Generic;
using System.Linq;


namespace Dictionnaire_TestsUnitaires
{
    public class UnitTest1
    {
        #region Constructeur

        // Constructeurs
        [Fact]
        public void Ctor1_CreerUnDictionnaire_CountAZero()
        {
            // Arrange
            Dictionnaire<int, string> dictionnaire;

            int countAttendu = 0;
            // Act
            dictionnaire = new Dictionnaire<int, string>();

            // Assert
            Assert.Equal(countAttendu, dictionnaire.Count);
        }
        [Fact]
        public void Ctor2_PreconditionCollectionVide_LanceException()
        {
            // Arrange
            List<CoupleClefValeur<int, int>> couplesClefValeurNull = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { Dictionnaire<int, int> dictionnaire = new Dictionnaire<int, int>(couplesClefValeurNull); });
        }
        [Fact]
        public void Ctor2_RecoitCollectionValeur_créerDictionnaireBonneValeur()
        {
            // Arrange
            CoupleClefValeur<int, string> couple1 = new CoupleClefValeur<int, string>(1, "aaa");
            CoupleClefValeur<int, string> couple2 = new CoupleClefValeur<int, string>(2, "bbb");
            CoupleClefValeur<int, string> couple3 = new CoupleClefValeur<int, string>(3, "ccc");
            CoupleClefValeur<int, string> couple4 = new CoupleClefValeur<int, string>(4, "ddd");
            List<CoupleClefValeur<int, string>> couplesClefValeur = new List<CoupleClefValeur<int, string>>() { couple1, couple2, couple3, couple4 };

            int countAttendu = 4;

            // Act
            Dictionnaire<int, string> nouveauDictionnaire = new Dictionnaire<int, string>(couplesClefValeur);
            ICollection<int> clefsObtenues = nouveauDictionnaire.Keys;
            ICollection<string> valeursObtenues = nouveauDictionnaire.Values;
            // Assert
            Assert.True(clefsObtenues.Contains(1));
            Assert.True(clefsObtenues.Contains(2));
            Assert.True(clefsObtenues.Contains(3));
            Assert.True(clefsObtenues.Contains(4));
            Assert.True(valeursObtenues.Contains("aaa"));
            Assert.True(valeursObtenues.Contains("bbb"));
            Assert.True(valeursObtenues.Contains("ccc"));
            Assert.True(valeursObtenues.Contains("ddd"));
            Assert.Equal(countAttendu, nouveauDictionnaire.Count);

        }
        #endregion

        #region Propriete
        // Propriétés Keys Values
        [Fact]
        public void Keys_ObtenirClefsDictionnaire_RetourneListeClefsComplete()
        {
            // Arrange
            CoupleClefValeur<int, string> couple1 = new CoupleClefValeur<int, string>(1, "aaa");
            CoupleClefValeur<int, string> couple2 = new CoupleClefValeur<int, string>(2, "bbb");
            CoupleClefValeur<int, string> couple3 = new CoupleClefValeur<int, string>(3, "ccc");
            CoupleClefValeur<int, string> couple4 = new CoupleClefValeur<int, string>(4, "ddd");
            List<CoupleClefValeur<int, string>> couplesClefValeur = new List<CoupleClefValeur<int, string>>() { couple1, couple2, couple3, couple4 };
            Dictionnaire<int, string> nouveauDictionnaire = new Dictionnaire<int, string>(couplesClefValeur);

            int countAttendu = 4;

            // Act
            ICollection<int> clefObtenue = nouveauDictionnaire.Keys;

            // Assert
            Assert.True(clefObtenue.Contains(1));
            Assert.True(clefObtenue.Contains(2));
            Assert.True(clefObtenue.Contains(3));
            Assert.True(clefObtenue.Contains(4));
            Assert.Equal(countAttendu, clefObtenue.Count);
        }
        [Fact]
        public void Keys_ObtenirClefsDictionnaireVide_RetourneListeVide()
        {
            // Arrange
            List<CoupleClefValeur<int, string>> couplesClefValeur = new List<CoupleClefValeur<int, string>>();
            Dictionnaire<int, string> nouveauDictionnaire = new Dictionnaire<int, string>(couplesClefValeur);

            int countAttendu = 0;

            // Act
            ICollection<int> clefObtenue = nouveauDictionnaire.Keys;

            // Assert
            Assert.Equal(countAttendu, clefObtenue.Count);
        }
        [Fact]
        public void Values_ObtenirClefsDictionnaire_RetourneListeClefsComplete()
        {
            // Arrange
            CoupleClefValeur<int, string> couple1 = new CoupleClefValeur<int, string>(1, "aaa");
            CoupleClefValeur<int, string> couple2 = new CoupleClefValeur<int, string>(2, "bbb");
            CoupleClefValeur<int, string> couple3 = new CoupleClefValeur<int, string>(3, "ccc");
            CoupleClefValeur<int, string> couple4 = new CoupleClefValeur<int, string>(4, "ddd");
            List<CoupleClefValeur<int, string>> couplesClefValeur = new List<CoupleClefValeur<int, string>>() { couple1, couple2, couple3, couple4 };
            Dictionnaire<int, string> nouveauDictionnaire = new Dictionnaire<int, string>(couplesClefValeur);

            int countAttendu = 4;

            // Act
            ICollection<string> valeursObtenues = nouveauDictionnaire.Values;

            // Assert
            Assert.True(valeursObtenues.Contains("aaa"));
            Assert.True(valeursObtenues.Contains("bbb"));
            Assert.True(valeursObtenues.Contains("ccc"));
            Assert.True(valeursObtenues.Contains("ddd"));
            Assert.Equal(countAttendu, valeursObtenues.Count);
        }
        [Fact]
        public void Values_ObtenirClefsDictionnaireVide_RetourneListeVide()
        {
            // Arrange
            List<CoupleClefValeur<int, string>> couplesClefValeur = new List<CoupleClefValeur<int, string>>();
            Dictionnaire<int, string> nouveauDictionnaire = new Dictionnaire<int, string>(couplesClefValeur);

            int countAttendu = 0;

            // Act
            ICollection<string> clefObtenue = nouveauDictionnaire.Values;

            // Assert
            Assert.Equal(countAttendu, clefObtenue.Count);
        }

        // OpérateurCrochet
        [Fact]
        public void OperateurCrochetGet_PreconditionClefNonExistante_LanceException()
        {
            // Arrange
            Dictionnaire<int, string> dictionnaire = new Dictionnaire<int, string>();
            dictionnaire.Add(1, "aaa");
            dictionnaire.Add(2, "bbb");
            dictionnaire.Add(3, "ccc");

            // Act and Assert
            Assert.Throws<ClefNonTrouveeException>(() => { string valeur = dictionnaire[4]; });
        }
        [Fact]
        public void OperateurCrochetGet_GetterSurClefExistante_RetourneBonneValeur()
        {
            // Arrange
            Dictionnaire<int, string> dictionnaire = new Dictionnaire<int, string>();
            dictionnaire.Add(1, "aaa");
            dictionnaire.Add(2, "bbb");
            dictionnaire.Add(3, "ccc");

            string valeurAttendue = "aaa";

            // Act
            string valeurObtenue = dictionnaire[1];

            // Assert
            Assert.Equal(valeurAttendue, valeurObtenue);
        }
        [Fact]
        public void OperateurCrochetSet_PreconditionClefDejaPresente_LanceException()
        {
            // Arrange
            Dictionnaire<int, string> dictionnaire = new Dictionnaire<int, string>();
            dictionnaire.Add(1, "aaa");
            dictionnaire.Add(2, "bbb");
            dictionnaire.Add(3, "ccc");

            // Act and Assert
            Assert.Throws<ClefDejaPresenteException>(() => { dictionnaire[1] = "ddd"; });
        }
        [Fact]
        public void OperateurCrochetSet_GetterSurClefExistante_RetourneBonneValeur()
        {
            // Arrange
            Dictionnaire<int, string> dictionnaire = new Dictionnaire<int, string>();
            dictionnaire.Add(1, "aaa");
            dictionnaire.Add(2, "bbb");
            dictionnaire.Add(3, "ccc");

            string valeurAttendue = "ddd";

            // Act
            dictionnaire[30] = "ddd";

            // Assert
            Assert.Equal(valeurAttendue, dictionnaire[30]);
        }
        #endregion

        #region methodes
        // Add
        [Fact]
        public void Add1_AjouterUnElement_AugmenteCountDeUn()
        {
            // Arrange
            Dictionnaire<int, string> dictionnaireVide = new Dictionnaire<int, string>();
            int countAttendu = 1;

            // Act
            dictionnaireVide.Add(1, "aaa");

            // Assert
            Assert.Equal(countAttendu, dictionnaireVide.Count);
        }
        [Fact]
        public void Add1_AjouterUnElement_AjouteCoupleCorrectement()
        {
            // Arrange
            Dictionnaire<int, string> dictionnaireUnElement = new Dictionnaire<int, string>();
            int clefAttendue = 1;
            string valeurAttendue = "aaa";

            // Act
            dictionnaireUnElement.Add(1, "aaa");
            ICollection<int> clefsObtenues = dictionnaireUnElement.Keys;
            ICollection<string> valeursObtenues = dictionnaireUnElement.Values;

            // Assert
            Assert.True(clefsObtenues.Contains(clefAttendue));
            Assert.True(valeursObtenues.Contains(valeurAttendue));
        }
        [Fact]
        public void Add2_AjouterUnElement_AugmenteCountDeUn()
        {
            // Arrange
            Dictionnaire<int, string> dictionnaireVide = new Dictionnaire<int, string>();
            int countAttendu = 1;

            // Act
            dictionnaireVide.Add(new KeyValuePair<int, string>(1, "aaa"));

            // Assert
            Assert.Equal(countAttendu, dictionnaireVide.Count);
        }
        [Fact]
        public void Add2_AjouterUnElement_AjouteCoupleCorrectement()
        {
            // Arrange
            Dictionnaire<int, string> dictionnaireUnElement = new Dictionnaire<int, string>();
            int clefAttendue = 1;
            string valeurAttendue = "aaa";

            // Act
            dictionnaireUnElement.Add(new KeyValuePair<int, string>(1, "aaa"));
            ICollection<int> clefsObtenues = dictionnaireUnElement.Keys;
            ICollection<string> valeursObtenues = dictionnaireUnElement.Values;

            // Assert
            Assert.True(clefsObtenues.Contains(clefAttendue));
            Assert.True(valeursObtenues.Contains(valeurAttendue));
        }

        // Clear
        [Fact]
        public void Clear_NettoyerDictionnaireAvecElement_CountAZero()
        {
            // Arrange
            Dictionnaire<int, string> dictionnaireAvecElements = new Dictionnaire<int, string>();
            dictionnaireAvecElements.Add(1, "aaa");
            dictionnaireAvecElements.Add(2, "bbb");
            dictionnaireAvecElements.Add(3, "ccc");

            int countAttendu = 0;

            // Act
            dictionnaireAvecElements.Clear();

            // Assert
            Assert.Equal(countAttendu, dictionnaireAvecElements.Count);
        }

        // Contains
        [Fact]
        public void Contains_DictionnaireContientClefValeur_RetourneTrue()
        {
            // Arrange
            Dictionnaire<int, string> dictionnaireAvecElements = new Dictionnaire<int, string>();
            dictionnaireAvecElements.Add(1, "aaa");
            dictionnaireAvecElements.Add(2, "bbb");
            dictionnaireAvecElements.Add(3, "ccc");

            KeyValuePair<int, string> valeurAChercher = new KeyValuePair<int, string>(1, "aaa");

            // Act
            bool valeurObtenue = dictionnaireAvecElements.Contains(valeurAChercher);

            // Assert
            Assert.True(valeurObtenue);
        }
        [Fact]
        public void Contains_DictionnaireContientClefPasValeur_RetourneTrue()
        {
            // Arrange
            Dictionnaire<int, string> dictionnaireAvecElements = new Dictionnaire<int, string>();
            dictionnaireAvecElements.Add(1, "aaa");
            dictionnaireAvecElements.Add(2, "bbb");
            dictionnaireAvecElements.Add(3, "ccc");

            KeyValuePair<int, string> valeurAChercher = new KeyValuePair<int, string>(1, "zzz");

            // Act
            bool valeurObtenue = dictionnaireAvecElements.Contains(valeurAChercher);

            // Assert
            Assert.False(valeurObtenue);
        }
        [Fact]
        public void Contains_DictionnaireContientPasClefContientValeur_RetourneTrue()
        {
            // Arrange
            Dictionnaire<int, string> dictionnaireAvecElements = new Dictionnaire<int, string>();
            dictionnaireAvecElements.Add(1, "aaa");
            dictionnaireAvecElements.Add(2, "bbb");
            dictionnaireAvecElements.Add(3, "ccc");

            KeyValuePair<int, string> valeurAChercher = new KeyValuePair<int, string>(23, "aaa");

            // Act
            bool valeurObtenue = dictionnaireAvecElements.Contains(valeurAChercher);

            // Assert
            Assert.False(valeurObtenue);
        }

        // ContainsKey
        [Fact]
        public void ContainsKey_DictionnaireContientLaClef_RetourneTrue()
        {
            // Arrange
            Dictionnaire<int, string> dictionnaire = new Dictionnaire<int, string>();
            dictionnaire.Add(1, "aaa");
            dictionnaire.Add(2, "bbb");
            dictionnaire.Add(3, "ccc");

            int clefExistante = 1;
            // Act
            bool valeurObtenue = dictionnaire.ContainsKey(clefExistante);

            // Assert
            Assert.True(valeurObtenue);

        }
        [Fact]
        public void ContainsKey_DictionnaireNeContientPasClef_RetourneFalse()
        {
            // Arrange
            Dictionnaire<int, string> dictionnaire = new Dictionnaire<int, string>();
            dictionnaire.Add(1, "aaa");
            dictionnaire.Add(2, "bbb");
            dictionnaire.Add(3, "ccc");

            int clefNonExistante = 5;

            // Act
            bool valeurObtenue = dictionnaire.ContainsKey(clefNonExistante);

            // Assert
            Assert.False(valeurObtenue);

        }

        // CopyTo
        [Fact]
        public void CopyTo_Precondition1OutOfRangeIndexNegatif_LanceException()
        {
            // Arrange
            KeyValuePair<int, string> couple1 = new KeyValuePair<int, string>(1, "aaa");
            KeyValuePair<int, string> couple2 = new KeyValuePair<int, string>(2, "bbb");
            KeyValuePair<int, string> couple3 = new KeyValuePair<int, string>(3, "www");
            KeyValuePair<int, string> couple4 = new KeyValuePair<int, string>(4, "qqq");
            KeyValuePair<int, string>[] tableau = new KeyValuePair<int, string>[] { couple1, couple2, couple3, couple4 };

            Dictionnaire<int, string> dictionnaire = new Dictionnaire<int, string>();
            dictionnaire.Add(10, "ttt");
            dictionnaire.Add(5, "nnn");

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { dictionnaire.CopyTo(tableau, -1); });
        }
        [Fact]
        public void CopyTo_Precondition1OutOfRangeIndexPlusGrandEgaleCapaciteTableauDestination_LanceException()
        {
            // Arrange
            KeyValuePair<int, string> couple1 = new KeyValuePair<int, string>(1, "aaa");
            KeyValuePair<int, string> couple2 = new KeyValuePair<int, string>(2, "bbb");
            KeyValuePair<int, string> couple3 = new KeyValuePair<int, string>(3, "www");
            KeyValuePair<int, string> couple4 = new KeyValuePair<int, string>(4, "qqq");
            KeyValuePair<int, string>[] tableau = new KeyValuePair<int, string>[] { couple1, couple2, couple3, couple4 };

            Dictionnaire<int, string> dictionnaire = new Dictionnaire<int, string>();
            dictionnaire.Add(10, "ttt");
            dictionnaire.Add(5, "nnn");

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { dictionnaire.CopyTo(tableau, 4); });
        }
        [Fact]
        public void CopyTo_Precondition2CountPlusIndexDepartDepasseCapaciteTableauDestination_LanceException()
        {
            // Arrange
            KeyValuePair<int, string> couple1 = new KeyValuePair<int, string>(1, "aaa");
            KeyValuePair<int, string> couple2 = new KeyValuePair<int, string>(2, "bbb");
            KeyValuePair<int, string> couple3 = new KeyValuePair<int, string>(3, "www");
            KeyValuePair<int, string> couple4 = new KeyValuePair<int, string>(4, "qqq");
            KeyValuePair<int, string>[] tableau = new KeyValuePair<int, string>[] { couple1, couple2, couple3, couple4 };

            Dictionnaire<int, string> dictionnaire = new Dictionnaire<int, string>();
            dictionnaire.Add(10, "ttt");
            dictionnaire.Add(5, "nnn");

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => { dictionnaire.CopyTo(tableau, 3); });
        }
        [Fact]
        public void CopyTo_CopierDictionnaireDansTableauCorrectement_CouplesCopiesBonIndex()
        {
            // Arrange
            KeyValuePair<int, string> couple1 = new KeyValuePair<int, string>(1, "aaa");
            KeyValuePair<int, string> couple2 = new KeyValuePair<int, string>(2, "bbb");
            KeyValuePair<int, string> couple3 = new KeyValuePair<int, string>(3, "www");
            KeyValuePair<int, string> couple4 = new KeyValuePair<int, string>(4, "qqq");
            KeyValuePair<int, string>[] tableau = new KeyValuePair<int, string>[] { couple1, couple2, couple3, couple4 };

            Dictionnaire<int, string> dictionnaire = new Dictionnaire<int, string>();
            dictionnaire.Add(10, "ttt");
            dictionnaire.Add(5, "nnn");

            string valeur1 = "ttt";
            string valeur2 = "nnn";

            // Act
            dictionnaire.CopyTo(tableau, 2);

            // Assert
            Assert.True(Array.Exists(tableau, y => y.Value.GetHashCode() == valeur1.GetHashCode()));
            Assert.True(Array.Exists(tableau, y => y.Value.GetHashCode() == valeur2.GetHashCode()));
        }

        // Remove
        [Fact]
        public void Remove1_SupprimerClefExistante_RetourneTrue()
        {
            // Arrange
            Dictionnaire<int, string> dictionnaire = new Dictionnaire<int, string>();
            dictionnaire.Add(10, "ttt");
            dictionnaire.Add(5, "nnn");
            dictionnaire.Add(7, "ooo");
            int clefExistante = 10;
            int CountAttendu = 2;

            // Act
            bool valeurObtenue = dictionnaire.Remove(clefExistante);
            var clefRestante = dictionnaire.Keys;

            // Assert
            Assert.True(valeurObtenue);
            Assert.Equal(CountAttendu, dictionnaire.Count);
            Assert.False(clefRestante.Contains(10));
        }
        [Fact]
        public void Remove1_SupprimerClefNonExistante_RetourneFalse()
        {
            // Arrange
            Dictionnaire<int, string> dictionnaire = new Dictionnaire<int, string>();
            dictionnaire.Add(10, "ttt");
            dictionnaire.Add(5, "nnn");
            dictionnaire.Add(7, "ooo");
            int clefNonExistante = 21;
            int CountAttendu = 3;

            // Act
            bool valeurObtenue = dictionnaire.Remove(clefNonExistante);
            var clefRestante = dictionnaire.Keys;

            // Assert
            Assert.False(valeurObtenue);
            Assert.Equal(CountAttendu, dictionnaire.Count);
            Assert.True(clefRestante.Contains(10));
            Assert.True(clefRestante.Contains(5));
            Assert.True(clefRestante.Contains(7));
        }

        // Remove
        [Fact]
        public void Remove2_SupprimerCoupleClefValeurExistant_RetourneTrue()
        {
            // Arrange
            Dictionnaire<int, string> dictionnaire = new Dictionnaire<int, string>();
            dictionnaire.Add(10, "ttt");
            dictionnaire.Add(5, "nnn");
            dictionnaire.Add(7, "ooo");
            KeyValuePair<int, string> coupleClefValeurExistant = new KeyValuePair<int, string>(10, "ttt");
            int CountAttendu = 2;

            // Act
            bool valeurObtenue = dictionnaire.Remove(coupleClefValeurExistant);
            var clefRestante = dictionnaire.Keys;

            // Assert
            Assert.True(valeurObtenue);
            Assert.Equal(CountAttendu, dictionnaire.Count);
            Assert.False(clefRestante.Contains(10));
        }
        [Fact]
        public void Remove2_SupprimerCoupleClefNonExistanteValeurExistante_RetourneFalse()
        {
            // Arrange
            Dictionnaire<int, string> dictionnaire = new Dictionnaire<int, string>();
            dictionnaire.Add(10, "ttt");
            dictionnaire.Add(5, "nnn");
            dictionnaire.Add(7, "ooo");
            KeyValuePair<int, string> coupleClefValeurExistant = new KeyValuePair<int, string>(21, "ttt");
            int CountAttendu = 3;

            // Act
            bool valeurObtenue = dictionnaire.Remove(coupleClefValeurExistant);
            var clefRestante = dictionnaire.Keys;

            // Assert
            Assert.False(valeurObtenue);
            Assert.Equal(CountAttendu, dictionnaire.Count);
            Assert.True(clefRestante.Contains(10));
            Assert.True(clefRestante.Contains(5));
            Assert.True(clefRestante.Contains(7));
        }
        [Fact]
        public void Remove2_SupprimerCoupleClefExistanteValeurNonExistante_RetourneFalse()
        {
            // Arrange
            Dictionnaire<int, string> dictionnaire = new Dictionnaire<int, string>();
            dictionnaire.Add(10, "ttt");
            dictionnaire.Add(5, "nnn");
            dictionnaire.Add(7, "ooo");
            KeyValuePair<int, string> coupleClefValeurNonExistant = new KeyValuePair<int, string>(5, "uuu");
            int CountAttendu = 3;

            // Act
            bool valeurObtenue = dictionnaire.Remove(coupleClefValeurNonExistant);
            var clefRestante = dictionnaire.Keys;

            // Assert
            Assert.False(valeurObtenue);
            Assert.Equal(CountAttendu, dictionnaire.Count);
            Assert.True(clefRestante.Contains(10));
            Assert.True(clefRestante.Contains(5));
            Assert.True(clefRestante.Contains(7));
        }

        #endregion
    }
}
