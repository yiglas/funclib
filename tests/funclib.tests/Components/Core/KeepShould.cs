using funclib.Components.Core;
using funclib.Components.Core.Generic;
using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class KeepShould
    {
        [Test]
        public void Keep_should_return_return_return_list_with_results()
        {
            var expected = funclib.Core.List(false, true, false, true, false, true, false, true, false);
            var actual = funclib.Core.Keep(new IsEven(), funclib.Core.Range(1, 10));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Keep_should_return_values_from_function()
        {
            var expected = funclib.Core.List(1, 3, 5, 7, 9);
            var actual = funclib.Core.Keep(new Function<object, object>(x => (bool)funclib.Core.IsOdd(x) ? x : null), funclib.Core.Range(10));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Keep_should_be_able_to_be_used_with_maps()
        {
            var expected = funclib.Core.List(1, 2);
            var actual = funclib.Core.Keep(funclib.Core.ArrayMap(":a", 1, ":b", 2, ":c", 3), funclib.Core.Vector(":a", ":b", ":d"));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Keep_should_be_able_to_be_used_with_sets()
        {
            var expected = funclib.Core.List(2, 3);
            var actual = funclib.Core.ToArray(funclib.Core.Keep(funclib.Core.HashSet(0, 1, 2, 3), funclib.Core.HashSet(2, 3, 4, 5)));

            Assert.AreEqual(expected, actual);
        }
    }
}
