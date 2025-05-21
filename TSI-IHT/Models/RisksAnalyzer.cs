using System.Collections.Generic;

namespace TSI_IHT.Models
{
    public enum LevelOfRisc
    {
        none = 0,
        Low = 1,
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
                totalRisk/= Risks.Count;
                
                if (totalRisk < 6) return LevelOfRisc.Low;
                return totalRisk < 18 ? LevelOfRisc.Medium : LevelOfRisc.High;
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
                totalRisk/= Risks.Count;

                if (totalRisk < 6) return LevelOfRisc.Low;
                return totalRisk < 18 ? LevelOfRisc.Medium : LevelOfRisc.High;
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
                totalRisk/= Risks.Count;

                if (totalRisk < 6) return LevelOfRisc.Low;
                return totalRisk < 18 ? LevelOfRisc.Medium : LevelOfRisc.High;
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
                totalRisk/= Risks.Count;

                if (totalRisk < 6) return LevelOfRisc.Low;
                return totalRisk < 18 ? LevelOfRisc.Medium : LevelOfRisc.High;
            }
        }
    }
}