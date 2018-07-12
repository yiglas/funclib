using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace FunctionalLibrary.Tests.Core
{
    public class IsCountedShould
    {
        [Test]
        public void IsCounted_should_return_true_if_an_object_is_ICounted()
        {
            Assert.IsTrue((bool)new IsCounted().Invoke(new Vector().Invoke()));
        }

        [Test]
        public void IsCounted_should_return_false_if_an_object_is_not_ICounted()
        {
            Assert.IsFalse((bool)new IsCounted().Invoke(1));
            Assert.IsFalse((bool)new IsCounted().Invoke(null));
        }
    }
}