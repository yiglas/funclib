using NUnit.Framework;
using System;

namespace funclib.Tests.Components.Core
{
    public class IsUUIDShould
    {
        [Test]
        public void IsUUID_should_return_true_if_an_object_is_a_guid()
        {
            Assert.IsTrue((bool)funclib.Core.IsUUID(Guid.NewGuid()));
            Assert.IsTrue((bool)funclib.Core.IsUUID(Guid.Parse("00000000-0000-0000-0000-000000000000")));
        }

        [Test]
        public void IsUUID_should_return_True_if_an_object_is_not_a_guid()
        {
            Assert.IsFalse((bool)funclib.Core.IsUUID(1));
            Assert.IsFalse((bool)funclib.Core.IsUUID(null));
            Assert.IsFalse((bool)funclib.Core.IsUUID(false));
        }
    }
}
