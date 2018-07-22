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
            var actual = filter(new IsEven(), new Range().Invoke(10));

            Assert.IsInstanceOf<LazySeq>(actual);
        }

        [Test]
        public void Filter_should_filter_range_of_values()
        {
            var expected = new funclib.Components.Core.List().Invoke(0, 2, 4, 6, 8);
            var actual = new ToArray().Invoke(filter(new IsEven(), new Range().Invoke(10)));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Filter_should_filter_a_string()
        {
            var expected = new funclib.Components.Core.List().Invoke('d', 'e', 'v', 'i', 'n');
            var actual = new ToArray().Invoke(filter(new Function<object, object>(x => !string.IsNullOrWhiteSpace(x.ToString())), "d e v i n"));

            Assert.AreEqual(expected, actual);
        }
    }
}
