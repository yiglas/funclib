using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Comp :
        IFunction<IFunction<object>, IFunction<object>>,
        IFunction<IFunction<object, object>, IFunction<object>, IFunction<object>>,
        IFunction<IFunction<object, object>, IFunction<object, object>, IFunction<object, object>>,
        IFunction<IFunction<object, object>, IFunction<object, object, object>, IFunction<object, object, object>>,
        IFunction<IFunction<object, object>, IFunction<object, object, object, object>, IFunction<object, object, object, object>>,
        IFunction<IFunction<object, object>, IFunctionParams<object, object, object, object, object>, IFunctionParams<object, object, object, object, object>>,

        IFunction<IFunction<object, object>, IFunction<object, object>, IFunction<object>, IFunction<object>>,
        IFunction<IFunction<object, object>, IFunction<object, object>, IFunction<object, object>, IFunction<object, object>>,
        IFunction<IFunction<object, object>, IFunction<object, object>, IFunction<object, object, object>, IFunction<object, object, object>>,
        IFunction<IFunction<object, object>, IFunction<object, object>, IFunction<object, object, object, object>, IFunction<object, object, object, object>>,
        IFunction<IFunction<object, object>, IFunction<object, object>, IFunctionParams<object, object, object, object, object>, IFunctionParams<object, object, object, object, object>>,

        IFunction<IFunction<object, object>, IFunction<object, object>, IFunction<object, object>, IFunction<object>, IFunction<object>>,
        IFunction<IFunction<object, object>, IFunction<object, object>, IFunction<object, object>, IFunction<object, object>, IFunction<object, object>>,
        IFunction<IFunction<object, object>, IFunction<object, object>, IFunction<object, object>, IFunction<object, object, object>, IFunction<object, object, object>>,
        IFunction<IFunction<object, object>, IFunction<object, object>, IFunction<object, object>, IFunction<object, object, object, object>, IFunction<object, object, object, object>>,
        IFunction<IFunction<object, object>, IFunction<object, object>, IFunction<object, object>, IFunctionParams<object, object, object, object, object>, IFunctionParams<object, object, object, object, object>>
    {
        public IFunction<object> Invoke(IFunction<object> f) => f;
        public IFunction<object> Invoke(IFunction<object, object> f, IFunction<object> g) => new Function<object>(() => f.Invoke(g.Invoke()));
        public IFunction<object, object> Invoke(IFunction<object, object> f, IFunction<object, object> g) => new Function<object, object>(x => f.Invoke(g.Invoke(x)));
        public IFunction<object, object, object> Invoke(IFunction<object, object> f, IFunction<object, object, object> g) =>
            new Function<object, object, object>((x, y) => f.Invoke(g.Invoke(x, y)));
        public IFunction<object, object, object, object> Invoke(IFunction<object, object> f, IFunction<object, object, object, object> g) =>
            new Function<object, object, object, object>((x, y, z) => f.Invoke(g.Invoke(x, y, z)));
        public IFunctionParams<object, object, object, object, object> Invoke(IFunction<object, object> f, IFunctionParams<object, object, object, object, object> g) =>
            new FunctionParams<object, object, object, object, object>((x, y, z, args) => f.Invoke(g.Invoke(x, y, z, args)));

        public IFunction<object> Invoke(IFunction<object, object> f, IFunction<object, object> g, IFunction<object> h) => new Function<object>(() => f.Invoke(g.Invoke(h.Invoke())));
        public IFunction<object, object> Invoke(IFunction<object, object> f, IFunction<object, object> g, IFunction<object, object> h) =>
            new Function<object, object>(x => f.Invoke(g.Invoke(h.Invoke(x))));
        public IFunction<object, object, object> Invoke(IFunction<object, object> f, IFunction<object, object> g, IFunction<object, object, object> h) =>
            new Function<object, object, object>((x, y) => f.Invoke(g.Invoke(h.Invoke(x, y))));
        public IFunction<object, object, object, object> Invoke(IFunction<object, object> f, IFunction<object, object> g, IFunction<object, object, object, object> h) =>
            new Function<object, object, object, object>((x, y, z) => f.Invoke(g.Invoke(h.Invoke(x, y, z))));
        public IFunctionParams<object, object, object, object, object> Invoke(IFunction<object, object> f, IFunction<object, object> g, IFunctionParams<object, object, object, object, object> h) =>
            new FunctionParams<object, object, object, object, object>((x, y, z, args) => f.Invoke(g.Invoke(h.Invoke(x, y, z, args))));

        public IFunction<object> Invoke(IFunction<object, object> f, IFunction<object, object> g, IFunction<object, object> h, IFunction<object> i) => new Function<object>(() => f.Invoke(g.Invoke(h.Invoke(i.Invoke()))));
        public IFunction<object, object> Invoke(IFunction<object, object> f, IFunction<object, object> g, IFunction<object, object> h, IFunction<object, object> i) => 
            new Function<object, object>(x => f.Invoke(g.Invoke(h.Invoke(i.Invoke(x)))));
        public IFunction<object, object, object> Invoke(IFunction<object, object> f, IFunction<object, object> g, IFunction<object, object> h, IFunction<object, object, object> i) =>
            new Function<object, object, object>((x, y) => f.Invoke(g.Invoke(h.Invoke(i.Invoke(x, y)))));
        public IFunction<object, object, object, object> Invoke(IFunction<object, object> f, IFunction<object, object> g, IFunction<object, object> h, IFunction<object, object, object, object> i) =>
            new Function<object, object, object, object>((x, y, z) => f.Invoke(g.Invoke(h.Invoke(i.Invoke(x, y, z)))));
        public IFunctionParams<object, object, object, object, object> Invoke(IFunction<object, object> f, IFunction<object, object> g, IFunction<object, object> h, IFunctionParams<object, object, object, object, object> i) =>
            new FunctionParams<object, object, object, object, object>((x, y, z, args) => f.Invoke(g.Invoke(h.Invoke(i.Invoke(x, y, z, args)))));
    }
}
