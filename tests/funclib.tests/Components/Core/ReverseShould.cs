using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class ReverseShould
    {
        [Test]
        public void Reverse_should_reverse_a_sequence_of_items()
        {
            var expected = list(3, 2, 1);
            var actual = reverse(list(1, 2, 3));

            Assert.AreEqual(expected, actual);
        }
    }
}
