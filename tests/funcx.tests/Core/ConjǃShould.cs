using FunctionalLibrary.Collections;
using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace FunctionalLibrary.Tests.Core
{
    public class ConjǃShould
    {
        [Test]
        public void Conjǃ_should_return_an_emtpy_transient_vector()
        {
            var actual = new Conjǃ().Invoke();

            Assert.IsInstanceOf<ITransientCollection>(actual);
        }

        [Test]
        public void Conjǃ_should_return_the_passed_in_object_if_nothing_passed()
        {
            var expected = new FunctionalLibrary.Core.Vector().Invoke(1);
            var actual = new Conjǃ().Invoke(expected);

            Assert.IsTrue(expected == actual);
        }

        [Test]
        public void Conjǃ_should_add_item_to_collection()
        {
            var expected = new Conjǃ().Invoke();
            var actual = new Conjǃ().Invoke(expected, 1);

            Assert.IsTrue(expected == actual);
        }
    }
}
