using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class KeepShould
    {
        [Test]
        public void Keep_should_return_return_return_list_with_results()
        {
            var expected = list(false, true, false, true, false, true, false, true, false);
            var actual = keep(new IsEven(), range(1, 10));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Keep_should_return_values_from_function()
        {
            var expected = list(1, 3, 5, 7, 9);
            var actual = keep(new Function<object, object>(x => (bool)isOdd(x) ? x : null), range(10));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Keep_should_be_able_to_be_used_with_maps()
        {
            var expected = list(1, 2);
            var actual = keep(arrayMap(":a", 1, ":b", 2, ":c", 3), new Vector().Invoke(":a", ":b", ":d"));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Keep_should_be_able_to_be_used_with_sets()
        {
            var expected = list(2, 3);
            var actual = toArray(keep(hashSet(0, 1, 2, 3), hashSet(2, 3, 4, 5)));

            Assert.AreEqual(expected, actual);
        }
    }
}
