namespace CalculatorApp.View;

/// <summary>
/// Интерфейс представления калькулятора, предоставляющий свойства и события для взаимодействия с пользователем.
/// </summary>
public interface ICalculatorView
{
    /// <summary>
    /// Выражение, введенное пользователем.
    /// </summary>
    string Expression { get; set; }

    /// <summary>
    /// Результат вычисления выражения.
    /// </summary>

    event EventHandler<string> InputReceived;

    /// <summary>
    /// Событие, возникающее при нажатии кнопки "Вычислить".
    /// </summary>
    event EventHandler CalculateClicked;

    /// <summary>
    /// Событие, возникающее при нажатии кнопки "Очистить".
    /// </summary>
    event EventHandler ClearClicked;

    /// <summary>
    /// Событие, возникающее при нажатии кнопки "Удалить последний символ".
    /// </summary>
    event EventHandler BackspaceClicked;
}