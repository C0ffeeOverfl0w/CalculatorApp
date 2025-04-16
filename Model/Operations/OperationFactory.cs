namespace CalculatorApp.Model.Operations;

/// <summary>
/// Фабрика для создания стратегий выполнения математических операций.
/// </summary>
public static class OperationFactory
{
    /// <summary>
    /// Возвращает стратегию выполнения математической операции на основе заданного оператора.
    /// </summary>
    /// <param name="op">Оператор математической операции (например, "+", "-", "*", "/").</param>
    /// <returns>Экземпляр стратегии, реализующей интерфейс <see cref="IOperationStrategy"/>.</returns>
    /// <exception cref="InvalidOperationException">Выбрасывается, если передан неизвестный оператор.</exception>
    public static IOperationStrategy GetStrategy(string op) => op switch
    {
        "+" => new AdditionStrategy(),
        "-" => new SubtractionStrategy(),
        "*" => new MultiplicationStrategy(),
        "/" => new DivisionStrategy(),
        _ => throw new InvalidOperationException("Unknown operation")
    };
}