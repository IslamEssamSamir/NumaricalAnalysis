using NumaricalAnalysis.Models;

namespace NumaricalAnalysis.Services
{
    public interface ISolveMatrix
    {
         List<ChapterTwoResult> GaussElimination(double[,] matrix, bool IsPivoting);
        public List<ChapterTwoResult> CramerRule(double[,] matrix, out double x1, out double x2, out double x3);
    }
}
