namespace NumaricalAnalysis.Services
{
    public interface IEvaluation
    {
        double Evaluate(string function, double x);
        double EvaluateDerivative(string equation, double x);
    }
}
