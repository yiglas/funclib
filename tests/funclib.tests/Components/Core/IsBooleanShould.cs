using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class IsBooleanShould
    {
        [Test]
        public void IsBoolean_should_return_true_if_an_object_is_a_boolean()
        {
            Assert.IsTrue((bool)new IsBoolean().Invoke(true));
            Assert.IsTrue((bool)new IsBoolean().Invoke(false));

            object b = true;
            Assert.IsTrue((bool)new IsBoolean().Invoke(b));
        }

        [Test]
        public void IsBoolean_should_return_false_if_an_object_is_not_a_boolean()
        {
            Assert.IsFalse((bool)new IsBoolean().Invoke(1));
            Assert.IsFalse((bool)new IsBoolean().Invoke(null));
        }
    }
}