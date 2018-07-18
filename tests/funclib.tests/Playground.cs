using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace FunctionalLibrary.Tests
{
    public class Playground
    {

        [Test]
        public void Testing()
        {
            var list = map(Inc, vector(1, 2, 3));
        }
    }
}
