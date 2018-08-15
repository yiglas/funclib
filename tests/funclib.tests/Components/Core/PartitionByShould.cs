using funclib.Components.Core.Generic;
using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class PartitionByShould
    {
        [Test]
        public void PartitionBy_should_when_result_changes()
        {
            var expected = funclib.Core.List(funclib.Core.List(1, 2), funclib.Core.List(3), funclib.Core.List(4, 5));
            var actual = funclib.Core.PartitionBy(new Function<object, object>(x => x.Equals(3)), funclib.Core.Vector(1, 2, 3, 4, 5));

            Assert.AreEqual(expected, actual);
        }
    }
}
