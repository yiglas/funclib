using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Tests.Components.Core
{
    public class VolatileǃShould
    {
        [Test]
        public void Volatileǃ_should_return_a_volatile_object()
        {
            var actual = volatileǃ(0);

            Assert.IsInstanceOf<Volatileǃ>(actual);
        }

        [Test]
        public void Volatileǃ_should_return_value_when_called_via_deref()
        {
            var expected = 0;
            var actual = deref(volatileǃ(0));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Volatileǃ_should_swap_the_value_via_a_function()
        {
            var val = volatileǃ(0);

            var expected = 1;
            var actual = new VSwapǃ(val, new Inc()).Invoke();

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected, deref(val));
        }

        [Test]
        public void Volatileǃ_should_swap_the_value_when_called_reset()
        {
            var val = volatileǃ(0);

            var expected = "nothing";
            var actual = vresetǃ(val, "nothing");

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected, deref(val));
        }
    }
}
