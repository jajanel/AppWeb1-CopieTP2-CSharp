using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Reflection.PortableExecutable;

namespace TP2_H24_Code.Models
{
    public class CatalogueUtilisateurs : Catalogue
    {
       


        /// <summary>
        /// HashSet dans laquel nous allons ranger les valeurs obtenu du JSON
        /// </summary>
        public HashSet<Utilisateur> setUtilisateurs = null;

        public HashSet<Utilisateur> SetUtilisateurs{ get => setUtilisateurs; set => setUtilisateurs = value; }

        public CatalogueUtilisateurs()
        {
            SetUtilisateurs = new HashSet<Utilisateur>();
        }

        public CatalogueUtilisateurs(String pathComplet)
        {

            SetUtilisateurs = new HashSet<Utilisateur>();
            Ajouter(pathComplet);
        }

        /// <summary>
        /// Méthode ajouter qui prends un utilisateur en paramêtre et l'ajoute dans le HashSet d'utilisateurs
        /// </summary>
        public void Ajouter(Utilisateur utilisateur)
        {
            setUtilisateurs.Add(utilisateur);
        }

        /// <summary>
        /// Methode ajouter surchargé du parent. Celle si convertie l'information contenu dans le fichier JSON et l'ajoute au HashSet.
        /// </summary>
        public void Ajouter(string path)
        {
            setUtilisateurs = JsonConvert.DeserializeObject<HashSet<Utilisateur>>(File.ReadAllText(@path), new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
        }


        /// <summary>
        /// prends en paramêtre deux utilisateurs. 
        /// Appel la méthôde Supprimer et Ajouter(Utilisateur utilisateur) pour remplacer les utilisateurs qui ont le même ID
        /// </summary>
        public void Remplacer(Utilisateur utilisateurAEnlever, Utilisateur utilisateurAMettre)
        {
            if (utilisateurAEnlever.Equals(utilisateurAMettre))
            {
                Supprimer(utilisateurAEnlever);
                Ajouter(utilisateurAMettre);

            }
        }

        /// <summary>
        /// Supprime l'utilisateur reçu en paramêtre du HashSet d'utilisateurs
        /// </summary>
        public void Supprimer(Utilisateur utilisateur)
        {
            setUtilisateurs.Remove(utilisateur);

        }

        /// <summary>
        /// Sérialise ce qui se trouve dans le HashSet d'utilisateurs dans le fichier Json
        /// </summary>
        public void Sauvegarder(string lien)
        {
            string jsonFichier = JsonConvert.SerializeObject(setUtilisateurs, setUtilisateurs.GetType(), Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            File.WriteAllText(lien, jsonFichier);
        }



        public IEnumerable<Utilisateur> ChercherCourrielEntre(CatalogueUtilisateurs catalogueUtilisateurs, string courriel)
        {
            return from utilisateur in catalogueUtilisateurs.SetUtilisateurs
                   where utilisateur.AdresseCourriel == courriel
                   select utilisateur;
        }


        /// <summary>
        /// Format d'affichage du HashSet des utilisateurs
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            String retour = "\nVoici les utilisateurs de MetalliFoo:\n";
            foreach (Utilisateur utilisateur in setUtilisateurs)
            {
                retour += utilisateur.ToString() + "\n|||||||||||||||||||||||||||||||||||\n";
            }
            retour += "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";

            return retour;
        }
    }
}
