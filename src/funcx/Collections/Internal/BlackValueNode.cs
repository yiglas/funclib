using System;
using System.Collections.Generic;
using System.Text;

namespace funcx.Collections.Internal
{
    class BlackValueNode :
        BlackNode
    {
        protected readonly object _val;

        public BlackValueNode(object key, object val)
            : base(key)
        {
            this._val = val;
        }

        public override object Value => this._val;

        protected internal override RedBlackNode Redden() => new RedValueNode(this._key, this._val);
    }
}
