
using WilliamN_MarcOlivierG_Tp1_H24_Code;

namespace TestMetaliFoo
{
    public class TestUtilisateurs
    {
        Utilisateur utilisateur;
        [SetUp]
        public void Setup()
        {
            utilisateur = new Utilisateur();
        }

        /// <summary>
        /// Test des Setter
        /// </summary>
        [Test]
        public void etantDonneeIntegerIdentifiantNegatif_QuandSetIdentifiant_AlorsErreur()
        {
            Assert.Throws<Exception>(() => utilisateur.Identifiant = -1);
            Assert.Throws<Exception>(() => utilisateur.Identifiant = -10);
        }

        [Test]
        public void etantDonneeIntegerIdentifiantOK_QuandSetIdentifiant_AlorsOK()
        {
            Assert.DoesNotThrow(() => utilisateur.Identifiant = 1054);
        }

        [Test]
        public void etantDonneeStringCourrielSansArobaseEtSansPoint_QuandSetAdresseCourriel_AlorsErreur()
        {
            Assert.Throws<Exception>(() => utilisateur.AdresseCourriel = "adresseTest");
            Assert.Throws<Exception>(() => utilisateur.AdresseCourriel = "adresseTest@cegeplimoilouca");
        }

        [Test]
        public void etantDonneeStringCourrielOK_QuandSetAdresseCourriel_AlorsOk()
        {
            Assert.DoesNotThrow(() => utilisateur.AdresseCourriel = "addressTest@cegeplimoilou.ca");
        }

        [Test]
        public void etantDonneeStringNomContenantCharactereAutreQueLettre_QuandSetNom_AlorsErreur()
        {
            Assert.Throws<Exception>(() => utilisateur.Nom = "Trembl@y");
            Assert.Throws<Exception>(() => utilisateur.Nom = "Tr1mblay");
        }

        [Test]
        public void etantDonneeStringNomOk_QuandSetNom_AlorsOk()
        {
            utilisateur.Nom = "Tremblay";
            Assert.That(utilisateur.Nom == "Tremblay");
        }

        [Test]
        public void etantDonneeStringPrenomContenantCharactereAutreQueLettre_QuandSetPrenom_AlorsErreur()
        {
            Assert.Throws<Exception>(() => utilisateur.Prenom = "Jacque$");
            Assert.Throws<Exception>(() => utilisateur.Prenom = "J4cques");
        }
        [Test]
        public void etantDonneeStringPrenomOk_QuandSetPrenom_AlorsOk()
        {
            utilisateur.Prenom = "Jacques";
            Assert.That(utilisateur.Prenom == "Jacques");
        }
        [Test]
        public void etantDonneeIntegerRolePlusGrandQueValeurEnum_QuandSetRole_AlorsErreur()
        {
            Assert.Throws<Exception>(() => utilisateur.Role = (EnumRole)7);
        }

        [Test]
        public void etantDonneeStringRoleOk_QuandSetRole_AlorsOk()
        {
            utilisateur.Role = (EnumRole).0;
            Assert.That(utilisateur.Role == EnumRole.Admin);
        }
        [Test]
        public void etantDonneeHashSetDeMedia_QuandSetFavoris_AlorsOk()
        {
            utilisateur.Favoris = new HashSet<Media>();
            Media mediaFavoriTest = new Media();
            utilisateur.AjouterFavori(mediaFavoriTest);
            Assert.That(utilisateur.Favoris.Contains(mediaFavoriTest));
        }

        [Test]
        public void etantDonneeHashSetDEvaluationEvaluations_QuandSetEvaluations_AlorsOk()
        {
            utilisateur.Identifiant = 1;
            utilisateur.Nom = "Test";
            utilisateur.Prenom = "Test";
            utilisateur.Evaluations = new HashSet<Evaluation>();
            utilisateur.Favoris = new HashSet<Media>();
            Media mediaTest = new Media(1);
            int cote = 5;
            string description = "test decription";
            Evaluation evaluationTest = new Evaluation(mediaTest.Identifiant, utilisateur.Identifiant, cote, utilisateur.Nom, utilisateur.Prenom, description);

            utilisateur.CreerEvalutation(mediaTest.Identifiant, cote, description);
            Assert.That(utilisateur.Evaluations.Contains(evaluationTest));
        }


        /// <summary>
        /// Test des Getter + Constructeur
        /// </summary>
        [Test]
        public void testConstructeurUtilisateur()
        {
            int identifiantAttendu = 1;
            string courrielAttendu = "test@cegeplimoilou.ca";
            string motDePasseAttendu = "abc123";
            string nomAttendu = "Test";
            string prenomAttendu = "Test";
            EnumRole roleAttendu = EnumRole.Utilisateur;
            HashSet<Media> favorisAttendu = null;
            HashSet<Evaluation> evaluationAttendu = null;

            Utilisateur utilisateurTestConstructeur = new Utilisateur(1, "test@cegeplimoilou.ca", "abc123", "Test", "Test", EnumRole.Utilisateur, null, null);

            Assert.Multiple(() =>
            {
                Assert.That(identifiantAttendu == utilisateurTestConstructeur.Identifiant);
                Assert.That(motDePasseAttendu == utilisateurTestConstructeur.MotDePasse);
                Assert.That(nomAttendu == utilisateurTestConstructeur.Nom);
                Assert.That(prenomAttendu == utilisateurTestConstructeur.Prenom);
                Assert.That(roleAttendu == utilisateurTestConstructeur.Role);
                Assert.That(favorisAttendu == utilisateurTestConstructeur.Favoris);
                Assert.That(evaluationAttendu == utilisateurTestConstructeur.Evaluations);
            }
                );
        }
         
        /// <summary>
        /// Test toString()
        /// </summary>
        [Test]
        public void TestToStringUtilisateur()
        {
            string courrielAttendu = "test@cegeplimoilou.ca";
            string nomAttendu = "Test";
            string prenomAttendu = "Test";
            EnumRole roleAttendu = EnumRole.Utilisateur;
            string stringAttendu = "Nom: " + prenomAttendu + " " + nomAttendu + "\nAdresse courriel: " + courrielAttendu + "\nRole: " + roleAttendu;

            Utilisateur utilisateurTestToString = new Utilisateur(1, "test@cegeplimoilou.ca", "abc123", "Test", "Test", EnumRole.Utilisateur, null, null);
            Assert.That(stringAttendu == utilisateurTestToString.ToString());
        }
    }
}
