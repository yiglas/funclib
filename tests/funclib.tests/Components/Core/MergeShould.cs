using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class MergeShould
    {
        [Test]
        public void Merge_should_return_new_map_with_maps_conjed()
        {
            var expected = hashMap(":a", 1, ":c", 3, ":b", 9, ":d", 4);
            var actual = merge(arrayMap(":a", 1, ":b", 2, ":c", 3), arrayMap(":b", 9, ":d", 4));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Merge_should_allow_null_as_the_second_argument()
        {
            var expected = hashMap(":a", 1);
            var actual = merge(arrayMap(":a", 1), null);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Merge_should_allow_null_as_the_first_argument()
        {
            var expected = hashMap(":a", 1);
            var actual = merge(null, arrayMap(":a", 1));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Merge_should_return_null_if_passed_null()
        {
            Assert.IsNull(merge(null, null));
        }
    }
}
