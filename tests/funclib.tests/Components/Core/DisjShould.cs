using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class DisjShould
    {
        [Test]
        public void Disj_should_return_passed_in_collection_if_not_passed_object_to_remove()
        {
            var expected = hashSet(1, 2);
            var actual = disj(expected);

            Assert.IsTrue(expected == actual);
        }

        [Test]
        public void Disj_should_return_a_new_set_without_the_given_key()
        {
            var expected = hashSet(1, 2, 3, 5);
            var actual = disj(hashSet(1, 2, 3, 4, 5), 4);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Disj_should_return_a_new_set_without_all_the_given_keys()
        {
            var expected = hashSet(1, 3, 5, 7, 9);
            var actual = disj(hashSet(1, 2, 3, 4, 5, 6, 7, 8, 9), 2, 4, 6, 8);

            Assert.AreEqual(expected, actual);
        }
    }
}
