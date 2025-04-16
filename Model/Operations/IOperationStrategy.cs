namespace CalculatorApp.Model.Operations;

/// <summary>
/// Интерфейс, представляющий стратегию выполнения математической операции.
/// </summary>
public interface IOperationStrategy
{
    /// <summary>
    /// Выполняет математическую операцию над двумя числами.
    /// </summary>
    /// <param name="a">Первое число.</param>
    /// <param name="b">Второе число.</param>
    /// <returns>Результат выполнения операции.</returns>
    double Execute(double a, double b);
}