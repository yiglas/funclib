using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class TransduceShould
    {
        object xf;

        [SetUp]
        public void SetUp()
        {
            xf = comp(filter(new IsOdd()), take(10));
        }

        [Test]
        public void Transduce_should_return_the_numbers_as_a_sequence()
        {
            var expected = new Vector().Invoke(1, 3, 5, 7, 9, 11, 13, 15, 17, 19);
            var actual = transduce(xf, new Conj(), range());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Transduce_should_return_sumed_values()
        {
            var expected = 100;
            var actual = transduce(xf, new Plus(), range());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Transduce_should_return_sumed_values_with_seed_value()
        {
            var expected = 117;
            var actual = transduce(xf, new Plus(), 17, range());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Transduce_should_return_string_when_called_via_str()
        {
            var expected = "135791113151719";
            var actual = transduce(xf, new Str(), range());

            Assert.AreEqual(expected, actual);
        }
    }
}
