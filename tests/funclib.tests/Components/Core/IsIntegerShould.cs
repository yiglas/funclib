using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class IsIntegerShould
    {
        [Test]
        public void IsInteger_should_return_true_if_an_object_is_integer()
        {
            Assert.IsTrue((bool)new IsInteger().Invoke(1));
            Assert.IsTrue((bool)new IsInteger().Invoke((short)1));
            Assert.IsTrue((bool)new IsInteger().Invoke((long)1));
            Assert.IsTrue((bool)new IsInteger().Invoke((byte)1));
            Assert.IsTrue((bool)new IsInteger().Invoke((uint)1));
            Assert.IsTrue((bool)new IsInteger().Invoke((ushort)1));
            Assert.IsTrue((bool)new IsInteger().Invoke((ulong)1));
            Assert.IsTrue((bool)new IsInteger().Invoke((sbyte)1));
            Assert.IsTrue((bool)new IsInteger().Invoke((char)1));
        }

        [Test]
        public void IsInteger_should_return_false_if_an_object_is_not_integer()
        {
            Assert.IsFalse((bool)new IsInteger().Invoke(1D));
            Assert.IsFalse((bool)new IsInteger().Invoke(null));
        }
    }
}
