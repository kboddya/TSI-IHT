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

        public LevelOfRisc TP { get; set; } = LevelOfRisc.none;
        
        public LevelOfRisc VL { get; set; } = LevelOfRisc.none;
        
        public LevelOfRisc SEV { get; set; } = LevelOfRisc.none;
        
        public LevelOfRisc DET { get; set; } = LevelOfRisc.none;

        public LevelOfRisc Risk
        {
            get
            {
                var risk = (int)TP + (int)VL + (int)SEV + (int)DET;
                if (TP == LevelOfRisc.none ||
                    VL == LevelOfRisc.none ||
                    SEV == LevelOfRisc.none ||
                    DET == LevelOfRisc.none)
                {
                    return LevelOfRisc.none;
                }
                else if (risk < 20)
                {
                    return LevelOfRisc.Low;
                }
                else if (risk < 40)
                {
                    return LevelOfRisc.Medium;
                }
                else
                {
                    return LevelOfRisc.High;
                }
            }
        }

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

        public LevelOfRisc TP
        {
            get
            {
                int totalRisk = 0;
                foreach (var riskObject in Risks)
                {
                    totalRisk += (int)riskObject.TP;
                }
                
                if (totalRisk < 20) return LevelOfRisc.Low;
                if (totalRisk < 40) return LevelOfRisc.Medium;
                return LevelOfRisc.High;
            }
        }
        
        public LevelOfRisc VL
        {
            get
            {
                int totalRisk = 0;
                foreach (var riskObject in Risks)
                {
                    totalRisk += (int)riskObject.VL;
                }
                if (totalRisk < 20) return LevelOfRisc.Low;
                return totalRisk < 40 ? LevelOfRisc.Medium : LevelOfRisc.High;
            }
        }
        
        public LevelOfRisc SEV
        {
            get
            {
                int totalRisk = 0;
                foreach (var riskObject in Risks)
                {
                    totalRisk += (int)riskObject.SEV;
                }
                if (totalRisk < 20) return LevelOfRisc.Low;
                return totalRisk < 40 ? LevelOfRisc.Medium : LevelOfRisc.High;
            }
        }
        
        public LevelOfRisc DET
        {
            get
            {
                int totalRisk = 0;
                foreach (var riskObject in Risks)
                {
                    totalRisk += (int)riskObject.DET;
                }
                if (totalRisk < 20) return LevelOfRisc.Low;
                return totalRisk < 40 ? LevelOfRisc.Medium : LevelOfRisc.High;
            }
        }
    }
}