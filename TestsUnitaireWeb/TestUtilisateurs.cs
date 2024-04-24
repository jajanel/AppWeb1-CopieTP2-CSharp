
using TP2_H24_Code.Models;

namespace TestsUnitaireWeb
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
        public void etantDonneeStringCourrielIncorrect_QuandSetAdresseCourriel_AlorsErreur()
        {
            Assert.Throws<FormatException>(() => utilisateur.AdresseCourriel = "adresseTest");
            Assert.Throws<FormatException>(() => utilisateur.AdresseCourriel = "adresseTest@cegeplimoilouca");
            Assert.Throws<FormatException>(() => utilisateur.AdresseCourriel = "");
            Assert.Throws<FormatException>(() => utilisateur.AdresseCourriel = "1@2.");

            Assert.Throws<ArgumentNullException>(() => utilisateur.AdresseCourriel = null);

        }

        [Test]
        public void etantDonneeStringCourrielOK_QuandSetAdresseCourriel_AlorsOk()
        {
            utilisateur.AdresseCourriel = "Roland@desgf.ca";
            Assert.That(utilisateur.AdresseCourriel == "Roland@desgf.ca");
        }

        [Test]
        public void etantDonneeStringNomContenantCharactereAutreQueLettre_QuandSetNom_AlorsErreur()
        {
            Assert.Throws<FormatException>(() => utilisateur.Nom = "Trembl@y");
            Assert.Throws<FormatException>(() => utilisateur.Nom = "Tr1mblay");

            Assert.Throws<ArgumentNullException>(() => utilisateur.Nom = null);
        }

        [Test]
        public void etantDonneeStringNomOk_QuandSetNom_AlorsOk()
        {
            utilisateur.Nom = "Tremblay";
            Assert.That(utilisateur.Nom == "Tremblay");
            utilisateur.Nom = "Nolan-Geoffroy";
            Assert.That(utilisateur.Nom == "Nolan-Geoffroy");
        }

        [Test]
        public void etantDonneeStringPrenomContenantCharactereAutreQueLettre_QuandSetPrenom_AlorsErreur()
        {
            Assert.Throws<FormatException>(() => utilisateur.Prenom = "Jacque$");
            Assert.Throws<FormatException>(() => utilisateur.Prenom = "J4cques");
        }

        [Test]
        public void etantDonneeStringPrenomnull_QuandSetPrenom_AlorsErreur()
        {
            Assert.Throws<ArgumentNullException>(() => utilisateur.Prenom = null);
        }

        [Test]
        public void etantDonneeStringPrenomOk_QuandSetPrenom_AlorsOk()
        {
            utilisateur.Prenom = "Roland";
            Assert.That(utilisateur.Prenom == "Roland");
            utilisateur.Prenom = "Jacques-Martel";
            Assert.That(utilisateur.Prenom == "Jacques-Martel");
        }
        [Test]
        public void etantDonneeIntegerRolePlusGrandQueValeurEnum_QuandSetRole_AlorsErreur()
        {
            Assert.Throws<MemberAccessException>(() => utilisateur.Role = (EnumRole)7);
            
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

        /// <summary>
        /// Test mot de passe 
        /// Mot de Passe doit avoir au moins 8 caractères, au moins une lettre majuscule, au moins une lettre minuscule, au moins 1 chiffre, au moins un caractère spécial (Le regex ne prends pas les accents)
        /// </summary>
        [Test]
        public void etantDonneeStringMotDePasseOk_QuandSetMotDePasse_AlorsOk()
        {
            utilisateur.MotDePasse = "L!moilou01";
            Assert.That(utilisateur.MotDePasse == "L!moilou01");
            utilisateur.MotDePasse = "1jD¦@±423";
            Assert.That(utilisateur.MotDePasse == "1jD¦@±423");
        }

        [Test]
        public void etantDonneeStringMotDePasseNonValide_QuandSetMotDePasse_AlorsErreur()
        {
            Assert.Throws<FormatException>(() => utilisateur.MotDePasse = "Limoilou01");
            Assert.Throws<FormatException>(() => utilisateur.MotDePasse = "l!moilou01");
            Assert.Throws<FormatException>(() => utilisateur.MotDePasse = "L¢¤1");
            Assert.Throws<FormatException>(() => utilisateur.MotDePasse = "L!MOILOU0321");
            Assert.Throws<ArgumentNullException>(() => utilisateur.MotDePasse = null);
        }


        /// <summary>
        /// Test des Getter + Constructeur
        /// </summary>
        [Test]
        public void testConstructeurUtilisateur()
        {
            string courrielAttendu = "test@cegeplimoilou.ca";
            string motDePasseAttendu = "L!moilou01";
            string nomAttendu = "Test";
            string prenomAttendu = "Test";
            EnumRole roleAttendu = EnumRole.Utilisateur;
            HashSet<Media> favorisAttendu = new HashSet<Media>();
            HashSet<Evaluation> evaluationAttendu = new HashSet<Evaluation>();

            Utilisateur utilisateurTestConstructeur = new Utilisateur("test@cegeplimoilou.ca", "L!moilou01", "Test", "Test", EnumRole.Utilisateur, favorisAttendu, evaluationAttendu);

            Assert.Multiple(() =>
            {
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
            HashSet<Media> favorisAttendu = new HashSet<Media>();
            HashSet<Evaluation> evaluationAttendu = new HashSet<Evaluation>();
            string stringAttendu = "Nom: " + prenomAttendu + " " + nomAttendu + "\nAdresse courriel: " + courrielAttendu + "\nRole: " + roleAttendu;

            Utilisateur utilisateurTestToString = new Utilisateur("test@cegeplimoilou.ca", "L!moilou01", "Test", "Test", EnumRole.Utilisateur, favorisAttendu, evaluationAttendu);
            Assert.That(stringAttendu == utilisateurTestToString.ToString());
        }
    }
}
