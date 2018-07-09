using FunctionalLibrary.Core;
using NUnit.Framework;
using System;
using System.Text;

namespace FunctionalLibrary.Tests.Core
{
    public class HashMapShould
    {
        [Test]
        public void HashMap_should_create_in_correct_order()
        {
            var actual = new HashMap().Invoke(":a", 1, ":b", 2, ":c", 3, ":d", 4, ":e", 5);
        }
    }
}
