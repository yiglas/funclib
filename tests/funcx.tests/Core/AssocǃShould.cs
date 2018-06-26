using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace FunctionalLibrary.Tests.Core
{
    public class AssocǃShould
    {
        [Test]
        public void Assocǃ_should_update_map_and_not_return_new()
        {
            var expected = new HashMap().Invoke(":x", 1, ":y", 2, ":z", 3);
            var actual = new Persistentǃ().Invoke(new Assocǃ().Invoke(new Transient().Invoke(expected), ":x", 1, ":y", 2, ":z", 3));

            Assert.AreEqual(expected, actual);
        }
    }
}
