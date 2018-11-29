# Assignment 9

## Reading

* Finish reading through Chapter 17 by 11/29/2018

## Coding Exercise (due 12/3/2018)

The purpose of this homework is to practice using LINQ to extract, transform and aggregate information out of a collection of items and to understand deferred execution and how to avoid it.

For the following exersizes, use the PatentData class defined in
https://github.com/IntelliTect/EssentialCSharp/blob/v7.0/src/Chapter15/Listing15.10.FilteringWithSystem.Linq.Enumerable.Where.cs

Write a static `PatentDataAnalyzer` **class library** that has methods for the following:

* `InventorNames`: Return a list of the inventor names from the specified country where the country is specified as a parameter.
* `InventorLastNames`: Returns the only the last name of each of the inventor sorted in reverse order by inventor Id.
* `LocationsWithInventors`: Returns a single comma separated list of all the **unique** "<State>-<Country>" (where you list the unique state and country combinations with a dash between the state and the country) strings for each inventor.  The result should be a scalar value of type `string`, not a collection (other than the fact that a string is a collection of characters).  E.g. NC-USA, PA-USA, NY, etc....
* `Randomize`: Write an `IEnumerable<T>` extension method on a class called `Enumerable<T>` that returns an `IEnumerable<T>` of the original items in random order.  To test execute the method using LINQ and verify the order is not the same for at least 3 invocations.

### Extra Credit

* `GetInventorsWithMulitplePatents`: Create a method that returns a list of inventors that have `n` patents, where `n` is provided as a parameter to the method.
* `NthFibonacciNumbers`: Write a method that returns a collection of every nth fibonacci number.

IMPORTANT NOTES:

* All methods should leverage LINQ.  Do not use control flow statements like foreach, if, while, or do-while, or for loops.
* Do not instantiate a new collection unless doing so in order to cache the data and improve performance.
* Do "pretend" the LINQ queries are executing over a slow network and cache data accordingly in both tests and the library you are testing.
* Use the method names specified at the beginning of each bullet.

## Coding Guidlines

* **All production code should be unit tested.  And, although we can't verify it, you are encouraged to do so following a TDD process.**
* **All projects should have project properties set so that warnings are reported as errors by the compiler**
* **Follow all coding guidelines for chapters covered**
