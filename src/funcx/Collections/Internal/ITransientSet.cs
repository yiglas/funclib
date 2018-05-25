﻿using System;
using System.Collections.Generic;
using System.Text;

namespace funcx.Collections.Internal
{
    interface ITransientSet : 
        ITransientCollection
    {
        new int Count { get; }
        ITransientSet Disjoin(object key);
        bool Contains(object key);
        object Get(object key);        
    }
}
