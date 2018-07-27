using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class InterposeShould
    {
        [Test]
        public void Interpose_should_return_a_lazy_seq()
        {
            var actual = interpose(",", vector("one", "two", "three"));

            Assert.IsInstanceOf<LazySeq>(actual);
        }

        [Test]
        public void Interpose_should_return_a_list_of_items_with_the_sep_in_between_each()
        {
            var expected = list("one", ", ", "two", ", ", "three");
            var actual = toArray(interpose(", ", vector("one", "two", "three")));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Interpose_should_concat_a_string_using_apply()
        {
            var expected = "one, two, three";
            var actual = apply(new Str(), interpose(", ", vector("one", "two", "three")));

            Assert.AreEqual(expected, actual);
        }
    }
}
