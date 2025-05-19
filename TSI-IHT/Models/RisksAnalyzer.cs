using System.Collections.Generic;

namespace TSI_IHT.Models
{
    public enum LevelOfRisc
    {
        none = 100,
        Low = 0,
        Medium = 12,
        High = 25
    }
    
    public class RiskObject
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public LevelOfRisc TP { get; set; }
        
        public LevelOfRisc VL { get; set; }
        
        public LevelOfRisc SEV { get; set; }
        
        public LevelOfRisc DET { get; set; }

        public LevelOfRisc Risk { get; set; } = LevelOfRisc.none;
        
        public string Recommendation { get; set; }
    }
    
    public class ListOfRisks
    {
        public string CompanyName { get; set; }
        
        public List<RiskObject> Risks { get; set; }
        
        public ListOfRisks()
        {
            Risks = new List<RiskObject>();
        }
        
        public int GlobalRisk
        {
            get
            {
                int totalRisk = 0;
                foreach (var riskObject in Risks)
                {
                    totalRisk += (int)riskObject.TP + (int)riskObject.VL + (int)riskObject.SEV + (int)riskObject.DET;
                }
                totalRisk/= Risks.Count;
                return totalRisk;
            }
        }
    }
}