using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class AddWatchShould
    {
        [Test]
        public void AddWatch_should_add_a_watch_to_a_given_ref()
        {
            StringWriter writer;
            Variables.Out = writer = new StringWriter();

            var atm = atom(1);
            addWatch(atm, "print-change", PrintLn);
            swapǃ(atm, Inc);

            Variables.Out = Console.Out;

            Assert.IsNotEmpty(writer.ToString());
        }

    }
}
