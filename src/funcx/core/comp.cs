using System;
using System.Collections.Generic;
using System.Text;

namespace funcx.Core
{
    public class Comp<TResult> :
        IFunction<IFunction<TResult>, IFunction<TResult>>
    {
        public IFunction<TResult> Invoke(IFunction<TResult> f) => f;
    }

    public class Comp<T1, TResult> :
        IFunction<IFunction<T1, TResult>, IFunction<T1>, IFunction<TResult>>
    {
        public IFunction<TResult> Invoke(IFunction<T1, TResult> f, IFunction<T1> g) =>
            new Function<TResult>(() => f.Invoke(g.Invoke()));
    }

    public class Comp<T1, T2, TResult> :
        IFunction<IFunction<T2, TResult>, IFunction<T1, T2>, IFunction<T1, TResult>>,
        IFunction<IFunction<T2, TResult>, IFunction<T1, T2>, IFunction<T1>, IFunction<TResult>>
    {
        public IFunction<T1, TResult> Invoke(IFunction<T2, TResult> f, IFunction<T1, T2> g) =>
            new Function<T1, TResult>(x => f.Invoke(g.Invoke(x)));

        public IFunction<TResult> Invoke(IFunction<T2, TResult> f, IFunction<T1, T2> g, IFunction<T1> h) =>
            new Function<TResult>(() => f.Invoke(g.Invoke(h.Invoke())));
    }

    public class Comp<T1, T2, T3, TResult> :
        IFunction<IFunction<T3, TResult>, IFunction<T1, T2, T3>, IFunction<T1, T2, TResult>>,
        IFunction<IFunction<T3, TResult>, IFunction<T2, T3>, IFunction<T1, T2>, IFunction<T1, TResult>>,
        IFunction<IFunction<T3, TResult>, IFunction<T2, T3>, IFunction<T1, T2>, IFunction<T1>, IFunction<TResult>>
    {
        public IFunction<T1, T2, TResult> Invoke(IFunction<T3, TResult> f, IFunction<T1, T2, T3> g) =>
            new Function<T1, T2, TResult>((x, y) => f.Invoke(g.Invoke(x, y)));

        public IFunction<T1, TResult> Invoke(IFunction<T3, TResult> f, IFunction<T2, T3> g, IFunction<T1, T2> h) =>
            new Function<T1, TResult>((x) => f.Invoke(g.Invoke(h.Invoke(x))));

        public IFunction<TResult> Invoke(IFunction<T3, TResult> f, IFunction<T2, T3> g, IFunction<T1, T2> h, IFunction<T1> i) =>
            new Function<TResult>(() => f.Invoke(g.Invoke(h.Invoke(i.Invoke()))));
    }

    public class Comp<T1, T2, T3, T4, TResult> :
        IFunction<IFunction<T4, TResult>, IFunction<T1, T2, T3, T4>, IFunction<T1, T2, T3, TResult>>,
        IFunction<IFunction<T4, TResult>, IFunction<T3, T4>, IFunction<T1, T2, T3>, IFunction<T1, T2, TResult>>,
        IFunction<IFunction<T4, TResult>, IFunction<T3, T4>, IFunction<T2, T3>, IFunction<T1, T2>, IFunction<T1, TResult>>
    {
        public IFunction<T1, T2, T3, TResult> Invoke(IFunction<T4, TResult> f, IFunction<T1, T2, T3, T4> g) =>
            new Function<T1, T2, T3, TResult>((x, y, z) => f.Invoke(g.Invoke(x, y, z)));

        public IFunction<T1, T2, TResult> Invoke(IFunction<T4, TResult> f, IFunction<T3, T4> g, IFunction<T1, T2, T3> h) =>
            new Function<T1, T2, TResult>((x, y) => f.Invoke(g.Invoke(h.Invoke(x, y))));

        public IFunction<T1, TResult> Invoke(IFunction<T4, TResult> f, IFunction<T3, T4> g, IFunction<T2, T3> h, IFunction<T1, T2> i) =>
            new Function<T1, TResult>(x => f.Invoke(g.Invoke(h.Invoke(i.Invoke(x)))));
    }

    public class Comp<T1, T2, T3, T4, T5, TResult> :
        IFunction<IFunction<T5, TResult>, IFunctionParams<T1, T2, T3, T4, T5>, IFunctionParams<T1, T2, T3, T4, TResult>>,
        IFunction<IFunction<T5, TResult>, IFunction<T4, T5>, IFunction<T1, T2, T3, T4>, IFunction<T1, T2, T3, TResult>>,
        IFunction<IFunction<T5, TResult>, IFunction<T4, T5>, IFunction<T3, T4>, IFunction<T1, T2, T3>, IFunction<T1, T2, TResult>>
    {
        public IFunctionParams<T1, T2, T3, T4, TResult> Invoke(IFunction<T5, TResult> f, IFunctionParams<T1, T2, T3, T4, T5> g) =>
            new FunctionParams<T1, T2, T3, T4, TResult>((x, y, z, args) => f.Invoke(g.Invoke(x, y, z, args)));

        public IFunction<T1, T2, T3, TResult> Invoke(IFunction<T5, TResult> f, IFunction<T4, T5> g, IFunction<T1, T2, T3, T4> h) =>
            new Function<T1, T2, T3, TResult>((x, y, z) => f.Invoke(g.Invoke(h.Invoke(x, y, z))));

        public IFunction<T1, T2, TResult> Invoke(IFunction<T5, TResult> f, IFunction<T4, T5> g, IFunction<T3, T4> h, IFunction<T1, T2, T3> i) =>
            new Function<T1, T2, TResult>((x, y) => f.Invoke(g.Invoke(h.Invoke(i.Invoke(x, y)))));
    }

    public class Comp<T1, T2, T3, T4, T5, T6, TResult> :
        IFunction<IFunction<T6, TResult>, IFunction<T5, T6>, IFunctionParams<T1, T2, T3, T4, T5>, IFunctionParams<T1, T2, T3, T4, TResult>>,
        IFunction<IFunction<T6, TResult>, IFunction<T5, T6>, IFunction<T4, T5>, IFunction<T1, T2, T3, T4>, IFunction<T1, T2, T3, TResult>>
    {
        public IFunctionParams<T1, T2, T3, T4, TResult> Invoke(IFunction<T6, TResult> f, IFunction<T5, T6> g, IFunctionParams<T1, T2, T3, T4, T5> h) =>
            new FunctionParams<T1, T2, T3, T4, TResult>((x, y, z, args) => f.Invoke(g.Invoke(h.Invoke(x, y, z, args))));

        public IFunction<T1, T2, T3, TResult> Invoke(IFunction<T6, TResult> f, IFunction<T5, T6> g, IFunction<T4, T5> h, IFunction<T1, T2, T3, T4> i) =>
            new Function<T1, T2, T3, TResult>((x, y, z) => f.Invoke(g.Invoke(h.Invoke(i.Invoke(x, y, z)))));
    }

    public class Comp<T1, T2, T3, T4, T5, T6, T7, TResult> :
        IFunction<IFunction<T7, TResult>, IFunction<T6, T7>, IFunction<T5, T6>, IFunctionParams<T1, T2, T3, T4, T5>, IFunctionParams<T1, T2, T3, T4, TResult>>
    {
        public IFunctionParams<T1, T2, T3, T4, TResult> Invoke(IFunction<T7, TResult> f, IFunction<T6, T7> g, IFunction<T5, T6> h, IFunctionParams<T1, T2, T3, T4, T5> i) =>
            new FunctionParams<T1, T2, T3, T4, TResult>((x, y, z, args) => f.Invoke(g.Invoke(h.Invoke(i.Invoke(x, y, z, args)))));
    }
}
