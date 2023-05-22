using NumaricalAnalysis.Models;

namespace NumaricalAnalysis.Services
{
    public interface ISolveMatrix
    {
         List<ChapterTwoResult> GaussElimination(double[,] matrix, bool IsPivoting);
        List<ChapterTwoResult> LUDecomposition(double[,] matrix, bool IsPivoting, double[] matrixC, double[] matrixX);
        public List<ChapterTwoResult> CramerRule(double[,] matrix, out double x1, out double x2, out double x3);
    }
}
