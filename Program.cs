using System;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class CalculatorForm : Form
    {
        private TextBox? display;
        private double currentValue = 0;
        private string currentOperator = "";
        private bool isNewValue = true;

        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Calculator";
            this.Size = new System.Drawing.Size(300, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Display TextBox
            display = new TextBox();
            display.Location = new System.Drawing.Point(10, 10);
            display.Size = new System.Drawing.Size(260, 40);
            display.Font = new System.Drawing.Font("Arial", 16);
            display.TextAlign = HorizontalAlignment.Right;
            display.ReadOnly = true;
            display.Text = "0";
            this.Controls.Add(display);

            // Buttons
            string[] buttons = { "7", "8", "9", "/", "4", "5", "6", "*", "1", "2", "3", "-", "0", "C", "=", "+" };

            int x = 10, y = 60;
            foreach (string btnText in buttons)
            {
                Button btn = new Button();
                btn.Text = btnText;
                btn.Size = new System.Drawing.Size(60, 60);
                btn.Location = new System.Drawing.Point(x, y);
                btn.Font = new System.Drawing.Font("Arial", 14);
                btn.Click += Button_Click;
                this.Controls.Add(btn);

                x += 65;
                if (x > 200)
                {
                    x = 10;
                    y += 65;
                }
            }
        }

        private void Button_Click(object? sender, EventArgs e)
        {
            Button btn = (Button)(sender ?? throw new InvalidOperationException("Sender is null"));
            string buttonText = btn.Text;

            if (char.IsDigit(buttonText[0]) || buttonText == ".")
            {
                if (isNewValue)
                {
                    display!.Text = buttonText;
                    isNewValue = false;
                }
                else
                {
                    display!.Text += buttonText;
                }
            }
            else if (buttonText == "C")
            {
                display!.Text = "0";
                currentValue = 0;
                currentOperator = "";
                isNewValue = true;
            }
            else if (buttonText == "=")
            {
                if (!string.IsNullOrEmpty(currentOperator))
                {
                    double secondValue = double.Parse(display!.Text);
                    double result = Calculate(currentValue, secondValue, currentOperator);
                    display!.Text = result.ToString();
                    currentValue = result;
                    currentOperator = "";
                    isNewValue = true;
                }
            }
            else // operators
            {
                if (!isNewValue)
                {
                    currentValue = double.Parse(display!.Text);
                    currentOperator = buttonText;
                    isNewValue = true;
                }
                else
                {
                    currentOperator = buttonText;
                }
            }
        }

        private double Calculate(double first, double second, string op)
        {
            switch (op)
            {
                case "+": return first + second;
                case "-": return first - second;
                case "*": return first * second;
                case "/": return second != 0 ? first / second : 0;
                default: return 0;
            }
        }
    }

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CalculatorForm());
        }
    }
}
