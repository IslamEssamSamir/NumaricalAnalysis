namespace NumaricalAnalysis.Models
{
    public class ChapterTwoResult
    {
        public static UsedMethod usedMethod { get; set; }


        public string? Multiplier { get; set; } 
        public string? ResultStep { get; set; }
        public string? UpperOrLowerMatrix { get; set; }
               
        public double[,] Matrix { get; set; } = new double[3,4];

    }
}
