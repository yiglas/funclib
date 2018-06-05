using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static FunctionalLibrary.core;

namespace FunctionalLibrary.Tests.Corex
{
    public class ConcatShould
    {
        [Test]
        public void Concat_should_return_empyt_list_if_passed_nothing()
        {
            var actual = toarray(concat<int>());

            Assert.AreEqual(0, actual.Length);
        }

        [Test]
        public void Concat_should_return_empyt_list_if_passed_null()
        {
            var actual = toarray(concat<int>(null));

            Assert.AreEqual(0, actual.Length);
        }

        [Test]
        public void Concat_should_join_two_list_together()
        {
            var actual = toarray(concat("abc", "cde"));

            Assert.AreEqual(6, actual.Length);
        }

        [Test]
        public void Concat_should_join_or_more_list_together()
        {
            var actual = toarray(concat("abc", "cde", "fgh", "ijk"));

            Assert.AreEqual(12, actual.Length);
        }
    }
}
