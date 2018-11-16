using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8_WPF
{
    public class RealDateTime : IDateTime
    {
        public DateTime DateTime()
        {            
            return System.DateTime.Now;

        }
    }
}
