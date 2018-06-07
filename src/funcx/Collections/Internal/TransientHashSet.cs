using System;
using System.Text;

namespace FunctionalLibrary.Collections.Internal
{
    class TransientHashSet :
        ATransientSet
    {
        public TransientHashSet(ITransientMap impl) :
            base(impl)
        { }

        #region Overrides
        public override ICollection ToPersistent() => new HashSet(this._impl.ToPersistent());
        #endregion
    }
}
