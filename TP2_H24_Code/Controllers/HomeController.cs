using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Diagnostics;
using TP2_H24_Code.Models;

namespace TP2_H24_Code.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string pathComplet = "../TP2_H24_Code/JSON/Utilisateurs/Utilisateurs.json";


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Permet de garder les informations de l'utilisateur en mémoire et de les afficher dans la vue Index.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            if (TempData["MessageErreurConnexion"] != null)
            {
                ViewBag.MessageErreurConnection = TempData["MessageErreurConnexion"].ToString();
            }

            if (TempData["MessageErreurInscription"] != null)
            {
                ViewBag.MessageErreur = TempData["MessageErreurInscription"].ToString();
                if (TempData["PrenomAvantErreur"] != null)
                {
                    ViewBag.PrenomPreErreur = TempData["PrenomAvantErreur"].ToString();
                    if (TempData["NomAvantErreur"] != null)
                    {
                        ViewBag.NomPreErreur = TempData["NomAvantErreur"].ToString();
                        if (TempData["CourrielAvantErreur"] != null)
                        {
                            ViewBag.CourrielPreErreur = TempData["CourrielAvantErreur"].ToString();
                        }
                    }
                }
            }

            TempData.Clear();
            return View();
        }

     

        /// <summary>
        /// Permet de rediriger vers la View des administrateurs lorsque l'action GoToAdminstrateur est appelé.
        /// </summary>
        /// <returns> la redirection</returns>
        public IActionResult GoToAdministateurs()
        {
            return RedirectToAction("Index", "Administrateurs");
        }


        /// <summary>
        /// Permet de rediriger vers la View des Utilisateurs lorsque l'action GoToUtilisateurs est appelé.
        /// </summary>
        /// <returns> la redirection</returns>
        public IActionResult GoToUtilisateurs()
        {
            return RedirectToAction("PageTousLesMedias", "Utilisateurs");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




        /// <summary>
        /// Fonction qui permet vérifier si les informations de connexion sont valides et redirige vers la page des utilisateurs si elles le sont.
        /// Vérifie si les informations de connexion correspondent à un compte administrateur et redirige vers la page des administrateur.
        /// </summary>
        /// <returns> redirect to page des utilisateur ou la page des administrateurs.</returns>
        [HttpPost]
        public IActionResult SeConnecter()
        {
            {

                string courriel = Request.Form["courriel"];
                string motDePasse = Request.Form["motDePasse"];

                Utilisateur utilisateurConnecte = new Utilisateur();
                CatalogueUtilisateurs catalogueUtilisateurs = new CatalogueUtilisateurs(pathComplet);

                bool utilisateurValide = false;
                bool estUnAdministrateur = false;
                
                foreach (Utilisateur utilisateur in catalogueUtilisateurs.SetUtilisateurs)
                {

                    if (utilisateur.AdresseCourriel == courriel && utilisateur.MotDePasse == motDePasse)
                    {
                        utilisateurValide = true;
                        utilisateurConnecte = utilisateur;
                        TempData["PrenomUtilisateur"] = utilisateur.Prenom;
                        TempData["NomUtilisateur"] = utilisateur.Nom;
                        TempData["CourrielUtilisateur"] = utilisateur.AdresseCourriel;
                        TempData["TypeUtilisateur"] = utilisateur.Role.ToString();
                        TempData.Keep();

                        if (utilisateur.Role == EnumRole.Admin)
                        {
                            estUnAdministrateur = true;
                        }
                    }
                }
                if (!utilisateurValide)
                {
                    TempData["MessageErreurConnexion"] = "Adresse courriel ou mot de passe invalide!";
                    return RedirectToAction("Index");
                }
                if (estUnAdministrateur)
                {

                    return RedirectToAction("GoToAdministateurs");
                }
                else
                {
                    return RedirectToAction("GoToUtilisateurs");
                }
            }
        }


        /// <summary>
        /// Permet a un utilisateur de s'inscrire et redirige vers la page des utilisateurs.
        /// </summary>
        /// <returns> La vue de l'index pour que l'utilisateur se connecte après s'être inscrit.</returns>
        [HttpPost]
        public IActionResult Sinscrire()
        {
            try
            {
                CatalogueUtilisateurs catalogueUtilisateurs = new CatalogueUtilisateurs(pathComplet);
                Utilisateur utilisateur = new Utilisateur();

                utilisateur.Prenom = Request.Form["prenom"];
                TempData["PrenomAvantErreur"] = utilisateur.Prenom;

                utilisateur.Nom = Request.Form["nom"];
                TempData["NomAvantErreur"] = utilisateur.Nom;

                utilisateur.AdresseCourriel = Request.Form["courriel"];
                TempData["CourrielAvantErreur"] = utilisateur.AdresseCourriel;

                utilisateur.MotDePasse = Request.Form["motDePasse"];

                utilisateur.Role = EnumRole.Utilisateur;

                // Initialize Favoris as an empty HashSet

                catalogueUtilisateurs.Ajouter(utilisateur);
                catalogueUtilisateurs.Sauvegarder(pathComplet);

                TempData["MessageErreurInscription"] = "Veuillez maintenant vous connecter";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["MessageErreurInscription"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
