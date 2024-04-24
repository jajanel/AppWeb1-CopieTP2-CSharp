using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Reflection.PortableExecutable;

namespace WilliamN_MarcOlivierG_Tp1_H24_Code
{
    public class CatalogueUtilisateurs : Catalogue
    {
        private string racine = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/ressources/Utilisateurs/Utilisateurs.json";


        /// <summary>
        /// HashSet dans laquel nous allons ranger les valeurs obtenu du JSON
        /// </summary>
        public HashSet<Utilisateur> setUtilisateurs = new HashSet<Utilisateur>();

        public CatalogueUtilisateurs()
        {
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
        /// @racine réfère au champ privé racine. 
        /// </summary>
        public override void Ajouter()
        {
            setUtilisateurs = JsonConvert.DeserializeObject<HashSet<Utilisateur>>(File.ReadAllText(@racine), new JsonSerializerSettings
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
        public override void Sauvegarder()
        {
            string jsonFichier = JsonConvert.SerializeObject(setUtilisateurs, setUtilisateurs.GetType(), Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            File.WriteAllText(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/ressources/Utilisateurs/UtilisateursTest.json", jsonFichier);
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
