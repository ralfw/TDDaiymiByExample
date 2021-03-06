﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DesktopCalculator.domain;
using DesktopCalculator.ui;
using NUnit.Framework;
using Application = System.Windows.Forms.Application;

namespace DesktopCalculator.tests
{
    [TestFixture]
    public class test_UI
    {
        [Test, Explicit]
        public void Run()
        {
            var app = new MockApplication();
            var sut = new UI(app);

            Application.Run(sut);
        }
    }

    class MockApplication : IApplication
    {
        public int Assemble_number(string digit)
        {
            Console.WriteLine("Digit: {0}", digit);
            return int.Parse(digit)*10;
        }

        public int Calculate(string op)
        {
            Console.WriteLine("Calculate({0})", op);

            if (op == "/") throw new DivideByZeroException();

            return DateTime.Now.Second;
        }
    }

}
