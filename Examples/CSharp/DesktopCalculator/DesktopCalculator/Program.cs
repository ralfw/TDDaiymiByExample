using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DesktopCalculator.domain;
using DesktopCalculator.ui;
using Application = System.Windows.Forms.Application;

namespace DesktopCalculator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UI(new domain.Application(new NumberAssembler(), new Calculator())));
        }
    }
}
