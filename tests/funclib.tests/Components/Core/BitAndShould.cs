using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class BitAndShould
    {
        [Test]
        public void BitAnd_should_allow_radix_notation()
        {
            var actual = funclib.Core.BitAnd(0b1100, 0b1001);

            Assert.AreEqual(8, actual);
        }

        [Test]
        public void BitAnd_should_allow_numbers_to_be_passed()
        {
            var actual = funclib.Core.BitAnd(12, 9);

            Assert.AreEqual(8, actual);
        }

        [Test]
        public void BitAnd_should_allow_hexidecimal_to_be_passed()
        {
            var actual = funclib.Core.BitAnd(0x08, 0xFF);

            Assert.AreEqual(8, actual);
        }

        [Test]
        public void BitAnd_should_allow_params()
        {
            var actual = funclib.Core.BitAnd(12, 9, 12);

            Assert.AreEqual(8, actual);
        }
    }
}
