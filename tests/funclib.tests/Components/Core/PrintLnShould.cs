using NUnit.Framework;
using System;
using System.IO;

namespace funclib.Tests.Components.Core
{
    public class PrintLnShould
    {
        StringWriter _writer;

        [SetUp]
        public void SetUp()
        {
            Variables.Out = this._writer = new StringWriter();
        }

        [TearDown]
        public void TearDown()
        {
            Variables.Out = Console.Out;
        }

        [Test]
        public void Print_should_write_string()
        {
            funclib.Core.PrintLn("Foo");
            Assert.AreEqual(this._writer.ToString(), "Foo" + Environment.NewLine);
        }
    }
}
