namespace NumaricalAnalysis.Models
{
    public class Bisection
    {
        public byte Iteration { get; set; }
        public double Xl { get; set; }
        public double F_Xl { get; set; }

        public double Xu { get; set; }
        public double F_Xu { get; set; }

        public double Xr { get; set; }
        public double F_Xr { get; set; }

        public double Error { get; set; }

    }
}
