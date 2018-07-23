using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class IsLessThanShould
    {
        [Test]
        public void IsLessThan_should_return_true_if_passed_one_value()
        {
            Assert.IsTrue((bool)isLessThan(1));
        }

        [Test]
        public void IsLessThan_should_return_true_if_nums_are_lesser()
        {
            Assert.IsTrue((bool)isLessThan(1, 2));
        }

        [Test]
        public void IsLessThan_should_return_false_if_nums_are_equal()
        {
            Assert.IsFalse((bool)isLessThan(2, 2));
        }

        [Test]
        public void IsLessThan_should_return_false_if_nums_are_not_lesser()
        {
            Assert.IsFalse((bool)isLessThan(2, 1));
        }

        [Test]
        public void IsLessThan_should_return_true_if_all_nums_are_lesser()
        {
            Assert.IsTrue((bool)isLessThan(-1, 0, 1, 2));
        }
    }
}
