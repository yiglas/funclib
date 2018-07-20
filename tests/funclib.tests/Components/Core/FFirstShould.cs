using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class FFirstShould
    {
        [Test]
        public void FFirst_should_return_null_if_empty_empty()
        {
            var actual = new FFirst().Invoke(new funclib.Components.Core.List().Invoke(new Vector().Invoke()));

            Assert.IsNull(actual);
        }

        [Test]
        public void FFirst_should_return_the_first_items_first_item()
        {
            var expected = "a";
            var actual = new FFirst().Invoke(new Vector().Invoke(new funclib.Components.Core.List().Invoke("a", "b", "c"), new funclib.Components.Core.List().Invoke("b", "c", "d")));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FFirst_should_return_first_key_when_passed_array_map()
        {
            var expected = "a";
            var actual = new FFirst().Invoke(arrayMap("a", 1, "b", 2, "c", 3));

            Assert.AreEqual(expected, actual);
        }
    }
}
