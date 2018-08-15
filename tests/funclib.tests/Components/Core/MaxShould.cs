using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class MaxShould
    {
        [Test]
        public void Max_should_return_the_value_passed()
        {
            var expected = 100;
            var actual = funclib.Core.Max(100);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Max_should_return_the_max_value_from_passed_in_values()
        {
            var expected = 5;
            var actual = funclib.Core.Max(1, 2, 3, 4, 5);

            Assert.AreEqual(expected, actual);
        }
    }
}
