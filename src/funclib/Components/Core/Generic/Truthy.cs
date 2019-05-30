namespace funclib.Components.Core.Generic
{
    // public class Truthy<T> :
    //     IFunction<T, bool>
    // {
    //     public bool Invoke(T source) => !funclib.Generic.Core.Falsy(source);
    // }

    public static partial class Stuff
    {
        public static bool Truthy(bool source) => !Falsy(source);
        public static bool Truthy<T>(T source) => !Falsy(source);
    }
}
