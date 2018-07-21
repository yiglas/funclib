using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class EmptyShould
    {
        [Test]
        public void Empty_should_return_an_emtpy_collection()
        {
            var expected = new Vector().Invoke();
            var actual = empty(new Vector().Invoke(1, 2, 3));

            Assert.IsInstanceOf<funclib.Collections.Vector>(actual);
            Assert.AreEqual(expected, actual);
        }
    }
}
