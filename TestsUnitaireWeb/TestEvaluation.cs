using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_H24_Code.Models;

namespace TestsUnitaireWeb
{

    public class TestEvaluation
    {
        Evaluation evaluation;

        [SetUp]
        public void Setup()
        {
            evaluation = new Evaluation();
        }

        /// <summary>
        /// Test des Setter
        /// </summary>
        [Test]
        public void etantDonneeIntegerIdMediaNegatif_QuandSetIdMedia_AlorsErreur()
        {
            Assert.Throws<Exception>(() => evaluation.IdMedia = -1);
            Assert.Throws<Exception>(() => evaluation.IdMedia = -10);
        }

        [Test]
        public void etantDonneeIntegerIdMediaOK_QuandSetIdMedia_AlorsOK()
        {
            Assert.DoesNotThrow(() => evaluation.IdMedia = 1054);
        }

        [Test]
        public void etantDonneeIntegerIdUtilisateurNegatif_QuandSetIdUtilisateur_AlorsErreur()
        {
            Assert.Throws<Exception>(() => evaluation.IdUtilisateur = -1);
            Assert.Throws<Exception>(() => evaluation.IdUtilisateur = -10);
        }

        [Test]
        public void etantDonneeIntegerIdUtilisateurOK_QuandSetIdUtilisateur_AlorsOK()
        {
            Assert.DoesNotThrow(() => evaluation.IdUtilisateur = 1054);
        }

        [Test]
        public void etantDonneeIntegerCote_QuandSetIntegerCoteHorsBorne_AlorsErreur()
        {
            Assert.Throws<Exception>(() => evaluation.Cote = -1);
            Assert.Throws<Exception>(() => evaluation.Cote = 6);
        }

        [Test]
        public void etantDonneeIntegerCote_QuandSetIntegerCoteDansLesBornes_AlorsOK()
        {
            Assert.DoesNotThrow(() => evaluation.Cote = 0);
            Assert.DoesNotThrow(() => evaluation.Cote = 5);
        }

        [Test]
        public void etantDonneeStringUtilisateurNomContenantCharactereAutreQueLettre_QuandSetUtilisateurNom_AlorsErreur()
        {
            Assert.Throws<Exception>(() => evaluation.NomUtilisateur = "Trembl@y");
            Assert.Throws<Exception>(() => evaluation.NomUtilisateur = "Tr1mblay");
        }

        [Test]
        public void etantDonneeStringUtilisateurNomOk_QuandSetUtilisateurNom_AlorsOk()
        {
            evaluation.NomUtilisateur = "Tremblay";
            Assert.That(evaluation.NomUtilisateur == "Tremblay");
        }

        [Test]
        public void etantDonneeStringPrenomUtilisateurContenantCharactereAutreQueLettre_QuandSetPrenomUtilisateur_AlorsErreur()
        {
            Assert.Throws<Exception>(() => evaluation.PrenomUtilisateur = "Jacque$");
            Assert.Throws<Exception>(() => evaluation.PrenomUtilisateur = "J4cques");
        }

        [Test]
        public void etantDonneeStringPrenomUtilisateurOk_QuandSetPrenomUtilisateur_AlorsOk()
        {
            evaluation.PrenomUtilisateur = "Jacques";
            Assert.That(evaluation.PrenomUtilisateur == "Jacques");
        }

        [Test]
        public void etantDonneeStringDescriptionTropLongue_QuandSetDescription_AlorsErreur()
        {
            string descriptionTest = new string('a', 201);

            Assert.Throws<Exception>(() => evaluation.Description = descriptionTest);
        }

        /// <summary>
        /// Test des Getter + Constructeur
        /// </summary>

        [Test]
        public void testConstructeurEvaluation()
        {
            int idMediaAttendu = 1;
            int idUtilisateurAttendu = 1;
            int coteAttendu = 3;
            string nomUtilisateurAttendu = "Test";
            string prenomUtilisateurAttendu = "Test";
            string descriptionAttendu = "Test";

            Evaluation evaluationTestConstructeur = new Evaluation(1, 1, 3, "Test", "Test", "Test");

            Assert.Multiple(() =>
            {
                Assert.That(idMediaAttendu == evaluationTestConstructeur.IdMedia);
                Assert.That(idUtilisateurAttendu == evaluationTestConstructeur.IdUtilisateur);
                Assert.That(coteAttendu == evaluationTestConstructeur.Cote);
                Assert.That(nomUtilisateurAttendu == evaluationTestConstructeur.NomUtilisateur);
                Assert.That(prenomUtilisateurAttendu == evaluationTestConstructeur.PrenomUtilisateur);
                Assert.That(descriptionAttendu == evaluationTestConstructeur.Description);
            }
                );
        }

        /// <summary>
        /// Test toString()
        /// </summary>
        [Test]
        public void testToStringEvaluation()
        {
            int idMediaAttendu = 1;
            int idUtilisateurAttendu = 1;
            int coteAttendu = 3;
            string nomUtilisateurAttendu = "Test";
            string prenomUtilisateurAttendu = "Test";
            string descriptionAttendu = "Test";

            string stringAttendu = "Cote: " + coteAttendu + "\nNom de l'utilisateur: " + prenomUtilisateurAttendu + " " + nomUtilisateurAttendu + "\nDescription: " + descriptionAttendu;
               


            Evaluation evaluationTestConstructeur = new Evaluation(1, 1, 3, "Test", "Test", "Test");

            Assert.That(stringAttendu == evaluationTestConstructeur.ToString());

        }

    }
}
