# FunctionalLibrary
Functional Library for C# that follows the Clojure idiom

To Add:





read
read line
read string




mapv
filterv
slurp
spit
map indexed
every pred
some fn
cat
halt when
dedupe
run!

thread
case
cond
cond thread
distinct
is distinct
flatten
if not 
if some
keep indexed
memoize
partition by
reduce kv
replace
slurp
spit
take nth
update in
is uuid
while

todo:
1. create persistent queue<t>
2. change all invalidcastexception message to match .net invalid castexception message
3. create a static class with properties for each of the functions so we do not need to say new 
4. implement transducers


static object FunctionalLibrary.Prelude.Split => new Split()
static object FunctionalLibrary.Core.split(...) => Prelude.Split.Invoke(...);