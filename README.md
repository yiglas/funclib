# FunctionalLibrary

Functional Library for C# that follows the Clojure idiom.

# To Do:
* Implement Atom data structure
* Implement Queue data structure
* Change namespace to funclib.Components.Core -> FunctionalLibrary
* Add funclib.Components.Core class that has static methods for each of the Invoke methods.
```c#
public static object Map(object f) => new Map().Invoke(f);
```
* Add FunctionLibrary.Prelude class that has static properties for each of the classes.
```c#
public static Map Map => new Map();
```
* Missing functions:
	- read
	- read line
	- read stringmapv
	- filterv
	- map indexed
	- some fn
	- dedupe
	- run!
	- thread
	- case
	- cond
	- cond thread
	- flatten
	- if not 
	- if some
	- keep indexed
	- memoize
	- replace
	- slurp
	- spit
	- while

# Non-Pure methods
Non-Pure methods (methods that have side effects) should be prefesed with at http://www.fileformat.info/info/unicode/char/01c3/index.htm character.

# Other possible characters
http://www.fileformat.info/info/unicode/char/1405/index.htm 
http://www.fileformat.info/info/unicode/char/1433/index.htm
http://www.fileformat.info/info/unicode/char/2d67/index.htm
http://www.fileformat.info/info/unicode/char/ffda/index.htm


https://unicode-table.com/en/1433/