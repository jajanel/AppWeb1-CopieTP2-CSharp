using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TP2_H24_Code.Models
{
    public class Utilisateur
    {
        /// <summary>
        /// Champs pour la classe
        /// </summary>
        private string adresseCourriel;
        private string motDePasse; //Ajouter de la securite
        private string nom;
        private string prenom;
        private EnumRole role;
        private HashSet<Media> favoris; //favoris du user (Media)
        private HashSet<Evaluation> evaluations = new HashSet<Evaluation>();

        /// <summary>
        /// Regex pour validation
        /// </summary>
        Regex regexCourriel = new Regex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");
        //Mot de Passe doit avoir 8 caractères, au moins une lettre majuscule, au moins une lettre minuscule, au moins 1 chiffre, au moins un caractère spécial (Le regex ne prends pas les accents) 
        Regex regexMotDePasse = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
        //Regex de nom, Ne prends pas en compte les accents.
        Regex regexNom = new Regex("^[A-Za-z\\s\\-.']+$");


        /// <summary>
        /// Constructeur avec tous les champs
        /// </summary>
        /// <param name="adresseCourriel"></param>
        /// <param name="motDePasse"></param>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="role"></param>
        /// <param name="favoris"></param>
        /// <param name="evaluations"></param>
        public Utilisateur( string adresseCourriel, string motDePasse, string nom, string prenom, EnumRole role, HashSet<Media> favoris, HashSet<Evaluation> evaluations)
        {
            this.AdresseCourriel = adresseCourriel;
            this.MotDePasse = motDePasse;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Role = role;
            this.Favoris = favoris;
            this.Evaluations = evaluations;
        }

        /// <summary>
        /// Constructeur avec nom et mot de passe de l'utilisateur
        /// </summary>
        /// <param name="adresseCourriel"></param>
        /// <param name="motDePasse"></param>
        public Utilisateur(string adresseCourriel, string motDePasse)
        {
            this.adresseCourriel = adresseCourriel;
            this.motDePasse = motDePasse;
        }

        /// <summary>
        /// Constructeur par defaut
        /// </summary>
        public Utilisateur()
        {
            Favoris = new HashSet<Media>();

        }

        public string AdresseCourriel { get => adresseCourriel; set { if (!regexCourriel.IsMatch(value)) { throw new FormatException("Format adresse courriel non valide"); } else { adresseCourriel = value; } } }
        public string MotDePasse { get => motDePasse; set { if (!regexMotDePasse.IsMatch(value)) { throw new FormatException("Mot de passe non valide"); } else { motDePasse = value; } } }
        public string Nom { get => nom; set { if (!regexNom.IsMatch(value)) { throw new FormatException("Nom Invalide!"); } else { nom = value; } } }
        public string Prenom { get => prenom; set { if (!regexNom.IsMatch(value)) { throw new FormatException("Prénom Invalide!"); } else { prenom = value; } } }
        public EnumRole Role { get => role; set { if (!Enum.IsDefined(typeof(EnumRole), value)) { throw new MemberAccessException("Role Inexistant!"); } else { role = value; } } }
        //Favoris peut être vide, mais pas null!
        public HashSet<Media> Favoris { get => favoris; set { if (value == null) { throw new FormatException("Favoris Invalide!"); } else { favoris = value; } } }
        public HashSet<Evaluation> Evaluations { get => evaluations; set { if (value == null) { throw new FormatException("Evaluations Invalide!"); } else { evaluations = value; } } }

        /// <summary>
        /// Prends un media en paramêtre et l'ajoute aux favoris
        /// </summary>
        /// <param name="mediaFavori"></param>
        public void AjouterFavori(Media mediaFavori)
        {
            favoris.Add(mediaFavori);
        }

        public void SupprimerFavoris(Media mediaSupprimer)
        {
            favoris.Remove(mediaSupprimer);
        }


        /// <summary>
        /// Prends les informations ainsi que les paramêtres demandé pour les ajouter dans une évaluation
        /// </summary>
        /// <param name="idMedia"></param>
        /// <param name="cote"></param>
        /// <param name="description"></param>
        public void CreerEvalutation(int idMedia, int cote, string description)
        {
            Evaluation evaluation = new Evaluation();
            evaluation.PrenomUtilisateur = this.prenom;
            evaluation.NomUtilisateur = this.nom;
            evaluation.IdMedia = idMedia;
            evaluation.Cote = cote;
            evaluation.Description = description;

            evaluations.Add(evaluation);
        }

        /// <summary>
        /// Redéfinision du == et du != sur l'objet Utilisateur
        /// </summary>
        /// <param name="op1"></param>
        /// <param name="op2"></param>
        public static bool operator ==(Utilisateur op1, Utilisateur op2)
        {
            return (op1.Equals(op2));
        }

        /// <summary>
        /// Redéfinision du == et du != sur l'objet Utilisateur
        /// </summary>
        /// <param name="op1"></param>
        /// <param name="op2"></param>
        public static bool operator !=(Utilisateur op1, Utilisateur op2)
        {
            return !(op1.Equals(op2));
        }


        /// <summary>
        /// Redéfinition du equals sur l'adresse courriel de l'utilisateur
        /// </summary>
        /// <param name="obj"></param>
        public override bool Equals(object? obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;

            }

            return obj is Utilisateur utilisateur &&
                   AdresseCourriel == utilisateur.AdresseCourriel;
        }

        /// <summary>
        /// Redéfinition de la méthode sur l'adresse courriel de l'utilisateur
        /// </summary>
        public override int GetHashCode()
        {
            return HashCode.Combine(AdresseCourriel);
        }

        /// <summary>
        /// Affichage des informations des Utilisateurs
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string retour = "";
            retour = "Nom: " + Prenom + " " + Nom + "\nAdresse courriel: " + AdresseCourriel + "\nRole: " + Role;

            return retour;
        }
    }
}
