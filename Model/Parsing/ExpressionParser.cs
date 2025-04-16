using CalculatorApp.Model.Operations;

namespace CalculatorApp.Model.Parsing;

/// <summary>
/// Класс для парсинга и вычисления математических выражений.
/// Поддерживает преобразование инфиксной записи в постфиксную и вычисление результата.
/// </summary>
public class ExpressionParser
{
    /// <summary>
    /// Парсит строку с математическим выражением и вычисляет его результат.
    /// </summary>
    /// <param name="expression">Математическое выражение в инфиксной записи.</param>
    /// <returns>Результат вычисления выражения.</returns>
    public double ParseAndEvaluate(string expression)
    {
        var postfix = InfixToPostfix(expression);
        return EvaluatePostfix(postfix);
    }

    /// <summary>
    /// Преобразует математическое выражение из инфиксной записи в постфиксную.
    /// </summary>
    /// <param name="input">Математическое выражение в инфиксной записи.</param>
    /// <returns>Очередь строк, представляющих выражение в постфиксной записи.</returns>
    private Queue<string> InfixToPostfix(string input)
    {
        var output = new Queue<string>();
        var ops = new Stack<char>();
        var number = "";

        int Precedence(char op) => op switch { '+' or '-' => 1, '*' or '/' => 2, _ => 0 };

        foreach (char c in input.Replace(" ", string.Empty))
        {
            if (char.IsDigit(c) || c == '.')
            {
                number += c;
            }
            else if (c == '(')
            {
                if (!string.IsNullOrEmpty(number)) { output.Enqueue(number); number = ""; }
                ops.Push(c);
            }
            else if (c == ')')
            {
                if (!string.IsNullOrEmpty(number)) { output.Enqueue(number); number = ""; }
                while (ops.Count > 0 && ops.Peek() != '(')
                    output.Enqueue(ops.Pop().ToString());
                if (ops.Count == 0 || ops.Pop() != '(')
                    throw new FormatException("Mismatched parentheses");
            }
            else
            {
                if (!string.IsNullOrEmpty(number)) { output.Enqueue(number); number = ""; }
                while (ops.Count > 0 && Precedence(ops.Peek()) >= Precedence(c))
                    output.Enqueue(ops.Pop().ToString());
                ops.Push(c);
            }
        }

        if (!string.IsNullOrEmpty(number)) output.Enqueue(number);

        while (ops.Count > 0)
        {
            var op = ops.Pop();
            if (op == '(' || op == ')') throw new FormatException("Mismatched parentheses");
            output.Enqueue(op.ToString());
        }

        return output;
    }

    /// <summary>
    /// Вычисляет результат выражения, представленного в постфиксной записи.
    /// </summary>
    /// <param name="tokens">Очередь строк, представляющих выражение в постфиксной записи.</param>
    /// <returns>Результат вычисления выражения.</returns>
    private double EvaluatePostfix(Queue<string> tokens)
    {
        var stack = new Stack<double>();

        while (tokens.Count > 0)
        {
            var token = tokens.Dequeue();
            if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out var number))
            {
                stack.Push(number);
            }
            else
            {
                if (stack.Count < 2) throw new InvalidOperationException("Invalid expression format.");
                var b = stack.Pop();
                var a = stack.Pop();
                var strategy = OperationFactory.Get(token);
                stack.Push(strategy.Execute(a, b));
            }
        }

        return stack.Pop();
    }
}