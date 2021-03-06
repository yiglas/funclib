﻿using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class DisjǃShould
    {
        [Test]
        public void Disjǃ_should_return_pass_in_set()
        {
            var expected = funclib.Core.Transient(funclib.Core.HashSet(1, 2, 3));
            var actual = funclib.Core.Disjǃ(expected);

            Assert.IsTrue(expected == actual);
        }

        [Test]
        public void Disjǃ_should_return_the_same_object_without_the_give_key()
        {
            var expected = funclib.Core.Transient(funclib.Core.HashSet(1, 2, 3));
            var actual = funclib.Core.Disjǃ(expected, 3);

            Assert.IsTrue(expected == actual);
        }

        [Test]
        public void Disjǃ_should_return_the_same_object_without_all_the_given_keys()
        {
            var expected = funclib.Core.Transient(funclib.Core.HashSet(1, 2, 3, 4, 5, 6, 7, 8, 9));
            var actual = funclib.Core.Disjǃ(expected, 2, 4, 6, 8);

            Assert.IsTrue(expected == actual);
        }
    }
}
