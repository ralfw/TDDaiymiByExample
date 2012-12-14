using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesktopCalculator.domain
{
    interface INumberAssembler
    {
        int Add_digit(string digit);
        int Number { get; set; }
    }
}
