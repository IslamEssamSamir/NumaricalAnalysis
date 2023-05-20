 using Microsoft.AspNetCore.Mvc;
using NumaricalAnalysis.Models;
using NumaricalAnalysis.Services;
using System.Security.Cryptography.X509Certificates;

namespace NumaricalAnalysis.Controllers
{
    //Chapter2..
    public class ChapterTwoController : Controller
    {
        private readonly ISolveMatrix _solveMatrix;

        public ChapterTwoController(ISolveMatrix solveMatrix)
        {
            _solveMatrix = solveMatrix;
        }

        public IActionResult Index()
        {
            
           
            return View(new ChapterTwoFormViewModel());
        }

        [HttpPost]
        public IActionResult SolveMatrix(ChapterTwoFormViewModel model)
        {
            double[,] matrix = new double[3, 4]
            {
                {model.X1, model.X2, model.X3, model.Xr },
                {model.Y1, model.Y2, model.Y3, model.Yr },
                {model.Z1, model.Z2, model.Z3, model.Zr }                              
            };

            List<ChapterTwoResult> Results = _solveMatrix.GaussElimination(matrix, model.IsPivoting);
            model.Steps = Results;


            model.Z = Math.Round(matrix[2, 3] / matrix[2, 2],1);
            model.Y = Math.Round((double)(matrix[1, 3] - (matrix[1, 2] * model.Z)) / matrix[1, 1],1);
            model.X = Math.Round((double)((matrix[0, 3] - (matrix[0, 2] * model.Z + matrix[0, 1] * model.Y)) / matrix[0, 0]),1);

            return View(nameof(Index), model);
        }
    }
}
