﻿using System;

namespace funclib.Collections
{
    [Serializable]
    public sealed class Cons :
        ASeq
    {
        readonly object _first;
        readonly ISeq _more;

        public Cons(object first, ISeq more)
        {
            this._first = first;
            this._more = more;
        }

        #region Overrides
        public override int Count => 1 + (int)funclib.Core.Count(this._more);
        public override object First() => this._first;
        public override ISeq Next() => More().Seq();
        public override ISeq More() => this._more is null ? List.EMPTY : this._more;
        public override IStack Pop() => throw new NotImplementedException();
        #endregion
    }
}
