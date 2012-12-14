using System;
using System.Windows.Forms;
using DesktopCalculator.domain;

namespace DesktopCalculator.ui
{
    public partial class UI : Form
    {
        private readonly IApplication _app;

        
        internal UI(IApplication app)
        {
            _app = app;
            InitializeComponent();
        }


        private void btnDigit_click(object sender, EventArgs e)
        {
            txtNumber.Text = _app.Assemble_number(((Button) sender).Text).ToString();
        }

        private void btnOp_Click(object sender, EventArgs e)
        {
            Calculate(((Button)sender).Text);
        }


        private void UI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ("+-*/=".IndexOf(e.KeyChar) < 0) return;

            e.Handled = true;
            Calculate(e.KeyChar.ToString());
        }


        private void Calculate(string op)
        {
            statError.Text = "";
            try
            {
                txtNumber.Text = _app.Calculate(op).ToString();
            }
            catch (DivideByZeroException)
            {
                statError.Text = "Division by zero!";
            }
        }

    }
}
