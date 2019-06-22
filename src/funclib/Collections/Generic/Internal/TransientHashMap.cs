using System;
using System.Threading;

namespace funclib.Collections.Generic.Internal
{
    sealed class TransientHashMap<TKey, TValue> :
        ATransientMap<TKey, TValue>
    {
        readonly AtomicReference<Thread> _edit;
        INode<TKey, TValue> _root;
        int _count;
        bool _hasNull;
        TValue _nullValue;
        readonly Box<object> _leafFlag = new Box<object>(null);

        public TransientHashMap(HashMap<TKey, TValue> init) :
            this(new AtomicReference<Thread>(Thread.CurrentThread), init.Root, init.Count, init.HasNull, init.NullValue) { }

        TransientHashMap(AtomicReference<Thread> edit, INode<TKey, TValue> root, int count, bool hasNull, TValue nullValue)
        {
            this._edit = edit;
            this._root = root;
            this._count = count;
            this._hasNull = hasNull;
            this._nullValue = nullValue;
        }

        #region Creates
        #endregion

        #region Overrides
        protected override ITransientMap<TKey, TValue> DoAssoc(TKey key, TValue val)
        {
            if (key is null)
            {
                if (!funclib.Generic.Core.Equals(this._nullValue, val))
                {
                    this._nullValue = val;
                }

                if (!this._hasNull)
                {
                    this._count++;
                    this._hasNull = true;
                }
                return this;
            }

            this._leafFlag.Value = null;
            var root = (this._root ?? BitmapIndexedNode<TKey, TValue>.EMPTY).Assoc(this._edit, 0, Hash(key), key, val, this._leafFlag);

            if (root != this._root)
            {
                this._root = root;
            }

            if (this._leafFlag.Value != null)
            {
                this._count++;
            }

            return this;
        }
        protected override int DoCount() => this._count;
        protected override TValue DoGetValue(TKey key, TValue notFound)
        {
            if (key is null)
            {
                if (this._hasNull)
                {
                    return this._nullValue;
                }

                return notFound;
            }

            if (this._root != null)
            {
                return this._root.Get(0, Hash(key), key, notFound);
            }

            return notFound;
        }

        protected override IMap<TKey, TValue> DoToPersistent()
        {
            this._edit.Set(null);
            return new HashMap<TKey, TValue>(this._count, this._root, this._hasNull, this._nullValue);
        }

        protected override ITransientMap<TKey, TValue> DoWithout(TKey key)
        {
            if (key is null)
            {
                if (!this._hasNull) return this;
                this._hasNull = false;
                this._nullValue = default;
                this._count--;
                return this;
            }

            if (this._root is null)
            {
                return this;
            }

            this._leafFlag.Value = null;
            var root = this._root.Without(this._edit, 0, Hash(key), key, this._leafFlag);

            if (root != this._root)
            {
                this._root = root;
            }

            if (this._leafFlag.Value != null)
            {
                this._count--;
            }

            return this;
        }
        protected override bool EnsureEditable()
        {
            if (this._edit.Get() is null)
            {
                throw new InvalidOperationException("Transient used after persistent! call");
            }

            return true;
        }
        #endregion

        int Hash(object key) => funclib.Util.GetHashCode(key);
    }
}