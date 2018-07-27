﻿[![Build Status](https://travis-ci.org/yiglas/funclib.svg?branch=master)](https://travis-ci.org/yiglas/funclib) [![License](https://img.shields.io/badge/License-EPL%201.0-red.svg)](https://opensource.org/licenses/EPL-1.0)

# funclib

Functional Library for C# that follows the Clojure idiom.


1. This style forces you to follow the Single Responsibility method.
2. lower case method name to make calling the functions 
3. Upper case names for classes
4. list of functions 
5. how to add your own functions.



# Funcitons

Each function has two different access methods. 

The first method is the standard c# naming style:
```csharp
using funclib.Compoents.Core;
...

var mapVector = new Map().Invoke(new Inc(), new Vector().Invoke(1, 2, 3, 4, 5));
// => [2, 3, 4, 5, 6]
```

The second and cleaner method is:
```csharp
using static funclib.Core;
...

var mapVector = map(Inc, vector(1, 2, 3, 4, 5));
var mapVector = Map(inc, Vector(1, 2, 3, 4, 5));
var b = isVector(vector(1, 2, 3));
var b = IsVector(Vector(1, 2, 4));
// => [2, 3, 4, 5, 6]
```

From the example above there are a few things to note.

1. Using a C# 6 feature: `using static`. This feature allows you to remove a explicit reference to the type when invoking a static method.

2. The use of the lower case function name for `map`. To distinguish between the different functions and the instantiation of the function's class, I choose to use lower case function name.

3. The use of the capital name of `Inc`. 



# To Do:
* Implement Atom data structure
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
	- if not 
	- if some
	- keep indexed
	- memoize
	- replace
	- slurp
	- spit
	- while

# Non-Pure methods
Non-Pure methods (methods that have side effects) should be suffixed with at http://www.fileformat.info/info/unicode/char/01c3/index.htm character.

# Other possible characters
http://www.fileformat.info/info/unicode/char/1405/index.htm 
http://www.fileformat.info/info/unicode/char/1433/index.htm
http://www.fileformat.info/info/unicode/char/2d67/index.htm
http://www.fileformat.info/info/unicode/char/ffda/index.htm


https://unicode-table.com/en/1433/

maybe test functions end with http://www.fileformat.info/info/unicode/char/0294/index.htm character