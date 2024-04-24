using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WilliamN_MarcOlivierG_Tp1_H24_Code;


namespace WilliamN_MarcOlivierG_Tp1_H24_Code
{

    public class Media
    {

        Evaluation evaluation = new Evaluation();
        CatalogueEvaluations catalogueEvaluation = new CatalogueEvaluations();


        /// <summary>
        /// Champs contenu dans le Media
        /// </summary>
        private int identifiant;
        private string nomMedia;
        private int evaluationCote;
        private EnumGenreDeMedia genreDeMedia;
        private List<Evaluation> evaluationUtilisateur;
        private string dateRealisation;
        private int dureeSecondes;
        private string auteur;
        private string producteur;
        private string audioExtrait;
        private string audioComplet;
        private string image;
        private string album;

        /// <summary>
        /// Constructeur par defaut
        /// </summary>
        public Media()
        {
        }

        /// <summary>
        /// Constructeur avec identifiant
        /// </summary>
        /// <param name="identifiant"></param>
        public Media(int identifiant)
        {
            this.identifiant = identifiant;
        }


        /// <summary>
        /// Constructeur avec tous les paramêtres
        /// </summary>
        /// <param name="identifiant"></param>
        /// <param name="nomMedia"></param>
        /// <param name="evaluationCote"></param>
        /// <param name="genreDeMedia"></param>
        /// <param name="evaluationUtilisateur"></param>
        /// <param name="dateRealisation"></param>
        /// <param name="dureeSecondes"></param>
        /// <param name="auteur"></param>
        /// <param name="producteur"></param>
        /// <param name="audioExtrait"></param>
        /// <param name="audioComplet"></param>
        /// <param name="image"></param>
        /// <param name="album"></param>
        public Media(int identifiant, string nomMedia, int evaluationCote, EnumGenreDeMedia genreDeMedia, List<Evaluation> evaluationUtilisateur, string dateRealisation, int dureeSecondes, string auteur, string producteur, string audioExtrait, string audioComplet, string image, string album)
        {
            this.identifiant = identifiant;
            this.NomMedia = nomMedia;
            this.evaluationCote = evaluationCote;
            this.genreDeMedia = genreDeMedia;
            this.EvaluationUtilisateur = evaluationUtilisateur;
            this.DateRealisation = dateRealisation;
            this.DureeSecondes = dureeSecondes;
            this.Auteur = auteur;
            this.Producteur = producteur;
            this.AudioExtrait = audioExtrait;
            this.AudioComplet = audioComplet;
            this.Image = image;
            this.Album = album;
        }

        /// <summary>
        /// Get/set pour les champs
        /// </summary>
        public int Identifiant { get => identifiant; set => identifiant = value; }
        public string NomMedia { get => nomMedia; set => nomMedia = value; } 
        /// <summary>
        /// EvaluationCote ne doit pas être plus petit que 0 ou plus grand que 5. lance une erreur si c'est le cas
        /// </summary>
        public int EvaluationCote { get => evaluationCote; set { if (value < 0 || value > 5) { throw new ArgumentOutOfRangeException("Entrez une valeur entre 0 et 5"); } else { evaluationCote = MoyenneCote(); } } }
        /// <summary>
        /// Si le type choisi n'est pas valide, une erreur est lancé
        /// </summary>
        public EnumGenreDeMedia GenreDeMedia { get => genreDeMedia; set { if (!Enum.IsDefined(typeof(EnumGenreDeMedia), value)) { throw new FormatException("Type de Genre Invalide"); } else { genreDeMedia = value; } } }
        //La liste d'evaluation peut être vide, mais pas null!
        public List<Evaluation> EvaluationUtilisateur { get => evaluationUtilisateur; set { if (value == null) { throw new FormatException("Evaluation Utilisateur Invalide!"); } else { evaluationUtilisateur = value; } } }
        //La valeur ne peut pas etre null. Si elle est vide, la string N/A sera mis à la place
        public string DateRealisation { get => dateRealisation; set { if (value == null) { throw new FormatException("Date de Realisation Invalide!"); } else if (value.Length == 0) { dateRealisation = "N/A"; } else { dateRealisation = value; } } }
        public int DureeSecondes { get => dureeSecondes; set { if (dureeSecondes <= 0) { throw new FormatException("Duree Invalide!"); } else { dureeSecondes = value; } } }
        //La valeur ne peut pas etre null. Si elle est vide, la string N/A sera mis à la place
        public string Auteur { get => auteur; set { if (value == null) { throw new FormatException("Auteur Invalide!"); } else if (value.Length == 0) { auteur = "N/A"; } else { auteur = value; } } }
        //La valeur ne peut pas etre null. Si elle est vide, la string N/A sera mis à la place
        public string Producteur { get => producteur; set { if (value == null) { throw new FormatException("Producteur Invalide!"); } else if (value.Length == 0) { producteur = "N/A"; } else { producteur = value; } } }
        public string AudioExtrait { get => audioExtrait; set => audioExtrait = value; }
        public string AudioComplet { get => audioComplet; set => audioComplet = value; }
        public string Image { get => image; set => image = value; }
        public string Album { get => album; set => album = value; }


        /// <summary>
        /// Ajoute les evaluations des utilisateurs dans la liste d'évaluation du media.
        /// Parcours Chaque évaluation de chaque utilisateur, si cette évaluation parle du media, on l'ajoute à sa liste.
        /// </summary>
        public void ajouterEvaluation(CatalogueUtilisateurs utilisateurs)
        {
            foreach(Utilisateur utilisateur in utilisateurs.setUtilisateurs) {
                foreach(Evaluation evaluation in utilisateur.Evaluations)
                {
                    if(evaluation.IdMedia == this.identifiant)
                    {
                        evaluationUtilisateur.Add(evaluation);
                    }
                }
            }

        }

        /// <summary>
        /// Redéfinision du == et du != sur l'objet Media
        /// </summary>
        /// <param name="op1"></param>
        /// <param name="op2"></param>
        /// <returns></returns>
        public static bool operator ==(Media op1, Media op2)
        {
            return (op1.Equals(op2));
        }

        /// <summary>
        /// Redéfinision du == et du != sur l'objet Media
        /// </summary>
        /// <param name="op1"></param>
        /// <param name="op2"></param>
        /// <returns></returns>
        public static bool operator !=(Media op1, Media op2)
        {
            return !(op1.Equals(op2));
        }


        /// <summary>
        /// Redéfinition du equals sur l'Identifiant de media
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;

            }

            return obj is Media media &&
                   Identifiant == media.Identifiant;
        }
        /// <summary>
        /// Redéfinition de la méthode sur l'Identifiant de media
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Identifiant);
        }

        public int MoyenneCote()
        {
            List<Evaluation> evaluationUtilisateur = catalogueEvaluation.ListEvaluations;

            int somme = 0;
            int total = 0;
            foreach (Evaluation evaluation in evaluationUtilisateur)
            {
                if (evaluation.IdMedia == this.Identifiant)
                {
                    somme += evaluation.Cote;
                    total++;
                }
            }
            if (total != 0)
            {
                return somme / total;
            }
            else return evaluation.Cote;
        }



        /// <summary>
        /// Affichage des informations des Évaluations
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string retour = "";


            retour = "Identifiant: " + Identifiant + "\nChanson: " + NomMedia + "\nGenre: " + GenreDeMedia + "\nDurée: " + DureeSecondes + "\nImage: "
             + Image + "\nAudio Complet: " + AudioComplet + "\nAudio Extrait: " + AudioExtrait + "\nDate de réalisation: " + DateRealisation
            + "\nAuteur: " + Auteur + " \nProducteur: " + Producteur
             + "\nCote: " + EvaluationCote + "\n\nÉvaluation:\n" + string.Join("\n++++++++++++\n", EvaluationUtilisateur);


            return retour;
        }
    }
}


