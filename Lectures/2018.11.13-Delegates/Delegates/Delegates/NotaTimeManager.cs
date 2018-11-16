using System;

namespace Delegates
{
    public class NotaTimeManager
    {
        public event EventHandler<AddEventArgs> AddEvent; 

        public event EventHandler<EventArgs> GenericEvent;

        public event Func<int> GetValue;
        
        public event Action TimeEventCreated;
        //public Action TimeEventCreated { get; set; }

        public void RaiseEvent() => TimeEventCreated?.Invoke();

        public int RaiseGetValue() => GetValue?.Invoke() ?? 0;

        public void RaiseGenericEvent(EventArgs e)
            => GenericEvent?.Invoke(this, e);

        public void RaiseAddEvent(AddEventArgs e)
            => AddEvent?.Invoke(this, e);
    }
}