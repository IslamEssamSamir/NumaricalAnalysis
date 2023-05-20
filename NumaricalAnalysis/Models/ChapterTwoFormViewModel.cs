using UoN.ExpressiveAnnotations.NetCore.Attributes;

namespace NumaricalAnalysis.Models
{
    public enum UsedMethod { GaussElimination, LUDecomposition, CramerRule };
    public class ChapterTwoFormViewModel
    {
        public UsedMethod usedMethod { get; set; } = UsedMethod.GaussElimination;

        public double X1 { get; set; }
        public double X2 { get; set; }
        public double X3 { get; set; }
        public double Xr { get; set; }

        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }
        public double Yr { get; set; }

        public double Z1 { get; set; }
        public double Z2 { get; set; }
        public double Z3 { get; set; }
        public double Zr { get; set; }

        public bool IsPivoting { get; set; } 

        public List<ChapterTwoResult> Steps { get; set; } = new List<ChapterTwoResult>();


        // FINAL RESULT
        public double? X { get; set; }
        public double? Y { get; set; }
        public double? Z { get; set; }

    }
}
