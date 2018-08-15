using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class PartitionAllShould
    {
        [Test]
        public void PartitionAll_should_return_fewer_then_n_times()
        {
            var expected = 2;
            var actual = funclib.Core.PartitionAll(4, funclib.Core.Range(10));

            Assert.AreEqual(expected, funclib.Core.Count(funclib.Core.Last(actual)));
        }
    }
}
