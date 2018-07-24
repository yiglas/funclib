using funclib.Components.Core;
using System;
using System.Text;
using System.Threading;
using static funclib.Core;

namespace funclib.Collections.Internal
{
    sealed class TransientArrayMap :
        ATransientMap
    {
        volatile int _length;
        readonly object[] _array;

        [NonSerialized]
        volatile Thread _owner;

        public TransientArrayMap(object[] init)
        {
            this._owner = Thread.CurrentThread;
            this._array = new object[Math.Max(Constants.HASH_TABLE_THRESHOLD, init.Length)];
            System.Array.Copy(init, this._array, init.Length);
            this._length = init.Length;
        }

        #region Creates
        #endregion

        #region Overrides
        protected override ITransientMap DoAssoc(object key, object val)
        {
            int i = IndexOf(key);
            if (i >= 0)
            {
                if (this._array[i + 1] != val)
                    this._array[i + 1] = val;
            }
            else
            {
                if (this._length >= this._array.Length)
                    return ((ITransientMap)HashMap.Create(this._array).ToTransient()).Assoc(key, val);

                this._array[this._length++] = key;
                this._array[this._length++] = val;
            }

            return this;
        }
        protected override int DoCount() => this._length / 2;
        protected override object DoGetValue(object key, object notFound)
        {
            int i = IndexOf(key);
            if (i >= 0)
                return this._array[i + 1];
            return notFound;
        }
        protected override IMap DoToPersistent()
        {
            this._owner = null;
            var a = new object[this._length];
            System.Array.Copy(this._array, a, this._length);
            return ArrayMap.Create(a);
        }
        protected override ITransientMap DoWithout(object key)
        {
            int i = IndexOf(key);
            if (i >= 0)
            {
                if (this._length >= 2)
                {
                    this._array[i] = this._array[this._length - 2];
                    this._array[i + 1] = this._array[this._length - 1];
                }
                this._length -= 2;
            }
            return this;
        }
        protected override bool EnsureEditable() =>
            this._owner is null
                ? throw new InvalidOperationException("Transient used after persistent! call")
                : true;
        #endregion

        bool IsEqual(object a, object b) => (bool)isEqualTo(a, b);

        int IndexOf(object key)
        {
            for (int i = 0; i < this._length; i += 2)
                if (IsEqual(this._array[i], key))
                    return i;

            return -1;
        }
    }
}
