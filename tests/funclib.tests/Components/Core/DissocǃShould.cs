using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class DissocǃShould
    {
        [Test]
        public void Dissocǃ_should_return_the_same_object_without_the_give_key()
        {
            var expected = transient(hashMap("a", 1, "b", 2, "c", 3));
            var actual = dissocǃ(expected, "c");

            Assert.IsTrue(expected == actual);
        }

        [Test]
        public void Dissocǃ_should_return_the_same_object_without_all_the_given_keys()
        {
            var expected = transient(hashMap("a", 1, "b", 2, "c", 3, "d", 4, "e", 5, "f", 6));
            var actual = dissocǃ(expected, "a", "c", "e");

            Assert.IsTrue(expected == actual);
        }
    }
}
