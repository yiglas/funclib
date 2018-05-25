using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static funcx.core;

namespace funcx.tests.Core
{
    public class RepeatShould
    {
        [Test]
        public void Repeat_should_return_a_lazy_seq()
        {
            var actual = take(5, repeat("x")).ToArray();

            Assert.AreEqual(5, actual.Length);
            Assert.AreEqual("x", actual[0]);
            Assert.AreEqual("x", actual[4]);
        }

        [Test]
        public void Repeat_should_return_the_number_of_x_specified()
        {
            var actual = repeat(5, "x").ToArray();

            Assert.AreEqual(5, actual.Length);
            Assert.AreEqual("x", actual[0]);
            Assert.AreEqual("x", actual[4]);
        }
    }
}
