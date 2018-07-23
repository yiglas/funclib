using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;

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
            printLn("Foo");
            Assert.AreEqual(this._writer.ToString(), "Foo" + Environment.NewLine);
        }
    }
}
