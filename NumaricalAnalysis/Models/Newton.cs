namespace NumaricalAnalysis.Models
{
    public class Newton
    {
        public byte Iteration { get; set; }
        public double Xi { get; set; }
        public double F_Xi { get; set; }
        public double DrivativeF_Xi { get; set; }

       

        public double Error { get; set; }
    }
}
