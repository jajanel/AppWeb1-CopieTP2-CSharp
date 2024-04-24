using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_H24_Code.Models
{
    public class CatalogueEvaluations : Catalogue
    {

        private string racine = "../JSON/Evaluations/Evaluations.json";


        /// <summary>
        /// List dans laquel nous allons ranger les valeurs obtenu du JSON
        /// </summary>
        List<Evaluation> listEvaluations = new List<Evaluation>();

        public List<Evaluation> ListEvaluations { get => listEvaluations; set => listEvaluations = value; }

        public CatalogueEvaluations()
        {
            ListEvaluations = new List<Evaluation>();
        }

        /// <summary>
        /// Constructeur avec la list comme parametre
        /// </summary>
        public CatalogueEvaluations(List<Evaluation> listEvaluations)
        {
            this.ListEvaluations = listEvaluations;
        }

        /// <summary>
        /// Méthode ajouter qui prends une évaluation en paramêtre et l'ajoute dans la liste des évaluations
        /// </summary>
        public void Ajouter(Evaluation evaluation)
        {
            ListEvaluations.Add(evaluation);

        }

        /// <summary>
        /// Methode ajouter surchargé du parent. Celle si convertie l'information contenu dans le fichier JSON et l'ajoute à la liste.
        /// @recine réfère au champ privé racine. 
        /// </summary>
        public override void Ajouter()
        {
            ListEvaluations = JsonConvert.DeserializeObject<List<Evaluation>>(File.ReadAllText(@racine), new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });

        }

        /// <summary>
        /// Supprime l'évaluation reçu en paramêtre de la liste des évaluations
        /// </summary>
        public void Supprimer(Evaluation evaluation)
        {
            ListEvaluations.Remove(evaluation);
        }

        /// <summary>
        /// prends en paramêtre deux évaluations. 
        /// APpel la méthôde Supprimer et Ajouter(Evaluation evaluation) pour remplacer les évaluation qui ont le même ID
        /// </summary>
        public void Remplacer(Evaluation evaluationAEnlever, Evaluation evaluationAMettre)
        {
            if (evaluationAEnlever.Equals(evaluationAMettre))
            {
                Supprimer(evaluationAEnlever);
                Ajouter(evaluationAMettre);
            }

        }

        /// <summary>
        /// Sauvegarde ce qui se trouve dans la liste d'évaluations dans le fichier Json
        /// </summary>
        public void Sauvegarder()
        {

            string jsonFichier = JsonConvert.SerializeObject(ListEvaluations, ListEvaluations.GetType(), Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });

            File.WriteAllText(racine, jsonFichier);
        }

        /// <summary>
        /// Affichage des informations des Évaluations
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            string ret = "\nVoici les évaluations de MetalliFoo:\n";

            foreach (Evaluation evaluation in ListEvaluations)
            {
                ret += evaluation.ToString() + "\n|||||||||||||||||||||||||||||||||||\n";
            }
            ret += "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";
            return ret;
        }

    }
}