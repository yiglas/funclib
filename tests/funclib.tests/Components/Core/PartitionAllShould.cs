using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class PartitionAllShould
    {
        [Test]
        public void PartitionAll_should_return_fewer_then_n_times()
        {
            var expected = 2;
            var actual = new PartitionAll().Invoke(4, new Range().Invoke(10));

            Assert.AreEqual(expected, new Count().Invoke(new Last().Invoke(actual)));
        }
    }
}
