using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class IsCharShould
    {
        [Test]
        public void IsChar_should_return_true_if_an_object_is_a_char()
        {
            Assert.IsTrue((bool)isChar('c'));

            object b = 'c';
            Assert.IsTrue((bool)isChar(b));
        }

        [Test]
        public void IsChar_should_return_false_if_an_object_is_not_a_char()
        {
            Assert.IsFalse((bool)isChar(1));
            Assert.IsFalse((bool)isChar(null));
        }
    }
}