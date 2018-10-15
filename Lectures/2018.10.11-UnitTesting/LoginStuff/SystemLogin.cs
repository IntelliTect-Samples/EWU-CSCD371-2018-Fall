using System;

namespace LoginStuff.Tests
{



    public class Application
    {
        private static Person[] credentials =
            {new Person("Inigo.Montoya","password"),
             new Person("Princess.Buttercup","AnybodyWantAPeanut")};


        public static bool Login(string userName, string password)
        {
            bool isValid = false;
            foreach(Person person in credentials)
            {
                if(person.IsValidCredentials(
                    userName, password))
                {
                    return true;
                }
            }
            return false;
        }
    }
}