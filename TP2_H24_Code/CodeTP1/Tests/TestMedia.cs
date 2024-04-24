using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WilliamN_MarcOlivierG_Tp1_H24_Code;
using static System.Net.Mime.MediaTypeNames;

namespace TestMetaliFoo
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
            mediaTousLesChamps = new Media(8, "One", 5, EnumGenreDeMedia.Metal, null, "20-01-1986", 300, "Metallica", "Golden House Records", "testLienAudioExtrait", "testLienAudioComplet", "testLienImage", "Nom d'album");


        }

        [Test]
        public void etantDonneConstructeurSansParametre_quandIdentifiantSet_alorsIdentifiantEstChange()
        {
            media1.Identifiant = 7;

            Assert.That(media1.Identifiant, Is.EqualTo(7));

        }



        [Test]
        public void etantDonneConstructeurParametreIdentifiant_quandIdentifiantGet_alorsIdentifiantEstCorrect()
        {
            Media mediaSeulementIdentifiant = new Media(7);

            Assert.That(mediaSeulementIdentifiant.Identifiant, Is.EqualTo(7));

        }

        [Test]
        public void etantDonneConstructeurParametreIdentifiant_quandIdentifiantSet_alorsIdentifiantEstChange()
        {
            Media mediaSeulementIdentifiant = new Media(7);
            mediaSeulementIdentifiant.Identifiant = 8;

            Assert.That(mediaSeulementIdentifiant.Identifiant, Is.EqualTo(8));

        }


        [Test]
        public void etantDonneConstructeurSansParametre_quandIdentifiantEqualsAutreMedia_alorsEqualsRetourneTrue()
        {
            media1.Identifiant = 7;
            media2.Identifiant = 7;

            Assert.That(media1.Identifiant, Is.EqualTo(media2.Identifiant));

        }


        [Test]
        public void etantDonneConstructeurParametreTousLesChamps_quandIdentifiantGet_alorsIdentifiantEstBon()
        {
            int idTest = mediaTousLesChamps.Identifiant;


            Assert.That(idTest, Is.EqualTo(8));

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



        [Test]
        public void etantDonneEqualsIdentifiantTest1_quandVerifierSiObjetMetaliFooMediaEstEgale_AlorsEquals()
        {

        }

    }
}
