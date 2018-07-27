﻿using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class AssocǃShould
    {
        [Test]
        public void Assocǃ_should_update_map_and_not_return_new()
        {
            var expected = hashMap(":x", 1, ":y", 2, ":z", 3);
            var actual = persistentǃ(assocǃ(transient(expected), ":x", 1, ":y", 2, ":z", 3));

            Assert.AreEqual(expected, actual);
            Assert.IsFalse(expected == actual);
        }

        [Test]
        public void Assocǃ_should_mutate_give_map()
        {
            var expected = transient(hashMap(":x", 1, ":y", 2, ":z", 3));
            var actual = assocǃ(expected, ":x", 1, ":y", 2, ":z", 3);

            Assert.AreEqual(expected, actual);
            Assert.IsTrue(expected == actual);
        }
    }
}
