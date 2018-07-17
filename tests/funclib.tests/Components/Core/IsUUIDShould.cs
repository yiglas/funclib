using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace funclib.Tests.Components.Core
{
    public class IsUUIDShould
    {
        [Test]
        public void IsUUID_should_return_true_if_an_object_is_a_guid()
        {
            Assert.IsTrue((bool)new IsUUID().Invoke(Guid.NewGuid()));
            Assert.IsTrue((bool)new IsUUID().Invoke(Guid.Parse("00000000-0000-0000-0000-000000000000")));
        }

        [Test]
        public void IsUUID_should_return_True_if_an_object_is_not_a_guid()
        {
            Assert.IsFalse((bool)new IsUUID().Invoke(1));
            Assert.IsFalse((bool)new IsUUID().Invoke(null));
            Assert.IsFalse((bool)new IsUUID().Invoke(false));
        }
    }
}
