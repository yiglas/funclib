using funclib.Collections;
using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class ConjǃShould
    {
        [Test]
        public void Conjǃ_should_return_an_emtpy_transient_vector()
        {
            var actual = conjǃ();

            Assert.IsInstanceOf<ITransientCollection>(actual);
        }

        [Test]
        public void Conjǃ_should_return_the_passed_in_object_if_nothing_passed()
        {
            var expected = new funclib.Components.Core.Vector().Invoke(1);
            var actual = conjǃ(expected);

            Assert.IsTrue(expected == actual);
        }

        [Test]
        public void Conjǃ_should_add_item_to_collection()
        {
            var expected = conjǃ();
            var actual = conjǃ(expected, 1);

            Assert.IsTrue(expected == actual);
        }
    }
}
