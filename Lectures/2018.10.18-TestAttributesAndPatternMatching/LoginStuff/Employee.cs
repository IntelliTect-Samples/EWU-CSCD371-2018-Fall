using LoginStuff.Tests;

namespace LoginStuff
{
    public class Employee : Person
    {
        private string EmployeeId { get; set; }
        public Employee(string firstName, string lastName, string password) 
            : base(firstName, lastName, password)
        { }

        public override string Id
        {
            get => EmployeeId;
            internal set => EmployeeId = value;
        }
    }
}
