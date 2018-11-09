using System;

/*
 * Caveats:
 * -By making the Value variable a class we allow the value being null, so we must explicitly check for null values
 * -A reference type will only need to copy a reference of the object.
 *     whereas a value type must be copied over every time it is accessed.
 * -By adding the constraint that the value is a class it ensures the passed objects is a reference type
 *    
 * A struct would ensure the value passed into the ctor is not null (because it is a value type)
 *     this would be enforced at compile time.
 */
namespace Assignment7
{
    public class NotNullable<T>
        where T : class
    {
        private T _value;
        public T Value
        {
            get => _value;
            set => _value = value ?? throw new ArgumentNullException($"{nameof(value)} cannot be null.");
        }

        public NotNullable(T value)
        {
            Value = value;
        }
    }

}