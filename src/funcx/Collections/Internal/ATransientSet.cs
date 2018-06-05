using FunctionalLibrary.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Collections.Internal
{
    abstract class ATransientSet : 
        ITransientSet,
        IFunction<object, object>,
        IFunction<object, object, object>
    {
        protected volatile ITransientMap _impl;

        public ATransientSet(ITransientMap impl)
        {
            this._impl = impl;
        }

        #region Abstract Methods
        public abstract ICollection ToPersistent();
        #endregion

        #region Functions
        public object Invoke(object key) => this._impl.GetValue(key);
        public object Invoke(object key, object notFound) => this._impl.GetValue(key, notFound);
        #endregion

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
    }
}
