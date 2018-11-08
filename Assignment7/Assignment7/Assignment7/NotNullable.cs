using System;

/*
 * Caveats:
 * -By making the Value variable a struct we eliminate the possibility of the value being null
 * -That being said every time we access the value of our variable it must be copied rather that
 *     a reference type which would only need to copy a reference of the object.
 *     *note that the ref keyword allows only a reference to be copied instead of the entire value type
 * -By adding the constraint that the value is unmanaged it ensures the passed objects is not a reference type
 *     and cannot contain any reference types. A draw back is for example any struct that is passed in cannot contain
 *     any references.
 *     
 */
namespace Assignment7
{
    public class NotNullable<T>
        where T : unmanaged 
    {
        public T Value { get; set; }

        public NotNullable(T value)
        {
            Value = value;
        }
    }

}