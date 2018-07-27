using System;
using System.Text;
using static funclib.core;

namespace funclib.Components.Core
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
        public virtual object Invoke() => invoke(this._rf);
        public virtual object Invoke(object result) => invoke(this._rf, result);
        #endregion

        #region Abstract Methods
        public abstract object Invoke(object result, object input);
        #endregion
    }
}
