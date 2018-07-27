using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class ReductionsShould
    {
        [Test]
        public void Reductions_should_sum_each_item_with_its_prediceser()
        {
            var expected = list(1, 2, 3, 4);
            var actual = reductions(new Plus(), vector(1, 1, 1, 1));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Reductions_should_conj_vectors()
        {
            var expected = vector(vector(), vector(1), vector(1, 2), vector(1, 2, 3));
            var actual = reductions(new Conj(), vector(), list(1, 2, 3));

            Assert.AreEqual(expected, actual);
        }
    }
}
