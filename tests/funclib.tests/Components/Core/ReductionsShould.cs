using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class ReductionsShould
    {
        [Test]
        public void Reductions_should_sum_each_item_with_its_prediceser()
        {
            var expected = list(1, 2, 3, 4);
            var actual = new Reductions().Invoke(new Plus(), new Vector().Invoke(1, 1, 1, 1));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Reductions_should_conj_vectors()
        {
            var expected = new Vector().Invoke(new Vector().Invoke(), new Vector().Invoke(1), new Vector().Invoke(1, 2), new Vector().Invoke(1, 2, 3));
            var actual = new Reductions().Invoke(new Conj(), new Vector().Invoke(), list(1, 2, 3));

            Assert.AreEqual(expected, actual);
        }
    }
}
