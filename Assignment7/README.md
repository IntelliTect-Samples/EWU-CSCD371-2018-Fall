# Assignment 7

## Reading

* Complete Chapter 12 by 11/06/2018
* Start Chapter 13 by 11/08/2018

## Coding Exercise (due 11/08/2018)

### 1. Resource Management

* Write a class that requires resource management.  An idea for an example is a class that counts how many instances there are.  When an instance is Disposed or no longer accessible, it should decrement the count.  The decrement should occur both when the programmer remembers to call `Dispose()` or equivalent or if the programmer forgets or doesn't realize `IDisposable` is supported.

### 2. Generics

* Define a generic type called `NotNullable` for which there is a strongly typed read/write property called "Value"
* Decide whether the `NotNullable` type is a value type or a reference type
* Identify the caveats with whichever approach you choose by describing them above the `NotNullable` type declaration. (Both approaches have caveats which is why likely why Microsoft has never solved the non-nullable problem with a generic type.)
* Include a description of why the caveats can't be resolved.
* Note: It is optional (neither better or worse) to use `IFactory<T>` (don't use `Factory<T>`) as as a means of providing the "default" value of `T` if `NonNullable`'s default constructor (if it has one) is invoked. I mention this because in class I inferred you would need a factory class but that is not necessarily the case.
* Prefix your PR Name with __"Assignment7"__ (no space)

NOTE: This exercise __can be implemented in pairs__ - with two people submitting the same solution (each person submits a PR with the same code).  (Identify who you paired with in the PR name.)

## Coding Guidelines

* **All production code should be unit tested.  And, although we can't verify it, you are encouraged to do so following a TDD process.**
* **All projects should have project properties set so that warnings are reported as errors by the compiler**
* **Follow all coding guidelines for chapters covered**
