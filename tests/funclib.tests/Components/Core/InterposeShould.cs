using funclib.Components.Core;
using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class InterposeShould
    {
        [Test]
        public void Interpose_should_return_a_lazy_seq()
        {
            var actual = funclib.Core.Interpose(",", funclib.Core.Vector("one", "two", "three"));

            Assert.IsInstanceOf<LazySeq>(actual);
        }

        [Test]
        public void Interpose_should_return_a_list_of_items_with_the_sep_in_between_each()
        {
            var expected = funclib.Core.List("one", ", ", "two", ", ", "three");
            var actual = funclib.Core.ToArray(funclib.Core.Interpose(", ", funclib.Core.Vector("one", "two", "three")));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Interpose_should_concat_a_string_using_apply()
        {
            var expected = "one, two, three";
            var actual = funclib.Core.Apply(new Str(), funclib.Core.Interpose(", ", funclib.Core.Vector("one", "two", "three")));

            Assert.AreEqual(expected, actual);
        }
    }
}
