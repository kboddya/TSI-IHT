using System;
using System.Collections.Generic;
using System.Web.Mvc;
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
            foreach (var riskObject in model.Risks)
            {
                var risk = (int)riskObject.TP + (int)riskObject.VL + (int)riskObject.SEV + (int)riskObject.DET;
                if (risk < 20)
                {
                    riskObject.Risk = LevelOfRisc.Low;
                }
                else if (risk < 40)
                {
                    riskObject.Risk = LevelOfRisc.Medium;
                }
                else
                {
                    riskObject.Risk = LevelOfRisc.High;
                }
            }

            return View(model);
        }
    }
}