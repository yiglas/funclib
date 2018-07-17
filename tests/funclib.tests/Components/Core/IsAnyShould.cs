using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class IsAnyShould
    {
        [Test]
        public void IsAny_should_return_true_given_any_argument()
        {
            Assert.IsTrue((bool)new IsAny().Invoke(1));
            Assert.IsTrue((bool)new IsAny().Invoke(null));
        }
    }
}
