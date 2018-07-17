using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using list = funclib.Collections.List;

namespace funclib.Tests.Components.Core
{
    public class ReverseShould
    {
        [Test]
        public void Reverse_should_reverse_a_sequence_of_items()
        {
            var expected = list.Create(3, 2, 1);
            var actual = new Reverse().Invoke(list.Create(1, 2, 3));

            Assert.AreEqual(expected, actual);
        }
    }
}
