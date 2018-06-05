using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Tests.Core
{
    public class CompShould
    {
        [Test]
        public void Comp_should_take_any_function()
        {
            var comp = new Comp().Invoke(new And());
        }
    }
}
