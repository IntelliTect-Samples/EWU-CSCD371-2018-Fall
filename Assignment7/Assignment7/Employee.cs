using System;

namespace Assignment7
{
    public class Employee : IDisposable
    {
        public static int Instances { get; set; }

        private string Name{ get; }
        private int Id { get; }

        private bool IsDisposed { get; set; }

        public Employee(string name, int id)
        {
            Id = id;
            Name = name;
            Instances++;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                {
                    Instances--; //dispose managed resources
                }
            }

            IsDisposed = true;
        }

        ~Employee()
        {
            Dispose(false);
        }
    }
}