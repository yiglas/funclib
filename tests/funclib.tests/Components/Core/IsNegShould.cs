using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class IsNegShould
    {
        [Test]
        public void IsNeg_should_return_true_if_an_object_is_less_than_zero()
        {
            Assert.IsTrue((bool)new IsNeg().Invoke(-1));
        }

        [Test]
        public void IsNeg_should_return_false_if_an_object_is_not_less_than_zero()
        {
            Assert.IsFalse((bool)new IsNeg().Invoke(1));
            Assert.IsFalse((bool)new IsNeg().Invoke(0));
        }
    }
}
