using funclib.Components.Core;
using funclib.Components.Core.Generic;
using NUnit.Framework;


namespace funclib.Tests.Components.Core
{
    public class ComplementShould
    {
        [Test]
        public void Complement_should_return_the_complement_of_the_given_function()
        {
            var notEmpty = (Complement.Function)funclib.Core.Complement(new IsEmpty());

            Assert.IsFalse((bool)notEmpty.Invoke(funclib.Core.Vector()));
            Assert.IsTrue((bool)notEmpty.Invoke(funclib.Core.Vector(1, 2)));
        }

        [Test]
        public void Complement_should_return_the_complement_with_muliple_param_for_a_given_function()
        {
            var containsChar = new Function<object, object, object>((s, c) => funclib.Core.Some(new Function<object, object>(x => c.Equals(x)), s));

            Assert.IsTrue((bool)containsChar.Invoke("abc", 'b'));
        }
    }
}
