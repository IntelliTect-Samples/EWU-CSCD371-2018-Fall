
/*
 * I decided to go with a class for the purpose of being able to implement a Default Constructor which can call the Default Constructor of T.
 * When any null is passed in, the Explicit Constructor will also call the Default Constructor of T.
 * 
 * Because of these reliances on a DVC, I used the new() generic constraint.
 * 
 * A class also seemed preferable for the purpose of being able to change the value after initialization.
 * 
 * The main issue with using a class is that the class itself is inherently and unavoidably capable of being null.
 * Another major caveat is that with the new() constraint, NotNullable is not able to wrap anything without a DVC, notably strings.
 * 
 */

namespace src
{
    public class NotNullable<T>
        where T : new()
    {
        private T _value;
        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                if(value != null)
                {
                    _value = value;
                }
            }
        }

        public NotNullable()
        {
            Value = new T();
        }

        public NotNullable(T value)
        {
            if(value == null)
            {
                Value = new T();
            }
            else
            {
                Value = value;
            }
        }
    }
}