using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Tennis.tests
{
    [TestFixture]
    public class test_Winner
    {
        [Test]
        public void Game_still_on()
        {
            Assert.AreEqual("", winner);
        }
    }
}
