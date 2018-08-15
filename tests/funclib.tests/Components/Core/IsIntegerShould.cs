using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class IsIntegerShould
    {
        [Test]
        public void IsInteger_should_return_true_if_an_object_is_integer()
        {
            Assert.IsTrue((bool)funclib.Core.IsInteger(1));
            Assert.IsTrue((bool)funclib.Core.IsInteger((short)1));
            Assert.IsTrue((bool)funclib.Core.IsInteger((long)1));
            Assert.IsTrue((bool)funclib.Core.IsInteger((byte)1));
            Assert.IsTrue((bool)funclib.Core.IsInteger((uint)1));
            Assert.IsTrue((bool)funclib.Core.IsInteger((ushort)1));
            Assert.IsTrue((bool)funclib.Core.IsInteger((ulong)1));
            Assert.IsTrue((bool)funclib.Core.IsInteger((sbyte)1));
            Assert.IsTrue((bool)funclib.Core.IsInteger((char)1));
        }

        [Test]
        public void IsInteger_should_return_false_if_an_object_is_not_integer()
        {
            Assert.IsFalse((bool)funclib.Core.IsInteger(1D));
            Assert.IsFalse((bool)funclib.Core.IsInteger(null));
        }
    }
}
