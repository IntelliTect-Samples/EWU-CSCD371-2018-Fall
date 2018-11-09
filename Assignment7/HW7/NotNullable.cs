using System;
using System.Collections.Generic;
using System.Text;

namespace HW7
{
    //Caveats 
    // - This generic reference type can not be instantiated with any parameter, as it only contains a default constructor.
    // - The type used my have a default constuctor. Enforced by the " where T : new() " constraint.
    // - The value property Value enforces the value can not be set to null, as it check for this and if true, calls 
    // -     the generic typed default constuctor.  

    public class NotNullable<T>
        where T : new() 
    {
         
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
                       new T();
                }
                else
                    _Value = value;
            }
        }
        private T _Value;

    }
}
