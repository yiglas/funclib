using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static FunctionalLibrary.core;

namespace FunctionalLibrary.Tests.Corex
{
    public class TimeShould
    {
        [Test]
        public void Time_should_print_milliseconds_to_console()
        {
            time(() => System.Threading.Thread.Sleep(100));
        }
    }
}
