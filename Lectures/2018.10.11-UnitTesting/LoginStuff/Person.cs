using System;

namespace LoginStuff.Tests
{
    public class Person
    {
        private string Password;

        public string LastName { get; set; }



        private string _FirstName;
        public string FirstName {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
            }
        }

        public string UserName
        {
            get
            {
                return $"{FirstName}.{LastName}";
            }
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(UserName));
                }
                (FirstName, LastName) = ParseName(value);
            }
        }

        internal bool IsValidCredentials(string userName, string password)
        {
            return UserName.ToLower() == userName.ToLower() &&
                Password == password;
        }

        private (string FirstName, string LastName) ParseName(string value)
        {
            int separatorIndex = value.IndexOf('.');
            if (separatorIndex < 2 || separatorIndex > value.Length - 2)
            {
                throw new ArgumentException(nameof(UserName),
                    "UserName must be of the format <FirstName>.<LastName>");
            }
            else
            {
                return (FirstName: value.Substring(0, separatorIndex),
                    LastName: value.Substring(separatorIndex + 1,
                    value.Length - separatorIndex - 1));
            }
        }

        public Person(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public Person(string firstName, string lastName, string password)
        {
            UserName = $"{firstName}.{lastName}";
            Password = password;
        }

    }
}