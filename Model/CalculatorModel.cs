namespace CalculatorApp.Model;

/// <summary>
/// Класс, предоставляющий функциональность для вычисления математических выражений.
/// </summary>
public class CalculatorModel
{
    /// <summary>
    /// Вычисляет результат математического выражения, переданного в виде строки.
    /// </summary>
    /// <param name="expression">Математическое выражение в виде строки.</param>
    /// <returns>Результат вычисления выражения в виде числа с плавающей запятой.</returns>
    public double Evaluate(string expression)
    {
        var parser = new ExpressionParser();
        return parser.ParseAndEvaluate(expression);
    }
}