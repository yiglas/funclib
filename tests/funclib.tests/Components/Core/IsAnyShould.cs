using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class IsAnyShould
    {
        [Test]
        public void IsAny_should_return_true_given_any_argument()
        {
            Assert.IsTrue((bool)isAny(1));
            Assert.IsTrue((bool)isAny(null));
        }
    }
}
