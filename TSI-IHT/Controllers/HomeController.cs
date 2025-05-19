using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSI_IHT.Models;

namespace TSI_IHT.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new ListOfRisks
            {
                Risks = new List<RiskObject>
                {
                    new RiskObject { ID = 1, Name = "Risk 1", Description = "Description 1", TP = LevelOfRisc.Low, VL = LevelOfRisc.Medium, SEV = LevelOfRisc.High, DET = LevelOfRisc.Medium, Recommendation = "Recommendation 1" },
                    new RiskObject { ID = 2, Name = "Risk 2", Description = "Description 2", TP = LevelOfRisc.Medium, VL = LevelOfRisc.High, SEV = LevelOfRisc.Low, DET = LevelOfRisc.Medium, Recommendation = "Recommendation 2" },
                }
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