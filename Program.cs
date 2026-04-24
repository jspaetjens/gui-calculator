using System;
using System.Data;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class CalculatorForm : Form
    {
        private TextBox? display;
        private string expression = "";

        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Advanced Calculator";
            this.Size = new System.Drawing.Size(500, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.ForeColor = System.Drawing.Color.White;

            // Display TextBox
            display = new TextBox();
            display.Location = new System.Drawing.Point(10, 10);
            display.Size = new System.Drawing.Size(460, 40);
            display.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold);
            display.TextAlign = HorizontalAlignment.Left;
            display.ReadOnly = true;
            display.Text = "";
            display.BackColor = System.Drawing.Color.FromArgb(50, 50, 50);
            display.ForeColor = System.Drawing.Color.White;
            display.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(display);

            // Buttons
            string[] buttons = {
                "7", "8", "9", "/", "sin", "cos",
                "4", "5", "6", "*", "tan", "log",
                "1", "2", "3", "-", "ln", "sqrt",
                "0", ".", "=", "+", "^", "(",
                "C", "x", "pi", ")", "e"
            };

            int x = 10, y = 70;
            int buttonWidth = 70;
            int buttonHeight = 50;
            foreach (string btnText in buttons)
            {
                Button btn = new Button();
                btn.Text = btnText;
                btn.Size = new System.Drawing.Size(buttonWidth, buttonHeight);
                btn.Location = new System.Drawing.Point(x, y);
                btn.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
                btn.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
                btn.ForeColor = System.Drawing.Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
                btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(80, 80, 80);
                btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(100, 100, 100);
                btn.Click += Button_Click;
                this.Controls.Add(btn);

                x += buttonWidth + 10;
                if (x > 450)
                {
                    x = 10;
                    y += buttonHeight + 10;
                }
            }
        }

        private void Button_Click(object? sender, EventArgs e)
        {
            Button btn = (Button)(sender ?? throw new InvalidOperationException("Sender is null"));
            string buttonText = btn.Text;

            if (buttonText == "C")
            {
                expression = "";
                display!.Text = expression;
            }
            else if (buttonText == "=")
            {
                try
                {
                    var result = new DataTable().Compute(expression, null);
                    display!.Text = result.ToString();
                    expression = result.ToString();
                }
                catch
                {
                    display!.Text = "Error";
                    expression = "";
                }
            }
            else
            {
                expression += buttonText;
                display!.Text = expression;
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
