using System.Data;
using WilliamN_MarcOlivierG_Tp1_H24_Code;

namespace WilliamN_MarcOlivierG
{
    public class Program
    {

        private static void DeserialiserCatalogue(CatalogueUtilisateurs catalogueUtilisateurs, CatalogueEvaluations catalogueEvaluation, CatalogueMedia cataloguemedia)
        {
            catalogueEvaluation.Ajouter();
            catalogueUtilisateurs.Ajouter();
            //Ajouter les évaluations dans les utilisateurs
            foreach(Utilisateur utilisateur in catalogueUtilisateurs.setUtilisateurs)
            {
                foreach (Evaluation evaluation in catalogueEvaluation.ListEvaluations)
                {
                    if(evaluation.IdUtilisateur == utilisateur.Identifiant)
                    {
                        utilisateur.Evaluations.Add(evaluation);
                    }
                }
            }

            cataloguemedia.Ajouter();
            //Ajouter les évaluations des utilisateurs dans chaque médias:
            foreach(Media media in cataloguemedia.SetMedias)
            {
                media.ajouterEvaluation(catalogueUtilisateurs);
            }
        }

        private static void SerialiserCatalogue(CatalogueUtilisateurs catalogueUtilisateurs, CatalogueEvaluations catalogueEvaluation, CatalogueMedia cataloguemedia)
        {
            catalogueUtilisateurs.Sauvegarder();
            catalogueEvaluation.Sauvegarder();
            cataloguemedia.Sauvegarder();
        }

        private static void AfficherCatalogues(CatalogueUtilisateurs catalogueUtilisateurs, CatalogueEvaluations catalogueEvaluation, CatalogueMedia cataloguemedia)
        {
            Console.WriteLine(catalogueUtilisateurs.ToString() + cataloguemedia.ToString());
        }



        private string racine = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        static void Main(string[] args)
        {

            CatalogueUtilisateurs catalogueUtilisateurs = new CatalogueUtilisateurs();
            CatalogueEvaluations catalogueEvaluation = new CatalogueEvaluations();
            CatalogueMedia cataloguemedia = new CatalogueMedia();

            Program.DeserialiserCatalogue(catalogueUtilisateurs, catalogueEvaluation, cataloguemedia);
            //Program.SerialiserCatalogue(catalogueUtilisateurs, catalogueEvaluation, cataloguemedia);
            Program.AfficherCatalogues(catalogueUtilisateurs, catalogueEvaluation, cataloguemedia);

        }
    }
}