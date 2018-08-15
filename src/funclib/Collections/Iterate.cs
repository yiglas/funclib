using funclib.Components.Core;
using System;

namespace funclib.Collections
{
    public class Iterate :
        ASeq,
        IReduce,
        IPending
    {
        static readonly object UNREALIZED_SEED = new object();

        readonly object _f;
        readonly object _prevSeed;
        volatile object _seed;
        volatile ISeq _next;

        Iterate(object f, object prevSeed, object seed)
        {
            this._f = f;
            this._prevSeed = prevSeed;
            this._seed = seed;
        }

        #region Creates
        public static Iterate Create(object f, object seed) => new Iterate(f, null, seed);
        #endregion

        #region Overrides
        public override object First()
        {
            if (this._seed == UNREALIZED_SEED)
                this._seed = funclib.Core.Invoke(this._f, this._prevSeed);

            return this._seed;
        }
        public override ISeq Next()
        {
            if (this._next is null)
                this._next = new Iterate(this._f, First(), UNREALIZED_SEED);

            return this._next;
        }
        public override IStack Pop() => throw new NotImplementedException();
        #endregion

        public bool IsRealized() => this._seed != UNREALIZED_SEED;
        public object Reduce(object f)
        {
            object ff = First();
            object ret = ff;
            object v = funclib.Core.Invoke(this._f, ff);

            while (true)
            {
                ret = funclib.Core.Invoke(f, ret, v);
                if (ret is Reduced r)
                    return r.Deref();
                v = funclib.Core.Invoke(this._f, v);
            }
        }

        public object Reduce(object f, object init)
        {
            object ret = init;
            object v = First();

            while (true)
            {
                ret = funclib.Core.Invoke(f, ret, v);
                if (ret is Reduced r)
                    return r.Deref();
                v = funclib.Core.Invoke(this._f, v);
            }
        }
    }
}
