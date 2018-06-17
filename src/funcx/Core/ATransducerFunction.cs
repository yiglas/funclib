using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public abstract class ATransducerFunction :
        ITransducerFunction
    {
        protected object _rf;

        protected ATransducerFunction(object rf)
        {
            this._rf = rf;
        }

        #region Virtual Methods
        public virtual object Invoke() => ((IFunction<object>)this._rf).Invoke();
        public virtual object Invoke(object result) => ((IFunction<object, object>)this._rf).Invoke(result);
        #endregion

        #region Abstract Methods
        public abstract object Invoke(object result, object input);
        #endregion
    }
}
