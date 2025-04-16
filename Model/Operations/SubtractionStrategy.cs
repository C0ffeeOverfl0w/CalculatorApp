namespace CalculatorApp.Model.Operations;

/// <summary>
/// Класс, представляющий стратегию вычитания.
/// </summary>
public class SubtractionStrategy : IOperationStrategy
{
    /// <inheritdoc/>
    public double Execute(double a, double b) => a - b;
}