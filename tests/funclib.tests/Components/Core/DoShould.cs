using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class DoShould
    {
        [Test]
        public void Do_should_run_each_express_and_return_last()
        {
            var expected = 2;
            var actual = funclib.Core.Do(
                funclib.Core.PrintLn("LOG: Computing..."),
                funclib.Core.Plus(1, 1));

            Assert.AreEqual(expected, actual);
        }
    }
}
