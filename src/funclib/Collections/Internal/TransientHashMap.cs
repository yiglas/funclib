using System;
using System.Text;
using System.Threading;

namespace funclib.Collections.Internal
{
    sealed class TransientHashMap :
        ATransientMap
    {
        [NonSerialized]
        readonly AtomicReference<Thread> _edit;
        volatile INode _root;
        volatile int _count;
        volatile bool _hasNull;
        volatile object _nullValue;
        readonly Box _leafFlag = new Box(null);

        public TransientHashMap(HashMap init) :
            this(new AtomicReference<Thread>(Thread.CurrentThread), init.Root, init.Count, init.HasNull, init.NullValue) { }

        TransientHashMap(AtomicReference<Thread> edit, INode root, int count, bool hasNull, object nullValue)
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
        protected override ITransientMap DoAssoc(object key, object val)
        {
            if (key == null)
            {
                if (this._nullValue != val) this._nullValue = val;
                if (!this._hasNull)
                {
                    this._count++;
                    this._hasNull = true;
                }
                return this;
            }

            this._leafFlag.Value = null;
            var root = (this._root ?? BitmapIndexedNode.EMPTY).Assoc(this._edit, 0, Hash(key), key, val, this._leafFlag);

            if (root != this._root) this._root = root;
            if (this._leafFlag.Value != null) this._count++;

            return this;
        }
        protected override int DoCount() => this._count;
        protected override object DoGetValue(object key, object notFound) =>
            key == null
                ? this._hasNull ? this._nullValue
                : notFound
                : this._root == null ? notFound
                : this._root.Get(0, Hash(key), key, notFound);

        protected override IMap DoToPersistent()
        {
            this._edit.Set(null);
            return new HashMap(this._count, this._root, this._hasNull, this._nullValue);
        }

        protected override ITransientMap DoWithout(object key)
        {
            if (key == null)
            {
                if (!this._hasNull) return this;
                this._hasNull = false;
                this._nullValue = null;
                this._count--;
                return this;
            }

            if (this._root == null) return this;

            this._leafFlag.Value = null;
            var root = this._root.Without(this._edit, 0, Hash(key), key, this._leafFlag);

            if (root != this._root) this._root = root;
            if (this._leafFlag.Value != null) this._count--;

            return this;
        }
        protected override bool EnsureEditable() =>
            this._edit.Get() == null
                ? throw new InvalidOperationException("Transient used after persistent! call")
                : true;
        #endregion

        int Hash(object key) => funclib.Util.GetHashCode(key);
    }
}
