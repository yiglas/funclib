using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class IsGreaterThenOrEqualToShould
    {
        [Test]
        public void IsGreaterThanOrEqualTo_should_return_true_if_passed_one_value()
        {
            Assert.IsTrue((bool)isGreaterThanOrEqualTo(1));
        }

        [Test]
        public void IsGreaterThanOrEqualTo_should_return_true_if_nums_are_greater()
        {
            Assert.IsTrue((bool)isGreaterThanOrEqualTo(2, 1));
        }

        [Test]
        public void IsGreaterThanOrEqualTo_should_return_true_if_nums_are_equal()
        {
            Assert.IsTrue((bool)isGreaterThanOrEqualTo(2, 2));
        }

        [Test]
        public void IsGreaterThanOrEqualTo_should_return_false_if_nums_are_not_greater()
        {
            Assert.IsFalse((bool)isGreaterThanOrEqualTo(1, 2));
        }

        [Test]
        public void IsGreaterThanOrEqualTo_should_return_true_if_all_nums_are_greater()
        {
            Assert.IsTrue((bool)isGreaterThanOrEqualTo(2, 1, 0, -1));
        }
    }
}
