using System;

namespace funclib.Collections.Generic
{
    public abstract class ASeq<T> :
        IList<T>,
        ISeqable<T>,
        IList,
        ISeqable
    {
        [NonSerialized]
        protected int _hash = 0;

        public bool IsReadOnly => true;
        public bool IsFixedSize => true;
        public bool IsSynchronized => true;
        public object SyncRoot => this;

        #region Overrides
        public override string ToString() => Util.Print(this);

        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (!(obj is System.Collections.Generic.IList<T>)) return false;

            var me = funclib.Generic.Core.Seq<T>(obj);

            for (var e = Seq(); e != null; e = e.Next(), me = me.Next())
            {
                if (me is null || !funclib.Generic.Core.IsEqualTo(e.First(), me.First()))
                    return false;
            }

            return me is null;
        }

        public override int GetHashCode()
        {
            var hash = this._hash;
            if (hash == 0)
            {
                for (var e = Seq(); e != null; e = e.Next())
                    hash = 31 * hash + (e.First()?.GetHashCode() ?? 0);

                this._hash = hash;
            }
            return hash;
        }
        #endregion

        #region Invalid Operations
        public void Add(T item) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ASeq<T>)}.");
        public int Add(object value) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ASeq<T>)}.");
        public void Clear() => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ASeq<T>)}.");
        public void Insert(int index, T item) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ASeq<T>)}.");
        public void Insert(int index, object value) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ASeq<T>)}.");
        public bool Remove(T item) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ASeq<T>)}.");
        public void Remove(object value) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ASeq<T>)}.");
        public void RemoveAt(int index) => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ASeq<T>)}.");
        #endregion

        #region Abstract Methods
        public abstract T First();
        public abstract ISeq<T> Next();
        public abstract IStack<T> Pop();
        #endregion

        #region Virtual Methods
        public virtual ISeq<T> Cons(T o) => new Cons<T>(o, this);
        public virtual ISeq<T> More() => Next() ?? List<T>.EMPTY;
        public virtual int Count
        {
            get
            {
                int i = 1;
                for (var e = Next(); e != null; e = e.Next(), i++)
                {
                    if (e is ICounted c)
                        return i + c.Count;
                }

                return i;
            }
        }
        public virtual ICollection<T> Empty() => List<T>.EMPTY;
        #endregion

        public T this[int index] { get => throw new NotImplementedException(); set => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ASeq<T>)}."); }
        object IList.this[int index] { get => throw new NotImplementedException(); set => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ASeq<T>)}."); }
        object System.Collections.IList.this[int index] { get => throw new NotImplementedException(); set => throw new InvalidOperationException($"Cannot modify an immutable {nameof(ASeq<T>)}."); }



        public ISeq Cons(object o) => throw new NotImplementedException();
        public bool Contains(T item) => throw new NotImplementedException();
        public bool Contains(object value) => throw new NotImplementedException();
        public void CopyTo(T[] array, int arrayIndex) => throw new NotImplementedException();
        public void CopyTo(Array array, int index) => throw new NotImplementedException();
        
        public System.Collections.Generic.IEnumerator<T> GetEnumerator() => throw new NotImplementedException();
        public int IndexOf(T item) => throw new NotImplementedException();
        public int IndexOf(object value) => throw new NotImplementedException();
        
        public T Peek() => throw new NotImplementedException();
        public ISeq<T> Seq() => throw new NotImplementedException();

        ICollection<T> ICollection<T>.Cons(T o) => Cons(o);
        ICollection ICollection.Cons(object o) => Cons(o);
        int ICollection<T>.Count() => Count;
        ICollection ICollection.Empty() => throw new NotImplementedException();
        object ISeq.First() => First;
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => throw new NotImplementedException();
        ISeq ISeq.More() => throw new NotImplementedException();
        ISeq ISeq.Next() => throw new NotImplementedException();
        object IStack.Peek() => Peek();
        IStack IStack.Pop() => throw new NotImplementedException();
        ISeq ISeqable.Seq() => throw new NotImplementedException();
    }
}
