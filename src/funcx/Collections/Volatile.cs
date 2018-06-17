using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Collections
{
    public sealed class Volatile :
        IDeref
    {
        volatile object _val;

        public Volatile(object val) => this._val = val;

        public object Deref() => this._val;

        public object Reset(object newVal) => this._val = newVal;
    }
}
