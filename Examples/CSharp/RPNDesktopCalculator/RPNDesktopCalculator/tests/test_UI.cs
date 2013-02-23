using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    ui.Display_result(new Tuple<List<int>, int>(list, n*10));
                };

            ui.ShowDialog();
        }
    }
}
