using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class IsStringShould
    {
        [Test]
        public void IsString_should_return_true_if_x_is_string()
        {
            Assert.IsTrue((bool)new IsString().Invoke("abc"));
            Assert.IsTrue((bool)new IsString().Invoke(""));
        }

        [Test]
        public void IsString_should_return_false_if_x_is_not_string()
        {
            Assert.IsFalse((bool)new IsString().Invoke(new Vector().Invoke("1", "2", "3")));
            Assert.IsFalse((bool)new IsString().Invoke('a'));
            Assert.IsFalse((bool)new IsString().Invoke(null));
            Assert.IsFalse((bool)new IsString().Invoke(1));
        }
    }
}
