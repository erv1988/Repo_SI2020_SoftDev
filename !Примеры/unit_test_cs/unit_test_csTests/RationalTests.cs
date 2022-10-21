using unit_test_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace unit_test_cs.Tests
{
    [TestClass()]
    public class RationalTests
    {
        [TestMethod()]
        public void MulTest()
        {
            Rational a = new Rational(1, 2);
            Rational b = new Rational(1, 3);
            Rational z = new Rational(0, 5);
            Rational ab = new Rational(1, 6);
            Assert.AreEqual(ab, Rational.Mul(a, b));
            Assert.AreEqual(ab, Rational.Mul(b, a));
            Assert.AreNotEqual(0, Rational.Mul(a, z).Q);
        }
    }
}