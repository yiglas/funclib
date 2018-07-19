using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class CharShould
    {
        [Test]
        public void Char_should_convert_int_to_char()
        {
            var expected = 'c';
            var actual = new funclib.Components.Core.Char().Invoke(99);

            Assert.AreEqual(expected, actual);
        }
    }
}
