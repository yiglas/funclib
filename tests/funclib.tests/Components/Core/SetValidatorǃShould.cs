using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class SetValidatorǃShould
    {
        [Test]
        public void SetValidatorǃ_should_return_null()
        {
            var atm = funclib.Core.Atom(funclib.Core.Vector(2));
            var actual = funclib.Core.SetValidatorǃ(atm, funclib.Core.Func((object _1) => (object)true));

            Assert.IsNull(actual);
        }

        [Test]
        public void SetValidatorǃ_should_set_the_validator_function()
        {
            var atm = funclib.Core.Atom(funclib.Core.Vector(2));
            var actual = funclib.Core.SetValidatorǃ(atm, funclib.Core.Func((object _1) => (object)true));
            var validator = funclib.Core.GetValidator(atm);

            Assert.IsNotNull(validator);
            Assert.IsInstanceOf<funclib.Components.Core.IFunction>(validator);
        }
    }
}
