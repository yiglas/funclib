using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class MaxShould
    {
        [Test]
        public void Max_should_return_the_value_passed()
        {
            var expected = 100;
            var actual = new Max().Invoke(100);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Max_should_return_the_max_value_from_passed_in_values()
        {
            var expected = 5;
            var actual = new Max().Invoke(1, 2, 3, 4, 5);

            Assert.AreEqual(expected, actual);
        }
    }
}
