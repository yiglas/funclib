using funclib.Collections;
using System;
using System.Text;
using System.Threading;

namespace funclib.Collections.Internal
{
    sealed class TransientSortedMap :
        ATransientMap
    {
        [NonSerialized]
        readonly AtomicReference<Thread> _edit;
        readonly System.Collections.IComparer _comp;
        volatile RedBlackNode _tree;
        volatile int _count;

        public TransientSortedMap(SortedMap init) :
            this(new AtomicReference<Thread>(Thread.CurrentThread), init.Comp, init.Tree, init.Count) { }

        public TransientSortedMap(AtomicReference<Thread> edit, System.Collections.IComparer comp, RedBlackNode tree, int count)
        {
            this._edit = edit;
            this._comp = comp;
            this._tree = tree;
            this._count = count;
        }

        #region Creates
        #endregion

        #region Overrides
        protected override ITransientMap DoAssoc(object key, object val)
        {
            var found = new Box(null);
            var t = SortedMap.Add(this._comp, this._tree, key, val, found);
            if (t == null)
            {
                var foundNode = found.Value as RedBlackNode;
                if (foundNode.Value == val)
                    return this;

                this._tree = SortedMap.Replace(this._comp, this._tree, key, val);
                return this;
            }

            this._tree = t.Blacken();
            this._count++;
            return this;
        }
        protected override int DoCount() => this._count;
        protected override object DoGetValue(object key, object notFound)
        {
            var n = SortedMap.NodeAt(this._comp, this._tree, key);
            return n != null ? n.Value : notFound;
        }
        protected override IMap DoToPersistent()
        {
            this._edit.Set(null);
            return new SortedMap(this._comp, this._tree, this._count);
        }
        protected override ITransientMap DoWithout(object key)
        {
            var found = new Box(null);
            var t = SortedMap.Remove(this._comp, this._tree, key, found);
            if (t == null)
            {
                return this;
            }

            this._tree = t.Blacken();
            this._count--;
            return this;
        }
        protected override bool EnsureEditable() =>
            this._edit.Get() == null
                ? throw new InvalidOperationException("Transient used after persistent! call")
                : true;
        #endregion
    }
}
