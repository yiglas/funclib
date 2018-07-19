using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class SortByShould
    {
        [Test]
        public void SortBy_should_sort_vector_by_comparor()
        {
            var expected = new funclib.Components.Core.List().Invoke("c", "bb", "aaa");
            var actual = new SortBy().Invoke(new Count(), new Vector().Invoke("aaa", "c", "bb"));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SortBy_should_sort_by_keyfn_and_comparor()
        {
            var expected = new funclib.Components.Core.List().Invoke(new Vector().Invoke(2, 3), new Vector().Invoke(2, 2), new Vector().Invoke(1, 2));
            var actual = new SortBy().Invoke(new First(), new IsGreaterThan(), new Vector().Invoke(new Vector().Invoke(1, 2), new Vector().Invoke(2, 2), new Vector().Invoke(2, 3)));
            
            Assert.AreEqual(expected, actual);
        }
    }
}
