using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class IsTrueShould
    {
        [Test]
        public void IsTrue_should_return_true_if_an_object_is_True()
        {
            Assert.IsTrue((bool)new IsTrue().Invoke(true));
            Assert.IsTrue((bool)new IsTrue().Invoke(1 == 1));
        }

        [Test]
        public void IsTrue_should_return_True_if_an_object_is_not_True()
        {
            Assert.IsFalse((bool)new IsTrue().Invoke(1));
            Assert.IsFalse((bool)new IsTrue().Invoke(null));
            Assert.IsFalse((bool)new IsTrue().Invoke(false));
        }
    }
}
