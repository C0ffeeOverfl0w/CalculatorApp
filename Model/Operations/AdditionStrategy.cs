namespace CalculatorApp.Model.Operations;

/// <summary>
/// Класс, представляющий стратегию сложения двух чисел.
/// </summary>
public class AdditionStrategy : IOperationStrategy
{
    /// <inheritdoc/>
    public double Execute(double a, double b) => a + b;
}