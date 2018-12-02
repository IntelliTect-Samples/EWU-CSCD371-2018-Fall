using System;

namespace Assignment7
{
    /*
     (Worked with Valdyn Hunt on project, but we ultimately wrote different solutions)

        Caveats:
     1. Passing in a null value won't give a warning at compile time,
        so we're forced to deal with the exception somehow. 
     2. Methods accessing _Value can still cause a NullReferenceException.
        So null checks are still necessary when accessing the _Value field.
     3. The default constructor can still be invoked when instantiating
        a new NonNullable struct, which bypasses the if check.
     4. Overall, I could not think of a solution that bypassed all of these issues.
        Implementing the NonNullable type as a struct or a reference type both have
        their own limitations. 
     */
    public struct NonNullable<T> where T: class
    {
        private T _Value;

        public NonNullable(T value)
        {
            _Value = value ?? throw new ArgumentNullException($"{nameof(value)} cannot be null");
        }

        public T Value
        {
            get
            {
                if (_Value == null)
                {
                    throw new NullReferenceException($"{nameof(_Value)} cannot be null");
                }

                return _Value;
            }

            set
            {
                if (_Value == null)
                {
                    throw new NullReferenceException($"{nameof(_Value)} cannot be null");
                }

                _Value = value;
            }
        }
    }
}