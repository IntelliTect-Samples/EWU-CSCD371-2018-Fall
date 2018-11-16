using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndStuff
{
    class ButtonWithDelegates
    {
        public ButtonWithDelegates(string name)
        {
            Name = name;
        }

        private Callback Callback { get; set; }
        public string Name { get; set; }

        public string NotifyMethodName { get; private set; }
        public object NotifyType { get; set; }

        public void Click()
        {
            Callback?.Notify();
            foreach (Action item in CallbackAction)
            {
                item?.Invoke();
            }

            CallbackAction.ForEach(
                (item) => item?.Invoke());
        }

        public void Register(Callback callback)
        {
            Callback = callback;
        }

        private List<Action> CallbackAction { get; set; } = new List<Action>();

        public void Register(Action notify)
        {
            CallbackAction.Add(notify);
        }
    }
}
