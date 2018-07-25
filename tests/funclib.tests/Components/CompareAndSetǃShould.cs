using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components
{
    public class CompareAndSetǃShould
    {
        [Test]
        public void CompareAndSetǃ_should_returns_false_when_old_value_doesnot_match()
        {
            var a = atom(0, ":validator", IsInt);

            var actual = compareAndSetǃ(a, 10, 20);
            
            Assert.IsFalse((bool)actual);
        }

        [Test]
        public void CompareAndSetǃ_should_throw_exception_if_validator_false()
        {
            var a = atom(0, ":validator", IsInt);

            Assert.Throws<InvalidOperationException>(() => compareAndSetǃ(a, 10, "a"));
        }

        [Test]
        public void CompareAndSetǃ_should_returns_true_when_old_value_matches()
        {
            var a = atom(0, ":validator", IsInt);

            var actual = compareAndSetǃ(a, 0, 20);

            Assert.IsTrue((bool)actual);
        }
    }
}
