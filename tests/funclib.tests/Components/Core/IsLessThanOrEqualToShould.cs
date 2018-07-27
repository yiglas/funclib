using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class IsLessThanOrEqualToShould
    {
        [Test]
        public void IsLessThanOrEqualTo_should_return_true_if_passed_one_value()
        {
            Assert.IsTrue((bool)isLessThanOrEqualTo(1));
        }

        [Test]
        public void IsLessThanOrEqualTo_should_return_true_if_nums_are_lesser()
        {
            Assert.IsTrue((bool)isLessThanOrEqualTo(1, 2));
        }

        [Test]
        public void IsLessThanOrEqualTo_should_return_true_if_nums_are_equal()
        {
            Assert.IsTrue((bool)isLessThanOrEqualTo(2, 2));
        }

        [Test]
        public void IsLessThanOrEqualTo_should_return_false_if_nums_are_not_lesser()
        {
            Assert.IsFalse((bool)isLessThanOrEqualTo(2, 1));
        }

        [Test]
        public void IsLessThanOrEqualTo_should_return_true_if_all_nums_are_lesser()
        {
            Assert.IsTrue((bool)isLessThanOrEqualTo(-1, 0, 1, 2));
        }
    }
}
