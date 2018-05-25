using funcx.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace funcx.Collections.Internal
{
    class TransientSet : 
        ITransientSet,
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        volatile ITransientMap _impl;

        public TransientSet(ITransientMap impl)
        {
            this._impl = impl;
        }

        public int Count => this._impl.Count;

        public ITransientCollection Conj(object val)
        {
            var m = this._impl.Assoc(val, val);
            if (m != this._impl)
                this._impl = m;
            return this;
        }
        public bool Contains(object key) => this != this._impl.GetValue(key, this);
        public ITransientSet Disjoin(object key)
        {
            var m = this._impl.Without(key);
            if (m != this._impl)
                this._impl = m;
            return this;
        }
        public object Get(object key) => this._impl.GetValue(key);
        public ICollection ToPersistent() => new HashSet(this._impl.ToPersistent());

        public object Invoke(object key) => this._impl.GetValue(key);
        public object Invoke(object key, object notFound) => this._impl.GetValue(key, notFound);

    }
}
