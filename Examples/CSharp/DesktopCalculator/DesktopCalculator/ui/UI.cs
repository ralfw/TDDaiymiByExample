using System;
using System.Windows.Forms;
using DesktopCalculator.domain;

namespace DesktopCalculator.ui
{
    public partial class UI : Form
    {
        private readonly ICalculator _calc;

        
        public UI(ICalculator calc)
        {
            _calc = calc;
            InitializeComponent();
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
                var result = _calc.Calculate(int.Parse(txtNumber.Text), op);
                txtNumber.Text = result.ToString();
            }
            catch (DivideByZeroException)
            {
                statError.Text = "Division by zero!";
            }

            txtNumber.Focus();
            txtNumber.SelectAll();
        }
    }
}
