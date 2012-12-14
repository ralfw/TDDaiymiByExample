using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesktopCalculator.domain;
using NUnit.Framework;

namespace DesktopCalculator.tests
{
    [TestFixture]
    public class test_NumberAssembler
    {
        [Test]
        public void First_digit_is_returned_as_number()
        {
            var sut = new NumberAssembler();
            Assert.AreEqual(2, sut.Add_digit("2"));
        }

        [Test]
        public void Next_digit_is_added_to_number()
        {
            var sut = new NumberAssembler();
            sut.Add_digit("2");
            Assert.AreEqual(23, sut.Add_digit("3"));
        }

        [Test]
        public void Read_number()
        {
            var sut = new NumberAssembler();
            sut.Add_digit("2");
            Assert.AreEqual(2, sut.Number);
        }

        [Test]
        public void Set_number_and_read_it()
        {
            var sut = new NumberAssembler();
            sut.Number = 23;
            Assert.AreEqual(23, sut.Number);
        }

        [Test]
        public void Set_number_and_send_a_digit()
        {
            var sut = new NumberAssembler();
            sut.Number = 23;
            Assert.AreEqual(9, sut.Add_digit("9"));
        }
    }
}
