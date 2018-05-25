using funcx.Core;
using System;
using System.Text;

namespace funcx.Collections
{
    // TODO: test to see if Linq's Reverse will work

    public class SortedSet :
        Set,
        ISorted
    {
        public static readonly SortedSet EMPTY = new SortedSet();
        
        SortedSet() : this(null) { } // TODO: pass SortedMap.EMPTY instead of null
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
            ICollection ret = new SortedSet(new SortedMap(null, comp));

            foreach (var item in init)
                ret = ret.Cons(item);

            return ret as SortedSet;
        }
        #endregion

        #region Overrides
        public override ICollection Cons(object o) => Contains(o) ? this : new SortedSet(this._impl.Assoc(o, o));
        public override ISet Disjoin(object key) => Contains(key) ? new SortedSet(this._impl.Without(key)) : this;
        public override ICollection Empty() => EMPTY;
        public override ITransientCollection ToTransient() => this._impl.ToTransient(); // TODO: implement this properly.
        #endregion

        public System.Collections.IComparer GetComparator() => (this._impl as ISorted)?.GetComparator();
    }
}
