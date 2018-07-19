using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class RemShould
    {
        [Test]
        public void Rem_should_return_the_remainder_of_two_numbers()
        {
            var expected = 1;
            var actual = new Rem().Invoke(10, 9);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Rem_should_return_zero_if_no_remainder()
        {
            var expected = 0;
            var actual = new Rem().Invoke(2, 2);

            Assert.AreEqual(expected, actual);
        }
    }
}
