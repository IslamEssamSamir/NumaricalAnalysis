using NumaricalAnalysis.Models;

namespace NumaricalAnalysis.Services
{
    public interface ISolveMatrix
    {
         List<ChapterTwoResult> GaussElimination(double[,] matrix, bool IsPivoting);
    }
}
