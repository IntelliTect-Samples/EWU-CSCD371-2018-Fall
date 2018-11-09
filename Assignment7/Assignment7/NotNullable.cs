using System;

namespace Assignment7
{
    /*
     This NonNullable class is set up to accept reference type objects.
     
     Benefits vs Struct:
         1. One benefit of this is that when passing this object as a parameter a reference
         of this object is passed. This allows changes to the original object, as well as saving
         memory on passing the parameter. 
         2. If this were set up so that T had to be of type struct, the contents of the struct 
         would be copied everytime the class was passed as a parameter 
         (barring the use of the ref keyword). 
         3. In addition structs are by convention read-only and do not have property setters, 
         so using a class type may allow the data contained within NotNullable._Value to be changed.

     Caveats:
         1. Unfortunately this implementation using reference types must still check for Null values
         at runtime. This is as opposed to the general use of generics in which the compiler can detect and
         flag incorrect types at compile time.


     Consideration of Struct:
         As noted above there are a couple of downside to using structs. If those constraints were
         acceptable for our intended application we still do not achieve an ideal solution. In particular
         while a struct can never be null, it may have a default value which does not conform to the application
         intended use.

         A potential workaround to this is to check if(MyStruct.Equals(default(T)), where T is the type of
         class/strcut the property points to. Again however, this is a runtime check as opposed to a compile time
         one like we would ideally achieve.

     */
    public class NotNullable<T>
        where T : class
    {
        public T Value
        {
            get => _Value;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Argument cannot be null on call to CTOR of NotNullable object");
                }
                _Value = value;
            }
        }
        private T _Value;

        public NotNullable(T value){
            Value = value;
        }
    }
}
