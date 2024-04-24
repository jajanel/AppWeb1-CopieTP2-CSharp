using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WilliamN_MarcOlivierG_Tp1_H24_Code;

namespace TestMetaliFoo
{
    public class TestCatalogueEvaluations
    {

        CatalogueEvaluations catalogueEvaluationTest;
        Evaluation eval1;
        Evaluation eval2;

        [SetUp]
        public void Setup()
        {
            catalogueEvaluationTest = new CatalogueEvaluations();
            eval1 = new Evaluation(1, 1);
            //eval2 est le même eval que le premier dans notre JSON
            eval2 = new Evaluation(1, 1, 4, "Nolan", "Willy", "wowowow!");

        }


        [Test]
        public void etantDonneEval1_quandAjouterAvecParametre_AlorsEval1EstDansLeHashSet()
        {
            catalogueEvaluationTest.Ajouter(eval1);
            Assert.That(catalogueEvaluationTest.ListEvaluations.Contains(eval1));
        }



        [Test]
        public void etantDonneJSONCatalogue_quandAjouterSansParametre_AlorsEvalEstDansLaList()
        {
            catalogueEvaluationTest.Ajouter();

            //media3 est le même media que le premier dans notre JSON
            Assert.That(catalogueEvaluationTest.ListEvaluations.Contains(eval2));
        }

        [Test]
        public void etantDonneEvalDansListEval_quandSupprimer_AlorsEvalNEstPlusDansLaListe()
        {
            catalogueEvaluationTest.Ajouter(eval1);
            catalogueEvaluationTest.Supprimer(eval1);

            Assert.That(catalogueEvaluationTest.ListEvaluations.Contains(eval1), Is.False);
        }



        [Test]
        public void etantDonneEvalDansListEval_quandRemplacerEval1ParEval2_AlorsEval2EstDansLaList()
        {
            //Pour remplacer un eval par un autre, les deux doivent avoir le même IdMedia et IdUtilisateur.
            catalogueEvaluationTest.Ajouter(eval1);
            catalogueEvaluationTest.Remplacer(eval1, eval2);

            Assert.That(catalogueEvaluationTest.ListEvaluations.Contains(eval2));

        }

        [Test]
        public void testCatalogueEvaluationToString()
        {
            catalogueEvaluationTest.Ajouter(eval1);

            string stringAttendu = "\nVoici les évaluations de MetalliFoo:\n" + eval1.ToString() + "\n|||||||||||||||||||||||||||||||||||\n" + "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";

            Assert.That(catalogueEvaluationTest.ToString() == stringAttendu);

        }

    }

}

