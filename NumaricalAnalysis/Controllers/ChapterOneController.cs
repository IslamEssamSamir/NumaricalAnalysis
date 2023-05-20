using Microsoft.AspNetCore.Mvc;
using NumaricalAnalysis.Models;
using NumaricalAnalysis.Helpers;
using MathNet.Symbolics;
using NumaricalAnalysis.Services;

namespace NumaricalAnalysis.Controllers
{
    public class ChapterOneController : Controller
    {
        private readonly IEvaluation _evaluation;

        public ChapterOneController(IEvaluation evaluation)
        {
            _evaluation = evaluation;
        }

        public IActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// BisectionFalsePosition Action
        /// </summary>
        /// <param name="Method Type : Bisection or FalsePosition"></param>
        /// <returns></returns>

        public IActionResult BisectionFalsePosition(MethodType type)
        {




            return View(new BisectionViewModel { methodType = type });
        }

        [HttpPost]
        public IActionResult BisectionFalsePosition(BisectionViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (_evaluation.Evaluate(model.equation, model.XL) * _evaluation.Evaluate(model.equation, model.XU) > 0)
            {
                ModelState.AddModelError("XL", "Root isn't in the interval");
                ModelState.AddModelError("XU", "Root isn't in the interval");
                return View(model);
            }





            double xl = model.XL;
            double xu = model.XU;


            byte iter = 0;
            double xr = 0, xrOld = 0, error = 0;

            do
            {
                xrOld = xr;

                if (model.methodType == MethodType.Bisection)
                    xr = (xl + xu) / 2;
                else if (model.methodType == MethodType.FalsePosition)
                    xr = xu - (_evaluation.Evaluate(model.equation, xu) * (xl - xu)) / (_evaluation.Evaluate(model.equation, xl) - _evaluation.Evaluate(model.equation, xu));


                error = Math.Abs((xr - xrOld) / xr) * 100;

                var row = new Bisection
                {
                    Iteration = iter,
                    Xl = Math.Round(xl, 3),
                    Xu = Math.Round(xu, 3),
                    F_Xl = Math.Round(_evaluation.Evaluate(model.equation, xl), 3),
                    F_Xu = Math.Round(_evaluation.Evaluate(model.equation, xu), 3),
                    Xr = Math.Round(xr, 3),
                    F_Xr = Math.Round(_evaluation.Evaluate(model.equation, xr), 3),
                    Error = Math.Round(error, 3)
                };

                model.TableResult.Add(row);



                if (_evaluation.Evaluate(model.equation, xl) * _evaluation.Evaluate(model.equation, xr) > 0)
                {
                    xl = xr;
                }
                else
                {
                    xu = xr;
                }

                iter++;

            } while (error > model.EPS);

            model.Root = xr;



            return View(model);
        }



        /// <summary>
        /// SimpleFixedPoint Method Action
        /// </summary>
        /// <returns></returns>
        public IActionResult SimpleFixedPoint()
        {
            return View(new SimpleFixedPointViewModel());
        }

        [HttpPost]
        public IActionResult SimpleFixedPoint(SimpleFixedPointViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            byte iter = 0;
            double xi = 0, xipluse1 = 0, error = 0;

            do
            {
                xi = model.Xi;
                xipluse1 = _evaluation.Evaluate(model.equation, xi);
                iter++;
                if (xipluse1 != 0)
                    error = Math.Abs((xipluse1 - xi) / xipluse1) * 100;


                var row = new SimpleFixedPoint
                {
                    Iteration = iter,
                    Xi = Math.Round(xi, 2),
                    XiPluse1 = Math.Round(xipluse1, 2),
                    Error = Math.Round(error, 2)
                };

                model.TableResult.Add(row);


            } while (iter < 9);

            model.Root = xi;






            return View(model);
        }




        /// <summary>
        /// Newton Method Action
        /// </summary>
        /// <returns></returns>
        public IActionResult Newton()
        {
            return View(new NewtonViewModel());
        }

        [HttpPost]
        public IActionResult Newton(NewtonViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            byte iter = 0;
            double xi = model.Xi, error = 0;

            do
            {

                var row = new Newton
                {
                    Iteration = iter,
                    Xi = Math.Round(xi, 3),
                    F_Xi = Math.Round(_evaluation.Evaluate(model.equation, xi), 3),
                    DrivativeF_Xi = Math.Round(_evaluation.EvaluateDerivative(model.equation, xi), 3),
                    Error = Math.Round(error, 3)
                };

                double xiOld = xi;

                xi = xiOld - (_evaluation.Evaluate(model.equation, xi) / _evaluation.EvaluateDerivative(model.equation, xi));
                iter++;
                error = Math.Abs((xi - xiOld) / xi) * 100;

                model.TableResult.Add(row);

            } while (error > model.EPS);

            model.Root = xi;


            return View(model);
        }



        /// <summary>
        /// Secant Method Action
        /// </summary>
        /// <returns></returns>
        public IActionResult Secant()
        {
            return View(new SecantViewModel());
        }

        [HttpPost]
        public IActionResult Secant(SecantViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            byte iter = 0;
            double XMinus1 = model.XMinus1, X0 = model.X0, error = 0;

            do
            {
                var x = X0 - ((_evaluation.Evaluate(model.equation, X0) * (XMinus1 - X0)) / (_evaluation.Evaluate(model.equation, XMinus1) - _evaluation.Evaluate(model.equation, X0)));
                var row = new Secant
                {
                    Iteration = iter,
                    XiMinus1 = Math.Round(XMinus1, 3),
                    F_XiMinus1 = Math.Round(_evaluation.Evaluate(model.equation, XMinus1), 3),
                    Xi = Math.Round(X0, 3),
                    F_Xi = Math.Round(_evaluation.Evaluate(model.equation, X0), 3),
                   
                    Error = Math.Round(error, 3)
                };
                model.TableResult.Add(row);


                XMinus1 = X0;
                X0 = x;
                error = Math.Abs((X0 - XMinus1) / X0) * 100;
                iter++;
               


            } while (error > model.EPS);

            model.Root = XMinus1;


            return View(model);
        }


    }
}