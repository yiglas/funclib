using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class VSwap_ :
        IMacroFunction
    {
        Volatile _v;
        object _f;
        object[] _args;

        public VSwap_(object vol, object f, params object[] args)
        {
            this._v = (Volatile)vol;
            this._f = f;
            this._args = args;
        }

        public object Invoke() => this._v.Reset(new Apply().Invoke(this._f, this._v.Deref(), this._args));
    }
}
