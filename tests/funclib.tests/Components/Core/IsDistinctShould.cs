using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class IsDistinctShould
    {
        [Test]
        public void IsDistinct_should_return_true_if_an_object_is_distinct()
        {
            Assert.IsTrue((bool)isDistinct(1));
            Assert.IsTrue((bool)isDistinct(1, 2));
            Assert.IsTrue((bool)isDistinct(1, 2, 3, 4));
        }

        [Test]
        public void IsDistinct_should_return_false_if_an_object_is_not_distinct()
        {
            Assert.IsFalse((bool)isDistinct(1, 1));
            Assert.IsFalse((bool)isDistinct(1, 1, 2, 3));
            Assert.IsFalse((bool)isDistinct(1, 2, 3, 3));
            Assert.IsFalse((bool)isDistinct(1, 2, 3, 1));
        }
    }
}