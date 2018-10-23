using System;
using System.Collections.Generic;

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

        public static List<string> RegisteredIds { get; } 
            = new List<string>();

        public static int Register(object @object)
        {
            switch(@object)
            {
                case Person person:
                    RegisteredIds.Add(person.Id);
                    break;
                case UniversityCourse course:
                    RegisteredIds.Add(course.Id);
                    break;
                case null:
                    throw new ArgumentNullException(nameof(@object));
                default:
                    throw new ArgumentException("Unknown object type", nameof(@object));
            }
            /*if (@object is Person person)
            {
                RegisteredIds.Add(person.Id);
            }
            if (@object is UniversityCourse course)
            {
                RegisteredIds.Add(course.Id);
            }*/
            return RegisteredIds.Count;
        }
    }

    public class UniversityCourse
    {
        public string Id { get; set; }
    }
}