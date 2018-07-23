using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class FNextShould
    {
        [Test]
        public void FNext_should_return_null_with_no_items()
        {
            Assert.IsNull(fnext(new Vector().Invoke()));
        }

        [Test]
        public void FNext_should_return_null_with_only_one_item()
        {
            Assert.IsNull(fnext(new Vector().Invoke(1)));
        }

        [Test]
        public void FNext_should_return_first_item_of_the_next_list()
        {
            var expected = new Vector().Invoke("b", "a", "c");
            var actual = fnext(list(new Vector().Invoke("a", "b", "c"), new Vector().Invoke("b", "a", "c")));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FNext_should_return_first_KeyValuePair_when_passed_array_map()
        {
            var expected = new funclib.Collections.KeyValuePair("b", 2);
            var actual = fnext(arrayMap("a", 1, "b", 2, "c", 3));

            Assert.AreEqual(expected, actual);
        }
    }
}
