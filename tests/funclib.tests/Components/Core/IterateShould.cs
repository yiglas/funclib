using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class IterateShould
    {
        [Test]
        public void Iterate_should_allow_an_IFunctionParams_to_be_passed()
        {
            var plus_one = funclib.Core.Func((object[] more) => funclib.Core.Inc(funclib.Core.First(more)));
            var expected = funclib.Core.List(5, 6, 7, 8, 9);
            var actual = funclib.Core.Take(5, funclib.Core.Iterate(plus_one, 5));

            Assert.AreEqual(expected, actual);
        }
    }
}
