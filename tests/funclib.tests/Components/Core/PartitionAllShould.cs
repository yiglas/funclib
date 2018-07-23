using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class PartitionAllShould
    {
        [Test]
        public void PartitionAll_should_return_fewer_then_n_times()
        {
            var expected = 2;
            var actual = partitionAll(4, range(10));

            Assert.AreEqual(expected, count(last(actual)));
        }
    }
}
