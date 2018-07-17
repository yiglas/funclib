using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class IsIntShould
    {
        [Test]
        public void IsInt_should_return_true_if_an_object_is_integer()
        {
            Assert.IsTrue((bool)new IsInt().Invoke(1));
            Assert.IsTrue((bool)new IsInt().Invoke((short)1));
            Assert.IsTrue((bool)new IsInt().Invoke((long)1));
            Assert.IsTrue((bool)new IsInt().Invoke((byte)1));
        }

        [Test]
        public void IsInt_should_return_false_if_an_object_is_not_integer()
        {
            Assert.IsFalse((bool)new IsInt().Invoke((double)1));
            Assert.IsFalse((bool)new IsInt().Invoke(null));
        }
    }
}
