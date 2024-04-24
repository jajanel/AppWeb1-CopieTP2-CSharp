using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WilliamN_MarcOlivierG_Tp1_H24_Code;

namespace TestMetaliFoo
{
    public class TestCatalogueMedia
    {

        CatalogueMedia catalogueMediaTest;
        Media media1;
      
        Media media3;

        [SetUp]
        public void Setup()
        {
            catalogueMediaTest = new CatalogueMedia();
            media1 = new Media(1);
            //media3 est le même media que le premier dans notre JSON
            media3 = new Media(1, "One", 0, (EnumGenreDeMedia)1, null, "1988-09-07", 446, "Metallica", "Flemming Rasmussen", "ext_One", "full_One", "img_And_Justice_For_All", "...And Justice for All");

        }


        [Test]
        public void etantDonneMedia1_quandAjouterAvecParametre_AlorsMedia1EstDansLeHashSet()
        {
            catalogueMediaTest.Ajouter(media1);
            Assert.That(catalogueMediaTest.SetMedias.Contains(media1));
        }



        [Test]
        public void etantDonneJSONCatalogue_quandAjouterSansParametre_AlorsMediaEstDansLeHashSet()
        {
            catalogueMediaTest.Ajouter();

            //media3 est le même media que le premier dans notre JSON
            Assert.That(catalogueMediaTest.SetMedias.Contains(media3));
        }

        [Test]
        public void etantDonneMediaDansSetMedias_quandSupprimer_AlorsMediaNEstPlusDansLeHashSet()
        {
            catalogueMediaTest.Ajouter(media1);
            catalogueMediaTest.Supprimer(media1);

            Assert.That(catalogueMediaTest.SetMedias.Contains(media1), Is.False);
        }



        [Test]
        public void etantDonneMedia1DansSetMedias_quandRemplacerMedia1ParMedia2_AlorsMedia2EstDansLeHashSet()
        {
            //Pour remplacer un media par un autre, les deux doivent avoir le même ID.
            catalogueMediaTest.Ajouter(media1);
            catalogueMediaTest.Remplacer(media1, media3);

            Assert.That(catalogueMediaTest.SetMedias.Contains(media3));

        }

    }






}
