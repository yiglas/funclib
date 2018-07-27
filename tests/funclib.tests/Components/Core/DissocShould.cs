using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class DissocShould
    {
        [Test]
        public void Dissoc_should_return_passed_in_collection_if_not_passed_object_to_remove()
        {
            var expected = hashMap();
            var actual = dissoc(expected);

            Assert.IsTrue(expected == actual);
        }

        [Test]
        public void Dissoc_should_return_a_new_map_without_the_given_key()
        {
            var expected = hashMap("a", 1, "c", 3);
            var actual = dissoc(hashMap("a", 1, "b", 2, "c", 3), "b");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Dissoc_should_return_a_new_map_without_all_the_given_keys()
        {
            var expected = hashMap("a", 1, "c", 3, "e", 5, "g", 7);
            var actual = dissoc(hashMap("a", 1, "b", 2, "c", 3, "d", 4, "e", 5, "f", 6, "g", 7), "b", "d", "f");

            Assert.AreEqual(expected, actual);
        }

    }
}
