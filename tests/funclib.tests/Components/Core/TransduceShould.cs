using funclib.Components.Core;
using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class TransduceShould
    {
        object xf;

        [SetUp]
        public void SetUp()
        {
            xf = funclib.Core.Comp(funclib.Core.Filter(new IsOdd()), funclib.Core.Take(10));
        }

        [Test]
        public void Transduce_should_return_the_numbers_as_a_sequence()
        {
            var expected = funclib.Core.Vector(1, 3, 5, 7, 9, 11, 13, 15, 17, 19);
            var actual = funclib.Core.Transduce(xf, new Conj(), funclib.Core.Range());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Transduce_should_return_sumed_values()
        {
            var expected = 100;
            var actual = funclib.Core.Transduce(xf, new Plus(), funclib.Core.Range());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Transduce_should_return_sumed_values_with_seed_value()
        {
            var expected = 117;
            var actual = funclib.Core.Transduce(xf, new Plus(), 17, funclib.Core.Range());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Transduce_should_return_string_when_called_via_str()
        {
            var expected = "135791113151719";
            var actual = funclib.Core.Transduce(xf, new Str(), funclib.Core.Range());

            Assert.AreEqual(expected, actual);
        }
    }
}
