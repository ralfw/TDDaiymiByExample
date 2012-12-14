using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesktopCalculator.domain
{
    class NumberAssembler : INumberAssembler
    {
        private int _number;
        private bool _numberHasBeenSet;

        public int Add_digit(string digit)
        {
            var d = int.Parse(digit);
            if (_numberHasBeenSet)
            {
                _number = d;
                _numberHasBeenSet = false;
            }
            else
                _number = 10 * _number + d;
            return _number;
        }

        public int Number
        {
            get { return _number; }
            set { _number = value; _numberHasBeenSet = true; }
        }
    }
}
