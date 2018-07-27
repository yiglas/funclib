using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class BitAndShould
    {
        [Test]
        public void BitAnd_should_allow_radix_notation()
        {
            var actual = bitAnd(0b1100, 0b1001);

            Assert.AreEqual(8, actual);
        }

        [Test]
        public void BitAnd_should_allow_numbers_to_be_passed()
        {
            var actual = bitAnd(12, 9);

            Assert.AreEqual(8, actual);
        }

        [Test]
        public void BitAnd_should_allow_hexidecimal_to_be_passed()
        {
            var actual = bitAnd(0x08, 0xFF);

            Assert.AreEqual(8, actual);
        }

        [Test]
        public void BitAnd_should_allow_params()
        {
            var actual = bitAnd(12, 9, 12);

            Assert.AreEqual(8, actual);
        }
    }
}
