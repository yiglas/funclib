using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class IsNatIntShould
    {
        [Test]
        public void IsNatInt_should_return_true_if_an_object_is_NonNegative()
        {
            Assert.IsTrue((bool)isNatInt(1));
            Assert.IsTrue((bool)isNatInt(0));
        }

        [Test]
        public void IsNatInt_should_return_false_if_an_object_is_not_NonNegative()
        {
            Assert.IsFalse((bool)isNatInt(-1));
            Assert.IsFalse((bool)isNatInt(null));
        }
    }
}
