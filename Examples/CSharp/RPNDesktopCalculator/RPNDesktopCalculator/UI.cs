using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPNDesktopCalculator
{
    public partial class UI : Form
    {
        public UI()
        {
            InitializeComponent();

            lstStack.DrawMode = DrawMode.OwnerDrawFixed;
            lstStack.DrawItem += new DrawItemEventHandler(listBox_DrawItem);
        }

        void listBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index <= -1) return;
            
            var list = (ListBox)sender;
            var item = list.Items[e.Index];
            e.DrawBackground();
            e.DrawFocusRectangle();
            var brush = new SolidBrush(e.ForeColor);
            var itemSize = e.Graphics.MeasureString(item.ToString(), e.Font);
            e.Graphics.DrawString(item.ToString(), e.Font, brush, 
                                  e.Bounds.Left + (e.Bounds.Width - itemSize.Width), 
                                  e.Bounds.Top + (e.Bounds.Height / 2 - itemSize.Height / 2));
        }


        private void btnEnter_Click(object sender, EventArgs e)
        {
            Number_entered(int.Parse(txtCurrentNumber.Text));
        }

        public event Action<int> Number_entered;


        public void Display_result(Tuple<IEnumerable<int>, int> result)
        {
            lstStack.Items.Clear();
            result.Item1.ToList().ForEach(n => lstStack.Items.Add(n.ToString()));
            txtCurrentNumber.Text = result.Item2.ToString();

            txtCurrentNumber.Focus();
            txtCurrentNumber.SelectAll();
        }

    }
}
