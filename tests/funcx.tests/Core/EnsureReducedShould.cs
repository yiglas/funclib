using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace FunctionalLibrary.Tests.Core
{
    public class EnsureReducedShould
    {
        [Test]
        public void EnsureReduced_should_return_value_if_already_reduced()
        {
            var expected = 1;
            var actual = new EnsureReduced().Invoke(1);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EnsureReduced_should_return_the_deref_value_if_its_reduced()
        {
            var expected = 1;
            var actual = new EnsureReduced().Invoke(new FunctionalLibrary.Collections.Reduced(1));

            Assert.AreEqual(expected, actual);
        }
    }
}
