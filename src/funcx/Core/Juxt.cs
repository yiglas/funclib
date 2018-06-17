using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Juxt :
        IFunction<object, object>,
        IFunction<object, object, object>,
        IFunction<object, object, object, object>,
        IFunctionParams<object, object, object, object, object>
    {
        public object Invoke(object f) => new Function(f);
        public object Invoke(object f, object g) => new Function(f, g);
        public object Invoke(object f, object g, object h) => new Function(f, g, h);
        public object Invoke(object f, object g, object h, params object[] fs) => new Function(f, g, h, fs);

        public class Function :
            IFunction<object>,
            IFunction<object, object>,
            IFunction<object, object, object>,
            IFunction<object, object, object, object>,
            IFunctionParams<object, object, object, object, object>
        {
            object _f;
            object _g;
            object _h;
            object[] _fs;

            public Function(object f) : this(f, null, null) { }
            public Function(object f, object g) : this(f, g, null) { }
            public Function(object f, object g, object h)
            {
                this._f = f;
                this._g = g;
                this._h = h;
            }
            public Function(object f, object g, object h, object[] fs) :
                this(null, null, null)
            {
                this._fs = (object[])new ToArray().Invoke(new ListS().Invoke(f, g, h, fs));
            }

            public object Invoke() =>
                this._fs != null
                    ? Reduce(this._fs)
                    : this._h != null ? new Vector().Invoke(Exec(this._f), Exec(this._g), Exec(this._h))
                    : this._g != null ? new Vector().Invoke(Exec(this._f), Exec(this._g))
                    : new Vector().Invoke(Exec(this._f));
            public object Invoke(object x) =>
                this._fs != null
                    ? Reduce(this._fs, x)
                    : this._h != null
                    ? new Vector().Invoke(Exec(this._f, x), Exec(this._g, x), Exec(this._h, x))
                    : this._g != null ? new Vector().Invoke(Exec(this._f, x), Exec(this._g, x))
                    : new Vector().Invoke(Exec(this._f, x));
            public object Invoke(object x, object y) =>
                this._fs != null
                    ? Reduce(this._fs, x, y)
                    : this._h != null
                    ? new Vector().Invoke(Exec(this._f, x, y), Exec(this._g, x, y), Exec(this._h, x, y))
                    : this._g != null ? new Vector().Invoke(Exec(this._f, x, y), Exec(this._g, x, y))
                    : new Vector().Invoke(Exec(this._f, x, y));
            public object Invoke(object x, object y, object z) =>
                this._fs != null
                    ? Reduce(this._fs, x, y, z)
                    : this._h != null
                    ? new Vector().Invoke(Exec(this._f, x, y, z), Exec(this._g, x, y, z), Exec(this._h, x, y, z))
                    : this._g != null ? new Vector().Invoke(Exec(this._f, x, y, z), Exec(this._g, x, y, z))
                    : new Vector().Invoke(Exec(this._f, x, y, z));
            public object Invoke(object x, object y, object z, params object[] args) =>
                this._fs != null
                    ? Reduce(this._fs, x, y, z, args)
                    : this._h != null
                    ? new Vector().Invoke(Exec(this._f, x, y, z, args), Exec(this._g, x, y, z, args), Exec(this._h, x, y, z, args))
                    : this._g != null ? new Vector().Invoke(Exec(this._f, x, y, z, args), Exec(this._g, x, y, z, args))
                    : new Vector().Invoke(Exec(this._f, x, y, z, args));

            public object Exec(object f) => ((IFunction<object>)f).Invoke();
            public object Exec(object f, object x) => ((IFunction<object, object>)f).Invoke(x);
            public object Exec(object f, object x, object y) => ((IFunction<object, object, object>)f).Invoke(x, y);
            public object Exec(object f, object x, object y, object z) => ((IFunction<object, object, object, object>)f).Invoke(x, y, z);
            public object Exec(object f, object x, object y, object z, params object[] args) => new Apply().Invoke(f, x, y, z, args);

            public object Reduce(object fs) => new Reduce1().Invoke(new Function<object, object, object>((_1, _2) => new Conj().Invoke(_1, Exec(_2))), new Vector().Invoke(), fs);
            public object Reduce(object fs, object x) => new Reduce1().Invoke(new Function<object, object, object>((_1, _2) => new Conj().Invoke(_1, Exec(_2, x))), new Vector().Invoke(), fs);
            public object Reduce(object fs, object x, object y) => new Reduce1().Invoke(new Function<object, object, object>((_1, _2) => new Conj().Invoke(_1, Exec(_2, x, y))), new Vector().Invoke(), fs);
            public object Reduce(object fs, object x, object y, object z) => new Reduce1().Invoke(new Function<object, object, object>((_1, _2) => new Conj().Invoke(_1, Exec(_2, x, y, z))), new Vector().Invoke(), fs);
            public object Reduce(object fs, object x, object y, object z, params object[] args) => new Reduce1().Invoke(new Function<object, object, object>((_1, _2) => new Conj().Invoke(_1, Exec(_2, x, y, z, args))), new Vector().Invoke(), fs);
        }
    }
}
