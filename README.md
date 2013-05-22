ScriptCs.MemberPrint
====================

# What is it?
A script pack that supplied helper methods for printing object members to the console. Intended for use on the REPL to help you work with large or unknown types.

#How do I get it?
* This package is available on Nuget under the name ScriptCs.MemberPrint. Use `scriptcs -install ScriptCs.MemberPrint`.

#Quick start
In the REPL, issue the command `var print = Require<MemberPrint>();`
Explore the MemberPrint API itself: `print.Methods(print);`
There are multiple overloads for each of the following methods:
* `Methods(object o)`
* `Properties(object o)`
* `Events(object o)`
* `Constructors(object o)`
* `Members(object o)` (this one just calls all of the others)

You can use `BindingFlags` to filter the results. There is also support for regular expression filtering:
`print.Methods(new List<string>(), "^Find.+");`
results in
```
+   FindAll(Predicate`1 match) : List`1
+   FindIndex(Predicate`1 match) : Int32
+   FindIndex(Int32 startIndex, Predicate`1 match) : Int32
+   FindIndex(Int32 startIndex, Int32 count, Predicate`1 match) : Int32
+   FindLast(Predicate`1 match) : String
+   FindLastIndex(Predicate`1 match) : Int32
+   FindLastIndex(Int32 startIndex, Predicate`1 match) : Int32
+   FindLastIndex(Int32 startIndex, Int32 count, Predicate`1 match) : Int32
```