using System.Text.RegularExpressions;

namespace WilliamN_MarcOlivierG_Tp1_H24_Code
{
    public class Evaluation
    {
        private int idMedia;
        private int idUtilisateur;
        private int cote;
        private string nomUtilisateur;
        private string prenomUtilisateur;
        private string description;

        /// <summary>
        /// Regex pour validation
        /// </summary>
        Regex regexCourriel = new Regex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");
        //Mot de Passe doit avoir 8 caractères, au moins une lettre majuscule, au moins une lettre minuscule, au moins 1 chiffre, au moins un caractère spécial (Le regex ne prends pas les accents) 
        Regex regexMotDePasse = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
        //Regex de nom, Ne prends pas en compte les accents.
        Regex regexNom = new Regex("/^ [a-z ,.'-]+$/i");


        /// <summary>
        /// Consructeur par defaut
        /// </summary>
        public Evaluation()
        {
        }

        /// <summary>
        /// Constructeur avec seulement idMedia et idUtilisateur
        /// </summary>
        /// <param name="idMedia"></param>
        /// <param name="idUtilisateur"></param>
        public Evaluation(int idMedia, int idUtilisateur)
        {
            this.IdMedia = idMedia;
            this.IdUtilisateur = idUtilisateur;
        }
        /// <summary>
        /// Constructeur contenant tous les paramêtres
        /// </summary>
        /// <param name="idMedia"></param>
        /// <param name="idUtilisateur"></param>
        /// <param name="cote"></param>
        /// <param name="nomUtilisateur"></param>
        /// <param name="prenomUtilisateur"></param>
        /// <param name="description"></param>
        public Evaluation(int idMedia, int idUtilisateur, int cote, string nomUtilisateur, string prenomUtilisateur, string description)
        {
            this.IdMedia = idMedia;
            this.IdUtilisateur = idUtilisateur;
            this.Cote = cote;
            this.NomUtilisateur = nomUtilisateur;
            this.PrenomUtilisateur = prenomUtilisateur;
            this.Description = description;
        }

        /// <summary>
        ///Get/set pour les paramêtre de constructeur complet
        /// </summary>

        /// <summary>
        ///IdMedia ne doit pas être plus petit que 0.
        /// </summary>
        public int IdMedia { get => idMedia; set { if (value < 0) { throw new ArgumentOutOfRangeException("Identifiant Média Invalide!"); } else { idMedia = value; } } }
        /// <summary>
        ///IdUtilisateur ne doit pas être plus petit que 0.
        /// </summary>
        public int IdUtilisateur { get => idUtilisateur; set { if (value < 0) { throw new ArgumentOutOfRangeException("Identifiant Utilisateur Invalide!"); } else { idUtilisateur = value; } } }
        /// <summary>
        ///La Cote doit être entre 0 et 5.
        /// </summary>
        public int Cote { get => cote; set { if (value < 0 || value > 5) { throw new ArgumentOutOfRangeException("Cote Invalide!"); } else { cote = value; } } }
        /// <summary>
        ///Le NomUtilisateur doit être composé uniquement de lettres.
        /// </summary>
        public string NomUtilisateur { get => nomUtilisateur; set { if (!regexNom.IsMatch(value) || value == null) { throw new FormatException("Nom Invalide!"); } else { nomUtilisateur = value; } } }
        /// <summary>
        ///Le PrenomUitlisateur doit être composé uniquement de lettres.
        /// </summary>
        public string PrenomUtilisateur { get => prenomUtilisateur; set { if (!regexNom.IsMatch(value) || value == null) { throw new FormatException("Prénom Invalide!"); } else { prenomUtilisateur = value; } } }
        /// <summary>
        ///La description doit être plus petite que 200 charactères.
        /// </summary>
        public string Description { get => description; set { if (value.Length > 200 || value == null) { throw new ArgumentOutOfRangeException("Description trop longue ou null!"); } else { description = value; } } }


        /// <summary>
        /// Redéfinision du == et du != sur l'objet Evaluation
        /// </summary>
        /// <param name="op1"></param>
        /// <param name="op2"></param>
        /// <returns></returns>
        public static bool operator ==(Evaluation op1, Evaluation op2)
        {
            return (op1.Equals(op2));
        }

        /// <summary>
        /// Redéfinision du == et du != sur l'objet Evaluation
        /// </summary>
        /// <param name="op1"></param>
        /// <param name="op2"></param>
        /// <returns></returns>
        public static bool operator !=(Evaluation op1, Evaluation op2)
        {
            return !(op1.Equals(op2));
        }

        /// <summary>
        /// Redéfinition du equals sur le idMedia et idUtilisateur d'évaluation
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;

            }

            return obj is Evaluation evaluation &&
                   idMedia == evaluation.idMedia &&
                   idUtilisateur == evaluation.idUtilisateur;
        }

        /// <summary>
        /// Redéfinition de la méthode sur le idMedia et idUtilisateur d'évaluation
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(idMedia, idUtilisateur);
        }


        /// <summary>
        /// Format d'affichage d'une évaluation.
        /// </summary>
        public override string ToString()
        {
            string retour = "";
            retour = "Cote: " + Cote + "\nNom de l'utilisateur: " + prenomUtilisateur + " " + NomUtilisateur + "\nDescription: " + Description;
               

            return retour;
        }
    }

}