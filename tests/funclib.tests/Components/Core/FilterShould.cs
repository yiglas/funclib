using funclib.Components.Core;
using funclib.Components.Core.Generic;
using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class FilterShould
    {
        [Test]
        public void Filter_should_return_a_lazy_seq()
        {
            var actual = funclib.Core.Filter(new IsEven(), funclib.Core.Range(10));

            Assert.IsInstanceOf<LazySeq>(actual);
        }

        [Test]
        public void Filter_should_filter_range_of_values()
        {
            var expected = funclib.Core.List(0, 2, 4, 6, 8);
            var actual = funclib.Core.ToArray(funclib.Core.Filter(new IsEven(), funclib.Core.Range(10)));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Filter_should_filter_a_string()
        {
            var expected = funclib.Core.List('d', 'e', 'v', 'i', 'n');
            var actual = funclib.Core.ToArray(funclib.Core.Filter(new Function<object, object>(x => !string.IsNullOrWhiteSpace(x.ToString())), "d e v i n"));

            Assert.AreEqual(expected, actual);
        }
    }
}
