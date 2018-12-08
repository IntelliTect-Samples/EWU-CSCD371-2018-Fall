using System;

namespace BrianBosAssignmentSeven
{
    /*
     * Although managing thread creation and termination would be a great example of resource management,
     * doing so in any meaningful manner would involve extensive setup (making up synchronization scenarios, deadlocks, etc.)
     * 
     * Creating many threads to either spin or wait in the unit tests would also be awkward.
     * 
     * Because of that, this class is just playing pretend instead. It only contains some thread-related properties.
     * 
     * Finding a good name for this was difficult (it's a very simple class.) At least it wasn't named ThreadExA.
     */
    public class ManagedThread : IDisposable
    {
        public uint HandleID { get; set; }

        public byte[] StackData { get; set; }

        /*
         * Outside of enforcing a singleton implementation, I couldn't think of any case where making a static class instance counter
         * would be better than having some form of centralized list. This static counter is for demonstration purposes only.
         */
        private static int _TotalThreadInstances = 0;
        public static int TotalThreadInstances
        {
            get
            {
                return _TotalThreadInstances;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The number of threads cannot be less than 0.");
                }
                else
                {
                    _TotalThreadInstances = value;
                }
            }
        }

        public ManagedThread()
        {
            /*
             * Theoretical failure mechanism: TotalThreadInstances overflows
             * 
             * This is such an extreme mode of failure that I didn't bother dealing with it.
             */
            TotalThreadInstances++;
        }

        public ManagedThread(uint handleID, byte[] stackData)
        {
            HandleID = handleID;
            StackData = stackData;

            TotalThreadInstances++;
        }

        public void Dispose()
        {
            TotalThreadInstances--;
            System.GC.SuppressFinalize(this); // Not suppressing finalization after disposal may result in an incorrect/negative TotalThreadInstances value
        }

        ~ManagedThread()
        {
            Dispose();
        }
    }
}