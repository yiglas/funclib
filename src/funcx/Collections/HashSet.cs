using FunctionalLibrary.Core;
using System;
using System.Text;

namespace FunctionalLibrary.Collections
{
    public class HashSet : 
        ASet
    {
        public static HashSet EMPTY = new HashSet();

        HashSet() : this(HashMap.EMPTY) { }
        internal HashSet(IMap impl)
        {
            this._impl = impl;
        }

        #region Creates
        public static HashSet Create(params object[] init)
        {
            var ret = EMPTY.ToTransient();

            for (int i = 0; i < init.Length; ++i)
            {
                ret = ret.Conj(init[i]);
                if (ret.Count != i + 1)
                    throw new ArgumentException($"Duplicate key: {init[i]}");
            }

            return ret.ToPersistent() as HashSet;
        }

        public static HashSet Create(System.Collections.IEnumerable init)
        {
            var ret = EMPTY.ToTransient();
            int i = 0;

            foreach (var item in init)
            {
                ret = ret.Conj(item);
                if (ret.Count != i + 1)
                    throw new ArgumentException($"Duplicate key: {item}");

                i++;
            }

            return ret.ToPersistent() as HashSet;
        }
        #endregion

        #region Overrides
        public override ICollection Cons(object o) => Contains(o) ? this : new HashSet(this._impl.Assoc(o, o));
        public override ISet Disj(object key) => Contains(key) ? new HashSet(this._impl.Without(key)) : this;
        public override ICollection Empty() => EMPTY;
        public override ITransientCollection ToTransient() => this._impl.ToTransient(); // TODO: implement this properly.
        #endregion
    }
}
