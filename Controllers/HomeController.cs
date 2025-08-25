using Microsoft.AspNetCore.Mvc;

using TPLOCAL1.Models;

//Subject is find at the root of the project and the logo in the wwwroot/ressources folders of the solution
//--------------------------------------------------------------------------------------
//Careful, the MVC model is a so-called convention model instead of configuration,
//The controller must imperatively be name with "Controller" at the end !!!
namespace TPLOCAL1.Controllers
{
    public class HomeController(IWebHostEnvironment env) : Controller
    {
        //methode "naturally" call by router

        private readonly IWebHostEnvironment _env = env;

        public ActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return View();
            else
            {
                //Call different pages, according to the id pass as parameter
                switch (id)
                {
                    case "OpinionList":
                        var opinionsPath = Path.Combine(_env.WebRootPath ?? "wwwroot", "XMLFile", "DataAvis.xml");
                        var list = new OpinionList().GetAvis(opinionsPath);
                        return View("OpinionList", list);
                    case "Form":
                        return View("Form", new FormModel());
                    default:
                        return View();
                }
            }
        }


        //methode to send datas from form to validation page
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ValidationFormulaire(FormModel model)
        {
            if (model.DateDebut.HasValue && model.DateDebut.Value >= DateTime.Today)
            {
                ModelState.AddModelError(nameof(model.DateDebut), "La date doit être antérieure au " + DateTime.Today.ToString("d") + ".");
            }
            if (string.IsNullOrWhiteSpace(model.Genre))
                ModelState.AddModelError(nameof(model.Genre), "Sélectionnez un sexe.");
            if (string.IsNullOrWhiteSpace(model.TypeFormation))
                ModelState.AddModelError(nameof(model.TypeFormation), "Sélectionnez une formation.");

            if (!ModelState.IsValid)
                return View("Form", model);
            return View("Validation", model);
        }
    }
}