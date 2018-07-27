using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class IsNegIntShould
    {
        [Test]
        public void IsNegInt_should_return_true_if_an_object_is_negative_int()
        {
            Assert.IsTrue((bool)isNegInt(-1));
        }

        [Test]
        public void IsNegInt_should_return_false_if_an_object_is_not_negative_int()
        {
            Assert.IsFalse((bool)isNegInt(1));
            Assert.IsFalse((bool)isNegInt(null));
            Assert.IsFalse((bool)isNegInt(0));
            Assert.IsFalse((bool)isNegInt((double)-1));
        }
    }
}
