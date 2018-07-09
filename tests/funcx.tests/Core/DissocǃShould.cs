﻿using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;
namespace FunctionalLibrary.Tests.Core
{
    public class DissocǃShould
    {
        [Test]
        public void Dissocǃ_should_return_the_same_object_without_the_give_key()
        {
            var expected = new Transient().Invoke(new HashMap().Invoke("a", 1, "b", 2, "c", 3));
            var actual = new Dissocǃ().Invoke(expected, "c");

            Assert.IsTrue(expected == actual);
        }

        [Test]
        public void Dissocǃ_should_return_the_same_object_without_all_the_given_keys()
        {
            var expected = new Transient().Invoke(new HashMap().Invoke("a", 1, "b", 2, "c", 3, "d", 4, "e", 5, "f", 6));
            var actual = new Dissocǃ().Invoke(expected, "a", "c", "e");

            Assert.IsTrue(expected == actual);
        }
    }
}
