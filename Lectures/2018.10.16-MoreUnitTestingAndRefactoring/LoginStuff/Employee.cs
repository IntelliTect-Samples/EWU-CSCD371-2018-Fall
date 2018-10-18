namespace LoginStuff.Tests
{
    public class Employee : Person
    {
        public Employee(string firstName, string lastName, string id) 
            : base(firstName, lastName)
        {
            ID = id;
        }

        public string ID { get; }
    }
}