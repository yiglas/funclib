using NUnit.Framework;
using System;

namespace funclib.Tests.Components.Core
{
    public class CompareAndSetǃShould
    {
        [Test]
        public void CompareAndSetǃ_should_returns_false_when_old_value_doesnot_match()
        {
            var a = funclib.Core.Atom(0, ":validator", funclib.Core.isInt);

            var actual = funclib.Core.CompareAndSetǃ(a, 10, 20);
            
            Assert.IsFalse((bool)actual);
        }

        [Test]
        public void CompareAndSetǃ_should_throw_exception_if_validator_false()
        {
            var a = funclib.Core.Atom(0, ":validator", funclib.Core.isInt);

            Assert.Throws<InvalidOperationException>(() => funclib.Core.CompareAndSetǃ(a, 10, "a"));
        }

        [Test]
        public void CompareAndSetǃ_should_returns_true_when_old_value_matches()
        {
            var a = funclib.Core.Atom(0, ":validator", funclib.Core.isInt);

            var actual = funclib.Core.CompareAndSetǃ(a, 0, 20);

            Assert.IsTrue((bool)actual);
        }
    }
}
