using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesktopCalculator.domain
{
    class Application : IApplication
    {
        private readonly INumberAssembler _numberAssembler;
        private readonly ICalculator _calculator;

        public Application(INumberAssembler numberAssembler, ICalculator calculator)
        {
            _numberAssembler = numberAssembler;
            _calculator = calculator;
        }


        public int Assemble_number(string digit)
        {
            return _numberAssembler.Add_digit(digit);
        }

        public int Calculate(string op)
        {
            var result = _calculator.Calculate(_numberAssembler.Number, op);
            _numberAssembler.Number = result;
            return _numberAssembler.Number;
        }
    }
}
