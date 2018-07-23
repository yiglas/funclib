using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class IsIntegerShould
    {
        [Test]
        public void IsInteger_should_return_true_if_an_object_is_integer()
        {
            Assert.IsTrue((bool)isInteger(1));
            Assert.IsTrue((bool)isInteger((short)1));
            Assert.IsTrue((bool)isInteger((long)1));
            Assert.IsTrue((bool)isInteger((byte)1));
            Assert.IsTrue((bool)isInteger((uint)1));
            Assert.IsTrue((bool)isInteger((ushort)1));
            Assert.IsTrue((bool)isInteger((ulong)1));
            Assert.IsTrue((bool)isInteger((sbyte)1));
            Assert.IsTrue((bool)isInteger((char)1));
        }

        [Test]
        public void IsInteger_should_return_false_if_an_object_is_not_integer()
        {
            Assert.IsFalse((bool)isInteger(1D));
            Assert.IsFalse((bool)isInteger(null));
        }
    }
}
