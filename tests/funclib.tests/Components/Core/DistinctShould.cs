using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class DistinctShould
    {
        [Test]
        public void Distinct_should_return_lazy_list_of_distinct_values()
        {
            var expected = list(1, 2, 3, 4, 5);
            var actual = toArray(distinct(new Vector().Invoke(1, 2, 1, 3, 1, 4, 1, 5)));

            Assert.AreEqual(expected, actual);
        }
    }
}
