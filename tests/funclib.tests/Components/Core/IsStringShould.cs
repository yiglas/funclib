using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class IsStringShould
    {
        [Test]
        public void IsString_should_return_true_if_x_is_string()
        {
            Assert.IsTrue((bool)isString("abc"));
            Assert.IsTrue((bool)isString(""));
        }

        [Test]
        public void IsString_should_return_false_if_x_is_not_string()
        {
            Assert.IsFalse((bool)isString(vector("1", "2", "3")));
            Assert.IsFalse((bool)isString('a'));
            Assert.IsFalse((bool)isString(null));
            Assert.IsFalse((bool)isString(1));
        }
    }
}
