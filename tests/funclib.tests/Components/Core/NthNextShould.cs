using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class NthNextShould
    {
        [Test]
        public void NthNext_should_return_the_items_after_passed_number()
        {
            var expected = new funclib.Components.Core.List().Invoke(3, 4, 5, 6, 7, 8, 9);
            var actual = new NthNext().Invoke(new Range().Invoke(10), 3);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void NthNext_should_return_a_null_if_an_empty_collection_is_passed()
        {
            var actual = new NthNext().Invoke(new Vector().Invoke(), 3);

            Assert.IsNull(actual);
        }
    }
}
