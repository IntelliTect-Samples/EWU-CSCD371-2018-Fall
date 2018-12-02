using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndStuff
{
    class Button
    {
        public Button(string name)
        {
            Name = name;
        }

        private Callback Callback { get; set; }
        public string Name { get; set; }

        public string NotifyMethodName { get; private set; }
        public object NotifyType { get; set; }

        public void Click()
        {
            CallbackAction?.Invoke(this, new EventArgs());
        }



        public event EventHandler CallbackAction;


    }
}
