using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class PartitionByShould
    {
        [Test]
        public void PartitionBy_should_when_result_changes()
        {
            var expected = new funclib.Components.Core.List().Invoke(new funclib.Components.Core.List().Invoke(1, 2), new funclib.Components.Core.List().Invoke(3), new funclib.Components.Core.List().Invoke(4, 5));
            var actual = new PartitionBy().Invoke(new Function<object, object>(x => x.Equals(3)), new Vector().Invoke(1, 2, 3, 4, 5));

            Assert.AreEqual(expected, actual);
        }
    }
}
