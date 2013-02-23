using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NUnit.Framework;

namespace RPNDesktopCalculator.tests
{
    [TestFixture]
    public class test_UI
    {
        [Test, Explicit]
        public void Enter_number_and_display_stack()
        {
            var ui = new UI();

            var list = new List<int>();
            ui.Number_entered += n =>
                {
                    list.Add(n);
                    ui.Display_result(new Tuple<IEnumerable<int>, int>(list, n*10));
                };

            ui.ShowDialog();
        }

        [Test, Explicit]
        public void Press_operator()
        {
            var ui = new UI();

            ui.Operator_pressed += req =>
                {
                    var opnum = (int) req.Item1[0];
                    ui.Display_result(new Tuple<IEnumerable<int>, int>(new[]{opnum}, req.Item2));
                };

            ui.ShowDialog();
        }

        [Test, Explicit]
        public void Drop_number()
        {
            var ui = new UI();

            ui.Number_dropped += () => MessageBox.Show("Drop number!");

            ui.ShowDialog();
        }
    }
}
