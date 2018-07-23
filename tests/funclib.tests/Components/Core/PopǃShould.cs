using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class PopǃShould
    {
        [Test]
        public void Popǃ_should_return_itself()
        {
            var expected = transient(new Vector().Invoke(1, 2, 3));
            var actual = popǃ(expected);

            Assert.IsTrue(expected == actual);
        }

        [Test]
        public void Popǃ_should_modify_the_original_structure()
        {
            var expected = transient(new Vector().Invoke(1, 2, 3));
            var actual = popǃ(expected);

            Assert.AreEqual(2, count(expected));
        }
    }
}
