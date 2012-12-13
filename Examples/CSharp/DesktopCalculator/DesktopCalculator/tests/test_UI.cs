using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NUnit.Framework;

namespace DesktopCalculator.tests
{
    [TestFixture]
    public class test_UI
    {
        [Test, Explicit]
        public void Run()
        {
            var calc = new MockCalculator();
            var sut = new UI(calc);

            Application.Run(sut);
        }
    }

    class MockCalculator : ICalculator
    {
        public int Calculate(int number, string op)
        {
            Console.WriteLine("Calculate({0}, {1})", number, op);

            if (number == 0) throw new DivideByZeroException();

            return DateTime.Now.Second;
        }
    }
}
