using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class RangeShould
    {
        [Test]
        public void Range_should_step_when_supplied()
        {
            var expected = funclib.Core.List(0, 2, 4, 6);
            var actual = funclib.Core.Range(0, 7, 2);

            Assert.AreEqual(expected, actual);
        }
    }
}
