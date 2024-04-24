using Microsoft.AspNetCore.Mvc;
using TP2_H24_Code.Models;

namespace TP2_H24_Code.Controllers
{
    public class UtilisateursController : Controller
    {

        private string pathCompletCatalogueMedia = "../TP2_H24_Code/JSON/media/CatalogueMedia/CatalogueMedia.json";
        private string pathCompletUtilisateurs = "../TP2_H24_Code/JSON/Utilisateurs/Utilisateurs.json";

        /// <summary>
        /// Méthode qui permet de retourner la page de tous les médias si l'utilisateur connecté est un simple utilisateur
        /// </summary>
        /// <returns> la vue du catalogue, ou la page index si quelqu'un non-connecté tente d'accéder à la page.</returns>
        public IActionResult PageTousLesMedias()
        {
            if ((string)TempData["TypeUtilisateur"] == EnumRole.Utilisateur.ToString())
            {
                TempData.Keep();
                CatalogueMedia catalogueMedia = new CatalogueMedia(pathCompletCatalogueMedia);
                return View(catalogueMedia);

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        /// <summary>
        /// Si l'utilisateur est connecté, retourne la page de ses favoris avec la liste des médias favoris de l'utilisateur du JSON.
        /// </summary>
        /// <returns> la vue de la liste des favoris, ou la page index si quelqu'un non-connecté tente d'accéder à la page.</returns>
        public IActionResult PageMesFavoris()
        {
            if ((string)TempData["TypeUtilisateur"] == EnumRole.Utilisateur.ToString())
            {
                CatalogueUtilisateurs catalogueUtilisateurs = new CatalogueUtilisateurs(pathCompletUtilisateurs);
                TempData.Keep();
                string courriel = null;
                if (TempData.ContainsKey("courrielUtilisateur"))
                {
                    courriel = (string)TempData["courrielUtilisateur"];
                    IEnumerable<Utilisateur> utilisateurQuery = catalogueUtilisateurs.ChercherCourrielEntre(catalogueUtilisateurs, courriel);


                    return View(utilisateurQuery.First<Utilisateur>());
                }
                else
                {
                    TempData.Clear();
                    return View("Index");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }


        /// <summary>
        /// Méthode qui permet de retourner la page détaillée du média si l'utilisateur connecté est un simple utilisateur.
        /// </summary>
        /// <param name="id"> l'id du média qui a été cliqué</param>
        /// <returns> la vue du média avec informations détaillées, ou la page index si quelqu'un non-connecté tente d'accéder à la page.</returns>
        public IActionResult PageDetailleDuMedia(int id)
        {
            if ((string)TempData["TypeUtilisateur"] == EnumRole.Utilisateur.ToString())
            {
                CatalogueMedia catalogueMedia = new CatalogueMedia(pathCompletCatalogueMedia);

                IEnumerable<Media> mediaQuery = catalogueMedia.chercherMediaSelonId(id, catalogueMedia);


                return View(mediaQuery.First<Media>());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        /// <summary>
        /// Retourne la page erreur
        /// </summary>
        /// <returns> la vue de la page d'erreur, ou la page index si quelqu'un non-connecté tente d'accéder à la page.</returns>
        public IActionResult PageErreur()
        {
            if ((string)TempData["TypeUtilisateur"] == EnumRole.Utilisateur.ToString())
            {
                return View("PageErreur");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        /// <summary>
        /// Méthode qui permet d'ajouter un média à la liste de médias favoris JSON de l'utilisateur connecté en utilisant l'id du média.
        /// </summary>
        /// <param name="id"> id du médias a ajouter à l aliste de favoris</param>
        /// <returns> La vue de la page mes favoris</returns>
        public IActionResult AjouterFavoris(int id)
        {

            TempData.Keep("courrielUtilisateur");
            string courriel = null;

            CatalogueUtilisateurs catalogueUtilisateurs = new CatalogueUtilisateurs(pathCompletUtilisateurs);
            CatalogueMedia catalogueMedia = new CatalogueMedia(pathCompletCatalogueMedia);
            Utilisateur utilisateur = new Utilisateur();

            if (TempData.ContainsKey("courrielUtilisateur"))
            {
                courriel = (string)TempData["courrielUtilisateur"];

                IEnumerable<Utilisateur> utilisateurQuery = catalogueUtilisateurs.ChercherCourrielEntre(catalogueUtilisateurs, courriel);


                IEnumerable<Media> mediaQuery = catalogueMedia.chercherMediaSelonId(id, catalogueMedia);

                utilisateur = utilisateurQuery.First<Utilisateur>();

                utilisateur.AjouterFavori(mediaQuery.First<Media>());
                catalogueUtilisateurs.Sauvegarder(pathCompletUtilisateurs);
            }

            return RedirectToAction("PageMesFavoris");
        }

        /// <summary>
        /// Méthode qui permet de supprimer un média de la liste de médias favoris JSON de l'utilisateur connecté en utilisant l'id du média.
        /// </summary>
        /// <returns> la page mes favoris</returns>
        [HttpPost]
        public IActionResult SupprimerFavoris()
        {
            TempData.Keep();
            string courriel = null;

            CatalogueUtilisateurs catalogueUtilisateurs = new CatalogueUtilisateurs(pathCompletUtilisateurs);
            CatalogueMedia catalogueMedia = new CatalogueMedia(pathCompletCatalogueMedia);
            Utilisateur utilisateur = new Utilisateur();


            int idFavoris = Int32.Parse(Request.Form["id"]);

            if (TempData.ContainsKey("courrielUtilisateur"))
            {
                courriel = (string)TempData["courrielUtilisateur"];

                IEnumerable<Utilisateur> utilisateurQuery = catalogueUtilisateurs.ChercherCourrielEntre(catalogueUtilisateurs, courriel);


                IEnumerable<Media> mediaQuery = catalogueMedia.chercherMediaSelonId(idFavoris, catalogueMedia);

                utilisateur = utilisateurQuery.First<Utilisateur>();

                utilisateur.SupprimerFavoris(mediaQuery.First<Media>());
                catalogueUtilisateurs.Sauvegarder(pathCompletUtilisateurs);
            }


            return RedirectToAction("PageMesFavoris");
        }
    }
}
