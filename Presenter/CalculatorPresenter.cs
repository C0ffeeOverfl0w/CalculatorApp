namespace CalculatorApp.Presenter;

/// <summary>
/// Презентер для управления взаимодействием
/// между представлением
/// и моделью калькулятора.
/// </summary>
public class CalculatorPresenter
{
    private readonly ICalculatorView _view;
    private readonly CalculatorModel _model = new();

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="CalculatorPresenter"/> с указанным представлением.
    /// </summary>
    /// <param name="view">Интерфейс представления калькулятора.</param>
    public CalculatorPresenter(ICalculatorView view)
    {
        _view = view;

        _view.InputReceived += (s, input) => _view.Expression += input;
        _view.ClearClicked += (s, e) => _view.Expression = string.Empty;
        _view.BackspaceClicked += (s, e) =>
        {
            if (!string.IsNullOrEmpty(_view.Expression))
                _view.Expression = _view.Expression[..^1];
        };
        _view.CalculateClicked += OnCalculate;
    }

    /// <summary>
    /// Обрабатывает событие нажатия кнопки "Вычислить".
    /// Выполняет вычисление выражения и обновляет результат в представлении.
    /// </summary>
    /// <param name="sender">Источник события.</param>
    /// <param name="e">Аргументы события.</param>
    private void OnCalculate(object sender, EventArgs e)
    {
        try
        {
            _view.Expression = _model.Evaluate(_view.Expression).ToString();
        }
        catch (Exception ex)
        {
            _view.Expression = $"Error: {ex.Message}";
        }
    }
}