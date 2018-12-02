# Assignment 7
My implementation uses a value type, with a constraint that the generic type have a default constructor.
* When it works:
  * NotNullable(T) is passed a non null value.
  * NotNullable(T) is passed a null value but the generic type has a default constructor that does not return null.
* Caveats:
  * Cannot use NotNullable<T> with types that do not implement a default constructor, for example `string`.
    * Possible solution: wrap type that doesn't have a default constructor in a class that does. See: `StringWrapper`.
  * Types that implement a default constructor that sets the value to null. See: `System.Nullable<>`.
