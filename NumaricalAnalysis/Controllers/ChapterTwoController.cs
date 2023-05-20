﻿using Microsoft.AspNetCore.Mvc;
using NumaricalAnalysis.Models;
using NumaricalAnalysis.Services;
using static Microsoft.FSharp.Core.ByRefKinds;

namespace NumaricalAnalysis.Controllers
{
    //Chapter2...
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
            ChapterTwoResult.usedMethod = model.usedMethod; // to handle _steps  partial view..
            List<ChapterTwoResult> Results;
            double[,] matrix = new double[3, 4]
            {
                {model.X1, model.X2, model.X3, model.Xr },
                {model.Y1, model.Y2, model.Y3, model.Yr },
                {model.Z1, model.Z2, model.Z3, model.Zr }
            };

            if (model.usedMethod == UsedMethod.GaussElimination)
            {
                Results = _solveMatrix.GaussElimination(matrix, model.IsPivoting);
                model.Steps = Results;


                model.Z = Math.Round(matrix[2, 3] / matrix[2, 2], 1);
                model.Y = Math.Round((double)(matrix[1, 3] - (matrix[1, 2] * model.Z)) / matrix[1, 1], 1);
                model.X = Math.Round((double)((matrix[0, 3] - (matrix[0, 2] * model.Z + matrix[0, 1] * model.Y)) / matrix[0, 0]), 1);

            }
            else if (model.usedMethod == UsedMethod.CramerRule)
            {
                double x1;
                double x2;
                double x3;
                Results = _solveMatrix.CramerRule(matrix, out x1, out x2, out x3);
                model.Steps = Results;

                model.X = x1;
                model.Y = x2;
                model.Z = x3;

            }








            return View(nameof(Index), model);
        }
    }
}
