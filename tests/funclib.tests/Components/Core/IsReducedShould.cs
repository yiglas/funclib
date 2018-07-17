using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class IsReducedShould
    {
        [Test]
        public void IsReduced_should_return_true_if_reduced()
        {
            Assert.IsTrue((bool)new IsReduced().Invoke(new Reduced().Invoke("foo")));
        }

        [Test]
        public void IsReduced_should_return_false_if_not_reduced()
        {
            Assert.IsFalse((bool)new IsReduced().Invoke(0));
        }
    }
}
