using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.Text;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class HashMapShould
    {
        [Test]
        public void HashMap_should_create_in_correct_order()
        {
            var actual = hashMap(":a", 1, ":b", 2, ":c", 3, ":d", 4, ":e", 5);
        }
    }
}
