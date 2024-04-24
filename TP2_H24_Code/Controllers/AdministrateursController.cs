using Microsoft.AspNetCore.Mvc;
using TP2_H24_Code.Models;

namespace TP2_H24_Code.Controllers
{
    public class AdministrateursController : Controller
    {
        private string pathComplet = "../TP2_H24_Code/JSON/Utilisateurs/Utilisateurs.json";

        /// <summary>
        /// Vérifie si l'utilisateur est un administrateur et retourne la vue des administrateurs si c'est le cas.
        /// </summary>
        /// <param name="message"> le message de bienvenue sur la page</param>
        /// <returns></returns>
        public IActionResult Index(string message = "")
        {
            if ((string)TempData["TypeUtilisateur"] == EnumRole.Admin.ToString())
            {
                //ViewBag.Message = "Bienvenue sur la page des administrateurs";

                CatalogueUtilisateurs catalogueUtilisateurs = new CatalogueUtilisateurs(pathComplet);
                ViewBag.MessageConfirmation = message;


                return View(catalogueUtilisateurs.SetUtilisateurs);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        /// <summary>
        ///  Méthode qui permet de supprimer un utilisateur du JSON des utilisateurs en validant si le courriel correspond à un utilisateur dans le JSON
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SuppressionUtilisateur()
        {
            CatalogueUtilisateurs catalogueUtilisateurs = new CatalogueUtilisateurs(pathComplet);

            string messageConfirmation = "";

            Utilisateur utilisateurASuprimer = new Utilisateur();
            bool utilisateurValide = false;
            string courrielUtilisateurASupprimer = Request.Form["courriel"];

            IEnumerable<Utilisateur> utilisateurQuery = catalogueUtilisateurs.ChercherCourrielEntre(catalogueUtilisateurs, courrielUtilisateurASupprimer);


            if (utilisateurQuery.First<Utilisateur>().AdresseCourriel.Equals(courrielUtilisateurASupprimer))
            {
                utilisateurASuprimer = utilisateurQuery.First<Utilisateur>();
                utilisateurValide = true;
            }


            if (!utilisateurValide)
            {
                messageConfirmation = "Erreur lors de la suppression, utilisateur introuvable dans la base de donnée!";

            }
            else
            {
                catalogueUtilisateurs.Supprimer(utilisateurASuprimer);
                catalogueUtilisateurs.Sauvegarder(pathComplet);
                messageConfirmation = utilisateurASuprimer.Prenom + " " + utilisateurASuprimer.Nom + " a bien été supprimé.";

            }
            return RedirectToAction("Index", new { message = messageConfirmation });
        }

        /// <summary>
        /// Si l'utilisateur est un administrateur, retourne la vue de la liste des médias administrateur qui affiche seulement un titre sinon retourne à l'accueil.
        /// </summary>
        /// <param name="message"> le titre de la page</param>
        /// <returns></returns>
        public IActionResult MediasAdministrateur(string message = "")
        {
            if ((string)TempData["TypeUtilisateur"] == EnumRole.Admin.ToString())
            {
                ViewBag.Message = "Affichage de tous les médias ici...";
                return View();

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


        }
    }
}
