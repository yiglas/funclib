using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class NthRestShould
    {
        [Test]
        public void NthRest_should_skip_the_first_x()
        {
            var expected = new funclib.Components.Core.List().Invoke(5, 6, 7, 8, 9);
            var actual = new NthRest().Invoke(new Range().Invoke(10), 5);

            Assert.AreEqual(expected, actual);
        }
    }
}
