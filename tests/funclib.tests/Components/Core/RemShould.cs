using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class RemShould
    {
        [Test]
        public void Rem_should_return_the_remainder_of_two_numbers()
        {
            var expected = 1;
            var actual = rem(10, 9);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Rem_should_return_zero_if_no_remainder()
        {
            var expected = 0;
            var actual = rem(2, 2);

            Assert.AreEqual(expected, actual);
        }
    }
}
