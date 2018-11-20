
using System;
using System.Collections;
using System.Collections.Generic;

namespace funclib.Collections.Generic
{
    public class EmptyList<T> :
        IList<T>
    {
        public int Count => 0;
        public bool IsFixedSize => true;
        public bool IsReadOnly => true;
        public object SyncRoot => this;

        public T this[int index]
        {
            get => throw new ArgumentOutOfRangeException(nameof(index), $"Cannot access elements in an {nameof(EmptyList<T>)}");
            set => throw new InvalidOperationException($"Cannot modify an immutable {nameof(EmptyList<T>)}.");
        }

        #region Overrides
        public override int GetHashCode() => 1;
        public override bool Equals(object obj) => throw new System.NotImplementedException();
        public override string ToString() => "()";
        #endregion

        #region Invalid Operations
        public void Add(T value) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(EmptyList<T>)}.");
        public void Clear() => throw new InvalidOperationException($"Cannot modify an immutable {nameof(EmptyList<T>)}.");
        public void Insert(int index, T value) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(EmptyList<T>)}.");
        public bool Remove(T value) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(EmptyList<T>)}.");
        public void RemoveAt(int index) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(EmptyList<T>)}.");
        #endregion

        public T Peek() => default;
        public IStack<T> Pop()=> throw new InvalidOperationException($"Cannot pop an {nameof(EmptyList<T>)}");
        public ISeq<T> Cons(T o) => new List<T>(o, null, 1);
        public T First() => default;
        public ISeq<T> Next() => default;
        public ISeq<T> More() => default;
        ICollection<T> ICollection<T>.Cons(T o) => Cons(o);
        public ICollection<T> Empty() => this;
        public ISeq<T> Seq() => default;
        public bool Contains(T item) => false;
        public int IndexOf(T item) => -1;
        public void CopyTo(T[] array, int index) { /* no items to copy. */ }
        public IEnumerator<T> GetEnumerator()
        {
            yield break;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            yield break;
        }
    }
}