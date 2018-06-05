using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using static FunctionalLibrary.core;

namespace FunctionalLibrary.Tests.Corex
{
    public class ContainsShould
    {
        [Test]
        public void Contains_should_check_numberically_indexed_collection()
        {
            var actual = contains(new int[] { 5, 6, 7, 8 }, 1);

            Assert.True(actual);
        }

        [Test]
        public void Contains_should_check_numberically_indexed_collection_two()
        {
            var actual = contains(new string[] { "a", "b", "c" }, 1);

            Assert.True(actual);
        }
    }
}
