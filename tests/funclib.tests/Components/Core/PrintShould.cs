using funclib.Components.Core;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using static funclib.Core;

namespace funclib.Tests.Components.Core
{
    public class PrintShould
    {
        StringWriter _writer;

        [SetUp]
        public void SetUp()
        {
            Variables.Out = this._writer = new StringWriter();
        }

        [TearDown]
        public void TearDown()
        {
            Variables.Out = Console.Out;
        }

        [Test]
        public void Print_should_write_string()
        {
            new Print().Invoke("Foo");
            Assert.AreEqual(this._writer.ToString(), "Foo");
        }

        [Test]
        public void Print_should_write_double()
        {
            var expected = 10D;
            new Print().Invoke(expected);
            Assert.AreEqual(this._writer.ToString(), "10.0");
        }

        [Test]
        public void Print_should_write_float()
        {
            float expected = 10.0F;
            new Print().Invoke(expected);
            Assert.AreEqual(this._writer.ToString(), "10.0");
        }

        [Test]
        public void Print_should_write_short()
        {
            var expected = (short)10;
            new Print().Invoke(expected);
            Assert.AreEqual(this._writer.ToString(), "10");
        }

        [Test]
        public void Print_should_write_int()
        {
            var expected = 10;
            new Print().Invoke(expected);
            Assert.AreEqual(this._writer.ToString(), "10");
        }

        [Test]
        public void Print_should_write_long()
        {
            var expected = (long)10;
            new Print().Invoke(expected);
            Assert.AreEqual(this._writer.ToString(), "10");
        }

        [Test]
        public void Print_should_write_ushort()
        {
            var expected = (ushort)10;
            new Print().Invoke(expected);
            Assert.AreEqual(this._writer.ToString(), "10");
        }

        [Test]
        public void Print_should_write_uint()
        {
            var expected = (uint)10;
            new Print().Invoke(expected);
            Assert.AreEqual(this._writer.ToString(), "10");
        }

        [Test]
        public void Print_should_write_ulong()
        {
            var expected = (ulong)10;
            new Print().Invoke(expected);
            Assert.AreEqual(this._writer.ToString(), "10");
        }

        [Test]
        public void Print_should_write_byte()
        {
            var expected = (byte)10;
            new Print().Invoke(expected);
            Assert.AreEqual(this._writer.ToString(), "10");
        }

        [Test]
        public void Print_should_write_sbyte()
        {
            var expected = (sbyte)10;
            new Print().Invoke(expected);
            Assert.AreEqual(this._writer.ToString(), "10");
        }

        [Test]
        public void Print_should_write_bool()
        {
            var expected = true;
            new Print().Invoke(expected);
            Assert.AreEqual(this._writer.ToString(), "true");
        }

        [Test]
        public void Print_should_write_char()
        {
            var expected = 'c';
            new Print().Invoke(expected);
            Assert.AreEqual(this._writer.ToString(), "\\c");
        }

        [Test]
        public void Print_should_write_type()
        {
            var expected = 'c'.GetType();
            new Print().Invoke(expected);
            Assert.AreEqual(this._writer.ToString(), "System.Char");
        }

        [Test]
        public void Print_should_write_regex()
        {
            var expected = new Regex("\\d+");
            new Print().Invoke(expected);
            Assert.AreEqual(this._writer.ToString(), "#\"\\d+\"");
        }

        [Test]
        public void Print_should_write_ISeq()
        {
            var expected = new Seq().Invoke(new funclib.Components.Core.List().Invoke(1, 2, 3));
            new Print().Invoke(expected);
            Assert.AreEqual(this._writer.ToString(), "(1 2 3)");
        }

        [Test]
        public void Print_should_write_IVector()
        {
            var expected = new Vector().Invoke(1, 2, 3);
            new Print().Invoke(expected);
            Assert.AreEqual(this._writer.ToString(), "[1 2 3]");
        }

        [Test]
        public void Print_should_write_IMap()
        {
            var expected = arrayMap(":a", 1, ":b", 2);
            new Print().Invoke(expected);
            Assert.AreEqual(this._writer.ToString(), "{\":a\" 1, \":b\" 2}");
        }

        [Test]
        public void Print_should_write_ISet()
        {
            var expected = hashSet(1, 2, 3);
            new Print().Invoke(expected);
            Assert.AreEqual(this._writer.ToString(), "#{1 2 3}");
        }

        [Test]
        public void Print_should_write_DateTime()
        {
            var expected = DateTime.Now;
            new Print().Invoke(expected);
            Assert.AreEqual(this._writer.ToString(), $"#inst \"{expected.ToString("yyyy-MM-ddTHH:mm:ss.fff-00:00")}\"");
        }

        [Test]
        public void Print_should_write_DateTimeOffset()
        {
            var expected = DateTimeOffset.Now;
            new Print().Invoke(expected);
            Assert.AreEqual(this._writer.ToString(), $"#inst \"{expected.ToString("yyyy-MM-ddTHH:mm:ss.fffzzzz")}\"");
        }

        [Test]
        public void Print_should_write_guid()
        {
            var expected = Guid.NewGuid();
            new Print().Invoke(expected);
            Assert.AreEqual(this._writer.ToString(), $"#uuid \"{expected}\"");
        }

        [Test]
        public void Print_should_write_Timespan()
        {
            var expected = TimeSpan.FromDays(1);
            new Print().Invoke(expected);
            Assert.AreEqual(this._writer.ToString(), $"1.00:00:00");
        }
    }
}
