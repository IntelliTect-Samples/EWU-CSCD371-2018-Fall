
using System;

namespace LoginStuff.Tests
{
    public class Person
    {
        private string _UserName;
        public string UserName
        {
            get
            {
                return $"{FirstName}.{LastName}";
            }
            set
            {
                string[] parts = value.Split(".");
                FirstName = parts[0];
                LastName = parts[1];
            }
        }

        private string Password;

        public string LastName { get; set; }

        public int Age { get; }

        private string _FirstName;
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                    //throw new ArgumentNullException("value");
                }
                _FirstName = value;
            }
        }

        public void Deconstruct(out string firstName, out string lastName)
        {
            firstName = FirstName;
            lastName = LastName;
        }

        public void Deconstruct(out string firstName, out string lastName,
            out string password)
        {
            Deconstruct(out firstName, out lastName);
            //firstName = FirstName;
            //lastName = LastName;
            password = Password;
        }

        public Person(string firstName, string lastName)
            : this(firstName, lastName, null)
        {

        }

        public Person(string firstName, string lastName, string password)
            //: this(firstName, lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }

    }
}