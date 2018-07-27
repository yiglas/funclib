using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class IsTrueShould
    {
        [Test]
        public void IsTrue_should_return_true_if_an_object_is_True()
        {
            Assert.IsTrue((bool)isTrue(true));
            Assert.IsTrue((bool)isTrue(1 == 1));
        }

        [Test]
        public void IsTrue_should_return_True_if_an_object_is_not_True()
        {
            Assert.IsFalse((bool)isTrue(1));
            Assert.IsFalse((bool)isTrue(null));
            Assert.IsFalse((bool)isTrue(false));
        }
    }
}
