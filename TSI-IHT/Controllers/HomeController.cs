using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.WebPages;
using Newtonsoft.Json;
using TSI_IHT.Models;

namespace TSI_IHT.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var jsonString = System.IO.File.ReadAllText("C:\\Users\\kboddya\\Project\\TSI-IHT\\Questions.json");

            var risks = JsonConvert.DeserializeObject<List<RiskObject>>(jsonString);

            var model = new ListOfRisks
            {
                Risks = risks ?? new List<RiskObject>()
            };
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(ListOfRisks model)
        {
            if (model.CompanyName.IsEmpty ()) model.CompanyName = "Noname";
            model.Risks.RemoveAll(x=> x.Risk == LevelOfRisc.none);
            return View(model);
        }
    }
}