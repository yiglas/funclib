using System;
using System.Text;

namespace FunctionalLibrary.Collections
{
    public abstract class AKeyValuePair :
        AVector,
        IKeyValuePair
    {
        #region Abstract Methods
        public abstract object Key { get; }
        public abstract object Value { get; }
        #endregion

        #region Overrides
        public override int Count => 2;
        public override object this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return Key;
                    case 1: return Value;
                }
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            set => throw new NotImplementedException();
        }
        public override IVector Assoc(int i, object val) => ToVector(Key, Value).Assoc(i, val);
        public override IVector Cons(object o) => ToVector(Key, Value).Cons(o);
        public override bool ContainsKey(object key) => ToVector(Key, Value).ContainsKey(key);
        public override IKeyValuePair Get(object key) => ToVector(Key, Value).Get(key);
        public override object GetValue(object key) => ToVector(Key, Value).GetValue(key);
        public override object GetValue(object key, object notFound) => ToVector(Key, Value).GetValue(key, notFound);
        public override ISeq Seq() => ToVector(Key, Value).Seq();
        public override ICollection Empty() => null;
        public override object Peek() => Value;
        public override IStack Pop() => ToVector(Key);
        #endregion

        IVector ToVector(params object[] items)
        {
            if (items.Length <= 32)
                return new Vector(items.Length, 5, Vector.EmptyNode, items);
            return Vector.Create(items);
        }
    }
}
