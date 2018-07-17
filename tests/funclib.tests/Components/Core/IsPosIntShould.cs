using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class IsPosIntShould
    {
        [Test]
        public void IsPosInt_should_return_true_if_is_a_positive_int()
        {
            Assert.IsTrue((bool)new IsPosInt().Invoke(1));
        }

        [Test]
        public void IsPosInt_should_return_false_if_is_not_a_positive_int()
        {
            Assert.IsFalse((bool)new IsPosInt().Invoke(0));
            Assert.IsFalse((bool)new IsPosInt().Invoke((double)1));
            Assert.IsFalse((bool)new IsPosInt().Invoke(-1));
        }
    }
}
