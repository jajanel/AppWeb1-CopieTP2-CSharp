using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WilliamN_MarcOlivierG_Tp1_H24_Code;

namespace TestMetaliFoo
{
    public class TestCatalogueUtilisateur
    {

        CatalogueUtilisateurs catalogueUtilisateursTest;
        Utilisateur user1;
        Utilisateur user2;
        Utilisateur user3;


        [SetUp]
        public void Setup()
        {
            catalogueUtilisateursTest = new CatalogueUtilisateurs();
            user1 = new Utilisateur("test@test.ca", "abc123");
            user2 = new Utilisateur("test2@test.com", "abc123");
            //user3 Même que le premier utilisateur dans le fichier JSON.
            user3 = new Utilisateur(1, "bob@cegeplimoilou.ca", "abc123", "Marley", "Bob", (EnumRole)0, null, null);
        }


        [Test]
        public void etantDonneUser1_quandAjouterAvecParametre_AlorsUser1EstDansLeHashSet()
        {
            catalogueUtilisateursTest.Ajouter(user1);
            Assert.That(catalogueUtilisateursTest.setUtilisateurs.Contains(user1));
        }



        [Test]
        public void etantDonneJSONUtilisateurs_quandAjouterSansParametre_AlorsUser3EstDansLeHashSet()
        {
            catalogueUtilisateursTest.Ajouter();

            foreach (Utilisateur user in catalogueUtilisateursTest.setUtilisateurs)
            {
                Console.WriteLine(user);
            }

            //user3 est le même media que le premier dans notre JSON
            Assert.That(catalogueUtilisateursTest.setUtilisateurs.Contains(user3));
        }

        [Test]
        public void etantDonneUser1DansSetUtilisateurs_quandSupprimer_AlorsUser1NEstPlusDansLeHashSet()
        {
            catalogueUtilisateursTest.Ajouter(user1);
            catalogueUtilisateursTest.Supprimer(user1);

            Assert.That(catalogueUtilisateursTest.setUtilisateurs.Contains(user1), Is.False);
        }



        [Test]
        public void etantDonneUser1DansSetUtilisateurs_quandRemplacerUser1ParUser2_AlorsUser2EstDansLeHashSet()
        {
            //Pour remplacer un media par un autre, les deux doivent avoir le même ID.
            catalogueUtilisateursTest.Ajouter(user1);
            catalogueUtilisateursTest.Remplacer(user1, user2);

            foreach (Utilisateur user in catalogueUtilisateursTest.setUtilisateurs)
            {
                Console.WriteLine(user.ToString());
            }

            Assert.That(catalogueUtilisateursTest.setUtilisateurs.Contains(user2));

        }

        [Test]
        public void testCatalogueMediaToString()
        {
            //Pour remplacer un media par un autre, les deux doivent avoir le même ID.
            catalogueUtilisateursTest.Ajouter(user1);

            string stringAttendu = "\nVoici les utilisateurs de MetalliFoo:\n" + user1.ToString() + "\n|||||||||||||||||||||||||||||||||||\n" + "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";

            Assert.That(catalogueUtilisateursTest.ToString() == stringAttendu);

        }
    }
}
