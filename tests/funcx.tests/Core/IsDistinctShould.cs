using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace FunctionalLibrary.Tests.Core
{
    public class IsDistinctShould
    {
        [Test]
        public void IsDistinct_should_return_true_if_an_object_is_distinct()
        {
            Assert.IsTrue((bool)new IsDistinct().Invoke(1));
            Assert.IsTrue((bool)new IsDistinct().Invoke(1, 2));
            Assert.IsTrue((bool)new IsDistinct().Invoke(1, 2, 3, 4));
        }

        [Test]
        public void IsDistinct_should_return_false_if_an_object_is_not_distinct()
        {
            Assert.IsFalse((bool)new IsDistinct().Invoke(1, 2, 3, 3));
            Assert.IsFalse((bool)new IsDistinct().Invoke(1, 2, 3, 1));
        }
    }
}