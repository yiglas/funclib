using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class IsNatIntShould
    {
        [Test]
        public void IsNatInt_should_return_true_if_an_object_is_NonNegative()
        {
            Assert.IsTrue((bool)new IsNatInt().Invoke(1));
            Assert.IsTrue((bool)new IsNatInt().Invoke(0));
        }

        [Test]
        public void IsNatInt_should_return_false_if_an_object_is_not_NonNegative()
        {
            Assert.IsFalse((bool)new IsNatInt().Invoke(-1));
            Assert.IsFalse((bool)new IsNatInt().Invoke(null));
        }
    }
}
