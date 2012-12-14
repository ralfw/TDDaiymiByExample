using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesktopCalculator.domain
{
    class NumberAssembler : INumberAssembler
    {
        public int Add_digit(string digit)
        {
            return DateTime.Now.Second;
        }

        public int Number
        {
            get { return DateTime.Now.Second; }
            set {  }
        }
    }
}
