using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class FilterShould
    {
        [Test]
        public void Filter_should_return_a_lazy_seq()
        {
            var actual = filter(new IsEven(), range(10));

            Assert.IsInstanceOf<LazySeq>(actual);
        }

        [Test]
        public void Filter_should_filter_range_of_values()
        {
            var expected = list(0, 2, 4, 6, 8);
            var actual = toArray(filter(new IsEven(), range(10)));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Filter_should_filter_a_string()
        {
            var expected = list('d', 'e', 'v', 'i', 'n');
            var actual = toArray(filter(new Function<object, object>(x => !string.IsNullOrWhiteSpace(x.ToString())), "d e v i n"));

            Assert.AreEqual(expected, actual);
        }
    }
}
