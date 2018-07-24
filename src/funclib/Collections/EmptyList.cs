using funclib.Components.Core;
using System;
using System.Collections;
using System.Text;
using static funclib.Core;

namespace funclib.Collections
{
    public class EmptyList : 
        IList
    {
        public int Count => 0;
        public bool IsFixedSize => true;
        public bool IsReadOnly => true;
        public bool IsSynchronized => true;
        public object SyncRoot => this;

        public object this[int index]
        {
            get => throw new ArgumentOutOfRangeException(nameof(index), $"Cannot access elements in an {nameof(EmptyList)}");
            set => throw new InvalidOperationException($"Cannot modify an immutable {nameof(EmptyList)}.");
        }

        #region Overrides
        public override int GetHashCode() => 1;
        public override bool Equals(object obj) => (obj is ISequential || obj is System.Collections.IList) && seq(obj) is null;
        public override string ToString() => "()";
        #endregion

        #region Invalid Operations
        public int Add(object value) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(EmptyList)}.");
        public void Clear() => throw new InvalidOperationException($"Cannot modify an immutable {nameof(EmptyList)}.");
        public void Insert(int index, object value) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(EmptyList)}.");
        public void Remove(object value) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(EmptyList)}.");
        public void RemoveAt(int index) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(EmptyList)}.");
        #endregion

        public object Peek() => null;
        public IStack Pop() => throw new InvalidOperationException($"Cannot pop an {nameof(EmptyList)}");
        public ISeq Cons(object o) => new List(o, null, 1);
        public object First() => null;
        public ISeq Next() => null;
        public ISeq More() => this;
        ICollection ICollection.Cons(object o) => Cons(o);
        public ICollection Empty() => this;
        public ISeq Seq() => null;
        public bool Contains(object value) => false;
        public int IndexOf(object value) => -1;
        public void CopyTo(Array array, int index) { /* no items to copy. */ }
        public IEnumerator GetEnumerator()
        {
            yield break;
        }
    }
}
