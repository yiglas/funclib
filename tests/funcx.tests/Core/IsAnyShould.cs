using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace FunctionalLibrary.Tests.Core
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
