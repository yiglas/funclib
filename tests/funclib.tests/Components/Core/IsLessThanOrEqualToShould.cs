using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class IsLessThanOrEqualToShould
    {
        [Test]
        public void IsLessThanOrEqualTo_should_return_true_if_passed_one_value()
        {
            Assert.IsTrue((bool)funclib.Core.IsLessThanOrEqualTo(1));
        }

        [Test]
        public void IsLessThanOrEqualTo_should_return_true_if_nums_are_lesser()
        {
            Assert.IsTrue((bool)funclib.Core.IsLessThanOrEqualTo(1, 2));
        }

        [Test]
        public void IsLessThanOrEqualTo_should_return_true_if_nums_are_equal()
        {
            Assert.IsTrue((bool)funclib.Core.IsLessThanOrEqualTo(2, 2));
        }

        [Test]
        public void IsLessThanOrEqualTo_should_return_false_if_nums_are_not_lesser()
        {
            Assert.IsFalse((bool)funclib.Core.IsLessThanOrEqualTo(2, 1));
        }

        [Test]
        public void IsLessThanOrEqualTo_should_return_true_if_all_nums_are_lesser()
        {
            Assert.IsTrue((bool)funclib.Core.IsLessThanOrEqualTo(-1, 0, 1, 2));
        }
    }
}
