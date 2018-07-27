using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using System.Threading;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class TimeShould
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
        public void Time_should_write_elapsed_time_to_variables_out_stream()
        {
            time(() => { Thread.Sleep(100); return null; });

            Assert.IsTrue(!string.IsNullOrWhiteSpace(this._writer.ToString()));
        }
    }
}
