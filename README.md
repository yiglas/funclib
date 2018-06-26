# FunctionalLibrary

Functions to are not pure are marked with http://www.fileformat.info/info/unicode/char/01c3/index.htm

http://www.fileformat.info/info/unicode/char/ffda/index.htm

http://www.fileformat.info/info/unicode/char/1405/index.htm 
http://www.fileformat.info/info/unicode/char/1433/index.htm
http://www.fileformat.info/info/unicode/char/2d67/index.htm
ﭸ

http://www.fileformat.info/info/unicode/char/ffda/index.htm

http://www.fileformat.info/info/unicode/char/2d67/index.htm

Functional Library for C# that follows the Clojure idiom

To Add:
read
read line
read stringmapv
filterv
map indexed
some fn
dedupe
run!
thread
case
cond
cond thread
flatten
if not 
if some
keep indexed
memoize
replace
slurp
spit
while

todo:
1. create persistent queue<t>

3. create a static class with properties for each of the functions so we do not need to say new 
4. implement transducers


static object FunctionalLibrary.Prelude.Split => new Split()
static object FunctionalLibrary.Core.split(...) => Prelude.Split.Invoke(...);