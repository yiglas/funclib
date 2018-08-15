using NUnit.Framework;

namespace funclib.Tests.Components.Core
{
    public class ZipMapShould
    {
        [Test]
        public void ZipMap_should_zip_two_list_together()
        {
            var expected = funclib.Core.ArrayMap(":a", 1, ":b", 2, ":c", 3);
            var actual = funclib.Core.ZipMap(funclib.Core.Vector(":a", ":b", ":c"), funclib.Core.Vector(1, 2, 3));

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ZipMap_should_zip_two_list_together_with_one_being_infinit()
        {
            var expected = funclib.Core.ArrayMap(":a", 0, ":b", 1, ":c", 2);
            var actual = funclib.Core.ZipMap(funclib.Core.Vector(":a", ":b", ":c"), funclib.Core.Range());

            Assert.AreEqual(expected, actual);
        }
    }
}
