using FunctionalLibrary.Collections;
using System;
using System.Linq;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class Disj :
        IFunction<ISet, ISet>,
        IFunction<ISet, object, ISet>,
        IFunctionParams<ISet, object, object, ISet>
    {
        public ISet Invoke(ISet set) => set;
        public ISet Invoke(ISet set, object key) => set.Disj(key);
        public ISet Invoke(ISet set, object key, params object[] ks)
        {
            if (set == null) return null;

            var ret = set.Disj(key);
            var next = new Next().Invoke(ks);
            if (next != null)
                return Invoke(ret, new First().Invoke(ks), next);

            return ret;
        }
    }
}
