using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Collections
{
    public sealed class Reduced :
        IDeref
    {
        readonly object _val;

        public Reduced(object val) => this._val = val;

        public object Deref() => this._val;
    }
}
