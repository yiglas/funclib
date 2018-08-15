using funclib.Collections;
using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class ConjǃShould
    {
        [Test]
        public void Conjǃ_should_return_an_emtpy_transient_vector()
        {
            var actual = funclib.Core.Conjǃ();

            Assert.IsInstanceOf<ITransientCollection>(actual);
        }

        [Test]
        public void Conjǃ_should_return_the_passed_in_object_if_nothing_passed()
        {
            var expected = new funclib.Components.Core.Vector().Invoke(1);
            var actual = funclib.Core.Conjǃ(expected);

            Assert.IsTrue(expected == actual);
        }

        [Test]
        public void Conjǃ_should_add_item_to_collection()
        {
            var expected = funclib.Core.Conjǃ();
            var actual = funclib.Core.Conjǃ(expected, 1);

            Assert.IsTrue(expected == actual);
        }
    }
}
