namespace NumaricalAnalysis.Models
{
    public class ChapterTwoResult
    {
        public string? Multiplier { get; set; } 
        public string? ResultStep { get; set; } 

        public double[,] Matrix { get; set; } = new double[3, 4];


    }
}
