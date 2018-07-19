// Generated on 7/19/2018 7:43:49 AM
using funclib.Collections;
using funclib.Components.Core;
using System;

namespace funclib
{
	public static class Core
	{
		#region Properties
		/// <summary>
		/// Evaluates objects one at a time, from left to right. If a object returns
		/// a logical false (null or false) then it is returned and stops evaluating
		/// all other expressions. Otherwise, it returns the value of the last object.
		/// </summary>
		public static funclib.Components.Core.And And => new funclib.Components.Core.And();
		/// <summary>
		/// Applies <see cref="IFunction"/> f to the argument list formed prepending
		/// intervening arguments to args.
		/// </summary>
		public static funclib.Components.Core.Apply Apply => new funclib.Components.Core.Apply();
		/// <summary>
		/// Constructs an <see cref="Collections.ArrayMap"/>. If any keys are equal,
		/// they are handled as if by repeated uses of <see cref="Assoc"/>.
		/// </summary>
		public static funclib.Components.Core.ArrayMap ArrayMap => new funclib.Components.Core.ArrayMap();
		/// <summary>
		/// Assoc[iate]. When applied to a map, returns a new map of the same (hash/sort) type.
		/// that contains the mapping of key(s) to val(s). When applied to a vector, returns
		/// a new vector that contains val at index. Note -> index must be less than or equal to
		/// count of vector.
		/// </summary>
		public static funclib.Components.Core.Assoc Assoc => new funclib.Components.Core.Assoc();
		/// <summary>
		/// Associates a value n a nested associative structure, where ks is a
		/// sequence of keys and v is the new value. Returns a new nested structure.
		/// If any levels do not exists, a new <see cref="Collections.HashMap"/>
		/// will be created.
		/// </summary>
		public static funclib.Components.Core.AssocIn AssocIn => new funclib.Components.Core.AssocIn();
		/// <summary>
		/// When applied to a transient map, addes mapping of key(s) to vals(s).
		/// When applied to a transient vector, sets the val at index. Note ->
		/// index must be less than or equal to the count of vector. Returns coll.
		/// </summary>
		public static funclib.Components.Core.Assocǃ Assocǃ => new funclib.Components.Core.Assocǃ();
		/// <summary>
		/// Unary "&" operator returns the address of its operand. Binary "&" operators are
		/// predefined for the integral types and <see cref="bool"/>.
		/// </summary>
		public static funclib.Components.Core.BitAnd BitAnd => new funclib.Components.Core.BitAnd();
		public static funclib.Components.Core.BitAndNot BitAndNot => new funclib.Components.Core.BitAndNot();
		public static funclib.Components.Core.BitClear BitClear => new funclib.Components.Core.BitClear();
		public static funclib.Components.Core.BitFlip BitFlip => new funclib.Components.Core.BitFlip();
		public static funclib.Components.Core.BitNot BitNot => new funclib.Components.Core.BitNot();
		public static funclib.Components.Core.BitOr BitOr => new funclib.Components.Core.BitOr();
		public static funclib.Components.Core.BitSet BitSet => new funclib.Components.Core.BitSet();
		public static funclib.Components.Core.BitShiftLeft BitShiftLeft => new funclib.Components.Core.BitShiftLeft();
		public static funclib.Components.Core.BitShiftRight BitShiftRight => new funclib.Components.Core.BitShiftRight();
		public static funclib.Components.Core.BitTest BitTest => new funclib.Components.Core.BitTest();
		public static funclib.Components.Core.BitXOr BitXOr => new funclib.Components.Core.BitXOr();
		/// <summary>
		/// If x is a <see cref="bool"/> return x, otherwise return x != null.
		/// </summary>
		public static funclib.Components.Core.Boolean Boolean => new funclib.Components.Core.Boolean();
		/// <summary>
		/// Returns a <see cref="Seq"/> of all but the last item. In linear time.
		/// </summary>
		public static funclib.Components.Core.ButLast ButLast => new funclib.Components.Core.ButLast();
		public static funclib.Components.Core.Cat Cat => new funclib.Components.Core.Cat();
		/// <summary>
		/// Coerce to char
		/// </summary>
		public static funclib.Components.Core.Char Char => new funclib.Components.Core.Char();
		public static funclib.Components.Core.Chunk Chunk => new funclib.Components.Core.Chunk();
		public static funclib.Components.Core.ChunkAppend ChunkAppend => new funclib.Components.Core.ChunkAppend();
		public static funclib.Components.Core.ChunkBuffer ChunkBuffer => new funclib.Components.Core.ChunkBuffer();
		public static funclib.Components.Core.ChunkCons ChunkCons => new funclib.Components.Core.ChunkCons();
		public static funclib.Components.Core.ChunkFirst ChunkFirst => new funclib.Components.Core.ChunkFirst();
		public static funclib.Components.Core.ChunkNext ChunkNext => new funclib.Components.Core.ChunkNext();
		public static funclib.Components.Core.ChunkRest ChunkRest => new funclib.Components.Core.ChunkRest();
		/// <summary>
		/// Returns the type of an object.
		/// </summary>
		public static funclib.Components.Core.Class Class => new funclib.Components.Core.Class();
		/// <summary>
		/// Takes a set of functions and returns a function that is the composition of
		/// those functions. The returned <see cref="Function"/> takes a variable number
		/// of args, applies the right-most of functions to the args, the next function
		/// (right-to-left) to the result, ect.
		/// </summary>
		public static funclib.Components.Core.Comp Comp => new funclib.Components.Core.Comp();
		/// <summary>
		/// Returns a <see cref="IFunction{T1, T2, TResult}"/> function that can be coerced into
		/// the <see cref="FunctionComparer"/> that implements <see cref="System.Collections.IComparer"/>
		/// interface.
		/// </summary>
		public static funclib.Components.Core.Comparator Comparator => new funclib.Components.Core.Comparator();
		/// <summary>
		/// Comparator, that returns a negative number, zero, or positive number when x
		/// is logically 'less than', 'equal to' or 'greater than' y. Same as
		/// <see cref="IComparable.CompareTo(object)"/> except it works for null and
		/// compares numbers and collections in a type-independent manner.
		/// </summary>
		public static funclib.Components.Core.Compare Compare => new funclib.Components.Core.Compare();
		/// <summary>
		/// Takes a <see cref="IFunction"/> and returns the function that takes the same arguments
		/// with the same effects, if any, and returns the opposite truthy value.
		/// </summary>
		public static funclib.Components.Core.Complement Complement => new funclib.Components.Core.Complement();
		public static funclib.Components.Core.Completing Completing => new funclib.Components.Core.Completing();
		/// <summary>
		/// Returns a <see cref="LazySeq"/> representing the concatenation of the elements
		/// in the supplied colls.
		/// </summary>
		public static funclib.Components.Core.Concat Concat => new funclib.Components.Core.Concat();
		/// <summary>
		/// Conj[oin]. Returns a new collection with the x 'added'. If
		/// coll is null, returns a new <see cref="Collections.List"/> with
		/// x as its first item. The addition may happen at different places
		/// depending on the concrete type of the collection.
		/// </summary>
		public static funclib.Components.Core.Conj Conj => new funclib.Components.Core.Conj();
		/// <summary>
		/// Adds x to the transient collection. and returns coll. The addition may happen
		/// at different places depending on the concrete type of the collection.
		/// </summary>
		public static funclib.Components.Core.Conjǃ Conjǃ => new funclib.Components.Core.Conjǃ();
		/// <summary>
		/// Returns a new <see cref="ISeq"/> where x is the first element and seq is the rest.
		/// </summary>
		public static funclib.Components.Core.Cons Cons => new funclib.Components.Core.Cons();
		/// <summary>
		/// Returns a <see cref="IFunctionParams{TRest, TResult}"/> that takes any number of
		/// arguments and returns x.
		/// </summary>
		public static funclib.Components.Core.Constantly Constantly => new funclib.Components.Core.Constantly();
		/// <summary>
		/// Returns true if key is present in the given collection, otherwise false. Note
		/// that for numerically indexed collections like vectors and arrays, this test is the
		/// number key is within the range of indexes. <see cref="Contains"/> operates constant or
		/// logarithmic time; it will not perform a linear search for a value.
		/// </summary>
		public static funclib.Components.Core.Contains Contains => new funclib.Components.Core.Contains();
		/// <summary>
		/// Returns the number of items in the collection. Passing null as coll returns 0.
		/// </summary>
		public static funclib.Components.Core.Count Count => new funclib.Components.Core.Count();
		/// <summary>
		/// Returns a number one less than num.
		/// </summary>
		public static funclib.Components.Core.Dec Dec => new funclib.Components.Core.Dec();
		/// <summary>
		/// Returns the current state of ref.
		/// </summary>
		public static funclib.Components.Core.Deref Deref => new funclib.Components.Core.Deref();
		/// <summary>
		/// Disj[oin]. Returns a new set of the same concrete type, that
		/// does not contain they key(s).
		/// </summary>
		public static funclib.Components.Core.Disj Disj => new funclib.Components.Core.Disj();
		/// <summary>
		/// Returns a <see cref="ITransientSet"/> of the same concrete type that
		/// does not contain key(s).
		/// </summary>
		public static funclib.Components.Core.Disjǃ Disjǃ => new funclib.Components.Core.Disjǃ();
		/// <summary>
		/// Dissoc[iate]. Returns a new map of the same concrete type,
		/// that does not contain a mapping for the key(s).
		/// </summary>
		public static funclib.Components.Core.Dissoc Dissoc => new funclib.Components.Core.Dissoc();
		/// <summary>
		/// Returns a <see cref="ITransientMap"/> of the same concrete type that
		/// doesn't contain the same <see cref="KeyValuePair"/>
		/// </summary>
		public static funclib.Components.Core.Dissocǃ Dissocǃ => new funclib.Components.Core.Dissocǃ();
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of elements of coll without duplicate values.
		/// </summary>
		public static funclib.Components.Core.Distinct Distinct => new funclib.Components.Core.Distinct();
		/// <summary>
		/// Divides number(s).
		/// </summary>
		public static funclib.Components.Core.Divide Divide => new funclib.Components.Core.Divide();
		/// <summary>
		/// For <see cref="LazySeq"/> that are produced via other functions and have side effects.
		/// The side effects are not produces until the sequence is consumed. <see cref="DoAll"/>
		/// walks though successive next, retains the head and returns it, thus causing the
		/// entire seq to reside in memory at one time.
		/// </summary>
		public static funclib.Components.Core.DoAll DoAll => new funclib.Components.Core.DoAll();
		/// <summary>
		/// For <see cref="LazySeq"/> that are produced via other functions and have side effects.
		/// The side effects are not produces until the sequence is consumed. <see cref="DoAll"/>
		/// walks though successive next, retains the head and returns it, thus causing the
		/// entire seq to reside in memory at one time.
		/// </summary>
		public static funclib.Components.Core.DoRun DoRun => new funclib.Components.Core.DoRun();
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of all but the first n items in coll.
		/// </summary>
		public static funclib.Components.Core.Drop Drop => new funclib.Components.Core.Drop();
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of all but the last n items. Default is 1.
		/// </summary>
		public static funclib.Components.Core.DropLast DropLast => new funclib.Components.Core.DropLast();
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of the items in coll starting from the first item
		/// for which the predicate returns a logical false.
		/// </summary>
		public static funclib.Components.Core.DropWhile DropWhile => new funclib.Components.Core.DropWhile();
		/// <summary>
		/// Returns an empty <see cref="ICollection"/> of the same category as coll or null.
		/// </summary>
		public static funclib.Components.Core.Empty Empty => new funclib.Components.Core.Empty();
		/// <summary>
		/// If x is already <see cref="IsReduced"/>, return it else return <see cref="Collections.Reduced.Deref"/> value.
		/// </summary>
		public static funclib.Components.Core.EnsureReduced EnsureReduced => new funclib.Components.Core.EnsureReduced();
		/// <summary>
		/// Takes a set of predicates, <see cref="IFunction{T1, TResult}"/>, and returns a <see cref="IFunction"/>. This
		/// function composes all the predicates that returns a logical true value against all of its arguments, else
		/// it returns false. Note: f is short-circuiting in that it will stop execution on the first
		/// argument that triggers a logical false result against the original predicates.
		/// </summary>
		public static funclib.Components.Core.EveryPred EveryPred => new funclib.Components.Core.EveryPred();
		public static funclib.Components.Core.Falsy Falsy => new funclib.Components.Core.Falsy();
		/// <summary>
		/// Returns the first item's first item. Same as <see cref="First.Invoke(First.Invoke(object))"/>.
		/// </summary>
		public static funclib.Components.Core.FFirst FFirst => new funclib.Components.Core.FFirst();
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of items in coll for which predicate returns a logical true.
		/// </summary>
		public static funclib.Components.Core.Filter Filter => new funclib.Components.Core.Filter();
		/// <summary>
		/// Returns the <see cref="KeyValuePair"/> for the key, or null if key is not present.
		/// </summary>
		public static funclib.Components.Core.Find Find => new funclib.Components.Core.Find();
		/// <summary>
		/// Returns the first time in the collection. Calls <see cref="Seq"/> on the collection.
		/// If coll is null, return null.
		/// </summary>
		public static funclib.Components.Core.First First => new funclib.Components.Core.First();
		/// <summary>
		/// Takes any nested combination of <see cref="funclib.Collections.ISequential"/>
		/// things (<see cref="Collections.List"/>, <see cref="Collections.Vector"/>, etc.) and returns
		/// their contents as a single, flat sequence.  <see cref="Flatten.Invoke(null)"/> returns an
		/// empty sequence.
		/// </summary>
		public static funclib.Components.Core.Flatten Flatten => new funclib.Components.Core.Flatten();
		/// <summary>
		/// Returns the first item's next list. Same as <see cref="First.Invoke(Next.Invoke(object))"/>.
		/// </summary>
		public static funclib.Components.Core.FNext FNext => new funclib.Components.Core.FNext();
		/// <summary>
		/// Takes a <see cref="IFunction"/> f, and returns a <see cref="Function"/> that calls f, replacing
		/// a null first argument with the supplied value x. Higher arity versions can replace arguments in
		/// the second and third positions.  Note: that the function f can take any number of arguments,
		/// not just the one(s) being null-patched.
		/// </summary>
		public static funclib.Components.Core.FNull FNull => new funclib.Components.Core.FNull();
		/// <summary>
		/// Formats a string using <see cref="string.Format(string, object[])"/> format syntax.
		/// </summary>
		public static funclib.Components.Core.Format Format => new funclib.Components.Core.Format();
		/// <summary>
		/// Returns a map from distinct items in coll to the number of times they appear.
		/// </summary>
		public static funclib.Components.Core.Frequencies Frequencies => new funclib.Components.Core.Frequencies();
		/// <summary>
		/// Returns the value mapped to the key, notFound or null if key is not present.
		/// </summary>
		public static funclib.Components.Core.Get Get => new funclib.Components.Core.Get();
		/// <summary>
		/// Returns the value in a nested associative structure, where ks
		/// is a sequence of keys. Returns null if the key is not present,
		/// otherwise notFound value if supplied.
		/// </summary>
		public static funclib.Components.Core.GetIn GetIn => new funclib.Components.Core.GetIn();
		/// <summary>
		/// Returns a <see cref="HashMap"/> of elements of coll keyed by the result of
		/// <see cref="IFunction{T1, TResult}"/> f. The value at each key will be a
		/// <see cref="Vector"/> of the corresponding elements, in the order they appeared
		/// in coll.
		/// </summary>
		public static funclib.Components.Core.GroupBy GroupBy => new funclib.Components.Core.GroupBy();
		public static funclib.Components.Core.HaltWhen HaltWhen => new funclib.Components.Core.HaltWhen();
		/// <summary>
		/// Returns a new <see cref="Collections.HashMap"/> with the supplied mappings. If any keys are
		/// equal, they are handled as if by repeated uses of <see cref="Assoc"/>.
		/// </summary>
		public static funclib.Components.Core.HashMap HashMap => new funclib.Components.Core.HashMap();
		/// <summary>
		/// Returns a new <see cref="Collections.HashSet"/> with the supplied keys. Any
		/// equal keys are handled as if by repeated uses of <see cref="Conj"/>.
		/// </summary>
		public static funclib.Components.Core.HashSet HashSet => new funclib.Components.Core.HashSet();
		/// <summary>
		/// Returns its argument.
		/// </summary>
		public static funclib.Components.Core.Identity Identity => new funclib.Components.Core.Identity();
		/// <summary>
		/// Returns a number one greater than x.
		/// </summary>
		public static funclib.Components.Core.Inc Inc => new funclib.Components.Core.Inc();
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of the first item in each coll, then the second, etc.
		/// </summary>
		public static funclib.Components.Core.Interleave Interleave => new funclib.Components.Core.Interleave();
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of elements separated by sep.
		/// </summary>
		public static funclib.Components.Core.Interpose Interpose => new funclib.Components.Core.Interpose();
		/// <summary>
		/// Returns a new collection consisting of to with all of the items of from conjoined.
		/// </summary>
		public static funclib.Components.Core.Into Into => new funclib.Components.Core.Into();
		public static funclib.Components.Core.Into1 Into1 => new funclib.Components.Core.Into1();
		public static funclib.Components.Core.IntoArray IntoArray => new funclib.Components.Core.IntoArray();
		/// <summary>
		/// Returns <see cref="true"/> given any argument.
		/// </summary>
		public static funclib.Components.Core.IsAny IsAny => new funclib.Components.Core.IsAny();
		/// <summary>
		/// Returns <see cref="true"/> if coll implements <see cref="IAssociative"/> interface, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsAssociative IsAssociative => new funclib.Components.Core.IsAssociative();
		/// <summary>
		/// Returns <see cref="true"/> if x is a <see cref="bool"/>, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsBoolean IsBoolean => new funclib.Components.Core.IsBoolean();
		/// <summary>
		/// Returns <see cref="true"/> if x is a <see cref="char"/>, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsChar IsChar => new funclib.Components.Core.IsChar();
		/// <summary>
		/// Returns <see cref="true"/> if s is a <see cref="IChunkedSeq"/>, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsChunkedSeq IsChunkedSeq => new funclib.Components.Core.IsChunkedSeq();
		/// <summary>
		/// Returns <see cref="true"/> if x is a <see cref="ICounted"/>, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsCounted IsCounted => new funclib.Components.Core.IsCounted();
		/// <summary>
		/// Returns <see cref="true"/> if no two arguments are equal, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsDistinct IsDistinct => new funclib.Components.Core.IsDistinct();
		/// <summary>
		/// Returns <see cref="true"/> if x is a <see cref="double"/>, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsDouble IsDouble => new funclib.Components.Core.IsDouble();
		/// <summary>
		/// Returns <see cref="true"/> if coll has no items. Same as <see cref="Not.Invoke(Seq.Invoke(object))"/>.
		/// </summary>
		public static funclib.Components.Core.IsEmpty IsEmpty => new funclib.Components.Core.IsEmpty();
		/// <summary>
		/// Returns <see cref="true"/> if values are equal, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsEqualTo IsEqual => new funclib.Components.Core.IsEqualTo();
		/// <summary>
		/// Returns <see cref="true"/> if n is an even number.
		/// </summary>
		public static funclib.Components.Core.IsEven IsEven => new funclib.Components.Core.IsEven();
		/// <summary>
		/// Returns <see cref="true"/> if <see cref="IFunction{T1, TResult}"/> pred is a logical
		/// true for every item in the coll, otherwise <see cref="false"/>
		/// </summary>
		public static funclib.Components.Core.IsEvery IsEvery => new funclib.Components.Core.IsEvery();
		/// <summary>
		/// Returns <see cref="true"/> if x is <see cref="false"/>, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsFalse IsFalse => new funclib.Components.Core.IsFalse();
		/// <summary>
		/// Returns <see cref="true"/> if x is a <see cref="IFunction"/>, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsFunction IsFunction => new funclib.Components.Core.IsFunction();
		/// <summary>
		/// Returns <see cref="true"/> if x is identical to y, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsIdentical IsIdentical => new funclib.Components.Core.IsIdentical();
		/// <summary>
		/// Returns <see cref="true"/> if c <see cref="Type"/> is an instance of x, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsInstance IsInstance => new funclib.Components.Core.IsInstance();
		/// <summary>
		/// Returns <see cref="true"/> if x is a <see cref="int"/>, <see cref="long"/>, <see cref="short"/> or <see cref="byte"/>, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsInt IsInt => new funclib.Components.Core.IsInt();
		/// <summary>
		/// Returns <see cref="true"/> if x is a
		/// <see cref="int"/>,
		/// <see cref="long"/>,
		/// <see cref="short"/>
		/// <see cref="uint"/>,
		/// <see cref="ulong"/>,
		/// <see cref="ushort"/>
		/// <see cref="char"/>
		/// <see cref="byte"/>,
		/// or <see cref="sbyte"/>,
		/// otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsInteger IsInteger => new funclib.Components.Core.IsInteger();
		/// <summary>
		/// Returns <see cref="true"/> if x is a <see cref="IList"/>, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsList IsList => new funclib.Components.Core.IsList();
		/// <summary>
		/// Returns <see cref="true"/> if x is a <see cref="IMap"/>, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsMap IsMap => new funclib.Components.Core.IsMap();
		/// <summary>
		/// Returns <see cref="true"/> if x is a non-negative <see cref="int"/>, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsNatInt IsNatInt => new funclib.Components.Core.IsNatInt();
		/// <summary>
		/// Returns <see cref="true"/> if x is less than zero, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsNeg IsNeg => new funclib.Components.Core.IsNeg();
		/// <summary>
		/// Returns <see cref="true"/> if x is a a negative <see cref="int"/>, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsNegInt IsNegInt => new funclib.Components.Core.IsNegInt();
		/// <summary>
		/// Returns <see cref="false"/> if x is logical true for any item in coll, otherwise <see cref="true"/>.
		/// </summary>
		public static funclib.Components.Core.IsNotAny IsNotAny => new funclib.Components.Core.IsNotAny();
		/// <summary>
		/// Returns <see cref="true"/> if values are not equal, otherwise <see cref="false"/>
		/// </summary>
		public static funclib.Components.Core.IsNotEqual IsNotEqual => new funclib.Components.Core.IsNotEqual();
		/// <summary>
		/// Returns <see cref="false"/> if x is logical true for every item in coll, otherwise <see cref="true"/>.
		/// </summary>
		public static funclib.Components.Core.IsNotEvery IsNotEvery => new funclib.Components.Core.IsNotEvery();
		/// <summary>
		/// Returns <see cref="true"/> if x is <see cref="null"/>, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsNull IsNull => new funclib.Components.Core.IsNull();
		/// <summary>
		/// Returns <see cref="true"/> if x is a number, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsNumber IsNumber => new funclib.Components.Core.IsNumber();
		/// <summary>
		/// Returns <see cref="true"/> if x is an odd number, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsOdd IsOdd => new funclib.Components.Core.IsOdd();
		/// <summary>
		/// Returns <see cref="true"/> if x is an greater than zero, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsPos IsPos => new funclib.Components.Core.IsPos();
		/// <summary>
		/// Returns <see cref="true"/> if x is a positive <see cref="IsInt"/>, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsPosInt IsPosInt => new funclib.Components.Core.IsPosInt();
		/// <summary>
		/// Returns <see cref="true"/> if x is of type <see cref="Reduced"/>, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsReduced IsReduced => new funclib.Components.Core.IsReduced();
		/// <summary>
		/// Returns <see cref="true"/> if x is a <see cref="ISeq"/>, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsSeq IsSeq => new funclib.Components.Core.IsSeq();
		/// <summary>
		/// Returns <see cref="true"/> if x can be supported by the <see cref="Seq"/> function, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsSeqable IsSeqable => new funclib.Components.Core.IsSeqable();
		/// <summary>
		/// Returns <see cref="true"/> if coll implements <see cref="ISequential"/> interface, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsSequential IsSequential => new funclib.Components.Core.IsSequential();
		/// <summary>
		/// Returns <see cref="true"/> if coll implements <see cref="ISet"/> interface, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsSet IsSet => new funclib.Components.Core.IsSet();
		/// <summary>
		/// Returns <see cref="true"/> if x is not <see cref="null"/>, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsSome IsSome => new funclib.Components.Core.IsSome();
		/// <summary>
		/// Returns <see cref="true"/> if coll implements <see cref="ISorted"/> interface, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsSorted IsSorted => new funclib.Components.Core.IsSorted();
		/// <summary>
		/// Returns <see cref="true"/> if x is a <see cref="string"/>, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsString IsString => new funclib.Components.Core.IsString();
		/// <summary>
		/// Returns <see cref="true"/> if x is <see cref="true"/>, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsTrue IsTrue => new funclib.Components.Core.IsTrue();
		/// <summary>
		/// Returns <see cref="true"/> if x is a <see cref="Guid"/>, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsUUID IsUUID => new funclib.Components.Core.IsUUID();
		/// <summary>
		/// Returns <see cref="true"/> if coll implements <see cref="IVector"/> interface, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsVector IsVector => new funclib.Components.Core.IsVector();
		/// <summary>
		/// Returns <see cref="true"/> if x is of type <see cref="Volatile"/>, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsVolatile IsVolatile => new funclib.Components.Core.IsVolatile();
		/// <summary>
		/// Returns <see cref="true"/> if x is zero, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.IsZero IsZero => new funclib.Components.Core.IsZero();
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of x, f.Invoke(x), f.Invoke(f.Inovke(x))...
		/// f must be free of side-effects.
		/// </summary>
		public static funclib.Components.Core.Iterate Iterate => new funclib.Components.Core.Iterate();
		/// <summary>
		/// Takes a set of <see cref="IFunction"/> and returns <see cref="Function"/> that is the juxtaposition
		/// of those <see cref="IFunction"/>. The returned <see cref="Function"/> takes a variable number or
		/// args, and returns a <see cref="Vector"/> containing the result of applying each <see cref="IFunction"/>
		/// to the args (left-to-right).
		/// </summary>
		public static funclib.Components.Core.Juxt Juxt => new funclib.Components.Core.Juxt();
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of the non-null results of <see cref="IFunction{T1, TResult}"/>.
		/// Note: this means false return values will be included. F must be free of side-effects.
		/// </summary>
		public static funclib.Components.Core.Keep Keep => new funclib.Components.Core.Keep();
		/// <summary>
		/// Returns the key of the <see cref="KeyValuePair"/>.
		/// </summary>
		public static funclib.Components.Core.Key Key => new funclib.Components.Core.Key();
		/// <summary>
		/// Returns a <see cref="Seq"/> of the <see cref="IMap"/>'s keys.
		/// </summary>
		public static funclib.Components.Core.Keys Keys => new funclib.Components.Core.Keys();
		/// <summary>
		/// Returns the last item in coll, in linear time.
		/// </summary>
		public static funclib.Components.Core.Last Last => new funclib.Components.Core.Last();
		/// <summary>
		/// Creates a new <see cref="Collections.List"/> containing the times.
		/// </summary>
		public static funclib.Components.Core.List List => new funclib.Components.Core.List();
		/// <summary>
		/// Creates a new <see cref="Seq"/> containing the items perpended to the rest, the
		/// last of which will be treated as a sequence.
		/// </summary>
		public static funclib.Components.Core.ListS ListS => new funclib.Components.Core.ListS();
		/// <summary>
		/// Returns a <see cref="LazySeq"/> consisting of the results of applying <see cref="IFunction"/>
		/// to the set of first items of each coll, followed by applying <see cref="IFunction"/> to the set
		/// of second items in each coll, until any one of the colls are exhausted.  Any remaining items in
		/// other colls are ignored. <see cref="IFunction"/> should accept number of colls arguments.
		/// </summary>
		public static funclib.Components.Core.Map Map => new funclib.Components.Core.Map();
		/// <summary>
		/// Returns the result of applying <see cref="Concat"/> to the result of applying
		/// <see cref="Map"/> to f and colls. Thus function f should return a collections.
		/// </summary>
		public static funclib.Components.Core.MapCat MapCat => new funclib.Components.Core.MapCat();
		/// <summary>
		/// Returns the greatest of the numbers.
		/// </summary>
		public static funclib.Components.Core.Max Max => new funclib.Components.Core.Max();
		/// <summary>
		/// Returns a <see cref="IMap"/> that consists of the rest of the <see cref="IMap"/> conj-ed onto
		/// the first. If a key occurs in more than one map, the mapping from the latter (left-to-right)
		/// will be mapping in the result.
		/// </summary>
		public static funclib.Components.Core.Merge Merge => new funclib.Components.Core.Merge();
		/// <summary>
		/// Returns a <see cref="IMap"/> that consists of the rest of the <see cref="IMaps"/> conj-ed onto
		/// the first. If a key occurs in more than one map, the mapping(s0 from the latter (left-to-right)
		/// will be combined with the mapping in the result by calling f.Invoke(value-in-result, value-in-latter)
		/// </summary>
		public static funclib.Components.Core.MergeWith MergeWith => new funclib.Components.Core.MergeWith();
		/// <summary>
		/// Returns the least of the numbers.
		/// </summary>
		public static funclib.Components.Core.Min Min => new funclib.Components.Core.Min();
		/// <summary>
		/// If y is not suppled return <see cref="Numbers.Negate(object)"/> of x, else subtract
		/// ys from x and returns the result.
		/// </summary>
		public static funclib.Components.Core.Minus Minus => new funclib.Components.Core.Minus();
		/// <summary>
		/// Returns a <see cref="Seq"/> of the items after the first. Calls
		/// <see cref="Seq"/> on its argument. If there are no more items,
		/// returns <see cref="Collections.List.EMPTY"/> collection.
		/// </summary>
		public static funclib.Components.Core.More More => new funclib.Components.Core.More();
		/// <summary>
		/// Returns the product of numbers. No parameters past returns 1. Single parameter there is an
		/// implicit 1 passed.
		/// </summary>
		public static funclib.Components.Core.Multiply Multiply => new funclib.Components.Core.Multiply();
		/// <summary>
		/// Returns a <see cref="Seq"/> of the items after the first. Calls
		/// <see cref="Seq"/> on its argument. If there are no more items,
		/// returns null.
		/// </summary>
		public static funclib.Components.Core.Next Next => new funclib.Components.Core.Next();
		/// <summary>
		/// Same as <see cref="Next.Invoke(First.Invoke(object))"/>.
		/// </summary>
		public static funclib.Components.Core.NFirst NFirst => new funclib.Components.Core.NFirst();
		/// <summary>
		/// Same as <see cref="Next.Invoke(Next.Invoke(object))"/>.
		/// </summary>
		public static funclib.Components.Core.NNext NNext => new funclib.Components.Core.NNext();
		/// <summary>
		/// Returns <see cref="true"/> if x is logical false, otherwise <see cref="false"/>.
		/// </summary>
		public static funclib.Components.Core.Not Not => new funclib.Components.Core.Not();
		/// <summary>
		/// Returns <see cref="null"/> if coll is empty, otherwise coll
		/// </summary>
		public static funclib.Components.Core.NotEmpty NotEmpty => new funclib.Components.Core.NotEmpty();
		/// <summary>
		/// Returns the value at the index. <see cref="Nth"/> throws an exception if index
		/// is out of bounds or unless notFound is supplied. <see cref="Nth"/> works on
		/// strings, arrays, Regex matcher, lists and O(n) time for sequences.
		/// </summary>
		public static funclib.Components.Core.Nth Nth => new funclib.Components.Core.Nth();
		/// <summary>
		/// Returns the nth next of colls. <see cref="Seq"/> is called when n is zero.
		/// </summary>
		public static funclib.Components.Core.NthNext NthNext => new funclib.Components.Core.NthNext();
		/// <summary>
		/// Returns the nth rest of coll, coll when n is 0.
		/// </summary>
		public static funclib.Components.Core.NthRest NthRest => new funclib.Components.Core.NthRest();
		/// <summary>
		/// Evaluates objects one at a time, from left to right. If a object returns
		/// a logical true value then it is returned and stops evaluating
		/// all other expressions. Otherwise, it returns the value of the last object.
		/// </summary>
		public static funclib.Components.Core.Or Or => new funclib.Components.Core.Or();
		/// <summary>
		/// Takes a <see cref="IFunction"/> f and fewer than the normal arguments, and returns a
		/// <see cref="Function"/> that take the rest of the arguments.
		/// </summary>
		public static funclib.Components.Core.Partial Partial => new funclib.Components.Core.Partial();
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of lists of n items each, at offsets step
		/// apart. If step is not supplied, defaults to n, i.e. the partitions do not
		/// overlap. If a pad collections is supplied, use its elements a necessary
		/// to complete last partition up to n items. In case there are not enough
		/// padding elements, return a partition with  less than n items.
		/// </summary>
		public static funclib.Components.Core.Partition Partition => new funclib.Components.Core.Partition();
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of lists like <see cref="Partition"/>, but my include
		/// partitions with fewer then n items at the end.
		/// </summary>
		public static funclib.Components.Core.PartitionAll PartitionAll => new funclib.Components.Core.PartitionAll();
		/// <summary>
		/// Applies <see cref="IFunction{T1, TResult}"/> to each value in coll, splitting it each
		/// time f returns a new value. Returns a <see cref="LazySeq"/> of partitions.
		/// </summary>
		public static funclib.Components.Core.PartitionBy PartitionBy => new funclib.Components.Core.PartitionBy();
		/// <summary>
		/// Returns the same as <see cref="Collections.List"/>'s <see cref="Collections.List.First"/> method,
		/// for <see cref="Collections.Queue"/>'s <see cref="Collections.Queue.Peek"/> method, for
		/// <see cref="Collections.Vector"/>'s <see cref="Last"/> (but much more efficient). If the collection
		/// is empty return null.
		/// </summary>
		public static funclib.Components.Core.Peek Peek => new funclib.Components.Core.Peek();
		/// <summary>
		/// Returns a new, persistent version of the <see cref="ITransientCollection"/>, in
		/// constant time. The <see cref="ITransientCollection"/> cannot be used after this
		/// call.
		/// </summary>
		public static funclib.Components.Core.Persistentǃ Persistentǃ => new funclib.Components.Core.Persistentǃ();
		/// <summary>
		/// Returns the sum of numbers. No parameters past returns 0.
		/// </summary>
		public static funclib.Components.Core.Plus Plus => new funclib.Components.Core.Plus();
		/// <summary>
		/// For <see cref="Collections.List"/> or <see cref="Collections.Queue"/> returns a
		/// new <see cref="Collections.List"/>/<see cref="Collections.Queue"/> without the first
		/// item. For <see cref="Collections.Vector"/>, returns a new <see cref="Collections.Vector"/>
		/// without the last time. If the coll is empty, throws an exception.
		/// </summary>
		public static funclib.Components.Core.Pop Pop => new funclib.Components.Core.Pop();
		/// <summary>
		/// Removes the last time from a <see cref="ITransientVector"/>. If
		/// the collection is empty, throw an exception.
		/// </summary>
		public static funclib.Components.Core.Popǃ Popǃ => new funclib.Components.Core.Popǃ();
		/// <summary>
		/// Prints the object(s) to the <see cref="Variables.Out"/> stream.
		/// </summary>
		public static funclib.Components.Core.Print Print => new funclib.Components.Core.Print();
		/// <summary>
		/// The same as <see cref="Print"/> but followed by a <see cref="Environment.NewLine"/>.
		/// </summary>
		public static funclib.Components.Core.PrintLn PrintLn => new funclib.Components.Core.PrintLn();
		/// <summary>
		/// Returns a <see cref="Random"/> floating point number between
		/// 0 (inclusive) and n (default 1) (exclusive).
		/// </summary>
		public static funclib.Components.Core.Rand Rand => new funclib.Components.Core.Rand();
		/// <summary>
		/// Returns a <see cref="Random"/> <see cref="int"/> between 0 (inclusive) and n (exclusive).
		/// </summary>
		public static funclib.Components.Core.RandInt RandInt => new funclib.Components.Core.RandInt();
		/// <summary>
		/// Return a random element of the <see cref="Collections.ISequential"/> collection.
		/// </summary>
		public static funclib.Components.Core.RandNth RandNth => new funclib.Components.Core.RandNth();
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of numbers from start (inclusive) to end
		/// (Exclusive), by step, where start defaults to 0, step to 1, and end to
		/// infinity. When step is equal to 0, returns an infinite sequence of
		/// start. When start is equal to end, returns empty list.
		/// </summary>
		public static funclib.Components.Core.Range Range => new funclib.Components.Core.Range();
		/// <summary>
		/// f should implement the <see cref="IFunction{T1, T2, TResult}"/> interface. If val is not supplied,
		/// returns the result of applying f to the first 2 items in coll, then applying f to the result and
		/// the 3rd item, etc. If coll contains no items, f must implement <see cref="IFunction{TResult}"/>
		/// interface and reduce returns the result of calling f with no arguments. If coll has only 1 item,
		/// it is returned and f is not called. If val is supplied, returns the result of applying f to val
		/// and the first item in coll, then applying f to the result and the 2nd item, etc. If coll contains
		/// no items, val is returned and f is not called.
		/// </summary>
		public static funclib.Components.Core.Reduce Reduce => new funclib.Components.Core.Reduce();
		/// <summary>
		/// Wraps x in a way such that a <see cref="Reduce"/> will terminate with the value x.
		/// </summary>
		public static funclib.Components.Core.Reduced Reduced => new funclib.Components.Core.Reduced();
		public static funclib.Components.Core.ReduceKV ReduceKV => new funclib.Components.Core.ReduceKV();
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of the intermediate values of the reductions
		/// (as per reduce) of coll by f, starting with init.
		/// </summary>
		public static funclib.Components.Core.Reductions Reductions => new funclib.Components.Core.Reductions();
		/// <summary>
		/// Returns the next <see cref="Regex"/> match, if any, of string to pattern, using <see cref="funclib.ReMatcher.Find"/>.
		/// Uses <see cref="ReGroups"/> to return the group.
		/// </summary>
		public static funclib.Components.Core.ReFind ReFind => new funclib.Components.Core.ReFind();
		/// <summary>
		/// Returns the groups from the most recent match/find. If there are no
		/// nested groups, returns a string of the entire match. If there are
		/// nested groups, returns a <see cref="Collections.Vector"/> of groups,
		/// the first element being the entire match.
		/// </summary>
		public static funclib.Components.Core.ReGroups ReGroups => new funclib.Components.Core.ReGroups();
		public static funclib.Components.Core.Rem Rem => new funclib.Components.Core.Rem();
		public static funclib.Components.Core.ReMatcher ReMatcher => new funclib.Components.Core.ReMatcher();
		public static funclib.Components.Core.ReMatches ReMatches => new funclib.Components.Core.ReMatches();
		public static funclib.Components.Core.RePattern RePattern => new funclib.Components.Core.RePattern();
		public static funclib.Components.Core.Repeat Repeat => new funclib.Components.Core.Repeat();
		public static funclib.Components.Core.Repeatedly Repeatedly => new funclib.Components.Core.Repeatedly();
		public static funclib.Components.Core.ReSeq ReSeq => new funclib.Components.Core.ReSeq();
		public static funclib.Components.Core.Rest Rest => new funclib.Components.Core.Rest();
		public static funclib.Components.Core.Reverse Reverse => new funclib.Components.Core.Reverse();
		public static funclib.Components.Core.RSeq RSeq => new funclib.Components.Core.RSeq();
		public static funclib.Components.Core.Second Second => new funclib.Components.Core.Second();
		public static funclib.Components.Core.SelectKeys SelectKeys => new funclib.Components.Core.SelectKeys();
		public static funclib.Components.Core.Seq Seq => new funclib.Components.Core.Seq();
		public static funclib.Components.Core.Set Set => new funclib.Components.Core.Set();
		public static funclib.Components.Core.Some Some => new funclib.Components.Core.Some();
		public static funclib.Components.Core.Sort Sort => new funclib.Components.Core.Sort();
		public static funclib.Components.Core.SortBy SortBy => new funclib.Components.Core.SortBy();
		public static funclib.Components.Core.SortedMap SortedMap => new funclib.Components.Core.SortedMap();
		public static funclib.Components.Core.SortedMapBy SortedMapBy => new funclib.Components.Core.SortedMapBy();
		public static funclib.Components.Core.SortedSet SortedSet => new funclib.Components.Core.SortedSet();
		public static funclib.Components.Core.SortedSetBy SortedSetBy => new funclib.Components.Core.SortedSetBy();
		public static funclib.Components.Core.SplitAt SplitAt => new funclib.Components.Core.SplitAt();
		public static funclib.Components.Core.SplitWith SplitWith => new funclib.Components.Core.SplitWith();
		public static funclib.Components.Core.Str Str => new funclib.Components.Core.Str();
		public static funclib.Components.Core.Subs Subs => new funclib.Components.Core.Subs();
		public static funclib.Components.Core.SubVec SubVec => new funclib.Components.Core.SubVec();
		public static funclib.Components.Core.Take Take => new funclib.Components.Core.Take();
		public static funclib.Components.Core.TakeLast TakeLast => new funclib.Components.Core.TakeLast();
		public static funclib.Components.Core.TakeNth TakeNth => new funclib.Components.Core.TakeNth();
		public static funclib.Components.Core.TakeWhile TakeWhile => new funclib.Components.Core.TakeWhile();
		public static funclib.Components.Core.ToArray ToArray => new funclib.Components.Core.ToArray();
		public static funclib.Components.Core.Trampoline Trampoline => new funclib.Components.Core.Trampoline();
		public static funclib.Components.Core.Transduce Transduce => new funclib.Components.Core.Transduce();
		public static funclib.Components.Core.Transient Transient => new funclib.Components.Core.Transient();
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of the nodes in a tree, via a depth-first walk.
		/// </summary>
		public static funclib.Components.Core.TreeSeq TreeSeq => new funclib.Components.Core.TreeSeq();
		public static funclib.Components.Core.Truthy Truthy => new funclib.Components.Core.Truthy();
		public static funclib.Components.Core.Unreduce Unreduce => new funclib.Components.Core.Unreduce();
		public static funclib.Components.Core.UnsignedBitShiftRigth UnsignedBitShiftRigth => new funclib.Components.Core.UnsignedBitShiftRigth();
		public static funclib.Components.Core.Update Update => new funclib.Components.Core.Update();
		/// <summary>
		/// 'Updates' a value in a nested <see cref="Collections.IAssociative"/> structure,
		/// where ks is a <see cref="Collections.ISeq"/> of keys and f is a <see cref="IFunction"/>
		/// that will take the old value and any supplied args and return the new value, and
		/// returns a new nested structure. If any levels do not exists, a <see cref="HashMap"/>
		/// will be created.
		/// </summary>
		public static funclib.Components.Core.UpdateIn UpdateIn => new funclib.Components.Core.UpdateIn();
		/// <summary>
		/// Generates a new <see cref="System.Guid"/> object.
		/// </summary>
		public static funclib.Components.Core.UUID UUID => new funclib.Components.Core.UUID();
		/// <summary>
		/// Returns the value in the <see cref="KeyValuePair"/> object.
		/// </summary>
		public static funclib.Components.Core.Value Value => new funclib.Components.Core.Value();
		/// <summary>
		/// Creates a new <see cref="Collections.Vector"/> containing the items from coll.
		/// </summary>
		public static funclib.Components.Core.Vec Vec => new funclib.Components.Core.Vec();
		/// <summary>
		/// Creates a new <see cref="Collections.Vector"/> containing the args.
		/// </summary>
		public static funclib.Components.Core.Vector Vector => new funclib.Components.Core.Vector();
		/// <summary>
		/// Creates and returns a <see cref="Volatile"/> with an initial value of val.
		/// </summary>
		public static funclib.Components.Core.Volatileǃ Volatileǃ => new funclib.Components.Core.Volatileǃ();
		/// <summary>
		/// Sets the value of <see cref="Volatile"/> to a new value without
		/// regard for the current value
		/// </summary>
		public static funclib.Components.Core.VResetǃ VResetǃ => new funclib.Components.Core.VResetǃ();
		/// <summary>
		/// Returns a <see cref="HashMap"/> with the keys mapped to the corresponding values
		/// </summary>
		public static funclib.Components.Core.ZipMap ZipMap => new funclib.Components.Core.ZipMap();
		#endregion
		#region Methods
		/// <summary>
		/// Evaluates objects one at a time, from left to right. If a object returns
		/// a logical false (null or false) then it is returned and stops evaluating
		/// all other expressions. Otherwise, it returns the value of the last object.
		/// </summary>
		/// <returns>
		/// Returns true.
		/// </returns>
		public static object and() => And.Invoke();
		/// <summary>
		/// Evaluates objects one at a time, from left to right. If a object returns
		/// a logical false (null or false) then it is returned and stops evaluating
		/// all other expressions. Otherwise, it returns the value of the last object.
		/// </summary>
		/// <param name="x">Object to return.</param>
		/// <remarks>
		/// If x implements interface <see cref="IFunction{TResult}"/> then the object's
		/// Invoke() method is executed and sets its results to x.
		/// </remarks>
		/// <returns>
		/// Returns x or the result of calling Invoke on x.
		/// </returns>
		public static object and(object x) => And.Invoke(x);
		/// <summary>
		/// Evaluates objects one at a time, from left to right. If a object returns
		/// a logical false (null or false) then it is returned and stops evaluating
		/// all other expressions. Otherwise, it returns the value of the last object.
		/// </summary>
		/// <param name="x">First object to test.</param>
		/// <param name="next">Rest of the objects to test.</param>
		/// <remarks>
		/// If x implements interface <see cref="IFunction{TResult}"/> then the object's
		/// Invoke() method is executed and sets its results to x.
		/// </remarks>
		/// <returns>
		/// Returns the first logical false, otherwise the last object evaluated.
		/// </returns>
		public static object and(object x, params object[] next) => And.Invoke(x, next);
		/// <summary>
		/// Applies <see cref="IFunction"/> f to the argument list formed prepending
		/// intervening arguments to args.
		/// </summary>
		/// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
		/// <param name="args">An object that can be <see cref="Seq"/> against for the arguments for f.</param>
		/// <returns>
		/// Returns the results of executing f with the given arguments.
		/// </returns>
		public static object apply(object f, object args) => Apply.Invoke(f, args);
		/// <summary>
		/// Applies <see cref="IFunction"/> f to the argument list formed prepending
		/// intervening arguments to args.
		/// </summary>
		/// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
		/// <param name="x">First argument pass to f.</param>
		/// <param name="args">An object that can be <see cref="Seq"/> against for the rest of the arguments for f.</param>
		/// <returns>
		/// Returns the results of executing f with the given arguments.
		/// </returns>
		public static object apply(object f, object x, object args) => Apply.Invoke(f, x, args);
		/// <summary>
		/// Applies <see cref="IFunction"/> f to the argument list formed prepending
		/// intervening arguments to args.
		/// </summary>
		/// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
		/// <param name="x">First argument pass to f.</param>
		/// <param name="y">Second argument pass to f.</param>
		/// <param name="args">An object that can be <see cref="Seq"/> against for the rest of the arguments for f.</param>
		/// <returns>
		/// Returns the results of executing f with the given arguments.
		/// </returns>
		public static object apply(object f, object x, object y, object args) => Apply.Invoke(f, x, y, args);
		/// <summary>
		/// Applies <see cref="IFunction"/> f to the argument list formed prepending
		/// intervening arguments to args.
		/// </summary>
		/// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
		/// <param name="x">First argument pass to f.</param>
		/// <param name="y">Second argument pass to f.</param>
		/// <param name="z">Third argument passed to f.</param>
		/// <param name="args">An object that can be <see cref="Seq"/> against for the rest of the arguments for f.</param>
		/// <returns>
		/// Returns the results of executing f with the given arguments.
		/// </returns>
		public static object apply(object f, object x, object y, object z, object args) => Apply.Invoke(f, x, y, z, args);
		/// <summary>
		/// Applies <see cref="IFunction"/> f to the argument list formed prepending
		/// intervening arguments to args.
		/// </summary>
		/// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
		/// <param name="a">First argument pass to f.</param>
		/// <param name="b">Second argument pass to f.</param>
		/// <param name="c">Third argument passed to f.</param>
		/// <param name="d">Fourth argument passed to f.</param>
		/// <param name="args">Rest of the arguments passed to f.</param>
		/// <returns>
		/// Returns the results of executing f with the given arguments.
		/// </returns>
		public static object apply(object f, object a, object b, object c, object d, params object[] args) => Apply.Invoke(f, a, b, c, d, args);
		/// <summary>
		/// Constructs an <see cref="Collections.ArrayMap"/>. If any keys are equal,
		/// they are handled as if by repeated uses of <see cref="Assoc"/>.
		/// </summary>
		/// <returns>
		/// Returns <see cref="Collections.ArrayMap.EMPTY"/>.
		/// </returns>
		public static object arrayMap() => ArrayMap.Invoke();
		/// <summary>
		/// Constructs an <see cref="Collections.ArrayMap"/>. If any keys are equal,
		/// they are handled as if by repeated uses of <see cref="Assoc"/>.
		/// </summary>
		/// <param name="keyvals">List of Key, Value pairs.</param>
		/// <returns>
		/// Returns a new <see cref="Collections.ArrayMap"/> with Key/Value pairs added.
		/// </returns>
		public static object arrayMap(params object[] keyvals) => ArrayMap.Invoke(keyvals);
		/// <summary>
		/// Assoc[iate]. When applied to a map, returns a new map of the same (hash/sort) type.
		/// that contains the mapping of key(s) to val(s). When applied to a vector, returns
		/// a new vector that contains val at index. Note -> index must be less than or equal to
		/// count of vector.
		/// </summary>
		/// <param name="map">Object that implements the <see cref="IAssociative"/> interface.</param>
		/// <param name="key">The key of the object to associate in the map.</param>
		/// <param name="val">The value of the object to associate in the map.</param>
		/// <returns>
		/// Returns a new map with the same type of the map object.
		/// </returns>
		public static object assoc(object map, object key, object val) => Assoc.Invoke(map, key, val);
		/// <summary>
		/// Assoc[iate]. When applied to a map, returns a new map of the same (hash/sort) type.
		/// that contains the mapping of key(s) to val(s). When applied to a vector, returns
		/// a new vector that contains val at index. Note -> index must be less than or equal to
		/// count of vector.
		/// </summary>
		/// <param name="map">Object that implements the <see cref="IAssociative"/> interface.</param>
		/// <param name="key">The key of the object to associate in the map.</param>
		/// <param name="val">The value of the object to associate in the map.</param>
		/// <param name="kvs">Rest of the key/value pairs to associate in the map with.</param>
		/// <returns>
		/// Returns a new map with the same type of the map object.
		/// </returns>
		public static object assoc(object map, object key, object val, params object[] kvs) => Assoc.Invoke(map, key, val, kvs);
		/// <summary>
		/// Associates a value n a nested associative structure, where ks is a
		/// sequence of keys and v is the new value. Returns a new nested structure.
		/// If any levels do not exists, a new <see cref="Collections.HashMap"/>
		/// will be created.
		/// </summary>
		/// <param name="m">Object that implements the <see cref="IAssociative"/> interface.</param>
		/// <param name="ks">A sequence of keys to find the key/value pair to update.</param>
		/// <param name="v">A new value for the last key to update with.</param>
		/// <returns>
		/// A new nested associative with the value replaced.
		/// </returns>
		public static object assocIn(object m, object ks, object v) => AssocIn.Invoke(m, ks, v);
		/// <summary>
		/// When applied to a transient map, addes mapping of key(s) to vals(s).
		/// When applied to a transient vector, sets the val at index. Note ->
		/// index must be less than or equal to the count of vector. Returns coll.
		/// </summary>
		/// <param name="coll">An object that implements the <see cref="ITransientAssociative"/> interface.</param>
		/// <param name="key">The key of the object to associate in the map.</param>
		/// <param name="val">The value of the object to associate in the map.</param>
		/// <returns>
		/// Returns the modified coll object.
		/// </returns>
		public static object assocǃ(object coll, object key, object val) => Assocǃ.Invoke(coll, key, val);
		/// <summary>
		/// When applied to a transient map, addes mapping of key(s) to vals(s).
		/// When applied to a transient vector, sets the val at index. Note ->
		/// index must be less than or equal to the count of vector. Returns coll.
		/// </summary>
		/// <param name="coll">An object that implements the <see cref="ITransientAssociative"/> interface.</param>
		/// <param name="key">The key of the object to associate in the map.</param>
		/// <param name="val">The value of the object to associate in the map.</param>
		/// <param name="kvs">Rest of the key/value pairs to associate in the map with.</param>
		/// <returns>
		/// Returns the modified coll object.
		/// </returns>
		public static object assocǃ(object coll, object key, object val, params object[] kvs) => Assocǃ.Invoke(coll, key, val, kvs);
		/// <summary>
		/// Unary "&" operator returns the address of its operand. Binary "&" operators are
		/// predefined for the integral types and <see cref="bool"/>.
		/// </summary>
		/// <param name="x">Left hand side of the operand.</param>
		/// <param name="y">Right hand side of the operand.</param>
		/// <returns>
		/// Returns the <see cref="int"/> value of the operations.
		/// </returns>
		public static object bitAnd(object x, object y) => BitAnd.Invoke(x, y);
		/// <summary>
		/// Unary "&" operator returns the address of its operand. Binary "&" operators are
		/// predefined for the integral types and <see cref="bool"/>.
		/// </summary>
		/// <param name="x">Left hand side of the operand.</param>
		/// <param name="y">Right hand side of the operand.</param>
		/// <param name="more">Rest of the </param>
		/// <returns>
		/// Returns the <see cref="int"/> value of the operations.
		/// </returns>
		public static object bitAnd(object x, object y, params object[] more) => BitAnd.Invoke(x, y, more);
		public static object bitAndNot(object x, object y) => BitAndNot.Invoke(x, y);
		public static object bitAndNot(object x, object y, params object[] more) => BitAndNot.Invoke(x, y, more);
		public static object bitClear(object x, object n) => BitClear.Invoke(x, n);
		public static object bitFlip(object x, object n) => BitFlip.Invoke(x, n);
		public static object bitNot(object x) => BitNot.Invoke(x);
		public static object bitOr(object x, object y) => BitOr.Invoke(x, y);
		public static object bitOr(object x, object y, params object[] more) => BitOr.Invoke(x, y, more);
		public static object bitSet(object x, object n) => BitSet.Invoke(x, n);
		public static object bitShiftLeft(object x, object n) => BitShiftLeft.Invoke(x, n);
		public static object bitShiftRight(object x, object n) => BitShiftRight.Invoke(x, n);
		public static object bitTest(object x, object n) => BitTest.Invoke(x, n);
		public static object bitXOr(object x, object y) => BitXOr.Invoke(x, y);
		public static object bitXOr(object x, object y, params object[] more) => BitXOr.Invoke(x, y, more);
		/// <summary>
		/// If x is a <see cref="bool"/> return x, otherwise return x != null.
		/// </summary>
		/// <param name="x">Object to coerce into a boolean.</param>
		/// <returns>
		/// Returns a <see cref="bool"/> that indicates either the value of x if its a boolean, otherwise the result of x != null.
		/// </returns>
		public static object boolean(object x) => Boolean.Invoke(x);
		/// <summary>
		/// Returns a <see cref="Seq"/> of all but the last item. In linear time.
		/// </summary>
		/// <param name="coll">List of times to process.</param>
		/// <returns>
		/// Returns a <see cref="ISeq"/> of all items except for the last item.
		/// </returns>
		public static object butLast(object coll) => ButLast.Invoke(coll);
		public static object cat(object rf) => Cat.Invoke(rf);
		/// <summary>
		/// Coerce to char
		/// </summary>
		/// <param name="x">The number to convert to a <see cref="char"/>.</param>
		/// <returns>
		/// Returns a <see cref="char"/> value.
		/// </returns>
		public static object @char(object x) => Char.Invoke(x);
		public static object chunk(object b) => Chunk.Invoke(b);
		public static object chunkAppend(object b, object x) => ChunkAppend.Invoke(b, x);
		public static object chunkBuffer(object capacity) => ChunkBuffer.Invoke(capacity);
		public static object chunkCons(object chunk, object rest) => ChunkCons.Invoke(chunk, rest);
		public static object chunkFirst(object s) => ChunkFirst.Invoke(s);
		public static object chunkNext(object s) => ChunkNext.Invoke(s);
		public static object chunkRest(object s) => ChunkRest.Invoke(s);
		/// <summary>
		/// Returns the type of an object.
		/// </summary>
		/// <param name="x">Object to get the type of.</param>
		/// <returns>
		/// Returns the <see cref="Type"/> of object x.
		/// </returns>
		public static object @class(object x) => Class.Invoke(x);
		/// <summary>
		/// Takes a set of functions and returns a function that is the composition of
		/// those functions. The returned <see cref="Function"/> takes a variable number
		/// of args, applies the right-most of functions to the args, the next function
		/// (right-to-left) to the result, ect.
		/// </summary>
		/// <returns>
		/// Returns the <see cref="Identity"/> fucntion;
		/// </returns>
		public static object comp() => Comp.Invoke();
		/// <summary>
		/// Takes a set of functions and returns a function that is the composition of
		/// those functions. The returned <see cref="Function"/> takes a variable number
		/// of args, applies the right-most of functions to the args, the next function
		/// (right-to-left) to the result, ect.
		/// </summary>
		/// <param name="f">Object that implements the <see cref="IFunction{T1, TResult}"/> interface.</param>
		/// <returns>
		/// Returns the passed in function.
		/// </returns>
		public static object comp(object f) => Comp.Invoke(f);
		/// <summary>
		/// Takes a set of functions and returns a function that is the composition of
		/// those functions. The returned <see cref="Function"/> takes a variable number
		/// of args, applies the right-most of functions to the args, the next function
		/// (right-to-left) to the result, ect.
		/// </summary>
		/// <param name="f">Object that implements the <see cref="IFunction{T1, TResult}"/> interface.</param>
		/// <param name="g">Object that implements the <see cref="IFunction"/> interface.</param>
		/// <returns>
		/// Returns <see cref="Function"/> with f and g composed together.
		/// </returns>
		public static object comp(object f, object g) => Comp.Invoke(f, g);
		/// <summary>
		/// Takes a set of functions and returns a function that is the composition of
		/// those functions. The returned <see cref="Function"/> takes a variable number
		/// of args, applies the right-most of functions to the args, the next function
		/// (right-to-left) to the result, ect.
		/// </summary>
		/// <param name="f">Object that implements the <see cref="IFunction{T1, TResult}"/> interface.</param>
		/// <param name="g">Object that implements the <see cref="IFunction"/> interface.</param>
		/// <param name="fs">Array of objects that implement the <see cref="IFunction"/> interface.</param>
		/// <returns>
		/// Returns <see cref="Function"/> with f, g and fs composed together.
		/// </returns>
		public static object comp(object f, object g, params object[] fs) => Comp.Invoke(f, g, fs);
		/// <summary>
		/// Returns a <see cref="IFunction{T1, T2, TResult}"/> function that can be coerced into
		/// the <see cref="FunctionComparer"/> that implements <see cref="System.Collections.IComparer"/>
		/// interface.
		/// </summary>
		/// <param name="pred">An object that implements the <see cref="IFunction{T1, T2, TResult}"/> interface.</param>
		/// <returns>
		/// Returns a <see cref="int"/> that will be: -1 if pred.Invoke(x, y) is truthy, or 1 if pred.Invoke(y, x) is truthy, otherwise 0
		/// </returns>
		public static object comparator(object pred) => Comparator.Invoke(pred);
		/// <summary>
		/// Comparator, that returns a negative number, zero, or positive number when x
		/// is logically 'less than', 'equal to' or 'greater than' y. Same as
		/// <see cref="IComparable.CompareTo(object)"/> except it works for null and
		/// compares numbers and collections in a type-independent manner.
		/// </summary>
		/// <param name="x">Object that is either null, number or implements the <see cref="IComparable"/> interface.</param>
		/// <param name="y">Other that is eitehr null, number or an object to test.</param>
		/// <returns>
		/// Returns a <see cref="int"/> thats a negative number when  x 'less than' y, zero when x 'equal to' y or positive number
		/// x 'greater than' y.
		/// </returns>
		public static object compare(object x, object y) => Compare.Invoke(x, y);
		/// <summary>
		/// Takes a <see cref="IFunction"/> and returns the function that takes the same arguments
		/// with the same effects, if any, and returns the opposite truthy value.
		/// </summary>
		/// <param name="f">Object that implements the <see cref="IFunction"/> interface.</param>
		/// <returns>
		/// Returns a <see cref="bool"/> value which is the opposite truthy value.
		/// </returns>
		public static object complement(object f) => Complement.Invoke(f);
		public static object completing(object f) => Completing.Invoke(f);
		public static object completing(object f, object cf) => Completing.Invoke(f, cf);
		/// <summary>
		/// Returns a <see cref="LazySeq"/> representing the concatenation of the elements
		/// in the supplied colls.
		/// </summary>
		/// <returns>
		/// Returns a <see cref="LazySeq"/>, when invoked returns null.
		/// </returns>
		public static object concat() => Concat.Invoke();
		/// <summary>
		/// Returns a <see cref="LazySeq"/> representing the concatenation of the elements
		/// in the supplied colls.
		/// </summary>
		/// <param name="x">Object to return via a lazy implementation.</param>
		/// <returns>
		/// Returna a <see cref="LazySeq"/>, when invoked returns x.
		/// </returns>
		public static object concat(object x) => Concat.Invoke(x);
		/// <summary>
		/// Returns a <see cref="LazySeq"/> representing the concatenation of the elements
		/// in the supplied colls.
		/// </summary>
		/// <param name="x">First collection in the concatenation.</param>
		/// <param name="y">Second collection to be concatenated.</param>
		/// <returns>
		/// Returns a <see cref="LazySeq"/> that will concatenate y to x.
		/// </returns>
		public static object concat(object x, object y) => Concat.Invoke(x, y);
		/// <summary>
		/// Returns a <see cref="LazySeq"/> representing the concatenation of the elements
		/// in the supplied colls.
		/// </summary>
		/// <param name="x">First collection in the concatenation.</param>
		/// <param name="y">Second collection to be concatenated.</param>
		/// <param name="zs">Other collections to be concatenated with.</param>
		/// <returns>
		/// Returns a <see cref="LazySeq"/> that will concatentat zs, y to x.
		/// </returns>
		public static object concat(object x, object y, params object[] zs) => Concat.Invoke(x, y, zs);
		/// <summary>
		/// Conj[oin]. Returns a new collection with the x 'added'. If
		/// coll is null, returns a new <see cref="Collections.List"/> with
		/// x as its first item. The addition may happen at different places
		/// depending on the concrete type of the collection.
		/// </summary>
		/// <returns>
		/// Returns an <see cref="Collections.Vector.EMPTY"/>.
		/// </returns>
		public static object conj() => Conj.Invoke();
		/// <summary>
		/// Conj[oin]. Returns a new collection with the x 'added'. If
		/// coll is null, returns a new <see cref="Collections.List"/> with
		/// x as its first item. The addition may happen at different places
		/// depending on the concrete type of the collection.
		/// </summary>
		/// <param name="coll">Object that implements the <see cref="ICollection"/> interface.</param>
		/// <returns>
		/// Returns the coll object.
		/// </returns>
		public static object conj(object coll) => Conj.Invoke(coll);
		/// <summary>
		/// Conj[oin]. Returns a new collection with the x 'added'. If
		/// coll is null, returns a new <see cref="Collections.List"/> with
		/// x as its first item. The addition may happen at different places
		/// depending on the concrete type of the collection.
		/// </summary>
		/// <param name="coll">Object that implements the <see cref="ICollection"/> interface.</param>
		/// <param name="x">Object to add to the collection.</param>
		/// <returns>
		/// If coll is null returns a new <see cref="Collections.List"/>, otherwise returns
		/// a new collection with the same concrete type as coll with x <see cref="ICollection.Cons(object)"/>
		/// onto the list.
		/// </returns>
		public static object conj(object coll, object x) => Conj.Invoke(coll, x);
		/// <summary>
		/// Conj[oin]. Returns a new collection with the x 'added'. If
		/// coll is null, returns a new <see cref="Collections.List"/> with
		/// x as its first item. The addition may happen at different places
		/// depending on the concrete type of the collection.
		/// </summary>
		/// <param name="coll">Object that implements the <see cref="ICollection"/> interface.</param>
		/// <param name="x">Object to add to the collection.</param>
		/// <param name="xs">Array of other objects to add to the collection.</param>
		/// <returns>
		/// Returns a new collection with the same concrete type of coll but with the
		/// add objects.
		/// </returns>
		public static object conj(object coll, object x, params object[] xs) => Conj.Invoke(coll, x, xs);
		/// <summary>
		/// Adds x to the transient collection. and returns coll. The addition may happen
		/// at different places depending on the concrete type of the collection.
		/// </summary>
		/// <returns>
		/// Returns a <see cref="ITransientCollection"/> for an empty <see cref="Collections.Vector"/>.
		/// </returns>
		public static object conjǃ() => Conjǃ.Invoke();
		/// <summary>
		/// Adds x to the transient collection. and returns coll. The addition may happen
		/// at different places depending on the concrete type of the collection.
		/// </summary>
		/// <param name="coll">Object of the collection to return.</param>
		/// <returns>
		/// Returns the coll object.
		/// </returns>
		public static object conjǃ(object coll) => Conjǃ.Invoke(coll);
		/// <summary>
		/// Adds x to the transient collection. and returns coll. The addition may happen
		/// at different places depending on the concrete type of the collection.
		/// </summary>
		/// <param name="coll">Object that implement the <see cref="ITransientCollection"/> interface.</param>
		/// <param name="x"></param>
		/// <returns>
		/// Returns a <see cref="ITransientCollection"/> with the object added.
		/// </returns>
		public static object conjǃ(object coll, object x) => Conjǃ.Invoke(coll, x);
		/// <summary>
		/// Returns a new <see cref="ISeq"/> where x is the first element and seq is the rest.
		/// </summary>
		/// <param name="x">Object to be the first in the <see cref="ISeq"/> object.</param>
		/// <param name="seq">Object to be the rest of the <see cref="ISeq"/> object.</param>
		/// <returns>
		/// Returns a <see cref="ISeq"/> collection.
		/// </returns>
		public static object cons(object x, object seq) => Cons.Invoke(x, seq);
		/// <summary>
		/// Returns a <see cref="IFunctionParams{TRest, TResult}"/> that takes any number of
		/// arguments and returns x.
		/// </summary>
		/// <param name="x">Object to return.</param>
		/// <returns>
		/// Returns a <see cref="IFunctionParams{TRest, TResult}"/> when invoked returns x.
		/// </returns>
		public static object constantly(object x) => Constantly.Invoke(x);
		/// <summary>
		/// Returns true if key is present in the given collection, otherwise false. Note
		/// that for numerically indexed collections like vectors and arrays, this test is the
		/// number key is within the range of indexes. <see cref="Contains"/> operates constant or
		/// logarithmic time; it will not perform a linear search for a value.
		/// </summary>
		/// <param name="coll">Collection to check if key exists.</param>
		/// <param name="key">Object to check if contains in the collection.</param>
		/// <remarks>
		/// <code>coll</code> can be either:
		/// - <see cref="IAssociative"/>,
		/// - <see cref="System.Collections.IDictionary"/>
		/// - <see cref="string"/>
		/// - <see cref="Array"/>
		/// - <see cref="ITransientSet"/>
		/// - <see cref="ITransientAssociative"/>
		/// - <see cref="ISet"/>
		///
		/// <code>key</code> needs to be an <see cref="int"/> if coll is either a <see cref="string"/> or <see cref="Array"/>.
		/// </remarks>
		/// <returns>
		/// Returns a <see cref="bool"/>: true if key is present in the collection, otherwise false.
		/// </returns>
		public static object contains(object coll, object key) => Contains.Invoke(coll, key);
		/// <summary>
		/// Returns the number of items in the collection. Passing null as coll returns 0.
		/// </summary>
		/// <param name="coll">Object to count the number of items exists in the collection.</param>
		/// <remarks>
		/// <code>coll</code> can be:
		/// - <see cref="ICounted"/>
		/// - <see cref="ICollection"/>
		/// - <see cref="string"/>
		/// - <see cref="System.Collections.ICollection"/>
		/// - <see cref="System.Collections.IDictionary"/>
		/// - <see cref="System.Collections.DictionaryEntry"/>
		/// - <see cref="KeyValuePair"/>
		/// - <see cref="Array"/>
		/// </remarks>
		/// <returns>
		/// Returns an <see cref="int"/> of the number of items in the collection.
		/// </returns>
		public static object count(object coll) => Count.Invoke(coll);
		/// <summary>
		/// Returns a number one less than num.
		/// </summary>
		/// <param name="x">A number to decrease by one.</param>
		/// <returns>
		/// Returns either a <see cref="double"/> or <see cref="long"/> depending on
		/// what type x is.
		/// </returns>
		public static object dec(object x) => Dec.Invoke(x);
		/// <summary>
		/// Returns the current state of ref.
		/// </summary>
		/// <param name="ref">Object that implements the <see cref="IDeref"/> interface.</param>
		/// <returns>
		/// Returns the current state of ref.
		/// </returns>
		public static object deref(object @ref) => Deref.Invoke(@ref);
		/// <summary>
		/// Disj[oin]. Returns a new set of the same concrete type, that
		/// does not contain they key(s).
		/// </summary>
		/// <param name="set">Object that implements the <see cref="ISet"/> interface.</param>
		/// <returns>
		/// Returns the set object.
		/// </returns>
		public static object disj(object set) => Disj.Invoke(set);
		/// <summary>
		/// Disj[oin]. Returns a new set of the same concrete type, that
		/// does not contain they key(s).
		/// </summary>
		/// <param name="set">Object the implements the <see cref="ISet"/> interface.</param>
		/// <param name="key">Object to remove from the set.</param>
		/// <returns>
		/// Returns a new <see cref="ISet"/> collection without the key.
		/// </returns>
		public static object disj(object set, object key) => Disj.Invoke(set, key);
		/// <summary>
		/// Disj[oin]. Returns a new set of the same concrete type, that
		/// does not contain they key(s).
		/// </summary>
		/// <param name="set">Object the implements the <see cref="ISet"/> interface.</param>
		/// <param name="key">Object to remove from the set.</param>
		/// <param name="ks">An array of other object to remove from the set.</param>
		/// <returns>
		/// Returns null if the set parameter is null, otherwise removes all items from the
		/// <see cref="ISet"/> collection and returns a new <see cref="ISet"/> collection.
		/// </returns>
		public static object disj(object set, object key, params object[] ks) => Disj.Invoke(set, key, ks);
		/// <summary>
		/// Returns a <see cref="ITransientSet"/> of the same concrete type that
		/// does not contain key(s).
		/// </summary>
		/// <param name="set">Object that implements the <see cref="ITransientSet"/> interface.</param>
		/// <returns>
		/// Returns the set object.
		/// </returns>
		public static object disjǃ(object set) => Disjǃ.Invoke(set);
		/// <summary>
		/// Returns a <see cref="ITransientSet"/> of the same concrete type that
		/// does not contain key(s).
		/// </summary>
		/// <param name="set">Object that implements the <see cref="ITransientSet"/> interface.</param>
		/// <param name="key">Object to remove from the set.</param>
		/// <returns>
		/// Returns a <see cref="ITransientSet"/> without the key.
		/// </returns>
		public static object disjǃ(object set, object key) => Disjǃ.Invoke(set, key);
		/// <summary>
		/// Returns a <see cref="ITransientSet"/> of the same concrete type that
		/// does not contain key(s).
		/// </summary>
		/// <param name="set">Object that implements the <see cref="ITransientSet"/> interface.</param>
		/// <param name="key">Object to remove from the set.</param>
		/// <param name="ks">An array of other object to remove from the set.</param>
		/// <returns>
		/// Returns a <see cref="ITransientSet"/> without all of the items.
		/// </returns>
		public static object disjǃ(object set, object key, params object[] ks) => Disjǃ.Invoke(set, key, ks);
		/// <summary>
		/// Dissoc[iate]. Returns a new map of the same concrete type,
		/// that does not contain a mapping for the key(s).
		/// </summary>
		/// <param name="map">Object that implements the <see cref="IMap"/> interface.</param>
		/// <returns>
		/// Returns the map object.
		/// </returns>
		public static object dissoc(object map) => Dissoc.Invoke(map);
		/// <summary>
		/// Dissoc[iate]. Returns a new map of the same concrete type,
		/// that does not contain a mapping for the key(s).
		/// </summary>
		/// <param name="map">Object that implements the <see cref="IMap"/> interface.</param>
		/// <param name="key">Key to be removed from the map.</param>
		/// <returns>
		/// Returns a new <see cref="IMap"/> collection with out the key.
		/// </returns>
		public static object dissoc(object map, object key) => Dissoc.Invoke(map, key);
		/// <summary>
		/// Dissoc[iate]. Returns a new map of the same concrete type,
		/// that does not contain a mapping for the key(s).
		/// </summary>
		/// <param name="map">Object that implements the <see cref="IMap"/> interface.</param>
		/// <param name="key">Key to be removed from the map.</param>
		/// <param name="ks">An array of other object to remove from the map.</param>
		/// <returns>
		/// Returns null if the map parameter is null, otherwise removes all items from
		/// the <see cref="IMap"/> collection and returns a new <see cref="IMap"/> collection.
		/// </returns>
		public static object dissoc(object map, object key, params object[] ks) => Dissoc.Invoke(map, key, ks);
		/// <summary>
		/// Returns a <see cref="ITransientMap"/> of the same concrete type that
		/// doesn't contain the same <see cref="KeyValuePair"/>
		/// </summary>
		/// <param name="map">Object that implements the <see cref="ITransientMap"/> interface.</param>
		/// <param name="key">Key for the <see cref="KeyValuePair"/> to remove from the map.</param>
		/// <returns>
		/// Returns a <see cref="ITransientMap"/> collection without the given key.
		/// </returns>
		public static object dissocǃ(object map, object key) => Dissocǃ.Invoke(map, key);
		/// <summary>
		/// Returns a <see cref="ITransientMap"/> of the same concrete type that
		/// doesn't contain the same <see cref="KeyValuePair"/>
		/// </summary>
		/// <param name="map">Object that implements the <see cref="ITransientMap"/> interface.</param>
		/// <param name="key">Key for the <see cref="KeyValuePair"/> to remove from the map.</param>
		/// <param name="ks">An array of keys for the <see cref="KeyValuePair"/> to remove from the map.</param>
		/// <returns>
		/// Returns a <see cref="ITransientMap"/> collection without all the given keys.
		/// </returns>
		public static object dissocǃ(object map, object key, params object[] ks) => Dissocǃ.Invoke(map, key, ks);
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of elements of coll without duplicate values.
		/// </summary>
		/// <returns>
		/// Returns a <see cref="IFunction{T1, TResult}"/> that returns a <see cref="TransducerFunction"/>.
		/// </returns>
		public static object distinct() => Distinct.Invoke();
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of elements of coll without duplicate values.
		/// </summary>
		/// <param name="coll">A collection of items to return distinct with.</param>
		/// <returns>
		/// Returns a <see cref="LazySeq"/> of unique items from coll.
		/// </returns>
		public static object distinct(object coll) => Distinct.Invoke(coll);
		/// <summary>
		/// Divides number(s).
		/// </summary>
		/// <param name="x">The numerator of the equation.</param>
		/// <returns>
		/// Returns either <see cref="double"/> or <see cref="long"/> depending on the input. With 1 as the denominator.
		/// </returns>
		public static object divide(object x) => Divide.Invoke(x);
		/// <summary>
		/// Divides number(s).
		/// </summary>
		/// <param name="x">The denominator of the equation.</param>
		/// <param name="y">The numerator of the equation.</param>
		/// <returns>
		/// Returns either <see cref="double"/> or <see cref="long"/> depending on the input for the equation: x/y
		/// </returns>
		public static object divide(object x, object y) => Divide.Invoke(x, y);
		/// <summary>
		/// Divides number(s).
		/// </summary>
		/// <param name="x">The denominator of the equation.</param>
		/// <param name="y">The numerator of the equation.</param>
		/// <param name="more">Rest of the numerators applied left-to-right.</param>
		/// <returns>
		/// Returns either <see cref="double"/> or <see cref="long"/> depending on the input for the equation: x/y/more...
		/// </returns>
		public static object divide(object x, object y, params object[] more) => Divide.Invoke(x, y, more);
		/// <summary>
		/// For <see cref="LazySeq"/> that are produced via other functions and have side effects.
		/// The side effects are not produces until the sequence is consumed. <see cref="DoAll"/>
		/// walks though successive next, retains the head and returns it, thus causing the
		/// entire seq to reside in memory at one time.
		/// </summary>
		/// <param name="coll"><see cref="LazySeq"/> to consume.</param>
		/// <returns>
		/// Returns the <see cref="LazySeq"/> already consumed.
		/// </returns>
		public static object doAll(object coll) => DoAll.Invoke(coll);
		/// <summary>
		/// For <see cref="LazySeq"/> that are produced via other functions and have side effects.
		/// The side effects are not produces until the sequence is consumed. <see cref="DoAll"/>
		/// walks though successive next, retains the head and returns it, thus causing the
		/// entire seq to reside in memory at one time.
		/// </summary>
		/// <param name="n">The <see cref="int"/> times to walk the sequence.</param>
		/// <param name="coll"><see cref="LazySeq"/> to consume.</param>
		/// <returns>
		/// Returns the <see cref="LazySeq"/> already consumed.
		/// </returns>
		public static object doAll(object n, object coll) => DoAll.Invoke(n, coll);
		/// <summary>
		/// For <see cref="LazySeq"/> that are produced via other functions and have side effects.
		/// The side effects are not produces until the sequence is consumed. <see cref="DoAll"/>
		/// walks though successive next, retains the head and returns it, thus causing the
		/// entire seq to reside in memory at one time.
		/// </summary>
		/// <param name="coll">A <see cref="LazySeq"/> to consume.</param>
		/// <returns>
		/// Returns null.
		/// </returns>
		public static object doRun(object coll) => DoRun.Invoke(coll);
		/// <summary>
		/// For <see cref="LazySeq"/> that are produced via other functions and have side effects.
		/// The side effects are not produces until the sequence is consumed. <see cref="DoAll"/>
		/// walks though successive next, retains the head and returns it, thus causing the
		/// entire seq to reside in memory at one time.
		/// </summary>
		/// <param name="n">The <see cref="int"/> times to walk the sequence.</param>
		/// <param name="coll"><see cref="LazySeq"/> to consume.</param>
		/// <returns>
		/// Returns null.
		/// </returns>
		public static object doRun(object n, object coll) => DoRun.Invoke(n, coll);
		/// <summary>
		/// Constructor for the <see cref="DoTimes"/> class.
		/// </summary>
		/// <param name="n">Number of times to execute the fn.</param>
		/// <param name="fn">The function to execute.</param>
		public static object doTimes(int n, Func<int, object> fn) => new DoTimes(n, fn).Invoke();
		/// <summary>
		/// Constructor for the <see cref="DoTimes"/> class.
		/// </summary>
		/// <param name="n">Number of times to execute the fn.</param>
		/// <param name="fn">The function to execute.</param>
		public static object doTimes(int n, IFunction<int, object> fn) => new DoTimes(n, fn).Invoke();
		public static object drop(object n) => Drop.Invoke(n);
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of all but the first n items in coll.
		/// </summary>
		/// <param name="n">An <see cref="int"/> of the items to drop from the collection.</param>
		/// <param name="coll">The collection to drop the first x items from.</param>
		/// <returns>
		/// Returns a <see cref="LazySeq"/> of items without the first x items.
		/// </returns>
		public static object drop(object n, object coll) => Drop.Invoke(n, coll);
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of all but the last n items. Default is 1.
		/// </summary>
		/// <param name="coll">Collection of items to remove the last one from.</param>
		/// <returns>
		/// Returns a <see cref="LazySeq"/> with all but the last item.
		/// </returns>
		public static object dropLast(object coll) => DropLast.Invoke(coll);
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of all but the last n items. Default is 1.
		/// </summary>
		/// <param name="n">An <see cref="int"/> of the last times from the collection.</param>
		/// <param name="coll">The collection to remove from.</param>
		/// <returns>
		/// Returns a <see cref="LazySeq"/> of items without the last n items.
		/// </returns>
		public static object dropLast(object n, object coll) => DropLast.Invoke(n, coll);
		public static object dropWhile(object pred) => DropWhile.Invoke(pred);
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of the items in coll starting from the first item
		/// for which the predicate returns a logical false.
		/// </summary>
		/// <param name="pred">An object that implements the <see cref="IFunction{T1, T2, TResult}"/> interface.</param>
		/// <param name="coll">List of times to process.</param>
		/// <returns>
		/// Returns a <see cref="LazySeq"/> with items starting from the first logically false item in coll.
		/// </returns>
		public static object dropWhile(object pred, object coll) => DropWhile.Invoke(pred, coll);
		/// <summary>
		/// Returns an empty <see cref="ICollection"/> of the same category as coll or null.
		/// </summary>
		/// <param name="coll">An object to empty.</param>
		/// <returns>
		/// Returns an empty <see cref="ICollection"/> of the same category as coll. If coll
		/// doesn't implement the <see cref="ICollection"/> interface returns null.
		/// </returns>
		public static object empty(object coll) => Empty.Invoke(coll);
		/// <summary>
		/// If x is already <see cref="IsReduced"/>, return it else return <see cref="Collections.Reduced.Deref"/> value.
		/// </summary>
		/// <param name="x">Object to reduce or not.</param>
		/// <returns>
		/// Either x if it already <see cref="IsReduced"/> or <see cref="Collections.Reduced.Deref"/>ed value.
		/// </returns>
		public static object ensureReduced(object x) => EnsureReduced.Invoke(x);
		/// <summary>
		/// Takes a set of predicates, <see cref="IFunction{T1, TResult}"/>, and returns a <see cref="IFunction"/>. This
		/// function composes all the predicates that returns a logical true value against all of its arguments, else
		/// it returns false. Note: f is short-circuiting in that it will stop execution on the first
		/// argument that triggers a logical false result against the original predicates.
		/// </summary>
		/// <param name="p">An object that implements <see cref="IFunction{T1, TResult}"/> interface.</param>
		/// <returns>
		/// Returns <see cref="true"/> if p returns a logical true, otherwise <see cref="false"/>.
		/// </returns>
		public static object everyPred(object p) => EveryPred.Invoke(p);
		/// <summary>
		/// Takes a set of predicates, <see cref="IFunction{T1, TResult}"/>, and returns a <see cref="IFunction"/>. This
		/// function composes all the predicates that returns a logical true value against all of its arguments, else
		/// it returns false. Note: f is short-circuiting in that it will stop execution on the first
		/// argument that triggers a logical false result against the original predicates.
		/// </summary>
		/// <param name="p1">An object that implements <see cref="IFunction{T1, TResult}"/> interface.</param>
		/// <param name="p2">An object that implements <see cref="IFunction{T1, TResult}"/> interface.</param>
		/// <returns>
		/// Returns <see cref="true"/> if p returns a logical true, otherwise <see cref="false"/>.
		/// </returns>
		public static object everyPred(object p1, object p2) => EveryPred.Invoke(p1, p2);
		/// <summary>
		/// Takes a set of predicates, <see cref="IFunction{T1, TResult}"/>, and returns a <see cref="IFunction"/>. This
		/// function composes all the predicates that returns a logical true value against all of its arguments, else
		/// it returns false. Note: f is short-circuiting in that it will stop execution on the first
		/// argument that triggers a logical false result against the original predicates.
		/// </summary>
		/// <param name="p1">An object that implements <see cref="IFunction{T1, TResult}"/> interface.</param>
		/// <param name="p2">An object that implements <see cref="IFunction{T1, TResult}"/> interface.</param>
		/// <param name="p3">An object that implements <see cref="IFunction{T1, TResult}"/> interface.</param>
		/// <returns>
		/// Returns <see cref="true"/> if p returns a logical true, otherwise <see cref="false"/>.
		/// </returns>
		public static object everyPred(object p1, object p2, object p3) => EveryPred.Invoke(p1, p2, p3);
		/// <summary>
		/// Takes a set of predicates, <see cref="IFunction{T1, TResult}"/>, and returns a <see cref="IFunction"/>. This
		/// function composes all the predicates that returns a logical true value against all of its arguments, else
		/// it returns false. Note: f is short-circuiting in that it will stop execution on the first
		/// argument that triggers a logical false result against the original predicates.
		/// </summary>
		/// <param name="p1">An object that implements <see cref="IFunction{T1, TResult}"/> interface.</param>
		/// <param name="p2">An object that implements <see cref="IFunction{T1, TResult}"/> interface.</param>
		/// <param name="p3">An object that implements <see cref="IFunction{T1, TResult}"/> interface.</param>
		/// <param name="ps">Rest of objects that implement <see cref="IFunction{T1, TResult}"/> interface.</param>
		/// <returns>
		/// Returns <see cref="true"/> if p returns a logical true, otherwise <see cref="false"/>.
		/// </returns>
		public static object everyPred(object p1, object p2, object p3, params object[] ps) => EveryPred.Invoke(p1, p2, p3, ps);
		public static object falsy(object source) => Falsy.Invoke(source);
		/// <summary>
		/// Returns the first item's first item. Same as <see cref="First.Invoke(First.Invoke(object))"/>.
		/// </summary>
		/// <param name="x">Object to return the first item's first item.</param>
		/// <returns>
		/// Returns the first item's first item
		/// </returns>
		public static object fFirst(object x) => FFirst.Invoke(x);
		public static object filter(object pred) => Filter.Invoke(pred);
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of items in coll for which predicate returns a logical true.
		/// </summary>
		/// <param name="pred">An object that implements <see cref="IFunction{T1, TResult}"/> interface.</param>
		/// <param name="coll">An object to test.</param>
		/// <returns>
		/// Returns a <see cref="LazySeq"/> of items in coll for which predicate returns a logical true.
		/// </returns>
		public static object filter(object pred, object coll) => Filter.Invoke(pred, coll);
		/// <summary>
		/// Returns the <see cref="KeyValuePair"/> for the key, or null if key is not present.
		/// </summary>
		/// <param name="map">An object that implements either <see cref="IAssociative"/>, <see cref="System.Collections.IDictionary"/> or <see cref="ITransientAssociative"/> interface.</param>
		/// <param name="key">The key we want to find in the map.</param>
		/// <returns>
		/// Returns the <see cref="KeyValuePair"/> for the key, or null if key is not present.
		/// </returns>
		public static object find(object map, object key) => Find.Invoke(map, key);
		/// <summary>
		/// Returns the first time in the collection. Calls <see cref="Seq"/> on the collection.
		/// If coll is null, return null.
		/// </summary>
		/// <param name="coll">An object that is <see cref="Seq"/>able.</param>
		/// <returns>
		/// Returns the first time in the collection. Calls <see cref="Seq"/> on the collection.
		/// If coll is null, return null.
		/// </returns>
		public static object first(object coll) => First.Invoke(coll);
		/// <summary>
		/// Takes any nested combination of <see cref="funclib.Collections.ISequential"/>
		/// things (<see cref="Collections.List"/>, <see cref="Collections.Vector"/>, etc.) and returns
		/// their contents as a single, flat sequence.  <see cref="Flatten.Invoke(null)"/> returns an
		/// empty sequence.
		/// </summary>
		/// <param name="x">Object to flatten.</param>
		/// <returns>
		/// Returns a <see cref="LazySeq"/> that when invoked flattens the sequence.
		/// </returns>
		public static object flatten(object x) => Flatten.Invoke(x);
		/// <summary>
		/// Returns the first item's next list. Same as <see cref="First.Invoke(Next.Invoke(object))"/>.
		/// </summary>
		/// <param name="x">Object to return the first item's next list.</param>
		/// <returns>
		/// Returns the first item's next list.
		/// </returns>
		public static object fNext(object x) => FNext.Invoke(x);
		/// <summary>
		/// Takes a <see cref="IFunction"/> f, and returns a <see cref="Function"/> that calls f, replacing
		/// a null first argument with the supplied value x. Higher arity versions can replace arguments in
		/// the second and third positions.  Note: that the function f can take any number of arguments,
		/// not just the one(s) being null-patched.
		/// </summary>
		/// <param name="f">An object that implements <see cref="IFunction"/> interface.</param>
		/// <param name="x">Object to replace a first parameter passed thats null.</param>
		/// <returns>
		/// Returns a <see cref="Function"/> that is null-patched.
		/// </returns>
		public static object fNull(object f, object x) => FNull.Invoke(f, x);
		/// <summary>
		/// Takes a <see cref="IFunction"/> f, and returns a <see cref="Function"/> that calls f, replacing
		/// a null first argument with the supplied value x. Higher arity versions can replace arguments in
		/// the second and third positions.  Note: that the function f can take any number of arguments,
		/// not just the one(s) being null-patched.
		/// </summary>
		/// <param name="f">An object that implements <see cref="IFunction"/> interface.</param>
		/// <param name="x">Object to replace a first parameter passed thats null.</param>
		/// <param name="y">Object to replace a second parameter passed thats null.</param>
		/// <returns>
		/// Returns a <see cref="Function"/> that is null-patched.
		/// </returns>
		public static object fNull(object f, object x, object y) => FNull.Invoke(f, x, y);
		/// <summary>
		/// Takes a <see cref="IFunction"/> f, and returns a <see cref="Function"/> that calls f, replacing
		/// a null first argument with the supplied value x. Higher arity versions can replace arguments in
		/// the second and third positions.  Note: that the function f can take any number of arguments,
		/// not just the one(s) being null-patched.
		/// </summary>
		/// <param name="f">An object that implements <see cref="IFunction"/> interface.</param>
		/// <param name="x">Object to replace a first parameter passed thats null.</param>
		/// <param name="y">Object to replace a second parameter passed thats null.</param>
		/// <param name="z">Object to replace a third parameter passed thats null.</param>
		/// <returns>
		/// Returns a <see cref="Function"/> that is null-patched.
		/// </returns>
		public static object fNull(object f, object x, object y, object z) => FNull.Invoke(f, x, y, z);
		/// <summary>
		/// Formats a string using <see cref="string.Format(string, object[])"/> format syntax.
		/// </summary>
		/// <param name="fmt">The string to be formatted.</param>
		/// <param name="args">An object array that contains zero or more objects to format.</param>
		/// <returns>
		/// Returns the formated <see cref="string"/>.
		/// </returns>
		public static object format(object fmt, params object[] args) => Format.Invoke(fmt, args);
		/// <summary>
		/// Returns a <see cref="Collections.HashMap"/> from distinct items in coll to the number of times they appear.
		/// </summary>
		/// <param name="coll">An object to run distinct against.</param>
		/// <returns>
		/// Returns a <see cref="Collections.HashMap"/> from distinct items in coll to the number of times they appear.
		/// </returns>
		public static object frequencies(object coll) => Frequencies.Invoke(coll);
		/// <summary>
		/// Creates a <see cref="Function{TResult}"/> from a <see cref="Func{TResult}"/>.
		/// </summary>
		/// <param name="x">A <see cref="Func{TResult}"/> to execute.</param>
		public static Function<TResult> func<TResult>(Func<TResult> x) => new Function<TResult>(x);
		/// <summary>
		/// Invokes the <see cref="Func{TResult}"/>.
		/// </summary>
		/// <returns>
		/// Returns the results of the <see cref="Func{TResult}"/> function.
		/// </returns>
		public static TResult invoke<TResult>(IFunction<TResult> func) => func.Invoke();
		/// <summary>
		/// Creates a <see cref="Function{T1, TResult}"/> from a <see cref="Func{T1, TResult}"/>.
		/// </summary>
		/// <param name="x">A <see cref="Func{T1, TResult}"/> to execute.</param>
		public static Function<T1, TResult> func<T1, TResult>(Func<T1, TResult> x) => new Function<T1, TResult>(x);
		/// <summary>
		/// Invokes the <see cref="Func{T1, TResult}"/>.
		/// </summary>
		/// <param name="x">First parameter of the function.</param>
		/// <returns>
		/// Returns the results of the <see cref="Func{T1, TResult}"/> function.
		/// </returns>
		public static TResult invoke<T1, TResult>(IFunction<T1, TResult> func, T1 x) => func.Invoke(x);
		/// <summary>
		/// Creates a <see cref="Function{T1, T2, TResult}"/> from a <see cref="Func{T1, T2, TResult}"/>.
		/// </summary>
		/// <param name="x">A <see cref="Func{T1, T2, TResult}"/> to execute.</param>
		public static Function<T1, T2, TResult> func<T1, T2, TResult>(Func<T1, T2, TResult> x) => new Function<T1, T2, TResult>(x);
		/// <summary>
		/// Invokes the <see cref="Func{T1, T2, TResult}"/>.
		/// </summary>
		/// <param name="x">First parameter of the function.</param>
		/// <param name="y">Second parameter of the function.</param>
		/// <returns>
		/// Returns the results of the <see cref="Func{T1, T2, TResult}"/> function.
		/// </returns>
		public static TResult invoke<T1, T2, TResult>(IFunction<T1, T2, TResult> func, T1 x, T2 y) => func.Invoke(x, y);
		/// <summary>
		/// Creates a <see cref="Function{T1, T2, T3, TResult}"/> from a <see cref="Func{T1, T2, T3, TResult}"/>.
		/// </summary>
		/// <param name="x">A <see cref="Func{T1, T2, T3, TResult}"/> to execute.</param>
		public static Function<T1, T2, T3, TResult> func<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> x) => new Function<T1, T2, T3, TResult>(x);
		/// <summary>
		/// Invokes the <see cref="Func{T1, T2, T3, TResult}"/>.
		/// </summary>
		/// <param name="x">First parameter of the function.</param>
		/// <param name="y">Second parameter of the function.</param>
		/// <param name="z">Third parameter of the function.</param>
		/// <returns>
		/// Returns the results of the <see cref="Func{T1, T2, T3, TResult}"/> function.
		/// </returns>
		public static TResult invoke<T1, T2, T3, TResult>(IFunction<T1, T2, T3, TResult> func, T1 x, T2 y, T3 z) => func.Invoke(x, y, z);
		/// <summary>
		/// Creates a <see cref="Function{T1, T2, T3, T4, TResult}"/> from a <see cref="Func{T1, T2, T3, T4, TResult}"/>.
		/// </summary>
		/// <param name="x">A <see cref="Func{T1, T2, T3, T4, TResult}"/> to execute.</param>
		public static Function<T1, T2, T3, T4, TResult> func<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> x) => new Function<T1, T2, T3, T4, TResult>(x);
		/// <summary>
		/// Invokes the <see cref="Func{T1, T2, T3, T4, TResult}"/>.
		/// </summary>
		/// <param name="a">First parameter of the function.</param>
		/// <param name="b">Second parameter of the function.</param>
		/// <param name="c">Third parameter of the function.</param>
		/// <param name="d">Fourth parameter of the function.</param>
		/// <returns>
		/// Returns the results of the <see cref="Func{T1, T2, T3, T4, TResult}"/> function.
		/// </returns>
		public static TResult invoke<T1, T2, T3, T4, TResult>(IFunction<T1, T2, T3, T4, TResult> func, T1 a, T2 b, T3 c, T4 d) => func.Invoke(a, b, c, d);
		/// <summary>
		/// Creates a <see cref="Function{T1, T2, T3, T4, T5, TResult}"/> from a <see cref="Func{T1, T2, T3, T4, T5, TResult}"/>.
		/// </summary>
		/// <param name="x">A <see cref="Func{T1, T2, T3, T4, T5, TResult}"/> to execute.</param>
		public static Function<T1, T2, T3, T4, T5, TResult> func<T1, T2, T3, T4, T5, TResult>(Func<T1, T2, T3, T4, T5, TResult> x) => new Function<T1, T2, T3, T4, T5, TResult>(x);
		/// <summary>
		/// Invokes the <see cref="Func{T1, T2, T3, T4, TResult}"/>.
		/// </summary>
		/// <param name="a">First parameter of the function.</param>
		/// <param name="b">Second parameter of the function.</param>
		/// <param name="c">Third parameter of the function.</param>
		/// <param name="d">Fourth parameter of the function.</param>
		/// <param name="e">Fifth parameter of the function.</param>
		/// <returns>
		/// Returns the results of the <see cref="Func{T1, T2, T3, T4, T5, TResult}"/> function.
		/// </returns>
		public static TResult invoke<T1, T2, T3, T4, T5, TResult>(IFunction<T1, T2, T3, T4, T5, TResult> func, T1 a, T2 b, T3 c, T4 d, T5 e) => func.Invoke(a, b, c, d, e);
		/// <summary>
		/// Creates a <see cref="FunctionParams{T1, TResult}"/> from a <see cref="Func{T1[], TResult}"/>.
		/// </summary>
		/// <param name="x">A <see cref="Func{T1[], TResult}"/> to execute.</param>
		public static FunctionParams<T1, TResult> func<T1, TResult>(Func<T1[], TResult> x) => new FunctionParams<T1, TResult>(x);
		/// <summary>
		/// Invokes the <see cref="Func{T1[], TResult}"/>.
		/// </summary>
		/// <param name="args">Array of parameters of the function.</param>
		/// <returns>
		/// Returns the results of the <see cref="Func{T1[], TResult}"/> function.
		/// </returns>
		public static TResult invoke<T1, TResult>(IFunction<T1[], TResult> func, params T1[] args) => func.Invoke(args);
		/// <summary>
		/// Creates a <see cref="FunctionParams{T1, T2, TResult}"/> from a <see cref="Func{T1, T2[], TResult}"/>.
		/// </summary>
		/// <param name="x">A <see cref="Func{T1, T2[], TResult}"/> to execute.</param>
		public static FunctionParams<T1, T2, TResult> func<T1, T2, TResult>(Func<T1, T2[], TResult> x) => new FunctionParams<T1, T2, TResult>(x);
		/// <summary>
		/// Invokes the <see cref="Func{T1, T2[], TResult}"/>.
		/// </summary>
		/// <param name="x">First parameter of the function.</param>
		/// <param name="args">Array of parameters.</param>
		/// <returns>
		/// Returns the results of the <see cref="Func{T1, T2[], TResult}"/> function.
		/// </returns>
		public static TResult invoke<T1, T2, TResult>(IFunction<T1, T2[], TResult> func, T1 x, params T2[] args) => func.Invoke(x, args);
		/// <summary>
		/// Creates a <see cref="FunctionParams{T1, T2, T3, TResult}"/> from a <see cref="Func{T1, T2, T3[], TResult}"/>.
		/// </summary>
		/// <param name="x">A <see cref="Func{T1, T2, T3[], TResult}"/> to execute.</param>
		public static FunctionParams<T1, T2, T3, TResult> func<T1, T2, T3, TResult>(Func<T1, T2, T3[], TResult> x) => new FunctionParams<T1, T2, T3, TResult>(x);
		/// <summary>
		/// Invokes the <see cref="Func{T1, T2, T3[], TResult}"/>.
		/// </summary>
		/// <param name="x">First parameter of the function.</param>
		/// <param name="y">Second parameter of the function.</param>
		/// <param name="args">Array of parameters.</param>
		/// <returns>
		/// Returns the results of the <see cref="Func{T1, T2, T3[], TResult}"/> function.
		/// </returns>
		public static TResult invoke<T1, T2, T3, TResult>(IFunction<T1, T2, T3[], TResult> func, T1 x, T2 y, params T3[] args) => func.Invoke(x, y, args);
		/// <summary>
		/// Creates a <see cref="FunctionParams{T1, T2, T3, T4, TResult}"/> from a <see cref="Func{T1, T2, T3, T4[], TResult}"/>.
		/// </summary>
		/// <param name="x">A <see cref="Func{T1, T2, T3, T4[], TResult}"/> to execute.</param>
		public static FunctionParams<T1, T2, T3, T4, TResult> func<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4[], TResult> x) => new FunctionParams<T1, T2, T3, T4, TResult>(x);
		/// <summary>
		/// Invokes the <see cref="Func{T1, T2, T3, T4[], TResult}"/>.
		/// </summary>
		/// <param name="x">First parameter of the function.</param>
		/// <param name="y">Second parameter of the function.</param>
		/// <param name="z">Third parameter of the function.</param>
		/// <param name="args">Array of parameters.</param>
		/// <returns>
		/// Returns the results of the <see cref="Func{T1, T2, T3, T4[], TResult}"/> function.
		/// </returns>
		public static TResult invoke<T1, T2, T3, T4, TResult>(IFunction<T1, T2, T3, T4[], TResult> func, T1 x, T2 y, T3 z, params T4[] args) => func.Invoke(x, y, z, args);
		/// <summary>
		/// Returns the value mapped to the key, notFound or null if key is not present.
		/// </summary>
		/// <param name="map">Object to pull key from.</param>
		/// <param name="key">If object is a map object, key is the key, otherwise key is an integer of the index.</param>
		/// <returns>
		/// Returns the value mapped to the key, notFound or null if key is not present.
		/// </returns>
		public static object get(object map, object key) => Get.Invoke(map, key);
		/// <summary>
		/// Returns the value mapped to the key, notFound or null if key is not present.
		/// </summary>
		/// <param name="map">Object to pull key from.</param>
		/// <param name="key">If object is a map object, key is the key, otherwise key is an integer of the index.</param>
		/// <param name="notFound">Object that returns if the key is not found.</param>
		/// <returns>
		/// Returns the value mapped to the key, notFound or null if key is not present.
		/// </returns>
		public static object get(object map, object key, object notFound) => Get.Invoke(map, key, notFound);
		/// <summary>
		/// Returns the value in a nested associative structure, where ks
		/// is a sequence of keys. Returns null if the key is not present,
		/// otherwise notFound value if supplied.
		/// </summary>
		/// <param name="m">Object to pull the final key from.</param>
		/// <param name="ks">Sequence of keys.</param>
		/// <returns>
		/// Returns the key found otherwise null.
		/// </returns>
		public static object getIn(object m, object ks) => GetIn.Invoke(m, ks);
		/// <summary>
		/// Returns the value in a nested associative structure, where ks
		/// is a sequence of keys. Returns null if the key is not present,
		/// otherwise notFound value if supplied.
		/// </summary>
		/// <param name="m">Object to pull the final key from.</param>
		/// <param name="ks">Sequence of keys.</param>
		/// <param name="notFound">Object to return if key is not found.</param>
		/// <returns>
		/// Returns the key found otherwise notFound.
		/// </returns>
		public static object getIn(object m, object ks, object notFound) => GetIn.Invoke(m, ks, notFound);
		/// <summary>
		/// Returns a <see cref="HashMap"/> of elements of coll keyed by the result of
		/// <see cref="IFunction{T1, TResult}"/> f. The value at each key will be a
		/// <see cref="Vector"/> of the corresponding elements, in the order they appeared
		/// in coll.
		/// </summary>
		/// <param name="f">An object that implements the <see cref="IFunction{T1, TResult}"/> interface.</param>
		/// <param name="coll">A collection of items to group by.</param>
		/// <returns>
		/// Returns a <see cref="HashMap"/> of elements of coll keyed by the result of
		/// <see cref="IFunction{T1, TResult}"/> f.
		/// </returns>
		public static object groupBy(object f, object coll) => GroupBy.Invoke(f, coll);
		public static object haltWhen(object pred) => HaltWhen.Invoke(pred);
		public static object haltWhen(object pred, object retf) => HaltWhen.Invoke(pred, retf);
		/// <summary>
		/// Returns a new <see cref="Collections.HashMap"/> with the supplied mappings. If any keys are
		/// equal, they are handled as if by repeated uses of <see cref="Assoc"/>.
		/// </summary>
		/// <returns>
		/// Returns <see cref="Collections.HashMap.EMPTY"/>.
		/// </returns>
		public static object hashMap() => HashMap.Invoke();
		/// <summary>
		/// Returns a new <see cref="Collections.HashMap"/> with the supplied mappings. If any keys are
		/// equal, they are handled as if by repeated uses of <see cref="Assoc"/>.
		/// </summary>
		/// <param name="keyvals">Key/value pairs adding to the <see cref="Collections.HashMap"/> data structure.</param>
		/// <returns>
		/// Returns a new <see cref="Collections.HashMap"/> with the supplied mappings.
		/// </returns>
		public static object hashMap(params object[] keyvals) => HashMap.Invoke(keyvals);
		/// <summary>
		/// Returns a new <see cref="Collections.HashSet"/> with the supplied keys. Any
		/// equal keys are handled as if by repeated uses of <see cref="Conj"/>.
		/// </summary>
		/// <returns>
		/// Returns <see cref="Collections.HashSet.EMPTY"/>.
		/// </returns>
		public static object hashSet() => HashSet.Invoke();
		/// <summary>
		/// Returns a new <see cref="Collections.HashSet"/> with the supplied keys. Any
		/// equal keys are handled as if by repeated uses of <see cref="Conj"/>.
		/// </summary>
		/// <param name="keys">Keys to add to <see cref="Collections.HashSet"/> data structure.</param>
		/// <returns>
		/// Returns a new <see cref="Collections.HashSet"/> with the supplied keys.
		/// </returns>
		public static object hashSet(params object[] keys) => HashSet.Invoke(keys);
		/// <summary>
		/// Returns its argument.
		/// </summary>
		/// <param name="x">Argument to return.</param>
		/// <returns>
		/// Returns its argument.
		/// </returns>
		public static object identity(object x) => Identity.Invoke(x);
		/// <summary>
		/// Returns a number one greater than x.
		/// </summary>
		/// <param name="x">Number to incremental by one.</param>
		/// <returns>
		/// Returns a number one greater than x.
		/// </returns>
		public static object inc(object x) => Inc.Invoke(x);
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of the first item in each coll, then the second, etc.
		/// </summary>
		/// <returns>
		/// Returns <see cref="Collections.List.EMPTY"/>.
		/// </returns>
		public static object interleave() => Interleave.Invoke();
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of the first item in each coll, then the second, etc.
		/// </summary>
		/// <param name="c1">The collection returned lazily.</param>
		/// <returns>
		/// Returns a <see cref="LazySeq"/> of c1.
		/// </returns>
		public static object interleave(object c1) => Interleave.Invoke(c1);
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of the first item in each coll, then the second, etc.
		/// </summary>
		/// <param name="c1">First collection to interleave.</param>
		/// <param name="c2">Second collection to interleave.</param>
		/// <returns>
		/// Returns a <see cref="LazySeq"/> of the first item in each coll, then the second, etc.
		/// </returns>
		public static object interleave(object c1, object c2) => Interleave.Invoke(c1, c2);
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of the first item in each coll, then the second, etc.
		/// </summary>
		/// <param name="c1">First collection to interleave.</param>
		/// <param name="c2">Second collection to interleave.</param>
		/// <param name="colls">Rest of the collections to interleave.</param>
		/// <returns>
		/// Returns a <see cref="LazySeq"/> of the first item in each coll, then the second, etc.
		/// </returns>
		public static object interleave(object c1, object c2, params object[] colls) => Interleave.Invoke(c1, c2, colls);
		public static object interpose(object sep) => Interpose.Invoke(sep);
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of elements separated by sep.
		/// </summary>
		/// <param name="sep">Separator object.</param>
		/// <param name="coll">Collection to insert the separtor with.</param>
		/// <returns>
		/// Returns a <see cref="LazySeq"/> of elements separated by sep.
		/// </returns>
		public static object interpose(object sep, object coll) => Interpose.Invoke(sep, coll);
		/// <summary>
		/// Returns a new collection consisting of to with all of the items of from conjoined.
		/// </summary>
		/// <returns>
		/// Returns <see cref="Collections.Vector.EMPTY"/>.
		/// </returns>
		public static object into() => Into.Invoke();
		/// <summary>
		/// Returns a new collection consisting of to with all of the items of from conjoined.
		/// </summary>
		/// <param name="to">Object returned.</param>
		/// <returns>
		/// Returns the to object.
		/// </returns>
		public static object into(object to) => Into.Invoke(to);
		/// <summary>
		/// Returns a new collection consisting of to with all of the items of from conjoined.
		/// </summary>
		/// <param name="to">Object to conjoin values to.</param>
		/// <param name="from">Object pulling values to be conjoined.</param>
		/// <returns>
		/// Returns a new collection with the same data type of to consisting of to with all of the items of from conjoined.
		/// </returns>
		public static object into(object to, object from) => Into.Invoke(to, from);
		/// <summary>
		/// Returns a new collection consisting of to with all of the items of from conjoined.
		/// </summary>
		/// <param name="to">Object to conjoin values to.</param>
		/// <param name="xform">A transducer</param>
		/// <param name="from">Object pulling values to be conjoined.</param>
		/// <returns>
		/// Returns a new collection with the same data type of to consisting of to with all of the items of from conjoined.
		/// </returns>
		public static object into(object to, object xform, object from) => Into.Invoke(to, xform, from);
		public static object into1(object to, object from) => Into1.Invoke(to, from);
		public static object intoArray(object aseq) => IntoArray.Invoke(aseq);
		public static object intoArray(object type, object aseq) => IntoArray.Invoke(type, aseq);
		/// <summary>
		/// Returns <see cref="true"/> given any argument.
		/// </summary>
		/// <param name="x">Given argument.</param>
		/// <returns>
		/// Returns <see cref="true"/> given any argument.
		/// </returns>
		public static object isAny(object x) => IsAny.Invoke(x);
		/// <summary>
		/// Returns <see cref="true"/> if coll implements <see cref="IAssociative"/> interface, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="coll">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if coll implements <see cref="IAssociative"/> interface, otherwise <see cref="false"/>.
		/// </returns>
		public static object isAssociative(object coll) => IsAssociative.Invoke(coll);
		/// <summary>
		/// Returns <see cref="true"/> if x is a <see cref="bool"/>, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="x">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if x is a <see cref="bool"/>, otherwise <see cref="false"/>.
		/// </returns>
		public static object isBoolean(object x) => IsBoolean.Invoke(x);
		/// <summary>
		/// Returns <see cref="true"/> if x is a <see cref="char"/>, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="x">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if x is a <see cref="char"/>, otherwise <see cref="false"/>.
		/// </returns>
		public static object isChar(object x) => IsChar.Invoke(x);
		/// <summary>
		/// Returns <see cref="true"/> if s is a <see cref="IChunkedSeq"/>, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="s">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if s is a <see cref="IChunkedSeq"/>, otherwise <see cref="false"/>.
		/// </returns>
		public static object isChunkedSeq(object s) => IsChunkedSeq.Invoke(s);
		/// <summary>
		/// Returns <see cref="true"/> if x is a <see cref="ICounted"/>, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="x">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if x is a <see cref="ICounted"/>, otherwise <see cref="false"/>.
		/// </returns>
		public static object isCounted(object x) => IsCounted.Invoke(x);
		/// <summary>
		/// Returns <see cref="true"/> if no two arguments are equal, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="x">Other to test.</param>
		/// <returns>
		/// Always returns <see cref="true"/>.
		/// </returns>
		public static object isDistinct(object x) => IsDistinct.Invoke(x);
		/// <summary>
		/// Returns <see cref="true"/> if no two arguments are equal, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="x">First object to test.</param>
		/// <param name="y">Second object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if no two arguments are equal, otherwise <see cref="false"/>.
		/// </returns>
		public static object isDistinct(object x, object y) => IsDistinct.Invoke(x, y);
		/// <summary>
		/// Returns <see cref="true"/> if no two arguments are equal, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="x">First object to test.</param>
		/// <param name="y">Second object to test.</param>
		/// <param name="more">Rest of the objects to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if no two arguments are equal, otherwise <see cref="false"/>.
		/// </returns>
		public static object isDistinct(object x, object y, params object[] more) => IsDistinct.Invoke(x, y, more);
		/// <summary>
		/// Returns <see cref="true"/> if x is a <see cref="double"/>, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="x">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if x is a <see cref="double"/>, otherwise <see cref="false"/>.
		/// </returns>
		public static object isDouble(object x) => IsDouble.Invoke(x);
		/// <summary>
		/// Returns <see cref="true"/> if coll has no items. Same as <see cref="Not.Invoke(Seq.Invoke(object))"/>.
		/// </summary>
		/// <param name="coll">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if coll has no items. Same as <see cref="Not.Invoke(Seq.Invoke(object))"/>.
		/// </returns>
		public static object isEmpty(object coll) => IsEmpty.Invoke(coll);
		/// <summary>
		/// Returns <see cref="true"/> if values are equal, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="x">First element to test.</param>
		/// <returns>
		/// Always true.
		/// </returns>
		public static object isEqual(object x) => IsEqual.Invoke(x);
		/// <summary>
		/// Returns <see cref="true"/> if values are equal, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="x">First element to test.</param>
		/// <param name="y">Second element to test against.</param>
		/// <returns>
		/// Returns <see cref="true"/> if x is equal to y, otherwise <see cref="false"/>.
		/// </returns>
		public static object isEqual(object x, object y) => IsEqual.Invoke(x, y);
		/// <summary>
		/// Returns <see cref="true"/> if values are equal, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="x">First element to test.</param>
		/// <param name="y">Second element to test against.</param>
		/// <param name="more">All other elements to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if values are equal, otherwise <see cref="false"/>.
		/// </returns>
		public static object isEqual(object x, object y, params object[] more) => IsEqual.Invoke(x, y, more);
		/// <summary>
		/// Returns <see cref="true"/> if n is an even number.
		/// </summary>
		/// <param name="n">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if n is an even number.
		/// </returns>
		public static object isEven(object n) => IsEven.Invoke(n);
		/// <summary>
		/// Returns <see cref="true"/> if <see cref="IFunction{T1, TResult}"/> pred is a logical
		/// true for every item in the coll, otherwise <see cref="false"/>
		/// </summary>
		/// <param name="pred">An object that implements the <see cref="IFunction{T1, TResult}"/> interface.</param>
		/// <param name="coll">The collection to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if <see cref="IFunction{T1, TResult}"/> pred is a logical
		/// true for every item in the coll, otherwise <see cref="false"/>
		/// </returns>
		public static object isEvery(object pred, object coll) => IsEvery.Invoke(pred, coll);
		/// <summary>
		/// Returns <see cref="true"/> if x is a <see cref="false"/>, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="x">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if x is a <see cref="false"/>, otherwise <see cref="false"/>.
		/// </returns>
		public static object isFalse(object x) => IsFalse.Invoke(x);
		/// <summary>
		/// Returns <see cref="true"/> if x is a <see cref="IFunction"/>, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="x">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if x is a <see cref="IFunction"/>, otherwise <see cref="false"/>.
		/// </returns>
		public static object isFunction(object x) => IsFunction.Invoke(x);
		/// <summary>
		/// Returns <see cref="true"/> if x is identical to y, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="x">First object.</param>
		/// <param name="y">Object to test against.</param>
		/// <returns>
		/// Returns <see cref="true"/> if x is identical to y, otherwise <see cref="false"/>.
		/// </returns>
		public static object isIdentical(object x, object y) => IsIdentical.Invoke(x, y);
		/// <summary>
		/// Returns <see cref="true"/> if c <see cref="Type"/> is an instance of x, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="c">An <see cref="Type"/> object.</param>
		/// <param name="x">An object to check type of.</param>
		/// <returns>
		/// Returns <see cref="true"/> if c <see cref="Type"/> is an instance of x, otherwise <see cref="false"/>.
		/// </returns>
		public static object isInstance(object c, object x) => IsInstance.Invoke(c, x);
		/// <summary>
		/// Returns <see cref="true"/> if x is a <see cref="int"/>, <see cref="long"/>, <see cref="short"/> or <see cref="byte"/>, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="n">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if x is a <see cref="int"/>, <see cref="long"/>, <see cref="short"/> or <see cref="byte"/>, otherwise <see cref="false"/>.
		/// </returns>
		public static object isInt(object n) => IsInt.Invoke(n);
		/// <summary>
		/// Returns <see cref="true"/> if x is a
		/// <see cref="int"/>,
		/// <see cref="long"/>,
		/// <see cref="short"/>
		/// <see cref="uint"/>,
		/// <see cref="ulong"/>,
		/// <see cref="ushort"/>
		/// <see cref="char"/>
		/// <see cref="byte"/>,
		/// or <see cref="sbyte"/>,
		/// otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="n">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if x is a
		/// <see cref="int"/>,
		/// <see cref="long"/>,
		/// <see cref="short"/>
		/// <see cref="uint"/>,
		/// <see cref="ulong"/>,
		/// <see cref="ushort"/>
		/// <see cref="char"/>
		/// <see cref="byte"/>,
		/// or <see cref="sbyte"/>,
		/// otherwise <see cref="false"/>.
		/// </returns>
		public static object isInteger(object n) => IsInteger.Invoke(n);
		/// <summary>
		/// Returns <see cref="true"/> if x is a <see cref="IList"/>, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="x">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if x is a <see cref="IList"/>, otherwise <see cref="false"/>.
		/// </returns>
		public static object isList(object x) => IsList.Invoke(x);
		/// <summary>
		/// Returns <see cref="true"/> if x is a <see cref="IMap"/>, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="x">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if x is a <see cref="IMap"/>, otherwise <see cref="false"/>.
		/// </returns>
		public static object isMap(object x) => IsMap.Invoke(x);
		/// <summary>
		/// Returns <see cref="true"/> if x is a non-negative <see cref="int"/>, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="n">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if x is a non-negative <see cref="int"/>, otherwise <see cref="false"/>.
		/// </returns>
		public static object isNatInt(object n) => IsNatInt.Invoke(n);
		/// <summary>
		/// Returns <see cref="true"/> if x is less than zero, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="num">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if x is less than zero, otherwise <see cref="false"/>.
		/// </returns>
		public static object isNeg(object num) => IsNeg.Invoke(num);
		/// <summary>
		/// Returns <see cref="true"/> if x is a a negative <see cref="int"/>, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="n">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if x is a a negative <see cref="int"/>, otherwise <see cref="false"/>.
		/// </returns>
		public static object isNegInt(object n) => IsNegInt.Invoke(n);
		/// <summary>
		/// Returns <see cref="true"/> if x is logical true for any item in coll, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="pred">An object that implements the <see cref="IFunction{T1, TResult}"/> interface.</param>
		/// <param name="coll">A collection of items to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if x is logical true for any item in coll, otherwise <see cref="false"/>.
		/// </returns>
		public static object isNotAny(object pred, object coll) => IsNotAny.Invoke(pred, coll);
		/// <summary>
		/// Returns <see cref="true"/> if values are not equal, otherwise <see cref="false"/>
		/// </summary>
		/// <param name="x">First element to test.</param>
		/// <returns>
		/// Returns false.
		/// </returns>
		public static object isNotEqual(object x) => IsNotEqual.Invoke(x);
		/// <summary>
		/// Returns <see cref="true"/> if values are not equal, otherwise <see cref="false"/>
		/// </summary>
		/// <param name="x">First element to test.</param>
		/// <param name="y">Second element to test</param>
		/// <returns>
		/// Returns <see cref="true"/> if values are not equal, otherwise <see cref="false"/>
		/// </returns>
		public static object isNotEqual(object x, object y) => IsNotEqual.Invoke(x, y);
		/// <summary>
		/// Returns <see cref="true"/> if values are not equal, otherwise <see cref="false"/>
		/// </summary>
		/// <param name="x">First element to test.</param>
		/// <param name="y">Second element to test against.</param>
		/// <param name="more">All other elements to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if values are not equal, otherwise <see cref="false"/>
		/// </returns>
		public static object isNotEqual(object x, object y, params object[] more) => IsNotEqual.Invoke(x, y, more);
		/// <summary>
		/// Returns <see cref="false"/> if x is logical true for every item in coll, otherwise <see cref="true"/>.
		/// </summary>
		/// <param name="pred">An object that implements the <see cref="IFunction{T1, TResult}"/> interface.</param>
		/// <param name="coll">A collection of items to test.</param>
		/// <returns>
		/// Returns <see cref="false"/> if x is logical true for every item in coll, otherwise <see cref="true"/>.
		/// </returns>
		public static object isNotEvery(object pred, object coll) => IsNotEvery.Invoke(pred, coll);
		/// <summary>
		/// Returns <see cref="true"/> if x is <see cref="null"/>, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="x">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if x is <see cref="null"/>, otherwise <see cref="false"/>.
		/// </returns>
		public static object isNull(object x) => IsNull.Invoke(x);
		/// <summary>
		/// Returns <see cref="true"/> if x is a number, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="x">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if x is a number, otherwise <see cref="false"/>.
		/// </returns>
		public static object isNumber(object x) => IsNumber.Invoke(x);
		/// <summary>
		/// Returns <see cref="true"/> if x is an odd number, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="n">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if x is an odd number, otherwise <see cref="false"/>.
		/// </returns>
		public static object isOdd(object n) => IsOdd.Invoke(n);
		/// <summary>
		/// Returns <see cref="true"/> if x is an greater than zero, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="num">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if x is an greater than zero, otherwise <see cref="false"/>.
		/// </returns>
		public static object isPos(object num) => IsPos.Invoke(num);
		/// <summary>
		/// Returns <see cref="true"/> if x is a positive <see cref="IsInt"/>, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="n">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if x is a positive <see cref="IsInt"/>, otherwise <see cref="false"/>.
		/// </returns>
		public static object isPosInt(object n) => IsPosInt.Invoke(n);
		/// <summary>
		/// Returns <see cref="true"/> if x is of type <see cref="Reduced"/>, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="x">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if x is of type <see cref="Reduced"/>, otherwise <see cref="false"/>.
		/// </returns>
		public static object isReduced(object x) => IsReduced.Invoke(x);
		/// <summary>
		/// Returns <see cref="true"/> if x is a <see cref="ISeq"/>, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="x">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if x is a <see cref="ISeq"/>, otherwise <see cref="false"/>.
		/// </returns>
		public static object isSeq(object x) => IsSeq.Invoke(x);
		/// <summary>
		/// Returns <see cref="true"/> if x can be supported by the <see cref="Seq"/> function, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="x">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if x can be supported by the <see cref="Seq"/> function, otherwise <see cref="false"/>.
		/// </returns>
		public static object isSeqable(object x) => IsSeqable.Invoke(x);
		/// <summary>
		/// Returns <see cref="true"/> if coll implements <see cref="ISequential"/> interface, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="coll">An object to test against.</param>
		/// <returns>
		/// Returns <see cref="true"/> if coll implements <see cref="ISequential"/> interface, otherwise <see cref="false"/>.
		/// </returns>
		public static object isSequential(object coll) => IsSequential.Invoke(coll);
		/// <summary>
		/// Returns <see cref="true"/> if coll implements <see cref="ISequential"/> interface, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="x">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if coll implements <see cref="ISequential"/> interface, otherwise <see cref="false"/>.
		/// </returns>
		public static object isSet(object x) => IsSet.Invoke(x);
		/// <summary>
		/// Returns <see cref="true"/> if x is not <see cref="null"/>, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="x">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if x is not <see cref="null"/>, otherwise <see cref="false"/>.
		/// </returns>
		public static object isSome(object x) => IsSome.Invoke(x);
		/// <summary>
		/// Returns <see cref="true"/> if coll implements <see cref="ISorted"/> interface, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="coll">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if coll implements <see cref="ISorted"/> interface, otherwise <see cref="false"/>.
		/// </returns>
		public static object isSorted(object coll) => IsSorted.Invoke(coll);
		/// <summary>
		/// Returns <see cref="true"/> if x is a <see cref="string"/>, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="x">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if x is a <see cref="string"/>, otherwise <see cref="false"/>.
		/// </returns>
		public static object isString(object x) => IsString.Invoke(x);
		/// <summary>
		/// Returns <see cref="true"/> if x is <see cref="true"/>, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="x">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if x is <see cref="true"/>, otherwise <see cref="false"/>.
		/// </returns>
		public static object isTrue(object x) => IsTrue.Invoke(x);
		/// <summary>
		/// Returns <see cref="true"/> if x is a <see cref="Guid"/>, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="x">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if x is a <see cref="Guid"/>, otherwise <see cref="false"/>.
		/// </returns>
		public static object isUUID(object x) => IsUUID.Invoke(x);
		/// <summary>
		/// Returns <see cref="true"/> if coll implements <see cref="IVector"/> interface, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="x">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if coll implements <see cref="IVector"/> interface, otherwise <see cref="false"/>.
		/// </returns>
		public static object isVector(object x) => IsVector.Invoke(x);
		/// <summary>
		/// Returns <see cref="true"/> if x is of type <see cref="Volatile"/>, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="x">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if x is of type <see cref="Volatile"/>, otherwise <see cref="false"/>.
		/// </returns>
		public static object isVolatile(object x) => IsVolatile.Invoke(x);
		/// <summary>
		/// Returns <see cref="true"/> if x is zero, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="n">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if x is zero, otherwise <see cref="false"/>.
		/// </returns>
		public static object isZero(object n) => IsZero.Invoke(n);
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of x, f.Invoke(x), f.Invoke(f.Inovke(x))...
		/// f must be free of side-effects.
		/// </summary>
		/// <param name="f">An object that implements <see cref="IFunction{T1, TResult}"/> interface.</param>
		/// <param name="x">First object of sequence.</param>
		/// <returns>
		/// Returns a <see cref="LazySeq"/> of x, f.Invoke(x), f.Invoke(f.Inovke(x))...
		/// f must be free of side-effects.
		/// </returns>
		public static object iterate(object f, object x) => Iterate.Invoke(f, x);
		/// <summary>
		/// Takes a set of <see cref="IFunction"/> and returns <see cref="Function"/> that is the juxtaposition
		/// of those <see cref="IFunction"/>. The returned <see cref="Function"/> takes a variable number or
		/// args, and returns a <see cref="Vector"/> containing the result of applying each <see cref="IFunction"/>
		/// to the args (left-to-right).
		/// </summary>
		/// <param name="f">Object that implements the <see cref="IFunction"/> interface.</param>
		/// <returns>
		/// Takes a set of <see cref="IFunction"/> and returns <see cref="Function"/> that is the juxtaposition
		/// of those <see cref="IFunction"/>. The returned <see cref="Function"/> takes a variable number or
		/// args, and returns a <see cref="Vector"/> containing the result of applying each <see cref="IFunction"/>
		/// to the args (left-to-right).
		/// </returns>
		public static object juxt(object f) => Juxt.Invoke(f);
		/// <summary>
		/// Takes a set of <see cref="IFunction"/> and returns <see cref="Function"/> that is the juxtaposition
		/// of those <see cref="IFunction"/>. The returned <see cref="Function"/> takes a variable number or
		/// args, and returns a <see cref="Vector"/> containing the result of applying each <see cref="IFunction"/>
		/// to the args (left-to-right).</summary>
		/// <param name="f">First object that implements the <see cref="IFunction"/> interface.</param>
		/// <param name="g">Second object that implements the <see cref="IFunction"/> interface.</param>
		/// <returns>
		/// Takes a set of <see cref="IFunction"/> and returns <see cref="Function"/> that is the juxtaposition
		/// of those <see cref="IFunction"/>. The returned <see cref="Function"/> takes a variable number or
		/// args, and returns a <see cref="Vector"/> containing the result of applying each <see cref="IFunction"/>
		/// to the args (left-to-right).
		/// </returns>
		public static object juxt(object f, object g) => Juxt.Invoke(f, g);
		/// <summary>
		/// Takes a set of <see cref="IFunction"/> and returns <see cref="Function"/> that is the juxtaposition
		/// of those <see cref="IFunction"/>. The returned <see cref="Function"/> takes a variable number or
		/// args, and returns a <see cref="Vector"/> containing the result of applying each <see cref="IFunction"/>
		/// to the args (left-to-right).</summary>
		/// <param name="f">First object that implements the <see cref="IFunction"/> interface.</param>
		/// <param name="g">Second object that implements the <see cref="IFunction"/> interface.</param>
		/// <param name="h">Third object that implements the <see cref="IFunction"/> interface.</param>
		/// <returns>
		/// Takes a set of <see cref="IFunction"/> and returns <see cref="Function"/> that is the juxtaposition
		/// of those <see cref="IFunction"/>. The returned <see cref="Function"/> takes a variable number or
		/// args, and returns a <see cref="Vector"/> containing the result of applying each <see cref="IFunction"/>
		/// to the args (left-to-right).
		/// </returns>
		public static object juxt(object f, object g, object h) => Juxt.Invoke(f, g, h);
		/// <summary>
		/// Takes a set of <see cref="IFunction"/> and returns <see cref="Function"/> that is the juxtaposition
		/// of those <see cref="IFunction"/>. The returned <see cref="Function"/> takes a variable number or
		/// args, and returns a <see cref="Vector"/> containing the result of applying each <see cref="IFunction"/>
		/// to the args (left-to-right).</summary>
		/// <param name="f">First object that implements the <see cref="IFunction"/> interface.</param>
		/// <param name="g">Second object that implements the <see cref="IFunction"/> interface.</param>
		/// <param name="h">Third object that implements the <see cref="IFunction"/> interface.</param>
		/// <param name="fs">Rest of the object that implements the <see cref="IFunction"/> interface.</param>
		/// <returns>
		/// Takes a set of <see cref="IFunction"/> and returns <see cref="Function"/> that is the juxtaposition
		/// of those <see cref="IFunction"/>. The returned <see cref="Function"/> takes a variable number or
		/// args, and returns a <see cref="Vector"/> containing the result of applying each <see cref="IFunction"/>
		/// to the args (left-to-right).
		/// </returns>
		public static object juxt(object f, object g, object h, params object[] fs) => Juxt.Invoke(f, g, h, fs);
		public static object keep(object f) => Keep.Invoke(f);
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of the non-null results of <see cref="IFunction{T1, TResult}"/>.
		/// Note: this means false return values will be included. F must be free of side-effects.
		/// </summary>
		/// <param name="f">An object that implements the <see cref="IFunction{T1, TResult}"/> implements.</param>
		/// <param name="coll">A collection of items.</param>
		/// <returns>
		/// Returns a <see cref="LazySeq"/> of the non-null results of <see cref="IFunction{T1, TResult}"/>.
		/// Note: this means false return values will be included. F must be free of side-effects.
		/// </returns>
		public static object keep(object f, object coll) => Keep.Invoke(f, coll);
		/// <summary>
		/// Returns the key of the <see cref="KeyValuePair"/>.
		/// </summary>
		/// <param name="e">An <see cref="KeyValuePair"/> object.</param>
		/// <returns>
		/// Returns the key of the <see cref="KeyValuePair"/>.
		/// </returns>
		public static object key(object e) => Key.Invoke(e);
		/// <summary>
		/// Returns a <see cref="Seq"/> of the <see cref="IMap"/>'s keys.
		/// </summary>
		/// <param name="coll">An object that implements the <see cref="IMap"/> interface.</param>
		/// <returns>
		/// Returns a <see cref="Seq"/> of the <see cref="IMap"/>'s keys.
		/// </returns>
		public static object keys(object coll) => Keys.Invoke(coll);
		/// <summary>
		/// Returns the last item in coll, in linear time.
		/// </summary>
		/// <param name="s">Object to return the last time for.</param>
		/// <returns>
		/// Returns the last item in coll, in linear time.
		/// </returns>
		public static object last(object s) => Last.Invoke(s);
		/// <summary>
		/// Creates an empty <see cref="LazySeq"/> that yields null.
		/// </summary>
		public static LazySeq lazySeq() => new LazySeq();
		/// <summary>
		/// Creates a <see cref="LazySeq"/> with the fn as its body.
		/// </summary>
		/// <param name="fn">A function to evaluate during each <see cref="LazySeq.Seq"/> call.</param>
		public static LazySeq lazySeq(Func<object> fn) => new LazySeq(fn);
		/// <summary>
		/// Creates a <see cref="LazySeq"/> with the fn as its body.
		/// </summary>
		/// <param name="fn">A function to evaluate during each <see cref="LazySeq.Seq"/> call.</param>
		public static LazySeq lazySeq(IFunction<object> fn) => new LazySeq(fn);
		/// <summary>
		/// Creates a <see cref="LazySeq"/> with the fn returning the object as its body.
		/// </summary>
		/// <param name="body">The object to return when <see cref="LazySeq.Seq"/> is called.</param>
		public static LazySeq lazySeq(object body) => new LazySeq(body);
		/// <summary>
		/// Creates a <see cref="LazySeq"/> with the items of the sequence.
		/// </summary>
		/// <param name="e">The sequence of items.</param>
		public static LazySeq lazySeq(ISeq e) => new LazySeq(e);
		/// <summary>
		/// Creates a new <see cref="Collections.List"/> containing the times.
		/// </summary>
		/// <param name="items">List of items to add.</param>
		/// <returns>
		/// Returns a new <see cref="Collections.List"/> containing the items.
		/// </returns>
		public static object list(params object[] items) => List.Invoke(items);
		/// <summary>
		/// Creates a new <see cref="Seq"/> containing the items perpended to the rest, the
		/// last of which will be treated as a sequence.
		/// </summary>
		/// <param name="args">An object is passed to the <see cref="Seq"/> function.</param>
		/// <returns>
		/// Returns the result of calling <see cref="Seq"/> with args.
		/// </returns>
		public static object listS(object args) => ListS.Invoke(args);
		/// <summary>
		/// Creates a new <see cref="Seq"/> containing the items perpended to the rest, the
		/// last of which will be treated as a sequence.
		/// </summary>
		/// <param name="a">First item in the list.</param>
		/// <param name="args">Rest of the items.</param>
		/// <returns>
		/// Returns the result of calling <see cref="Cons"/>.
		/// </returns>
		public static object listS(object a, object args) => ListS.Invoke(a, args);
		/// <summary>
		/// Creates a new <see cref="Seq"/> containing the items perpended to the rest, the
		/// last of which will be treated as a sequence.
		/// </summary>
		/// <param name="a">First item in the list.</param>
		/// <param name="b">Second item in the list.</param>
		/// <param name="args">Rest of the times.</param>
		/// <returns>
		/// Returns the result of calling <see cref="Cons"/>.
		/// </returns>
		public static object listS(object a, object b, object args) => ListS.Invoke(a, b, args);
		/// <summary>
		/// Creates a new <see cref="Seq"/> containing the items perpended to the rest, the
		/// last of which will be treated as a sequence.
		/// </summary>
		/// <param name="a">First item in the list.</param>
		/// <param name="b">Second item in the list.</param>
		/// <param name="c">Third item in the list.</param>
		/// <param name="args">Rest of the times.</param>
		/// <returns>
		/// Returns the result of calling <see cref="Cons"/>.
		/// </returns>
		public static object listS(object a, object b, object c, object args) => ListS.Invoke(a, b, c, args);
		/// <summary>
		/// Creates a new <see cref="Seq"/> containing the items perpended to the rest, the
		/// last of which will be treated as a sequence.
		/// </summary>
		/// <param name="a">First item in the list.</param>
		/// <param name="b">Second item in the list.</param>
		/// <param name="c">Third item in the list.</param>
		/// <param name="d">Fourth item in the list.</param>
		/// <param name="args">Rest of the times.</param>
		/// <returns>
		/// Returns the result of calling <see cref="Cons"/>.
		/// </returns>
		public static object listS(object a, object b, object c, object d, params object[] more) => ListS.Invoke(a, b, c, d, more);
		/// <summary>
		/// Creates a <see cref="Locking"/> object.
		/// </summary>
		/// <param name="x">Object to lock.</param>
		/// <param name="fn"><see cref="Func{TResult}"/> to execute.</param>
		public static object locking(object x, Func<object> fn) => new Locking(x, fn).Invoke();
		/// <summary>
		/// Creates a <see cref="Locking"/> object.
		/// </summary>
		/// <param name="x">Object to lock.</param>
		/// <param name="fn"><see cref="IFunction{TResult}"/> to execute.</param>
		public static object locking(object x, IFunction<object> fn) => new Locking(x, fn).Invoke();
		public static object map(object f) => Map.Invoke(f);
		/// <summary>
		/// Returns a <see cref="LazySeq"/> consisting of the results of applying <see cref="IFunction"/>
		/// to the set of first items of each coll, followed by applying <see cref="IFunction"/> to the set
		/// of second items in each coll, until any one of the colls are exhausted.  Any remaining items in
		/// other colls are ignored. <see cref="IFunction"/> should accept number of colls arguments.
		/// </summary>
		/// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
		/// <param name="coll">A collection of items.</param>
		/// <returns>
		/// Returns a <see cref="LazySeq"/> consisting of the results of applying <see cref="IFunction"/>
		/// to the set of first items of each coll, followed by applying <see cref="IFunction"/> to the set
		/// of second items in each coll, until any one of the colls are exhausted.  Any remaining items in
		/// other colls are ignored. <see cref="IFunction"/> should accept number of colls arguments.
		/// </returns>
		public static object map(object f, object coll) => Map.Invoke(f, coll);
		/// <summary>
		/// Returns a <see cref="LazySeq"/> consisting of the results of applying <see cref="IFunction"/>
		/// to the set of first items of each coll, followed by applying <see cref="IFunction"/> to the set
		/// of second items in each coll, until any one of the colls are exhausted.  Any remaining items in
		/// other colls are ignored. <see cref="IFunction"/> should accept number of colls arguments.
		/// </summary>
		/// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
		/// <param name="c1">A collection of items.</param>
		/// <param name="c2">A collection of items.</param>
		/// <returns>
		/// Returns a <see cref="LazySeq"/> consisting of the results of applying <see cref="IFunction"/>
		/// to the set of first items of each coll, followed by applying <see cref="IFunction"/> to the set
		/// of second items in each coll, until any one of the colls are exhausted.  Any remaining items in
		/// other colls are ignored. <see cref="IFunction"/> should accept number of colls arguments.
		/// </returns>
		public static object map(object f, object c1, object c2) => Map.Invoke(f, c1, c2);
		/// <summary>
		/// Returns a <see cref="LazySeq"/> consisting of the results of applying <see cref="IFunction"/>
		/// to the set of first items of each coll, followed by applying <see cref="IFunction"/> to the set
		/// of second items in each coll, until any one of the colls are exhausted.  Any remaining items in
		/// other colls are ignored. <see cref="IFunction"/> should accept number of colls arguments.
		/// </summary>
		/// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
		/// <param name="c1">A collection of items.</param>
		/// <param name="c2">A collection of items.</param>
		/// <param name="c3">A collection of items.</param>
		/// <returns>
		/// Returns a <see cref="LazySeq"/> consisting of the results of applying <see cref="IFunction"/>
		/// to the set of first items of each coll, followed by applying <see cref="IFunction"/> to the set
		/// of second items in each coll, until any one of the colls are exhausted.  Any remaining items in
		/// other colls are ignored. <see cref="IFunction"/> should accept number of colls arguments.
		/// </returns>
		public static object map(object f, object c1, object c2, object c3) => Map.Invoke(f, c1, c2, c3);
		/// <summary>
		/// Returns a <see cref="LazySeq"/> consisting of the results of applying <see cref="IFunction"/>
		/// to the set of first items of each coll, followed by applying <see cref="IFunction"/> to the set
		/// of second items in each coll, until any one of the colls are exhausted.  Any remaining items in
		/// other colls are ignored. <see cref="IFunction"/> should accept number of colls arguments.
		/// </summary>
		/// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
		/// <param name="c1">A collection of items.</param>
		/// <param name="c2">A collection of items.</param>
		/// <param name="c3">A collection of items.</param>
		/// <param name="colls">Rest of the collections of items.</param>
		/// <returns>
		/// Returns a <see cref="LazySeq"/> consisting of the results of applying <see cref="IFunction"/>
		/// to the set of first items of each coll, followed by applying <see cref="IFunction"/> to the set
		/// of second items in each coll, until any one of the colls are exhausted.  Any remaining items in
		/// other colls are ignored. <see cref="IFunction"/> should accept number of colls arguments.
		/// </returns>
		public static object map(object f, object c1, object c2, object c3, params object[] colls) => Map.Invoke(f, c1, c2, c3, colls);
		public static object mapCat(object f) => MapCat.Invoke(f);
		/// <summary>
		/// Returns the result of applying <see cref="Concat"/> to the result of applying
		/// <see cref="Map"/> to f and colls. Thus function f should return a collections.
		/// </summary>
		/// <param name="f">An object that implements <see cref="IFunction"/> interface.</param>
		/// <param name="colls">A collection of items.</param>
		/// <returns>
		/// Returns a collection.
		/// </returns>
		public static object mapCat(object f, params object[] colls) => MapCat.Invoke(f, colls);
		/// <summary>
		/// Returns the greatest of the numbers.
		/// </summary>
		/// <param name="x">Object to test.</param>
		/// <returns>
		/// Returns x.
		/// </returns>
		public static object max(object x) => Max.Invoke(x);
		/// <summary>
		/// Returns the greatest of the numbers.
		/// </summary>
		/// <param name="x">First object to test.</param>
		/// <param name="y">Second object to test.</param>
		/// <returns>
		/// Returns the greatest of the numbers.
		/// </returns>
		public static object max(object x, object y) => Max.Invoke(x, y);
		/// <summary>
		/// Returns the greatest of the numbers.
		/// </summary>
		/// <param name="x">First object to test.</param>
		/// <param name="y">Second object to test.</param>
		/// <param name="more">Rest of the objects to test.</param>
		/// <returns>
		/// Returns the greatest of the numbers.
		/// </returns>
		public static object max(object x, object y, params object[] more) => Max.Invoke(x, y, more);
		/// <summary>
		/// Returns a <see cref="IMap"/> that consists of the rest of the <see cref="IMap"/> conj-ed onto
		/// the first. If a key occurs in more than one map, the mapping from the latter (left-to-right)
		/// will be mapping in the result.
		/// </summary>
		/// <param name="maps">List of <see cref="IMap"/>s to merge together.</param>
		/// <returns>
		/// Returns a <see cref="IMap"/> that consists of the rest of the <see cref="IMap"/> conj-ed onto
		/// the first. If a key occurs in more than one map, the mapping from the latter (left-to-right)
		/// will be mapping in the result.
		/// </returns>
		public static object merge(params object[] maps) => Merge.Invoke(maps);
		/// <summary>
		/// Returns a <see cref="IMap"/> that consists of the rest of the <see cref="IMaps"/> conj-ed onto
		/// the first. If a key occurs in more than one map, the mapping(s0 from the latter (left-to-right)
		/// will be combined with the mapping in the result by calling f.Invoke(value-in-result, value-in-latter)
		/// </summary>
		/// <param name="f">An object that implements the <see cref="IFunction{T1, T2, TResult}"/> interface.</param>
		/// <param name="maps">A list of object maps to merge.</param>
		/// <returns>
		/// Returns a <see cref="IMap"/> that consists of the rest of the <see cref="IMaps"/> conj-ed onto
		/// the first. If a key occurs in more than one map, the mapping(s0 from the latter (left-to-right)
		/// will be combined with the mapping in the result by calling f.Invoke(value-in-result, value-in-latter)
		/// </returns>
		public static object mergeWith(object f, params object[] maps) => MergeWith.Invoke(f, maps);
		/// <summary>
		/// Returns the least of the numbers.
		/// </summary>
		/// <param name="x">Object to test.</param>
		/// <returns>
		/// Returns x.
		/// </returns>
		public static object min(object x) => Min.Invoke(x);
		/// <summary>
		/// Returns the least of the numbers.
		/// </summary>
		/// <param name="x">First object to test.</param>
		/// <param name="y">Second object to test.</param>
		/// <returns>
		/// Returns the greatest of the numbers.
		/// </returns>
		public static object min(object x, object y) => Min.Invoke(x, y);
		/// <summary>
		/// Returns the least of the numbers.
		/// </summary>
		/// <param name="x">First object to test.</param>
		/// <param name="y">Second object to test.</param>
		/// <param name="more">Rest of the objects to test.</param>
		/// <returns>
		/// Returns the greatest of the numbers.
		/// </returns>
		public static object min(object x, object y, params object[] more) => Min.Invoke(x, y, more);
		/// <summary>
		/// If y is not suppled return <see cref="Numbers.Negate(object)"/> of x, else subtract
		/// ys from x and returns the result.
		/// </summary>
		/// <param name="x">Object to <see cref="Numbers.Negate(object)"/>.</param>
		/// <returns>
		/// Returns <see cref="Numbers.Negate(object)"/> of x.
		/// </returns>
		public static object minus(object x) => Minus.Invoke(x);
		/// <summary>
		/// If y is not suppled return <see cref="Numbers.Negate(object)"/> of x, else subtract
		/// ys from x and returns the result.
		/// </summary>
		/// <param name="x">First number to subtract.</param>
		/// <param name="y">Second number to subtract.</param>
		/// <returns>
		/// Returns the result from subtracting y from x.
		/// </returns>
		public static object minus(object x, object y) => Minus.Invoke(x, y);
		/// <summary>
		/// If y is not suppled return <see cref="Numbers.Negate(object)"/> of x, else subtract
		/// ys from x and returns the result.
		/// </summary>
		/// <param name="x">First number to subtract.</param>
		/// <param name="y">Second number to subtract.</param>
		/// <param name="more">Rest of the numbers to subtract.</param>
		/// <returns>
		/// Returns the result of subtracting y from x then rest of the more values.
		/// </returns>
		public static object minus(object x, object y, params object[] more) => Minus.Invoke(x, y, more);
		/// <summary>
		/// Returns a <see cref="Seq"/> of the items after the first. Calls
		/// <see cref="Seq"/> on its argument. If there are no more items,
		/// returns <see cref="Collections.List.EMPTY"/> collection.
		/// </summary>
		/// <param name="coll">Should be a <see cref="Collections.ISeqable"/> collection.</param>
		/// <returns>
		/// Returns a <see cref="Seq"/> of the items after the first. Calls
		/// <see cref="Seq"/> on its argument. If there are no more items,
		/// returns <see cref="Collections.List.EMPTY"/> collection.
		/// </returns>
		public static object more(object coll) => More.Invoke(coll);
		/// <summary>
		/// Returns the product of numbers. No parameters past returns 1. Single parameter there is an
		/// implicit 1 passed.
		/// </summary>
		/// <returns>
		/// Returns 1.
		/// </returns>
		public static object multiply() => Multiply.Invoke();
		/// <summary>
		/// Returns the product of numbers. No parameters past returns 1. Single parameter there is an
		/// implicit 1 passed.
		/// </summary>
		/// <param name="x">First parameter multiply.</param>
		/// <returns>
		/// Returns the product of numbers. No parameters past returns 1. Single parameter there is an
		/// implicit 1 passed.
		/// </returns>
		public static object multiply(object x) => Multiply.Invoke(x);
		/// <summary>
		/// Returns the product of numbers. No parameters past returns 1. Single parameter there is an
		/// implicit 1 passed.
		/// </summary>
		/// <param name="x">First parameter multiply.</param>
		/// <param name="y">Second parameter multiply.</param>
		/// <returns>
		/// Returns the product of numbers. No parameters past returns 1. Single parameter there is an
		/// implicit 1 passed.
		/// </returns>
		public static object multiply(object x, object y) => Multiply.Invoke(x, y);
		/// <summary>
		/// Returns the product of numbers. No parameters past returns 1. Single parameter there is an
		/// implicit 1 passed.
		/// </summary>
		/// <param name="x">First parameter multiply.</param>
		/// <param name="y">Second parameter multiply.</param>
		/// <param name="more">Rest of the parameters to multiply.</param>
		/// <returns>
		/// Returns the product of numbers. No parameters past returns 1. Single parameter there is an
		/// implicit 1 passed.
		/// </returns>
		public static object multiply(object x, object y, params object[] more) => Multiply.Invoke(x, y, more);
		/// <summary>
		/// Returns a <see cref="Seq"/> of the items after the first. Calls
		/// <see cref="Seq"/> on its argument. If there are no more items,
		/// returns null.
		/// </summary>
		/// <param name="coll">Should be a <see cref="Collections.ISeqable"/> collection.</param>
		/// <returns>
		/// Returns a <see cref="Seq"/> of the items after the first. Calls
		/// <see cref="Seq"/> on its argument. If there are no more items,
		/// returns null.
		/// </returns>
		public static object next(object coll) => Next.Invoke(coll);
		/// <summary>
		/// Same as <see cref="Next.Invoke(First.Invoke(object))"/>.
		/// </summary>
		/// <param name="x">Object to return the first item's next item.</param>
		/// <returns>
		/// Returns the first item's next item
		/// </returns>
		public static object nFirst(object x) => NFirst.Invoke(x);
		/// <summary>
		/// Same as <see cref="Next.Invoke(Next.Invoke(object))"/>.
		/// </summary>
		/// <param name="x">Object to return the next item's next item.</param>
		/// <returns>
		/// Returns the next item's next item
		/// </returns>
		public static object nNext(object x) => NNext.Invoke(x);
		/// <summary>
		/// Returns <see cref="true"/> if x is logical false, otherwise <see cref="false"/>.
		/// </summary>
		/// <param name="x">Object to test.</param>
		/// <returns>
		/// Returns <see cref="true"/> if x is logical false, otherwise <see cref="false"/>.
		/// </returns>
		public static object not(object x) => Not.Invoke(x);
		/// <summary>
		/// Returns <see cref="null"/> if coll is empty, otherwise coll
		/// </summary>
		/// <param name="coll">Object to test.</param>
		/// <returns>
		/// Returns <see cref="null"/> if coll is empty, otherwise coll
		/// </returns>
		public static object notEmpty(object coll) => NotEmpty.Invoke(coll);
		/// <summary>
		/// Returns the value at the index. <see cref="Nth"/> throws an exception if index
		/// is out of bounds or unless notFound is supplied. <see cref="Nth"/> works on
		/// strings, arrays, Regex matcher, lists and O(n) time for sequences.
		/// </summary>
		/// <param name="coll">Collection to search for index.</param>
		/// <param name="index">Index to find.</param>
		/// <returns>
		/// Returns the value at the index. <see cref="Nth"/> throws an exception if index
		/// is out of bounds or unless notFound is supplied. <see cref="Nth"/> works on
		/// strings, arrays, Regex matcher, lists and O(n) time for sequences.
		/// </returns>
		public static object nth(object coll, object index) => Nth.Invoke(coll, index);
		/// <summary>
		/// Returns the value at the index. <see cref="Nth"/> throws an exception if index
		/// is out of bounds or unless notFound is supplied. <see cref="Nth"/> works on
		/// strings, arrays, Regex matcher, lists and O(n) time for sequences.
		/// </summary>
		/// <param name="coll">Collection to search for index.</param>
		/// <param name="index">Index to find.</param>
		/// <param name="notFound">Value to return if index is not found.</param>
		/// <returns>
		/// Returns the value at the index. <see cref="Nth"/> throws an exception if index
		/// is out of bounds or unless notFound is supplied. <see cref="Nth"/> works on
		/// strings, arrays, Regex matcher, lists and O(n) time for sequences.
		/// </returns>
		public static object nth(object coll, object index, object notFound) => Nth.Invoke(coll, index, notFound);
		/// <summary>
		/// Returns the nth next of colls. <see cref="Seq"/> is called when n is zero.
		/// </summary>
		/// <param name="coll">The collection to loop.</param>
		/// <param name="n">Number of Items to drop.</param>
		/// <returns>
		/// Returns the nth next of colls. <see cref="Seq"/> is called when n is zero.
		/// </returns>
		public static object nthNext(object coll, object n) => NthNext.Invoke(coll, n);
		/// <summary>
		/// Returns the nth rest of coll, coll when n is 0.
		/// </summary>
		/// <param name="coll">The collection to loop.</param>
		/// <param name="n">Number of Items to drop.</param>
		/// <returns>
		/// Returns the nth rest of coll, coll when n is 0.
		/// </returns>
		public static object nthRest(object coll, object n) => NthRest.Invoke(coll, n);
		/// <summary>
		/// Evaluates objects one at a time, from left to right. If a object returns
		/// a logical true value then it is returned and stops evaluating
		/// all other expressions. Otherwise, it returns the value of the last object.
		/// </summary>
		/// <returns>
		/// Returns null.
		/// </returns>
		public static object or() => Or.Invoke();
		/// <summary>
		/// Evaluates objects one at a time, from left to right. If a object returns
		/// a logical true value then it is returned and stops evaluating
		/// all other expressions. Otherwise, it returns the value of the last object.
		/// </summary>
		/// <param name="x">Object to return.</param>
		/// <remarks>
		/// If x implements interface <see cref="IFunction{TResult}"/> then the object's
		/// Invoke() method is executed and sets its results to x.
		/// </remarks>
		/// <returns>
		/// Evaluates objects one at a time, from left to right. If a object returns
		/// a logical true value then it is returned and stops evaluating
		/// all other expressions. Otherwise, it returns the value of the last object.
		/// </returns>
		public static object or(object x) => Or.Invoke(x);
		/// <summary>
		/// Evaluates objects one at a time, from left to right. If a object returns
		/// a logical true value then it is returned and stops evaluating
		/// all other expressions. Otherwise, it returns the value of the last object.
		/// </summary>
		/// <param name="x">First object to test.</param>
		/// <param name="next">Rest of the objects to test.</param>
		/// <returns>
		/// Evaluates objects one at a time, from left to right. If a object returns
		/// a logical true value then it is returned and stops evaluating
		/// all other expressions. Otherwise, it returns the value of the last object.
		/// </returns>
		public static object or(object x, params object[] next) => Or.Invoke(x, next);
		/// <summary>
		/// Takes a <see cref="IFunction"/> f and fewer than the normal arguments, and returns a
		/// <see cref="Function"/> that take the rest of the arguments.
		/// </summary>
		/// <param name="f">Object that implements the <see cref="IFunction"/> interface.</param>
		/// <param name="arg1">First argument to the function.</param>
		/// <returns>
		/// Returns <see cref="Function"/> that when executed will take args + additional args.
		/// </returns>
		public static object partial(object f, object arg1) => Partial.Invoke(f, arg1);
		/// <summary>
		/// Takes a <see cref="IFunction"/> f and fewer than the normal arguments, and returns a
		/// <see cref="Function"/> that take the rest of the arguments.
		/// </summary>
		/// <param name="f">Object that implements the <see cref="IFunction"/> interface.</param>
		/// <param name="arg1">First argument to the function.</param>
		/// <param name="arg2">Second argument to the function.</param>
		/// <returns>
		/// Returns <see cref="Function"/> that when executed will take args + additional args.
		/// </returns>
		public static object partial(object f, object arg1, object arg2) => Partial.Invoke(f, arg1, arg2);
		/// <summary>
		/// Takes a <see cref="IFunction"/> f and fewer than the normal arguments, and returns a
		/// <see cref="Function"/> that take the rest of the arguments.
		/// </summary>
		/// <param name="f">Object that implements the <see cref="IFunction"/> interface.</param>
		/// <param name="arg1">First argument to the function.</param>
		/// <param name="arg2">Second argument to the function.</param>
		/// <param name="arg3">Third argument to the function.</param>
		/// <returns>
		/// Returns <see cref="Function"/> that when executed will take args + additional args.
		/// </returns>
		public static object partial(object f, object arg1, object arg2, object arg3) => Partial.Invoke(f, arg1, arg2, arg3);
		/// <summary>
		/// Takes a <see cref="IFunction"/> f and fewer than the normal arguments, and returns a
		/// <see cref="Function"/> that take the rest of the arguments.
		/// </summary>
		/// <param name="f">Object that implements the <see cref="IFunction"/> interface.</param>
		/// <param name="arg1">First argument to the function.</param>
		/// <param name="arg2">Second argument to the function.</param>
		/// <param name="arg3">Third argument to the function.</param>
		/// <param name="more">Rest of the arguments to the function.</param>
		/// <returns>
		/// Returns <see cref="Function"/> that when executed will take args + additional args.
		/// </returns>
		public static object partial(object f, object arg1, object arg2, object arg3, params object[] more) => Partial.Invoke(f, arg1, arg2, arg3, more);
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of lists of n items each, at offsets step
		/// apart. If step is not supplied, defaults to n, i.e. the partitions do not
		/// overlap. If a pad collections is supplied, use its elements a necessary
		/// to complete last partition up to n items. In case there are not enough
		/// padding elements, return a partition with  less than n items.
		/// </summary>
		/// <param name="n">A <see cref="int"/> specifying the size of each group.</param>
		/// <param name="coll">A collection that can be <see cref="Seq"/> over.</param>
		/// <returns>
		/// Returns a <see cref="LazySeq"/> of lists of n items each, at offsets step
		/// apart. If step is not supplied, defaults to n, i.e. the partitions do not
		/// overlap. If a pad collections is supplied, use its elements a necessary
		/// to complete last partition up to n items. In case there are not enough
		/// padding elements, return a partition with  less than n items.
		/// </returns>
		public static object partition(object n, object coll) => Partition.Invoke(n, coll);
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of lists of n items each, at offsets step
		/// apart. If step is not supplied, defaults to n, i.e. the partitions do not
		/// overlap. If a pad collections is supplied, use its elements a necessary
		/// to complete last partition up to n items. In case there are not enough
		/// padding elements, return a partition with  less than n items.
		/// </summary>
		/// <param name="n">A <see cref="int"/> specifying the size of each group.</param>
		/// <param name="step">A <see cref="int"/> specifying the starting point for each group.</param>
		/// <param name="coll">A collection that can be <see cref="Seq"/> over.</param>
		/// <returns>
		/// Returns a <see cref="LazySeq"/> of lists of n items each, at offsets step
		/// apart. If step is not supplied, defaults to n, i.e. the partitions do not
		/// overlap. If a pad collections is supplied, use its elements a necessary
		/// to complete last partition up to n items. In case there are not enough
		/// padding elements, return a partition with  less than n items.
		/// </returns>
		public static object partition(object n, object step, object coll) => Partition.Invoke(n, step, coll);
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of lists of n items each, at offsets step
		/// apart. If step is not supplied, defaults to n, i.e. the partitions do not
		/// overlap. If a pad collections is supplied, use its elements a necessary
		/// to complete last partition up to n items. In case there are not enough
		/// padding elements, return a partition with  less than n items.
		/// </summary>
		/// <param name="n">A <see cref="int"/> specifying the size of each group.</param>
		/// <param name="step">A <see cref="int"/> specifing the starting point for each group.</param>
		/// <param name="pad">A collection to pad results with.</param>
		/// <param name="coll">A collection that can be <see cref="Seq"/> over.</param>
		/// <returns>
		/// Returns a <see cref="LazySeq"/> of lists of n items each, at offsets step
		/// apart. If step is not supplied, defaults to n, i.e. the partitions do not
		/// overlap. If a pad collections is supplied, use its elements a necessary
		/// to complete last partition up to n items. In case there are not enough
		/// padding elements, return a partition with  less than n items.
		/// </returns>
		public static object partition(object n, object step, object pad, object coll) => Partition.Invoke(n, step, pad, coll);
		public static object partitionAll(object n) => PartitionAll.Invoke(n);
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of lists like <see cref="Partition"/>, but my include
		/// partitions with fewer then n items at the end.
		/// </summary>
		/// <param name="n">A <see cref="int"/> specifying the size of each group.</param>
		/// <param name="coll">A collection that can be <see cref="Seq"/> over.</param>
		/// <returns>
		/// Returns a <see cref="LazySeq"/> of lists like <see cref="Partition"/>, but my include
		/// partitions with fewer then n items at the end.
		/// </returns>
		public static object partitionAll(object n, object coll) => PartitionAll.Invoke(n, coll);
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of lists like <see cref="Partition"/>, but my include
		/// partitions with fewer then n items at the end.
		/// </summary>
		/// <param name="n">A <see cref="int"/> specifying the size of each group.</param>
		/// <param name="step">A <see cref="int"/> specifying the starting point for each group.</param>
		/// <param name="coll">A collection that can be <see cref="Seq"/> over.</param>
		/// <returns>
		/// Returns a <see cref="LazySeq"/> of lists like <see cref="Partition"/>, but my include
		/// partitions with fewer then n items at the end.
		/// </returns>
		public static object partitionAll(object n, object step, object coll) => PartitionAll.Invoke(n, step, coll);
		public static object partitionBy(object f) => PartitionBy.Invoke(f);
		/// <summary>
		/// Applies <see cref="IFunction{T1, TResult}"/> to each value in coll, splitting it each
		/// time f returns a new value. Returns a <see cref="LazySeq"/> of partitions.
		/// </summary>
		/// <param name="f">An object that implements the <see cref="IFunction{T1, TResult}"/> interface.</param>
		/// <param name="coll">A collection that can be <see cref="Seq"/> over.</param>
		/// <returns>
		/// Returns a <see cref="LazySeq"/> of partitions.
		/// </returns>
		public static object partitionBy(object f, object coll) => PartitionBy.Invoke(f, coll);
		/// <summary>
		/// Returns the same as <see cref="Collections.List"/>'s <see cref="Collections.List.First"/> method,
		/// for <see cref="Collections.Queue"/>'s <see cref="Collections.Queue.Peek"/> method, for
		/// <see cref="Collections.Vector"/>'s <see cref="Last"/> (but much more efficient). If the collection
		/// is empty return null.
		/// </summary>
		/// <param name="coll">An object that implements the <see cref="IStack"/> interface.</param>
		/// <returns>
		/// Returns the same as <see cref="Collections.List"/>'s <see cref="Collections.List.First"/> method,
		/// for <see cref="Collections.Queue"/>'s <see cref="Collections.Queue.Peek"/> method, for
		/// <see cref="Collections.Vector"/>'s <see cref="Last"/> (but much more efficient). If the collection
		/// is empty return null.
		/// </returns>
		public static object peek(object coll) => Peek.Invoke(coll);
		/// <summary>
		/// Returns a new, persistent version of the <see cref="ITransientCollection"/>, in
		/// constant time. The <see cref="ITransientCollection"/> cannot be used after this
		/// call.
		/// </summary>
		/// <param name="coll">An object that implements the <see cref="ITransientCollection"/> interface.</param>
		/// <returns>
		/// Returns a new, persistent version of the <see cref="ITransientCollection"/>, in
		/// constant time.
		/// </returns>
		public static object persistentǃ(object coll) => Persistentǃ.Invoke(coll);
		/// <summary>
		/// Returns the sum of numbers. No parameters past returns 0.
		/// </summary>
		/// <returns>
		/// Returns 0.
		/// </returns>
		public static object plus() => Plus.Invoke();
		/// <summary>
		/// Returns the sum of numbers. No parameters past returns 0.
		/// </summary>
		/// <param name="x">First parameter added.</param>
		/// <returns>
		/// Returns the sum of numbers. No parameters past returns 0.
		/// </returns>
		public static object plus(object x) => Plus.Invoke(x);
		/// <summary>
		/// Returns the sum of numbers. No parameters past returns 0.
		/// </summary>
		/// <param name="x">First parameter added.</param>
		/// <param name="y">Second parameter added.</param>
		/// <returns>
		/// Returns the sum of numbers. No parameters past returns 0.
		/// </returns>
		public static object plus(object x, object y) => Plus.Invoke(x, y);
		/// <summary>
		/// Returns the sum of numbers. No parameters past returns 0.
		/// </summary>
		/// <param name="x">First parameter added.</param>
		/// <param name="y">Second parameter added.</param>
		/// <param name="more">Rest of the parameters to add.</param>
		/// <returns>
		/// Returns the sum of numbers. No parameters past returns 0.
		/// </returns>
		public static object plus(object x, object y, params object[] more) => Plus.Invoke(x, y, more);
		/// <summary>
		/// For <see cref="Collections.List"/> or <see cref="Collections.Queue"/> returns a
		/// new <see cref="Collections.List"/>/<see cref="Collections.Queue"/> without the first
		/// item. For <see cref="Collections.Vector"/>, returns a new <see cref="Collections.Vector"/>
		/// without the last time. If the coll is empty, throws an exception.
		/// </summary>
		/// <param name="coll">An object that implements a <see cref="IStack"/> interface.</param>
		/// <returns>
		/// Returns the same collection type as the input, minus the last item in a <see cref="Collections.Vector"/>
		/// or first time in a <see cref="Collections.List"/> or <see cref="Collections.Queue"/>
		/// </returns>
		public static object pop(object coll) => Pop.Invoke(coll);
		/// <summary>
		/// Removes the last time from a <see cref="ITransientVector"/>. If
		/// the collection is empty, throw an exception.
		/// </summary>
		/// <param name="coll">An object that implements the <see cref="ITransientVector"/> interface.</param>
		/// <returns>
		/// Returns coll.
		/// </returns>
		public static object popǃ(object coll) => Popǃ.Invoke(coll);
		/// <summary>
		/// Prints the object(s) to the <see cref="Variables.Out"/> stream.
		/// </summary>
		/// <returns>
		/// Returns null.
		/// </returns>
		public static object print() => Print.Invoke();
		/// <summary>
		/// Prints the object(s) to the <see cref="Variables.Out"/> stream.
		/// </summary>
		/// <param name="x">Object to print.</param>
		/// <returns>
		/// Returns null.
		/// </returns>
		public static object print(object x) => Print.Invoke(x);
		/// <summary>
		/// Prints the object(s) to the <see cref="Variables.Out"/> stream.
		/// </summary>
		/// <param name="x">First object to print.</param>
		/// <param name="more">Rest of the object to print.</param>
		/// <returns>
		/// Returns null.
		/// </returns>
		public static object print(object x, params object[] more) => Print.Invoke(x, more);
		/// <summary>
		/// The same as <see cref="Print"/> but followed by a <see cref="Environment.NewLine"/>.
		/// </summary>
		/// <param name="more">Any objects you want to print.</param>
		/// <returns>
		/// Returns null.
		/// </returns>
		public static object printLn(params object[] more) => PrintLn.Invoke(more);
		/// <summary>
		/// Returns a <see cref="Random"/> floating point number between
		/// 0 (inclusive) and n (default 1) (exclusive).
		/// </summary>
		/// <returns>
		/// Returns a <see cref="Random"/> floating point number between
		/// 0 (inclusive) and n (default 1) (exclusive).
		/// </returns>
		public static object rand() => Rand.Invoke();
		/// <summary>
		/// Returns a <see cref="Random"/> floating point number between
		/// 0 (inclusive) and n (default 1) (exclusive).
		/// </summary>
		/// <param name="n">An <see cref="int"/> for the exclusive value.</param>
		/// <returns>
		/// Returns a <see cref="Random"/> floating point number between
		/// 0 (inclusive) and n (default 1) (exclusive).
		/// </returns>
		public static object rand(object n) => Rand.Invoke(n);
		/// <summary>
		/// Returns a <see cref="Random"/> <see cref="int"/> between 0 (inclusive) and n (exclusive).
		/// </summary>
		/// <param name="n">An <see cref="int"/> for the exclusive value.</param>
		/// <returns>
		/// Returns a <see cref="Random"/> <see cref="int"/> between 0 (inclusive) and n (exclusive).
		/// </returns>
		public static object randInt(object n) => RandInt.Invoke(n);
		/// <summary>
		/// Return a random element of the <see cref="Collections.ISequential"/> collection.
		/// </summary>
		/// <param name="coll">Collection to search for index.</param>
		/// <returns>
		/// Return a random element of the <see cref="Collections.ISequential"/> collection.
		/// </returns>
		public static object randNth(object coll) => RandNth.Invoke(coll);
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of numbers from start (inclusive) to end
		/// (Exclusive), by step, where start defaults to 0, step to 1, and end to
		/// infinity. When step is equal to 0, returns an infinite sequence of
		/// start. When start is equal to end, returns empty list.
		/// </summary>
		/// <returns>
		/// Returns a <see cref="Collections.Iterate"/> collection starting at 0 continues infinitly.
		/// </returns>
		public static object range() => Range.Invoke();
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of numbers from start (inclusive) to end
		/// (Exclusive), by step, where start defaults to 0, step to 1, and end to
		/// infinity. When step is equal to 0, returns an infinite sequence of
		/// start. When start is equal to end, returns empty list.
		/// </summary>
		/// <param name="end">Either a <see cref="long"/> or <see cref="int"/> value to identify the end value.</param>
		/// <returns>
		/// Returns either <see cref="Collections.LongRange"/> if end is <see cref="long"/> or <see cref="Collections.Range"/> if end
		/// is <see cref="int"/>.
		/// </returns>
		public static object range(object end) => Range.Invoke(end);
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of numbers from start (inclusive) to end
		/// (Exclusive), by step, where start defaults to 0, step to 1, and end to
		/// infinity. When step is equal to 0, returns an infinite sequence of
		/// start. When start is equal to end, returns empty list.
		/// </summary>
		/// <param name="start">Either a <see cref="long"/> or <see cref="int"/> value to identify the start value.</param>
		/// <param name="end">Either a <see cref="long"/> or <see cref="int"/> value to identify the end value.</param>
		/// <returns>
		/// Returns either <see cref="Collections.LongRange"/> if end/start is <see cref="long"/> or <see cref="Collections.Range"/> if end/start
		/// is <see cref="int"/>.
		/// </returns>
		public static object range(object start, object end) => Range.Invoke(start, end);
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of numbers from start (inclusive) to end
		/// (Exclusive), by step, where start defaults to 0, step to 1, and end to
		/// infinity. When step is equal to 0, returns an infinite sequence of
		/// start. When start is equal to end, returns empty list.
		/// </summary>
		/// <param name="start">Either a <see cref="long"/> or <see cref="int"/> value to identify the start value.</param>
		/// <param name="end">Either a <see cref="long"/> or <see cref="int"/> value to identify the end value.</param>
		/// <param name="step">Either a <see cref="long"/> or <see cref="int"/> value to identify the step value.</param>
		/// <returns>
		/// Returns either <see cref="Collections.LongRange"/> if end/start/step is <see cref="long"/> or <see cref="Collections.Range"/> if end/start/step
		/// is <see cref="int"/>.
		/// </returns>
		public static object range(object start, object end, object step) => Range.Invoke(start, end, step);
		/// <summary>
		/// f should implement the <see cref="IFunction{T1, T2, TResult}"/> interface. If val is not supplied,
		/// returns the result of applying f to the first 2 items in coll, then applying f to the result and
		/// the 3rd item, etc. If coll contains no items, f must implement <see cref="IFunction{TResult}"/>
		/// interface and reduce returns the result of calling f with no arguments. If coll has only 1 item,
		/// it is returned and f is not called. If val is supplied, returns the result of applying f to val
		/// and the first item in coll, then applying f to the result and the 2nd item, etc. If coll contains
		/// no items, val is returned and f is not called.
		/// </summary>
		/// <param name="f">An object that implements <see cref="IFunction{T1, T2, TResult}"/> interface unless coll has not items, then it needs to implement the <see cref="IFunction{TResult}"/> interface.</param>
		/// <param name="coll">The collection to reduce.</param>
		/// <returns>
		/// Returns the result of calling f to the 1st and 2nd items, then calling f with the result and 3rd item, etc.
		/// </returns>
		public static object reduce(object f, object coll) => Reduce.Invoke(f, coll);
		/// <summary>
		/// f should implement the <see cref="IFunction{T1, T2, TResult}"/> interface. If val is not supplied,
		/// returns the result of applying f to the first 2 items in coll, then applying f to the result and
		/// the 3rd item, etc. If coll contains no items, f must implement <see cref="IFunction{TResult}"/>
		/// interface and reduce returns the result of calling f with no arguments. If coll has only 1 item,
		/// it is returned and f is not called. If val is supplied, returns the result of applying f to val
		/// and the first item in coll, then applying f to the result and the 2nd item, etc. If coll contains
		/// no items, val is returned and f is not called.
		/// </summary>
		/// <param name="f">An object that implements <see cref="IFunction{T1, T2, TResult}"/> interface.</param>
		/// <param name="val">The initial starting value.</param>
		/// <param name="coll">The collection to reduce over.</param>
		/// <returns>
		/// Returns the result of calling f to val and 1st, then calling f with the result and 2nd, etc.
		/// </returns>
		public static object reduce(object f, object val, object coll) => Reduce.Invoke(f, val, coll);
		/// <summary>
		/// Wraps x in a way such that a <see cref="Reduce"/> will terminate with the value x.
		/// </summary>
		/// <param name="x">Object to wrap.</param>
		/// <returns>
		/// Returns <see cref="Reduced"/> object that wraps x.
		/// </returns>
		public static object reduced(object x) => Reduced.Invoke(x);
		/// <summary>
		/// Reduces a <see cref="IAssociative"/> collection. f should implement <see cref="IFunction{T1, T2, T3, TResult}"/> interface.
		/// Returns the result of applying f to init, the 1st key and value in coll. Then applying f to that result and the
		/// 2nd key and value, etc. If coll contains no entries, returns init and f is not called. Note: <see cref="ReduceKV"/>
		/// is supported on <see cref="IVector"/>'s where the keys will be the ordinal values.
		/// </summary>
		/// <param name="f">An object that implements the <see cref="IFunction{T1, T2, T3, TResult}"/> interface.</param>
		/// <param name="init">The initial value for the reducing.</param>
		/// <param name="coll">The collection that implements <see cref="IAssociative"/> interface.</param>
		/// <returns>
		/// Returns the result of applying f to init, the 1st key and value in coll. Then applying f to that result and the
		/// 2nd key and value, etc. If coll contains no entries, returns init and f is not called.
		/// </returns>
		public static object reduceKV(object f, object init, object coll) => ReduceKV.Invoke(f, init, coll);
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of the intermediate values of the reductions
		/// (as per reduce) of coll by f, starting with init.
		/// </summary>
		/// <param name="f">An object that implements the <see cref="IFunction{TResult}"/> if coll contains no items, otherwise <see cref="IFunction{T1, T2, TResult}"/> interface.</param>
		/// <param name="coll">A object that can be <see cref="Seq"/> over.</param>
		/// <returns>
		/// Returns a <see cref="LazySeq"/> of the intermediate values of the reductions
		/// (as per reduce) of coll by f, starting with init.
		/// </returns>
		public static object reductions(object f, object coll) => Reductions.Invoke(f, coll);
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of the intermediate values of the reductions
		/// (as per reduce) of coll by f, starting with init.
		/// </summary>
		/// <param name="f">An object that implements the <see cref="IFunction{T1, T2, TResult}"/> interface.</param>
		/// <param name="init">The initial starting value.</param>
		/// <param name="coll">A object that can be <see cref="Seq"/> over.</param>
		/// <returns>
		/// Returns a <see cref="LazySeq"/> of the intermediate values of the reductions
		/// (as per reduce) of coll by f, starting with init.
		/// </returns>
		public static object reductions(object f, object init, object coll) => Reductions.Invoke(f, init, coll);
		/// <summary>
		/// Returns the next <see cref="Regex"/> match, if any, of string to pattern, using <see cref="ReMatcher.Find"/>.
		/// Uses <see cref="ReGroups"/> to return the group.
		/// </summary>
		/// <param name="m">A <see cref="ReMatcher"/> object already initialized.</param>
		/// <returns>
		/// Returns the next <see cref="Regex"/> match, if any, of string to pattern, using <see cref="ReMatcher.Find"/>.
		/// Uses <see cref="ReGroups"/> to return the group.
		/// </returns>
		public static object reFind(object m) => ReFind.Invoke(m);
		/// <summary>
		/// Returns the next <see cref="Regex"/> match, if any, of string to pattern, using <see cref="ReMatcher.Find"/>.
		/// Uses <see cref="ReGroups"/> to return the group.
		/// </summary>
		/// <param name="re">A <see cref="Regex"/> object.</param>
		/// <param name="s">The string to search for a match(s).</param>
		/// <returns>
		/// Returns the next <see cref="Regex"/> match, if any, of string to pattern, using <see cref="ReMatcher.Find"/>.
		/// Uses <see cref="ReGroups"/> to return the group.
		/// </returns>
		public static object reFind(object re, object s) => ReFind.Invoke(re, s);
		/// <summary>
		/// Returns the groups from the most recent match/find. If there are no
		/// nested groups, returns a string of the entire match. If there are
		/// nested groups, returns a <see cref="Collections.Vector"/> of groups,
		/// the first element being the entire match.
		/// </summary>
		/// <param name="m">A <see cref="ReMatcher"/> instance.</param>
		/// <returns>
		/// Returns the groups from the most recent match/find. If there are no
		/// nested groups, returns a string of the entire match. If there are
		/// nested groups, returns a <see cref="Collections.Vector"/> of groups,
		/// the first element being the entire match.
		/// </returns>
		public static object reGroups(object m) => ReGroups.Invoke(m);
		public static object rem(object num, object div) => Rem.Invoke(num, div);
		/// <summary>
		/// Returns an instance of <see cref="ReMatcher"/> to be used in <see cref="ReFind"/>.
		/// </summary>
		/// <param name="re">If re is a <see cref="string"/>, it creates a new <see cref="Regex"/> instance with this as its pattern, otherwise it needs to be a <see cref="Regex"/> object.</param>
		/// <param name="s">The string to search for a match(s).</param>
		/// <returns>
		/// Returns an instance of <see cref="ReMatcher"/>.
		/// </returns>
		public static object reMatcher(object re, object s) => ReMatcher.Invoke(re, s);
		public static object reMatches(object re, object s) => ReMatches.Invoke(re, s);
		public static object rePattern(object s) => RePattern.Invoke(s);
		public static object repeat(object x) => Repeat.Invoke(x);
		public static object repeat(object n, object x) => Repeat.Invoke(n, x);
		public static object repeatedly(object f) => Repeatedly.Invoke(f);
		public static object repeatedly(object n, object f) => Repeatedly.Invoke(n, f);
		public static object reSeq(object re, object s) => ReSeq.Invoke(re, s);
		public static object rest(object coll) => Rest.Invoke(coll);
		public static object reverse(object coll) => Reverse.Invoke(coll);
		public static object rSeq(object rev) => RSeq.Invoke(rev);
		public static object second(object x) => Second.Invoke(x);
		public static object selectKeys(object map, object keyseq) => SelectKeys.Invoke(map, keyseq);
		public static object seq(object coll) => Seq.Invoke(coll);
		public static object set(object coll) => Set.Invoke(coll);
		public static object some(object pred, object coll) => Some.Invoke(pred, coll);
		public static object sort(object coll) => Sort.Invoke(coll);
		public static object sort(object comp, object coll) => Sort.Invoke(comp, coll);
		public static object sortBy(object keyfn, object coll) => SortBy.Invoke(keyfn, coll);
		public static object sortBy(object keyfn, object comp, object coll) => SortBy.Invoke(keyfn, comp, coll);
		public static object sortedMap() => SortedMap.Invoke();
		public static object sortedMap(params object[] keyvals) => SortedMap.Invoke(keyvals);
		public static object sortedMapBy(object comparator, params object[] keyvals) => SortedMapBy.Invoke(comparator, keyvals);
		public static object sortedSet() => SortedSet.Invoke();
		public static object sortedSet(params object[] keys) => SortedSet.Invoke(keys);
		public static object sortedSetBy(object comparator, params object[] keys) => SortedSetBy.Invoke(comparator, keys);
		public static object splitAt(object n, object coll) => SplitAt.Invoke(n, coll);
		public static object splitWith(object pred, object coll) => SplitWith.Invoke(pred, coll);
		public static object str() => Str.Invoke();
		public static object str(object x) => Str.Invoke(x);
		public static object str(object x, params object[] ys) => Str.Invoke(x, ys);
		public static object subs(object s, object start) => Subs.Invoke(s, start);
		public static object subs(object s, object start, object end) => Subs.Invoke(s, start, end);
		public static object subVec(object v, object start) => SubVec.Invoke(v, start);
		public static object subVec(object v, object start, object end) => SubVec.Invoke(v, start, end);
		public static object take(object n) => Take.Invoke(n);
		public static object take(object n, object coll) => Take.Invoke(n, coll);
		public static object takeLast(object n, object coll) => TakeLast.Invoke(n, coll);
		public static object takeNth(object n) => TakeNth.Invoke(n);
		public static object takeNth(object n, object coll) => TakeNth.Invoke(n, coll);
		public static object takeWhile(object pred) => TakeWhile.Invoke(pred);
		public static object takeWhile(object pred, object coll) => TakeWhile.Invoke(pred, coll);
		public static object time(Func<object> fn) => new Time(fn).Invoke();
		public static object time(IFunction<object> fn) => new Time(fn).Invoke();
		public static object toArray(object coll) => ToArray.Invoke(coll);
		public static object trampoline(object f) => Trampoline.Invoke(f);
		public static object trampoline(object f, params object[] args) => Trampoline.Invoke(f, args);
		public static object transduce(object xform, object f, object coll) => Transduce.Invoke(xform, f, coll);
		public static object transduce(object xform, object f, object init, object coll) => Transduce.Invoke(xform, f, init, coll);
		public static object transient(object coll) => Transient.Invoke(coll);
		/// <summary>
		/// Returns a <see cref="LazySeq"/> of the nodes in a tree, via a depth-first walk.
		/// </summary>
		/// <param name="branch">An object that implements <see cref="IFunction{T1, TResult}"/> interface that returns true if passed a node
		/// that can have children, otherwise false.</param>
		/// <param name="children">An object that implements <see cref="IFunction{T1, TResult}"/> interface that returns a sequence of the children.</param>
		/// <param name="root">An object for the root node of the tree.</param>
		/// <returns>
		/// Returns a <see cref="LazySeq"/> of the nodes in a tree.
		/// </returns>
		public static object treeSeq(object branch, object children, object root) => TreeSeq.Invoke(branch, children, root);
		public static object truthy(object source) => Truthy.Invoke(source);
		public static object unreduce(object x) => Unreduce.Invoke(x);
		public static object unsignedBitShiftRigth(object x, object n) => UnsignedBitShiftRigth.Invoke(x, n);
		public static object update(object m, object k, object f) => Update.Invoke(m, k, f);
		public static object update(object m, object k, object f, object x) => Update.Invoke(m, k, f, x);
		public static object update(object m, object k, object f, object x, object y) => Update.Invoke(m, k, f, x, y);
		public static object update(object m, object k, object f, object x, object y, object z) => Update.Invoke(m, k, f, x, y, z);
		public static object update(object m, object k, object f, object x, object y, object z, params object[] more) => Update.Invoke(m, k, f, x, y, z, more);
		/// <summary>
		/// 'Updates' a value in a nested <see cref="Collections.IAssociative"/> structure,
		/// where ks is a <see cref="Collections.ISeq"/> of keys and f is a <see cref="IFunction"/>
		/// that will take the old value and any supplied args and return the new value, and
		/// returns a new nested structure. If any levels do not exists, a <see cref="Collections.HashMap"/>
		/// will be created.
		/// </summary>
		/// <param name="m">An object that implements the <see cref="Collections.IAssociative"/> interface.</param>
		/// <param name="ks">An object that implements the <see cref="Collections.ISeq"/> interface.</param>
		/// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
		/// <param name="args">A list of supplied arguments.</param>
		/// <returns>
		/// Returns a new <see cref="Collections.HashMap"/> with the value updated.
		/// </returns>
		public static object updateIn(object m, object ks, object f, params object[] args) => UpdateIn.Invoke(m, ks, f, args);
		/// <summary>
		/// Generates a new <see cref="System.Guid"/> object.
		/// </summary>
		/// <returns>
		/// Returns a new <see cref="System.Guid"/> object.
		/// </returns>
		public static object uuid() => UUID.Invoke();
		/// <summary>
		/// Returns the value in the <see cref="KeyValuePair"/> object.
		/// </summary>
		/// <param name="e">A <see cref="KeyValuePair"/> object pulling the value from.</param>
		/// <returns>
		/// Returns the value in the <see cref="KeyValuePair"/> object.
		/// </returns>
		public static object value(object e) => Value.Invoke(e);
		/// <summary>
		/// Creates a new <see cref="Collections.Vector"/> containing the items from coll.
		/// </summary>
		/// <param name="coll">A object that implements either <see cref="ISeq"/> or <see cref="System.Collections.IEnumerable"/> interface or anything that can be made into array via <see cref="ToArray"/> method.</param>
		/// <returns>
		/// Returns a <see cref="Collections.Vector"/> object. If coll is null returns <see cref="Collections.Vector.EMPTY"/> object.
		/// </returns>
		public static object vec(object coll) => Vec.Invoke(coll);
		/// <summary>
		/// Creates a new <see cref="Collections.Vector"/> containing the args.
		/// </summary>
		/// <returns>
		/// Returns the <see cref="Collections.Vector.EMPTY"/> object.
		/// </returns>
		public static object vector() => Vector.Invoke();
		/// <summary>
		/// Creates a new <see cref="Collections.Vector"/> containing the args.
		/// </summary>
		/// <param name="a">First value of the <see cref="Collections.Vector"/>.</param>
		/// <returns>
		/// Returns a <see cref="Collections.Vector"/> containing the args.
		/// </returns>
		public static object vector(object a) => Vector.Invoke(a);
		/// <summary>
		/// Creates a new <see cref="Collections.Vector"/> containing the args.
		/// </summary>
		/// <param name="a">First value of the <see cref="Collections.Vector"/>.</param>
		/// <param name="b">Second value of the <see cref="Collections.Vector"/>.</param>
		/// <returns>
		/// Returns a <see cref="Collections.Vector"/> containing the args.
		/// </returns>
		public static object vector(object a, object b) => Vector.Invoke(a, b);
		/// <summary>
		/// Creates a new <see cref="Collections.Vector"/> containing the args.
		/// </summary>
		/// <param name="a">First value of the <see cref="Collections.Vector"/>.</param>
		/// <param name="b">Second value of the <see cref="Collections.Vector"/>.</param>
		/// <param name="c">Third value of the <see cref="Collections.Vector"/>.</param>
		/// <returns>
		/// Returns a <see cref="Collections.Vector"/> containing the args.
		/// </returns>
		public static object vector(object a, object b, object c) => Vector.Invoke(a, b, c);
		/// <summary>
		/// Creates a new <see cref="Collections.Vector"/> containing the args.
		/// </summary>
		/// <param name="a">First value of the <see cref="Collections.Vector"/>.</param>
		/// <param name="b">Second value of the <see cref="Collections.Vector"/>.</param>
		/// <param name="c">Third value of the <see cref="Collections.Vector"/>.</param>
		/// <param name="d">Fourth value of the <see cref="Collections.Vector"/>.</param>
		/// <returns>
		/// Returns a <see cref="Collections.Vector"/> containing the args.
		/// </returns>
		public static object vector(object a, object b, object c, object d) => Vector.Invoke(a, b, c, d);
		/// <summary>
		/// Creates a new <see cref="Collections.Vector"/> containing the args.
		/// </summary>
		/// <param name="a">First value of the <see cref="Collections.Vector"/>.</param>
		/// <param name="b">Second value of the <see cref="Collections.Vector"/>.</param>
		/// <param name="c">Third value of the <see cref="Collections.Vector"/>.</param>
		/// <param name="d">Fourth value of the <see cref="Collections.Vector"/>.</param>
		/// <param name="e">Fifth value of the <see cref="Collections.Vector"/>.</param>
		/// <returns>
		/// Returns a <see cref="Collections.Vector"/> containing the args.
		/// </returns>
		public static object vector(object a, object b, object c, object d, object e) => Vector.Invoke(a, b, c, d, e);
		/// <summary>
		/// Creates a new <see cref="Collections.Vector"/> containing the args.
		/// </summary>
		/// <param name="a">First value of the <see cref="Collections.Vector"/>.</param>
		/// <param name="b">Second value of the <see cref="Collections.Vector"/>.</param>
		/// <param name="c">Third value of the <see cref="Collections.Vector"/>.</param>
		/// <param name="d">Fourth value of the <see cref="Collections.Vector"/>.</param>
		/// <param name="e">Fifth value of the <see cref="Collections.Vector"/>.</param>
		/// <param name="f">Sixth value of the <see cref="Collections.Vector"/>.</param>
		/// <returns>
		/// Returns a <see cref="Collections.Vector"/> containing the args.
		/// </returns>
		public static object vector(object a, object b, object c, object d, object e, object f) => Vector.Invoke(a, b, c, d, e, f);
		/// <summary>
		/// Creates a new <see cref="Collections.Vector"/> containing the args.
		/// </summary>
		/// <param name="a">First value of the <see cref="Collections.Vector"/>.</param>
		/// <param name="b">Second value of the <see cref="Collections.Vector"/>.</param>
		/// <param name="c">Third value of the <see cref="Collections.Vector"/>.</param>
		/// <param name="d">Fourth value of the <see cref="Collections.Vector"/>.</param>
		/// <param name="e">Fifth value of the <see cref="Collections.Vector"/>.</param>
		/// <param name="f">Sixth value of the <see cref="Collections.Vector"/>.</param>
		/// <param name="args">Rest of the values added to the <see cref="Collections.Vector"/>.</param>
		/// <returns>
		/// Returns a <see cref="Collections.Vector"/> containing the args.
		/// </returns>
		public static object vector(object a, object b, object c, object d, object e, object f, params object[] args) => Vector.Invoke(a, b, c, d, e, f, args);
		/// <summary>
		/// Creates and returns a <see cref="Volatile"/> with an initial value of val.
		/// </summary>
		/// <param name="val">Initial value.</param>
		/// <returns>
		/// Returns the <see cref="Volatile"/> set to val.
		/// </returns>
		public static object volatileǃ(object val) => Volatileǃ.Invoke(val);
		/// <summary>
		/// Sets the value of <see cref="Volatile"/> to a newValue without
		/// regard for the current value
		/// </summary>
		/// <param name="vol">A <see cref="Volatile"/> object</param>
		/// <param name="newVal">The new value for the <see cref="Volatile"/> object.</param>
		/// <returns>
		/// Returns the new <see cref="Volatile"/> object set to newVal.
		/// </returns>
		public static object vResetǃ(object vol, object newVal) => VResetǃ.Invoke(vol, newVal);
		/// <summary>
		/// Non-atomically swaps the value of volatile.
		/// </summary>
		/// <param name="vol">A <see cref="Volatile"/> object.</param>
		/// <param name="f">An object that implements the <see cref="IFunction"/> interface.</param>
		/// <param name="args">Any additional arguments passed to f</param>
		public static object vSwapǃ(object vol, object f, params object[] args) => new VSwapǃ(vol, f, args).Invoke();
		/// <summary>
		/// Returns a <see cref="HashMap"/> with the keys mapped to the corresponding values
		/// </summary>
		/// <param name="keys">A <see cref="Seq"/> collection for keys.</param>
		/// <param name="vals">A <see cref="Seq"/> collection for values.</param>
		/// <returns>
		/// Returns a <see cref="HashMap"/> with the keys mapped to the corresponding values
		/// </returns>
		public static object zipMap(object keys, object vals) => ZipMap.Invoke(keys, vals);
		#endregion
	}
}
