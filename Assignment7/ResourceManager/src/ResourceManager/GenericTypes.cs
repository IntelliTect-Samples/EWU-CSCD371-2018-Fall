using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceManager
{
    /*
     * Had discussions with Kris Veselits about how to solve problem 1 and a bit of 
     * discussion on problem 2, but for the assignment we wrote our own code. On
     * problem 2 we each took a different approach.                            
     */

    /* ---------------------Caveats ------------------------
      NonNullable is a reference type -> a valuetype does not make sense.
      A public parameterless constructor (default constructor) is required, so 
      this will NOT work with the string class, unfortunately.

      Non-Nullable types are types that represent all the values of an underlying 
      reference value type T, except that it cannot have the null value.

      We can use the following properties to examine an instance of a Non-Nullable type 
      for null and retrieve a value of an underlying type: 

          - Non-Nullable<T>.HasValue indicates whether an instance of a Non-Nullable 
            type has a value of its underlying type.

          - Non-Nullable<T>.Value gets the value of an underlying type if HasValue 
            is true. In our case, the underlying type is a reference, and so if the 
            underlying type is null (explicitly passed in), instead of returning null 
            it will assign to value a default instantiation of the reference. If the
            underlying value is not null, then value will simply contain the reference 
            to the underlying object. If HasValue is false, then a default reference 
            will be assigned to value.

     We would like to override default constructor - so a string will return the 
     string if the string is non-null, or will return the empty string if there is 
     no value, but alas, we cannot. In this problem, we really can’t override the 
     constructors, because during construction of the object we always are going to 
     state which class we are trying to construct and provide the arguments to the 
     constructor. All constructors in a given object hierarchy must connect to the 
     constructor of its parent or another one of the same class. Since we are dealing 
     with the type T, we cannot do this explicitly and are left resorting to using just 
     the default constructor if the value is not set. To do this, we must be assured 
     that the default constructor does indeed exist for the given T, and so we constrain
     NonNullable<T> where T : new().

     We can wrap a reference and retain its characteristics if it is non-null, but if the 
     passed in reference is null, then value will be set to an instance of the default
     contructor.
            
     Other references will return the nonnull value if it has been set, otherwise will 
     set value to the default instance of the underlying type.

     The current constructors will always set a value, so it will never be null. This
     behavior could be modified to incorporate GetValueOrDefault(T defaultValue), where 
     the default of T would be passed in or so a new default can override an existing value.
   */

    public class NonNullable<T> where T : class, new()
    {

        public NonNullable()
        {
            Value = new T();
            HasValue = true;
        }

        public NonNullable(T value)
        {
            Value = value ?? new T();
            HasValue = true;
        }

        private T _Value;
        public T Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (value == null)
                {
                    value = new T();
                }

                _Value = value;
            }
        }


        public bool HasValue { get; }

        public T GetValueOrDefault()
        {
            return Value;
        }

        public T GetValueOrDefault(T defaultValue)
        {
            defaultValue = defaultValue ?? new T();
            return HasValue ? Value : defaultValue;
        }

    }
}
