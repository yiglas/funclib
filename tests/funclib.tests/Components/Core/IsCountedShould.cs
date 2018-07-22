using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class IsCountedShould
    {
        [Test]
        public void IsCounted_should_return_true_if_an_object_is_ICounted()
        {
            Assert.IsTrue((bool)isCounted(new Vector().Invoke()));
        }

        [Test]
        public void IsCounted_should_return_false_if_an_object_is_not_ICounted()
        {
            Assert.IsFalse((bool)isCounted(1));
            Assert.IsFalse((bool)isCounted(null));
        }
    }
}