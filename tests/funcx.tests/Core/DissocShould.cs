using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace FunctionalLibrary.Tests.Core
{
    public class DissocShould
    {
        [Test]
        public void Dissoc_should_return_passed_in_collection_if_not_passed_object_to_remove()
        {
            var expected = new HashMap().Invoke();
            var actual = new Dissoc().Invoke(expected);

            Assert.IsTrue(expected == actual);
        }

        [Test]
        public void Dissoc_should_return_a_new_map_without_the_given_key()
        {
            var expected = new HashMap().Invoke("a", 1, "c", 3);
            var actual = new Dissoc().Invoke(new HashMap().Invoke("a", 1, "b", 2, "c", 3), "b");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Dissoc_should_return_a_new_map_without_all_the_given_keys()
        {
            var expected = new HashMap().Invoke("a", 1, "c", 3, "e", 5, "g", 7);
            var actual = new Dissoc().Invoke(new HashMap().Invoke("a", 1, "b", 2, "c", 3, "d", 4, "e", 5, "f", 6, "g", 7), "b", "d", "f");

            Assert.AreEqual(expected, actual);
        }

    }
}
