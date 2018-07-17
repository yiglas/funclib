using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class IsFalseShould
    {
        [Test]
        public void IsFalse_should_return_true_if_an_object_is_false()
        {
            Assert.IsTrue((bool)new IsFalse().Invoke(false));
        }

        [Test]
        public void IsFalse_should_return_false_if_an_object_is_not_false()
        {
            Assert.IsFalse((bool)new IsFalse().Invoke(1));
            Assert.IsFalse((bool)new IsFalse().Invoke(null));
            Assert.IsFalse((bool)new IsFalse().Invoke(true));
        }
    }
}
