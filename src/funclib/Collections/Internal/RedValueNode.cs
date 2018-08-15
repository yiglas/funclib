namespace funclib.Collections.Internal
{
    class RedValueNode :
        RedNode
    {
        protected readonly object _val;

        public RedValueNode(object key, object val) :
            base(key)
        {
            this._val = val;
        }

        public override object Value => this._val;

        protected internal override RedBlackNode Blacken() => new BlackValueNode(this._key, this._val);
    }
}
