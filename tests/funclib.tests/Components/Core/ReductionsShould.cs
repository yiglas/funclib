using funclib.Components.Core;
using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class ReductionsShould
    {
        [Test]
        public void Reductions_should_sum_each_item_with_its_prediceser()
        {
            var expected = funclib.Core.List(1, 2, 3, 4);
            var actual = funclib.Core.Reductions(new Plus(), funclib.Core.Vector(1, 1, 1, 1));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Reductions_should_conj_vectors()
        {
            var expected = funclib.Core.Vector(funclib.Core.Vector(), funclib.Core.Vector(1), funclib.Core.Vector(1, 2), funclib.Core.Vector(1, 2, 3));
            var actual = funclib.Core.Reductions(new Conj(), funclib.Core.Vector(), funclib.Core.List(1, 2, 3));

            Assert.AreEqual(expected, actual);
        }
    }
}
