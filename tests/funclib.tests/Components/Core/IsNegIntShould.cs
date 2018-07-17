using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class IsNegIntShould
    {
        [Test]
        public void IsNegInt_should_return_true_if_an_object_is_negative_int()
        {
            Assert.IsTrue((bool)new IsNegInt().Invoke(-1));
        }

        [Test]
        public void IsNegInt_should_return_false_if_an_object_is_not_negative_int()
        {
            Assert.IsFalse((bool)new IsNegInt().Invoke(1));
            Assert.IsFalse((bool)new IsNegInt().Invoke(null));
            Assert.IsFalse((bool)new IsNegInt().Invoke(0));
            Assert.IsFalse((bool)new IsNegInt().Invoke((double)-1));
        }
    }
}
