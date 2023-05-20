namespace NumaricalAnalysis.Models
{
    public class Secant
    {
        public byte Iteration { get; set; }

        public double XiMinus1 { get; set; }
        public double F_XiMinus1 { get; set; }

        public double Xi { get; set; }
        public double F_Xi { get; set; }

        
        public double Error { get; set; }
    }
}
