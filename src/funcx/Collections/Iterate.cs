using System;
using System.Text;
using FunctionalLibrary.Core;

namespace FunctionalLibrary.Collections
{
    public class Iterate :
        ASeq,
        IReduce,
        IPending
    {
        static readonly object UNREALIZED_SEED = new object();

        readonly IFunction<object, object> _f;
        readonly object _prevSeed;
        volatile object _seed;
        volatile ISeq _next;

        Iterate(IFunction<object, object> f, object prevSeed, object seed)
        {
            this._f = f;
            this._prevSeed = prevSeed;
            this._seed = seed;
        }

        #region Creates
        public static Iterate Create(IFunction<object, object> f, object seed) => new Iterate(f, null, seed);
        #endregion

        #region Overrides
        public override object First()
        {
            if (this._seed == UNREALIZED_SEED)
                this._seed = this._f.Invoke(this._prevSeed);

            return this._seed;
        }
        public override ISeq Next()
        {
            if (this._next == null)
                this._next = new Iterate(this._f, First(), UNREALIZED_SEED);

            return this._next;
        }
        public override IStack Pop() => throw new NotImplementedException();
        #endregion

        public bool IsRealized() => this._seed != UNREALIZED_SEED;
        public object Reduce(IFunction f)
        {
            object ff = First();
            object ret = ff;
            object v = this._f.Invoke(ff);

            while (true)
            {
                ret = ((IFunction<object, object, object>)f).Invoke(ret, v);
                if (ret is Reduced r)
                    return r.Deref();
                v = this._f.Invoke(v);
            }
        }

        public object Reduce(IFunction f, object init)
        {
            object ret = init;
            object v = First();

            while (true)
            {
                ret = ((IFunction<object, object, object>)f).Invoke(ret, v);
                if (ret is Reduced r)
                    return r.Deref();
                v = this._f.Invoke(v);
            }
        }
    }
}
