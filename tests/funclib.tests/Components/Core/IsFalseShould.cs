using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class IsFalseShould
    {
        [Test]
        public void IsFalse_should_return_true_if_an_object_is_false()
        {
            Assert.IsTrue((bool)isFalse(false));
        }

        [Test]
        public void IsFalse_should_return_false_if_an_object_is_not_false()
        {
            Assert.IsFalse((bool)isFalse(1));
            Assert.IsFalse((bool)isFalse(null));
            Assert.IsFalse((bool)isFalse(true));
        }
    }
}
