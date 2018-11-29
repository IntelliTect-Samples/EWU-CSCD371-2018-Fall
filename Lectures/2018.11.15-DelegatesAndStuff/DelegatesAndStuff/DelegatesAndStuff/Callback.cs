using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndStuff
{
    public class Callback
    {
        public bool Called { get; set; }
        public void Notify(object sender, EventArgs args)
        {
            Called = true;
        }

        public void Notify()
        {
            Called = true;
        }
    }
}
