using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace FunctionalLibrary.Tests.Core
{
    public class FlattenShould
    {
        [Test]
        public void Flatten_should_flatten_nested_vectors()
        {
            var expected = new FunctionalLibrary.Core.List().Invoke(1, 2, 3);
            var actual = new ToArray().Invoke(new Flatten().Invoke(new Vector().Invoke(1, new Vector().Invoke(2, 3))));

            Assert.AreEqual(expected, actual);
        }
    }
}
