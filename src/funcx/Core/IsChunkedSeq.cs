﻿using FunctionalLibrary.Collections;
using System;
using System.Text;

namespace FunctionalLibrary.Core
{
    public class IsChunkedSeq :
        IFunction<object, bool>
    {
        public bool Invoke(object s) => s is IChunkedSeq;
    }
}