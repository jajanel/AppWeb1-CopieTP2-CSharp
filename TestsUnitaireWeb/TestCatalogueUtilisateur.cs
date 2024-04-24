using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_H24_Code.Models;

namespace TestsUnitaireWeb
{
    public class TestCatalogueUtilisateur
    {
        String pathJSONtest = "../../../JSONTest/Utilisateurs/Utilisateurs.json";
        CatalogueUtilisateurs catalogueUtilisateursTest;
        Utilisateur user1;
        Utilisateur user2;
        Utilisateur user3;
        Utilisateur user4;

        [SetUp]
        public void Setup()
        {
            catalogueUtilisateursTest = new CatalogueUtilisateurs();
            user1 = new Utilisateur("test@test.ca", "L!moilou01");
            user2 = new Utilisateur("test2@test.com", "L!moilou01");
            //user3 Même que le premier utilisateur dans le fichier JSON.
            user3 = new Utilisateur("bob@cegeplimoilou.ca", "L!moilou01", "Marley", "Bob", (EnumRole)0, new HashSet<Media>(), new HashSet<Evaluation>());
            user4 = new Utilisateur("bob@cegeplimoilou.ca", "L!moilou01", "Ginette", "Reno", (EnumRole)0, new HashSet<Media>(), new HashSet<Evaluation>());
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
            catalogueUtilisateursTest.Ajouter(pathJSONtest);

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
            //Pour remplacer un utilisateur par un autre, les deux doivent avoir la même adresse courriel.
            catalogueUtilisateursTest.Ajouter(user3);
            catalogueUtilisateursTest.Remplacer(user3, user4);

            foreach (Utilisateur user in catalogueUtilisateursTest.setUtilisateurs)
            {
                Console.WriteLine(user.ToString());
            }

            Assert.That(catalogueUtilisateursTest.setUtilisateurs.Contains(user4));

        }

        [Test]
        public void testCatalogueMediaToString()
        {
            
            catalogueUtilisateursTest.Ajouter(user1);

            string stringAttendu = "\nVoici les utilisateurs de MetalliFoo:\n" + user1.ToString() + "\n|||||||||||||||||||||||||||||||||||\n" + "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";

            Assert.That(catalogueUtilisateursTest.ToString() == stringAttendu);

        }
    }
}
