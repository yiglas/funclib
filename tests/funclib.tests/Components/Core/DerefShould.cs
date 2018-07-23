using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class DerefShould
    {
        [Test]
        public void Deref_should_return_the_current_state_of_ref()
        {
            var expected = 10;
            var r = reduced(expected);
            var actual = deref(r);

            Assert.AreEqual(expected, actual);
        }
    }
}
