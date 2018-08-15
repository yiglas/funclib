using NUnit.Framework;
using System;
using System.IO;

namespace funclib.Tests.Components.Core
{
    public class AddWatchShould
    {
        [Test]
        public void AddWatch_should_add_a_watch_to_a_given_ref()
        {
            StringWriter writer;
            Variables.Out = writer = new StringWriter();

            var atm = funclib.Core.Atom(1);
            funclib.Core.AddWatch(atm, "print-change", funclib.Core.printLn);
            funclib.Core.Swapǃ(atm, funclib.Core.inc);

            Variables.Out = Console.Out;

            Assert.IsNotEmpty(writer.ToString());
        }

    }
}
