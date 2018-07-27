using funclib.Components.Core;
using System;
using System.Text;
using static funclib.core;

namespace funclib.Collections
{
    public class SortedSet :
        ASet,
        ISorted
    {
        public static readonly SortedSet EMPTY = new SortedSet();
        
        SortedSet() : this(SortedMap.EMPTY) { }
        internal SortedSet(IMap impl)
        {
            this._impl = impl;
        }

        #region Creates
        public static SortedSet Create(System.Collections.IEnumerable init)
        {
            ICollection ret = EMPTY;

            foreach (var item in init)
                ret = ret.Cons(item);

            return ret as SortedSet;
        }

        public static SortedSet Create(System.Collections.IComparer comp, System.Collections.IEnumerable init)
        {
            ICollection ret = new SortedSet(new SortedMap(comp));

            foreach (var item in init)
                ret = ret.Cons(item);

            return ret as SortedSet;
        }
        #endregion

        #region Overrides
        public override ICollection Cons(object o) => Contains(o) ? this : new SortedSet(this._impl.Assoc(o, o));
        public override ISet Disj(object key) => Contains(key) ? new SortedSet(this._impl.Without(key)) : this;
        public override ICollection Empty() => EMPTY;
        public override ITransientCollection ToTransient() => this._impl.ToTransient(); // TODO: implement this properly.
        #endregion

        public System.Collections.IComparer GetComparator() => (this._impl as ISorted)?.GetComparator();
        public ISeq Seq(bool ascending) => (ISeq)keys((this._impl as SortedMap).Seq(ascending));
        public ISeq Seq(object key, bool ascending) => (ISeq)keys((this._impl as SortedMap).Seq(key, ascending));
    }
}
