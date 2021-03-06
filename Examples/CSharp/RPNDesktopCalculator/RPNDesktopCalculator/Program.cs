﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RPNDesktopCalculator.tests;

namespace RPNDesktopCalculator
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

            var ui = new UI();
            var rpn = new RPNCalculator();

            ui.Number_entered += rpn.Push;
            ui.Operator_pressed += rpn.Calculate;
            ui.Number_dropped += rpn.Drop;
            rpn.Result += ui.Display_result;

            Application.Run(ui);
        }
    }
}
