using System;
using System.Diagnostics;

namespace Delegates
{
    class Program
    {
        public delegate int AddMethod(int first, int second);

        static void Main(string[] args)
        {
            var manager = new NotaTimeManager();
            //Action @delegate = WhenTimeEventCreated;

            //manager.TimeEventCreated += @delegate;
            //manager.RaiseEvent();

            //manager.TimeEventCreated += OtherMethod;

            //manager.GetValue += Get4;
            //manager.GetValue += Get5;
            //
            //int result = manager.RaiseGetValue();
            
            //manager.GenericEvent -= ManagerOnGenericEvent;
            //manager.GenericEvent += ManagerOnGenericEvent;
            //
            //manager.RaiseGenericEvent(EventArgs.Empty);
            //
            //manager.GenericEvent += ManagerOnGenericEvent;
            //manager.RaiseGenericEvent(EventArgs.Empty);
            //
            //manager.GenericEvent += ManagerOnGenericEvent;
            //manager.GenericEvent += ManagerOnGenericEvent;
            //manager.GenericEvent -= ManagerOnGenericEvent;
            //manager.RaiseGenericEvent(EventArgs.Empty);
            //
            //manager.GenericEvent -= ManagerOnGenericEvent; 
            //manager.GenericEvent -= ManagerOnGenericEvent;
            

            manager.AddEvent += Add4;
            manager.AddEvent += Add5;

            var addArgs = new AddEventArgs();
            addArgs.Value = 3;

            manager.RaiseAddEvent(addArgs);

            Debug.WriteLine($"Add total: {addArgs.Value}");

            Console.ReadLine();
        }

        private static void Add4(object sender, AddEventArgs e)
            => e.Value += 4;

        private static void Add5(object sender, AddEventArgs e)
            => e.Value += 5;

        private static void ManagerOnGenericEvent(object sender, EventArgs e)
        {
            Debug.WriteLine("Generic event handler");
        }

        private static int Get4() => 4;
        private static int Get5() => 5;

        private static void OtherMethod()
        {
            
        }

        private static void WhenTimeEventCreated()
        {
            throw new Exception();
        }

        private void InstanceMain()
        {
            AddMethod @delegate = DoAdd;

            Action<string> bar = DoStuff;

            Func<int, int, int> foo = DoAdd;
        }

        private void DoStuff(string @params)
        {

        }

        private int DoAdd(int a, int b)
        {
            return a + b;
        }
    }
}
