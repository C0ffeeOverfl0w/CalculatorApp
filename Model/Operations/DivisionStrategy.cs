namespace CalculatorApp.Model.Operations;

/// <summary>
/// Класс, представляющий стратегию выполнения деления.
/// </summary>
public class DivisionStrategy : IOperationStrategy
{
    /// <inheritdoc/>
    public double Execute(double a, double b)
    {
        if (b == 0) throw new DivideByZeroException("Cannot divide by zero");
        return a / b;
    }
}