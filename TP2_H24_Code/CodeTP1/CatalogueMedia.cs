
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;



namespace WilliamN_MarcOlivierG_Tp1_H24_Code
{
    public class CatalogueMedia : Catalogue
    {
        // TODO: Faire plus beau
        private string racine = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/ressources/media/CatalogueMedia/CatalogueMedia.json";



        HashSet<Media> setMedias = new HashSet<Media>();
        Evaluation Evaluation;

        public HashSet<Media> SetMedias { get => setMedias; set => setMedias = value; }

        /// <summary>
        /// Constructeur par defaut
        /// </summary>
        public CatalogueMedia()
        {
        }
        /// <summary>
        /// Ajouter qui prends un Media en paremêtre. Ajoute le media au setMedia.
        /// </summary>
        /// <param name="media"></param>
        public void Ajouter(Media media)
        {
            setMedias.Add(media);
        }

        /// <summary>
        ///  Methode ajouter surchargé du parent. Celle si convertie l'information contenu dans le fichier JSON et l'ajoute à la liste.
        /// @recine réfère au champ privé racine. 
        /// </summary>
        public override void Ajouter()
        {

            setMedias = JsonConvert.DeserializeObject<HashSet<Media>>(File.ReadAllText(@racine), new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });


        }

        /// <summary>
        /// Supprime le media reçu en paramêtre de la hashSet des Medias
        /// </summary>
        /// <param name="media"></param>
        public void Supprimer(Media media)
        {
            setMedias.Remove(media);
        }

        /// <summary>
        /// prends en paramêtre deux Media. 
        /// Appel la méthôde Supprimer et Ajouter(Media media) pour remplacer les medias qui ont le même ID
        /// </summary>
        /// <param name="mediaAEnlever"></param>
        /// <param name="mediaAMettre"></param>
        public void Remplacer(Media mediaAEnlever, Media mediaAMettre)
        {
            if (mediaAEnlever.Equals(mediaAMettre))
            {
                Supprimer(mediaAEnlever);
                Ajouter(mediaAMettre);

            }

        }

        /// <summary>
        /// Serialise ce qui se trouve dans le hashSet Media dans le fichier Json
        /// </summary>
        public override void Sauvegarder()
        {
            string jsonFichier = JsonConvert.SerializeObject(setMedias, setMedias.GetType(), Formatting.Indented, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            File.WriteAllText(racine, jsonFichier);
        }

        /// <summary>
        /// Affichage des informations des Medias
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            String retour = "\nVoici les chansons de MetalliFoo:\n";
            foreach (Media media in setMedias)
            {
                retour += media.ToString() + "\n|||||||||||||||||||||||||||||||||||\n";
            }
            retour += "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";
            return retour;
        }


    }
}
