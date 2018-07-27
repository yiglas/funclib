using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class EnsureReducedShould
    {
        [Test]
        public void EnsureReduced_should_return_the_value_wrapped()
        {
            var actual = ensureReduced(1);

            Assert.IsInstanceOf<Reduced>(actual);
        }

        [Test]
        public void EnsureReduced_should_return_the_deref_value_if_its_reduced()
        {
            var expected = reduced(1);
            var actual = ensureReduced(expected);

            Assert.IsTrue(expected == actual);
        }
    }
}
