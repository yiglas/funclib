using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class SetShould
    {
        [Test]
        public void Set_should_return_a_hashset()
        {
            var actual = new Set().Invoke(new Vector().Invoke(1, 1, 2, 3, 2, 4, 5, 5));

            Assert.IsInstanceOf<funclib.Collections.HashSet>(actual);
        }

        [Test]
        public void Set_should_return_a_distinct_list_of_items_from_a_list()
        {
            var expected = new HashSet().Invoke(1, 2, 3, 4, 5);
            var actual = new Set().Invoke(new funclib.Components.Core.List().Invoke(1, 1, 2, 3, 2, 4, 5, 5));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Set_should_return_an_empty_set_if_passed_null()
        {
            var expected = new HashSet().Invoke();
            var actual = new Set().Invoke(null);

            Assert.AreEqual(expected, actual);
        }
    }
}
