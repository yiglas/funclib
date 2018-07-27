using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class SetValidatorǃShould
    {
        [Test]
        public void SetValidatorǃ_should_return_null()
        {
            var atm = atom(vector(2));
            var actual = setValidatorǃ(atm, func((object _1) => (object)true));

            Assert.IsNull(actual);
        }

        [Test]
        public void SetValidatorǃ_should_set_the_validator_function()
        {
            var atm = atom(vector(2));
            var actual = setValidatorǃ(atm, func((object _1) => (object)true));
            var validator = getValidator(atm);

            Assert.IsNotNull(validator);
            Assert.IsInstanceOf<funclib.Components.Core.IFunction>(validator);
        }
    }
}
