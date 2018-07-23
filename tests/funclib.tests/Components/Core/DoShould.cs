using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class DoShould
    {
        [Test]
        public void Do_should_run_each_express_and_return_last()
        {
            var expected = 2;
            var actual = @do(
                printLn("LOG: Computing..."),
                plus(1, 1));

            Assert.AreEqual(expected, actual);
        }
    }
}
