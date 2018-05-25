using funcx.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace funcx.Collections
{
    [Serializable]
    public sealed class Cons :
        Enumerative
    {
        readonly object _first;
        readonly IEnumerative _more;

        public Cons(object first, IEnumerative more)
        {
            this._first = first;
            this._more = more;
        }

        public override int Count => 1 + new Count().Invoke(this._more);
        public override object First() => this._first;
        public override IEnumerative Next() => More().Enumerate();
        public override IEnumerative More() => this._more == null ? List.EMPTY : this._more;
        public override IStack Pop() => throw new NotImplementedException();
    }
}
