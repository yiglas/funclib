using System;
using System.Text;
using FunctionalLibrary.Core;

namespace FunctionalLibrary.Collections
{
    public class Repeat :
        ASeq,
        IReduce
    {
        const long INFINITE = -1;

        readonly long _count;
        readonly object _val;
        volatile ISeq _next;

        Repeat(long count, object val)
        {
            this._count = count;
            this._val = val;
        }

        #region Creates
        public static Repeat Create(object val) => new Repeat(INFINITE, val);
        public static ISeq Create(long count, object val) => count <= 0 ? List.EMPTY : new Repeat(count, val);
        #endregion

        #region Overrides
        public override object First() => this._val;
        public override ISeq Next() =>
            this._next != null
                ? this._next
                : this._count > 1 ? this._next = new Repeat(this._count - 1, this._val)
                : this._count == INFINITE ? this._next = this
                : this._next;

        public override IStack Pop() => throw new NotImplementedException();
        #endregion

        public object Reduce(IFunction<object, object, object> f)
        {
            var ret = this._val;
            if (this._count == INFINITE)
            {
                while (true)
                {
                    ret = f.Invoke(ret, this._val);
                    if ((bool)new IsReduced().Invoke(ret))
                        return ((IDeref)ret).Deref();
                }
            }
            else
            {
                for (long i = 1;  i < this._count; i++)
                {
                    ret = f.Invoke(ret, this._val);
                    if ((bool)new IsReduced().Invoke(ret))
                        return ((IDeref)ret).Deref();
                }

                return ret;
            }
        }
        public object Reduce(IFunction<object, object, object> f, object init)
        {
            var ret = init;
            if (this._count == INFINITE)
            {
                while (true)
                {
                    ret = f.Invoke(ret, this._val);
                    if ((bool)new IsReduced().Invoke(ret))
                        return ((IDeref)ret).Deref();
                }
            }
            else
            {
                for (long i = 0; i < this._count; i++)
                {
                    ret = f.Invoke(ret, this._val);
                    if ((bool)new IsReduced().Invoke(ret))
                        return ((IDeref)ret).Deref();
                }

                return ret;
            }
        }
    }
}
