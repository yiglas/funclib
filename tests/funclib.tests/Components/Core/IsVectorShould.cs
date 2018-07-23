using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class IsVectorShould
    {
        [Test]
        public void IsVector_should_return_true_if_an_object_is_false()
        {
            Assert.IsTrue((bool)isVector(vector(1, 2, 3)));
            Assert.IsTrue((bool)isVector(vec(new object[] { 1, 2, 3 })));
            Assert.IsTrue((bool)isVector(first(arrayMap(":a", 1, ":b", 2, ":c", 3))));
        }

        [Test]
        public void IsVector_should_return_false_if_an_object_is_not_false()
        {
            Assert.IsFalse((bool)isVector(1));
            Assert.IsFalse((bool)isVector(null));
            Assert.IsFalse((bool)isVector(hashSet(1, 2, 3)));
        }
    }
}
