using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class DoShould
    {
        [Test]
        public void Do_should_run_each_express_and_return_last()
        {
            var expected = 2;
            var actual = new Do().Invoke(
                new PrintLn().Invoke("LOG: Computing..."),
                new Plus().Invoke(1, 1));

            Assert.AreEqual(expected, actual);
        }
    }
}
