﻿using System;
using System.Text;

namespace FunctionalLibrary.Collections
{
    public interface IList : 
        IStack,
        ISeq,
        ICollection,
        System.Collections.IList,
        System.Collections.ICollection,
        System.Collections.IEnumerable
    {
        new object this[int index] { get; set; }
        new int Count { get; }
    }
}
