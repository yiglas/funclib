using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;
using list = FunctionalLibrary.Collections.List;

namespace FunctionalLibrary.Tests.Core
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
