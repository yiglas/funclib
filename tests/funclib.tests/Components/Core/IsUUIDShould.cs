using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class IsUUIDShould
    {
        [Test]
        public void IsUUID_should_return_true_if_an_object_is_a_guid()
        {
            Assert.IsTrue((bool)isUUID(Guid.NewGuid()));
            Assert.IsTrue((bool)isUUID(Guid.Parse("00000000-0000-0000-0000-000000000000")));
        }

        [Test]
        public void IsUUID_should_return_True_if_an_object_is_not_a_guid()
        {
            Assert.IsFalse((bool)isUUID(1));
            Assert.IsFalse((bool)isUUID(null));
            Assert.IsFalse((bool)isUUID(false));
        }
    }
}
