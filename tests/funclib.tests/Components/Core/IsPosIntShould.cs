using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class IsPosIntShould
    {
        [Test]
        public void IsPosInt_should_return_true_if_is_a_positive_int()
        {
            Assert.IsTrue((bool)isPosInt(1));
        }

        [Test]
        public void IsPosInt_should_return_false_if_is_not_a_positive_int()
        {
            Assert.IsFalse((bool)isPosInt(0));
            Assert.IsFalse((bool)isPosInt((double)1));
            Assert.IsFalse((bool)isPosInt(-1));
        }
    }
}
