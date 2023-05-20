using MathNet.Symbolics;
using NumaricalAnalysis.Services;

namespace NumaricalAnalysis.Helpers
{
    public class Evaluation : IEvaluation
    {
        public double Evaluate(string function, double x)
        {
            SymbolicExpression equation = SymbolicExpression.Parse(function);
            Dictionary<string, FloatingPoint> variables = new Dictionary<string, FloatingPoint> { { "x", x } };
            double result = equation.Evaluate(variables).RealValue;
            return result;
        }

        public double EvaluateDerivative(string equation, double x)
        {
            double h = 0.0001;
            return (Evaluate(equation, x + h) - Evaluate(equation, x - h)) / (2 * h);
        }


    }
}
