using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class IsGreaterThenShould
    {
        [Test]
        public void IsGreaterThan_should_return_true_if_passed_one_value()
        {
            Assert.IsTrue((bool)funclib.Core.IsGreaterThan(1));
        }

        [Test]
        public void IsGreaterThan_should_return_true_if_nums_are_greater()
        {
            Assert.IsTrue((bool)funclib.Core.IsGreaterThan(2, 1));
        }

        [Test]
        public void IsGreaterThan_should_return_false_if_nums_are_equal()
        {
            Assert.IsFalse((bool)funclib.Core.IsGreaterThan(2, 2));
        }

        [Test]
        public void IsGreaterThan_should_return_false_if_nums_are_not_greater()
        {
            Assert.IsFalse((bool)funclib.Core.IsGreaterThan(1, 2));
        }

        [Test]
        public void IsGreaterThan_should_return_true_if_all_nums_are_greater()
        {
            Assert.IsTrue((bool)funclib.Core.IsGreaterThan(2, 1, 0, -1));
        }
    }
}
