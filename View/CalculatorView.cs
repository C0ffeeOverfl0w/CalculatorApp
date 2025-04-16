namespace CalculatorApp;

/// <summary>
/// Представляет визуальный интерфейс калькулятора.
/// </summary>
public partial class CalculatorView : Form, ICalculatorView
{
    private TextBox txtExpression;
    private TableLayoutPanel layoutRoot;
    private TableLayoutPanel buttonPanel;

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="CalculatorView"/>.
    /// </summary>
    public CalculatorView()
    {
        InitializeComponent();
        InitializeControls();
        new CalculatorPresenter(this);
    }

    /// <inheritdoc/>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Expression
    {
        get => txtExpression.Text;
        set => txtExpression.Text = value;
    }

    /// <inheritdoc/>
    public event EventHandler<string> InputReceived;

    /// <inheritdoc/>
    public event EventHandler CalculateClicked;

    /// <inheritdoc/>
    public event EventHandler ClearClicked;

    /// <inheritdoc/>
    public event EventHandler BackspaceClicked;

    /// <summary>
    /// Инициализирует элементы управления калькулятора.
    /// </summary>
    private void InitializeControls()
    {
        this.Text = "MVP Calculator";
        this.Size = new Size(800, 1000);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;

        layoutRoot = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            RowCount = 2,
            ColumnCount = 1
        };
        layoutRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 100));
        layoutRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
        Controls.Add(layoutRoot);

        txtExpression = new TextBox
        {
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 28F),
            TextAlign = HorizontalAlignment.Right,
            ReadOnly = true
        };
        layoutRoot.Controls.Add(txtExpression, 0, 0);

        buttonPanel = new TableLayoutPanel
        {
            RowCount = 5,
            ColumnCount = 4,
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 20F),
            BackColor = Color.LightGray,
            Padding = new Padding(10)
        };

        for (int i = 0; i < 4; i++)
            buttonPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        for (int i = 0; i < 5; i++)
            buttonPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));

        string[] buttons =
        {
                "7", "8", "9", "/",
                "4", "5", "6", "*",
                "1", "2", "3", "-",
                "0", ".", "=", "+",
                "C", "←", "(", ")"
            };

        foreach (var btnText in buttons)
        {
            var btn = new Button
            {
                Text = btnText,
                Dock = DockStyle.Fill,
                Margin = new Padding(5),
                BackColor = Color.White,
                Font = new Font("Segoe UI", 22F)
            };
            btn.Click += (s, e) => HandleButtonClick(btn.Text);
            buttonPanel.Controls.Add(btn);
        }

        layoutRoot.Controls.Add(buttonPanel, 0, 1);
    }

    /// <summary>
    /// Обрабатывает нажатие кнопки калькулятора.
    /// </summary>
    /// <param name="input">Операция</param>
    private void HandleButtonClick(string input)
    {
        switch (input)
        {
            case "=": CalculateClicked?.Invoke(this, EventArgs.Empty); break;
            case "C": ClearClicked?.Invoke(this, EventArgs.Empty); break;
            case "←": BackspaceClicked?.Invoke(this, EventArgs.Empty); break;
            default: InputReceived?.Invoke(this, input); break;
        }
    }
}