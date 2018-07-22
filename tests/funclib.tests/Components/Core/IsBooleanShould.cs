using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class IsBooleanShould
    {
        [Test]
        public void IsBoolean_should_return_true_if_an_object_is_a_boolean()
        {
            Assert.IsTrue((bool)isBoolean(true));
            Assert.IsTrue((bool)isBoolean(false));

            object b = true;
            Assert.IsTrue((bool)isBoolean(b));
        }

        [Test]
        public void IsBoolean_should_return_false_if_an_object_is_not_a_boolean()
        {
            Assert.IsFalse((bool)isBoolean(1));
            Assert.IsFalse((bool)isBoolean(null));
        }
    }
}