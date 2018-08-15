namespace funclib
{
    class FunctionComparer : System.Collections.IComparer
    {
        object _comparator;

        public FunctionComparer(object comparator)
        {
            this._comparator = comparator;
        }

        public int Compare(object x, object y)
        {
            var result = funclib.Core.Invoke(this._comparator, x, y);
            if (result is bool b)
                result = b ? -1 : 1;

            return Numbers.ConvertToInt(result);
        }
    }
}
