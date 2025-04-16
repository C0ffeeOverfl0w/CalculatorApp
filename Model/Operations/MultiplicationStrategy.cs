namespace CalculatorApp.Model.Operations;

/// <summary>
/// Класс, реализующий стратегию умножения.
/// </summary>
public class MultiplicationStrategy : IOperationStrategy
{
    /// <inheritdoc/>
    public double Execute(double a, double b) => a * b;
}