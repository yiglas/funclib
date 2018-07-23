using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class FlattenShould
    {
        [Test]
        public void Flatten_should_flatten_nested_vectors()
        {
            var expected = list(1, 2, 3);
            var actual = toArray(flatten(vector(1, vector(2, 3))));

            Assert.AreEqual(expected, actual);
        }
    }
}
