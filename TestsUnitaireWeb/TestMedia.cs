using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TP2_H24_Code.Models;
using static System.Net.Mime.MediaTypeNames;

namespace TestsUnitaireWeb
{
    public class TestMedia
    {
        Media media1;
        Media media2;
        Media mediaTousLesChamps;

        [SetUp]
        public void Setup()
        {

            media1 = new Media();
            media2 = new Media();
            mediaTousLesChamps = new Media(8, "One", 5, EnumGenreDeMedia.Metal, new List<Evaluation>(),
                "20-01-1986", 300, "Metallica", "Golden House Records", "testLienAudioExtrait", "testLienAudioComplet", "testLienImage", "Nom d'album");


        }

        /// <summary>
        /// Test des Setter
        /// </summary>

        [Test]
        public void etantDonneeIntIdentifiantInvalide_QuandSetIdentifiant_AlorsErreur()
        {
            Assert.Throws<FormatException>(() => media1.Identifiant = -1);

        }


        [Test]
        public void etantDonneIntIdentifiantValide_QuandSetIdentifiant_AlorsOk()
        {
            media1.Identifiant = 7;
            Assert.That(media1.Identifiant, Is.EqualTo(7));

        }

        [Test]
        public void etantDonneeStringNomMediaInvalide_QuandSetNomMedia_AlorsErreur()
        {
            Assert.Throws<FormatException>(() => media1.NomMedia = null);

        }


        [Test]
        public void etantDonneStringNomMediaValide_QuandSetNomMedia_AlorsOk()
        {
            media1.NomMedia = "akjshijdha98iuhyuhn @£¤¤¢¬¤¬²³²£";
            Assert.That(media1.NomMedia == "akjshijdha98iuhyuhn @£¤¤¢¬¤¬²³²£");

        }

        [Test]
        public void etantDonneeIntEvalCoteInvalide_QuandSetCote_AlorsErreur()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => media1.EvaluationCote = 6);
            Assert.Throws<ArgumentOutOfRangeException>(() => media1.EvaluationCote = -1);

        }

        [Test]
        public void etantDonneeIntEvalCoteValide_QuandSetCote_AlorsOk()
        {
            media1.EvaluationCote = 1;
            Assert.That(media1.EvaluationCote == 1);

        }


        [Test]
        public void etantDonneeEnumGenreMediaInvalide_QuandSetGenreDeMedia_AlorsErreur()
        {
            Assert.Throws<FormatException>(() => media1.GenreDeMedia = (EnumGenreDeMedia)14);
            Assert.Throws<FormatException>(() => media1.GenreDeMedia = (EnumGenreDeMedia)65);
        }

        [Test]
        public void etantDonneeEnumGenreMediaValide_QuandSetGenreDeMedia_AlorsOk()
        {
            media1.GenreDeMedia = (EnumGenreDeMedia)1;
            Assert.That(media1.GenreDeMedia == EnumGenreDeMedia.Metal);
        }

        [Test]
        public void etantDonneeEvaluationUtilisateurInvalide_QuandSetEvaluationUtilisateur_AlorsErreur()
        {
            Assert.Throws<FormatException>(() => media1.EvaluationUtilisateur = null);
        }

        [Test]
        public void etantDonneeDateRealisationInvalide_QuandSetDateRealisation_AlorsErreur()
        {
            Assert.Throws<FormatException>(() => media1.DateRealisation = null);
        }

        [Test]
        public void etantDonneeDateRealisationVide_QuandSetDateRealisation_AlorsNA()
        {
            media1.DateRealisation = "";
            Assert.That(media1.DateRealisation == "N/A");

        }

        [Test]
        public void etantDonneeDureeSecondeInvalide_QuandSetDureeSeconde_AlorsErreur()
        {
            Assert.Throws<FormatException>(() => media1.DureeSecondes = -1);
            Assert.Throws<FormatException>(() => media1.DureeSecondes = 3601);

        }

        [Test]
        public void etantDonneeAuteurInvalide_QuandSetAuteur_AlorsErreur()
        {
            Assert.Throws<FormatException>(() => media1.Auteur = null);
   
        }

        [Test]
        public void etantDonneeAuteurVide_QuandSetAuteur_AlorsNA()
        {
            media1.Auteur = "";
            Assert.That(media1.Auteur == "N/A");

        }

        [Test]
        public void etantDonneeProducteurInvalide_QuandSetProducteur_AlorsErreur()
        {
            Assert.Throws<FormatException>(() => media1.Producteur = null);

        }

        [Test]
        public void etantDonneeProducteurVide_QuandSetProducteur_AlorsNA()
        {
            media1.Producteur = "";
            Assert.That(media1.Producteur == "N/A");

        }

        [Test]
        public void etantDonneeAudioExtraitInvalide_QuandSetAudioExtrait_AlorsErreur()
        {
            Assert.Throws<FormatException>(() => media1.AudioExtrait = null);

        }

        [Test]
        public void etantDonneeAudioCompletInvalide_QuandSetAudioComplet_AlorsErreur()
        {
            Assert.Throws<FormatException>(() => media1.AudioComplet = null);

        }

        [Test]
        public void etantDonneeImageInvalide_QuandSetImage_AlorsErreur()
        {
            Assert.Throws<FormatException>(() => media1.Image= null);

        }

        [Test]
        public void etantDonneeAlbumInvalide_QuandSetAlbum_AlorsErreur()
        {
            Assert.Throws<FormatException>(() => media1.Album = null);

        }


        [Test]
        public void etantDonneConstructeurParametreTousLesChamps_quandIdentifiantSet_alorsIdentifiantEstChange()
        {
            mediaTousLesChamps.Identifiant = 10;


            Assert.That(mediaTousLesChamps.Identifiant, Is.EqualTo(10));

        }


        [Test]
        public void etantDonneConstructeurParametreTousLesChamps_quandNomMediaGet_alorsNomMediaEstBon()
        {
            string nomMedia = mediaTousLesChamps.NomMedia;


            Assert.That(nomMedia, Is.EqualTo("One"));

        }

        [Test]
        public void etantDonneConstructeurParametreTousLesChamps_quandNomMediaSet_alorsNomMediaEstChange()
        {
            mediaTousLesChamps.NomMedia = "OneTest";


            Assert.That(mediaTousLesChamps.NomMedia, Is.EqualTo("OneTest"));

        }


        [Test]
        public void etantDonneConstructeurParametreTousLesChamps_quandEvaluationCoteGet_alorsEvaluationCoteEstBon()
        {
            int evaluationCote = mediaTousLesChamps.EvaluationCote;


            Assert.That(evaluationCote, Is.EqualTo(5));

        }


        [Test]
        public void etantDonneConstructeurParametreTousLesChamps_quandDateRealisationGet_alorsDateRealisationEstBon()
        {
            string dateRealisation = mediaTousLesChamps.DateRealisation;


            Assert.That(dateRealisation, Is.EqualTo("20-01-1986"));

        }

        [Test]
        public void etantDonneConstructeurParametreTousLesChamps_quandDateRealisationSet_alorsDateRealisationEstChange()
        {
            mediaTousLesChamps.DateRealisation = "20-01-1968";


            Assert.That(mediaTousLesChamps.DateRealisation, Is.EqualTo("20-01-1968"));

        }

        [Test]
        public void etantDonneConstructeurParametreTousLesChamps_quandDureeSecondesGet_alorsDureeSecondesEstBon()
        {
            int dureeSecondes = mediaTousLesChamps.DureeSecondes;


            Assert.That(dureeSecondes, Is.EqualTo(300));

        }

        [Test]
        public void etantDonneConstructeurParametreTousLesChamps_quandDureeSecondesSet_alorsDureeSecondesEstChange()
        {
            mediaTousLesChamps.DureeSecondes = 250;


            Assert.That(mediaTousLesChamps.DureeSecondes, Is.EqualTo(250));

        }

        [Test]
        public void etantDonneConstructeurParametreTousLesChamps_quandAuteurGet_alorsDateAuteurEstBon()
        {
            string auteur = mediaTousLesChamps.Auteur;


            Assert.That(auteur, Is.EqualTo("Metallica"));

        }

        [Test]
        public void etantDonneConstructeurParametreTousLesChamps_quandAutreuSet_alorsDateAutreuEstChange()
        {
            mediaTousLesChamps.Auteur = "Metallica";


            Assert.That(mediaTousLesChamps.Auteur, Is.EqualTo("Metallica"));

        }


        [Test]
        public void etantDonneConstructeurParametreTousLesChamps_quandProducteurGet_alorsDateProducteurEstBon()
        {
            string producteur = mediaTousLesChamps.Producteur;


            Assert.That(producteur, Is.EqualTo("Golden House Records"));

        }

        [Test]
        public void etantDonneConstructeurParametreTousLesChamps_quandProducteurSet_alorsDateProducteurEstChange()
        {
            mediaTousLesChamps.Producteur = "Golden House Records";


            Assert.That(mediaTousLesChamps.Producteur, Is.EqualTo("Golden House Records"));

        }


        [Test]
        public void etantDonneConstructeurParametreTousLesChamps_quandAudioExtraitGet_alorsDateAudioExtraitEstBon()
        {
            string audioExtrait = mediaTousLesChamps.AudioExtrait;


            Assert.That(audioExtrait, Is.EqualTo("testLienAudioExtrait"));

        }

        [Test]
        public void etantDonneConstructeurParametreTousLesChamps_quandAudioExtraitSet_alorsAudioExtraitEstChange()
        {
            mediaTousLesChamps.Auteur = "testLienAudioExtraitTest";


            Assert.That(mediaTousLesChamps.Auteur, Is.EqualTo("testLienAudioExtraitTest"));

        }


        [Test]
        public void etantDonneConstructeurParametreTousLesChamps_quandAudioCompletGet_alorsDateAudioCompletEstBon()
        {
            string audioComplet = mediaTousLesChamps.AudioComplet;


            Assert.That(audioComplet, Is.EqualTo("testLienAudioComplet"));

        }

        [Test]
        public void etantDonneConstructeurParametreTousLesChamps_quandAudioCompletSet_alorsAudioCompletEstChange()
        {
            mediaTousLesChamps.AudioComplet = "testLienAudioCompletTest";


            Assert.That(mediaTousLesChamps.AudioComplet, Is.EqualTo("testLienAudioCompletTest"));

        }

        [Test]
        public void etantDonneConstructeurParametreTousLesChamps_quandImageGet_alorsImageEstBon()
        {
            string image = mediaTousLesChamps.Image;


            Assert.That(image, Is.EqualTo("testLienImage"));

        }

        [Test]
        public void etantDonneConstructeurParametreTousLesChamps_quandImageSet_alorsImageEstChange()
        {
            mediaTousLesChamps.Image = "testLienImageTest";


            Assert.That(mediaTousLesChamps.Image, Is.EqualTo("testLienImageTest"));

        }


        [Test]
        public void etantDonneConstructeurParametreTousLesChamps_quandAlbumGet_alorsAlbumEstBon()
        {
            string album = mediaTousLesChamps.Album;


            Assert.That(album, Is.EqualTo("Nom d'album"));

        }

        [Test]
        public void etantDonneConstructeurParametreTousLesChamps_quandAlbumSet_alorsAlbumEstChange()
        {
            mediaTousLesChamps.Album = "testLienAlbumTest";


            Assert.That(mediaTousLesChamps.Album, Is.EqualTo("testLienAlbumTest"));

        }

    }
}
