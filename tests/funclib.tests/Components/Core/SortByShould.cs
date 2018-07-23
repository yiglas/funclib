using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class SortByShould
    {
        [Test]
        public void SortBy_should_sort_vector_by_comparor()
        {
            var expected = list("c", "bb", "aaa");
            var actual = sortBy(new Count(), vector("aaa", "c", "bb"));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SortBy_should_sort_by_keyfn_and_comparor()
        {
            var expected = list(vector(2, 3), vector(2, 2), vector(1, 2));
            var actual = sortBy(new First(), new IsGreaterThan(), vector(vector(1, 2), vector(2, 2), vector(2, 3)));
            
            Assert.AreEqual(expected, actual);
        }
    }
}
