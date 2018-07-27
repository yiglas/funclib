using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class IsIntShould
    {
        [Test]
        public void IsInt_should_return_true_if_an_object_is_integer()
        {
            Assert.IsTrue((bool)isInt(1));
            Assert.IsTrue((bool)isInt((short)1));
            Assert.IsTrue((bool)isInt((long)1));
            Assert.IsTrue((bool)isInt((byte)1));
        }

        [Test]
        public void IsInt_should_return_false_if_an_object_is_not_integer()
        {
            Assert.IsFalse((bool)isInt((double)1));
            Assert.IsFalse((bool)isInt(null));
        }
    }
}
