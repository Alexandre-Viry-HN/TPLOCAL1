using Microsoft.AspNetCore.Mvc;
using System.Xml;
using TPLOCAL1.Models;

//Subject is find at the root of the project and the logo in the wwwroot/ressources folders of the solution
//--------------------------------------------------------------------------------------
//Careful, the MVC model is a so-called convention model instead of configuration,
//The controller must imperatively be name with "Controller" at the end !!!
namespace TPLOCAL1.Controllers
{
    public class HomeController : Controller
    {
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
                         
                        var listeAvis = new OpinionList().GetAvis("XlmFile/DataAvis.xml");
                        return View("OpinionList", listeAvis);
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
            if (model.DateDebut.HasValue && model.DateDebut.Value >= new DateTime(2021, 1, 1))
                ModelState.AddModelError(nameof(model.DateDebut), "La date doit être antérieure au 01/01/2021");
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