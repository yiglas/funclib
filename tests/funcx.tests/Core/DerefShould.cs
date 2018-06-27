using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace FunctionalLibrary.Tests.Core
{
    public class DerefShould
    {
        [Test]
        public void Deref_should_return_the_current_state_of_ref()
        {
            var expected = 10;
            var r = new FunctionalLibrary.Collections.Reduced(expected);
            var actual = new Deref().Invoke(r);

            Assert.AreEqual(expected, actual);
        }
    }
}
