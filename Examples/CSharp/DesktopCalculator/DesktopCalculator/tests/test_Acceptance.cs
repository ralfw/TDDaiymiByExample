using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesktopCalculator.domain;
using NUnit.Framework;

namespace DesktopCalculator.tests
{
    [TestFixture]
    public class test_Acceptance
    {
        [Test]
        public void Run()
        {
            var sut = new Calculator();
            Assert.AreEqual(2, sut.Calculate(2, "+"));
            Assert.AreEqual(5, sut.Calculate(3, "*"));
            Assert.AreEqual(20, sut.Calculate(4, "="));
            Assert.AreEqual(20, sut.Calculate(20, "+"));
            Assert.AreEqual(27, sut.Calculate(7, "="));
            Assert.AreEqual(8, sut.Calculate(8, "/"));
            Assert.Throws<DivideByZeroException>(() => sut.Calculate(0, "="));
            Assert.AreEqual(4, sut.Calculate(2, "="));
        }
    }
}
