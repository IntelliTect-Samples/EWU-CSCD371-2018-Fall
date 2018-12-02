using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LoginStuff.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void Create_Person_Success()
        {
            Person person = new Person("Inigo", "Montoya", "Password");
            Assert.AreEqual("Inigo", person.FirstName);
            Assert.AreEqual("Montoya", person.LastName);
            Assert.AreEqual("Inigo.Montoya", person.UserName);
        }

        [TestMethod]
        public void UserName_ChangeName_Success()
        {
            Person person = new Person("Inigo", "Montoya", "Password");
            person.FirstName = "Frank";
            Assert.AreEqual("Frank", person.FirstName);
            person.LastName = "Nelson";
            Assert.AreEqual("Nelson", person.LastName);
        }

        [TestMethod]
        public void Deconstructor_Returns_FirstName_LastName()
        {
            var person = new Person("Inigo", "Montoya");
            
            //(string Other, string Bar) tuple = ("Kevin", "Joe");
            
            (string firstName, string lastName) = person;

            Assert.AreEqual("Inigo", firstName);
            Assert.AreEqual("Montoya", firstName);
        }

        [TestMethod]
        public void Foo()
        {
            var person = new Person("Inigo", "Montoya");

            string firstName = person.FirstName;
            string lastName = person.LastName;
            //person.Deconstruct(out string firstName, out string lastName);

            Assert.AreEqual("Inigo", firstName);
            //...etc
        }

        [TestMethod]
        public void PatternMatching()
        {
            Person person = new Employee("Kevin", "Bost", "42");

            Type personType = person.GetType();

            //Bad don't do type checks like this!
            Assert.AreEqual(nameof(Person), personType.Name);

            //Pre C# 7
            {
                //person = new object();
                Person kevin = person as Person;
                //ALWAYS check for null after an 'as' cast!
                if (kevin != null)
                {
                    //TODO
                }
            }
            //C# 7
            {
                if (person is Person kevin)
                {
                    Assert.IsTrue(ReferenceEquals(person, kevin));
                    Assert.AreEqual("Kevin", kevin.FirstName);
                }
            }
            //Pattern matching switch statement
            {
                switch (person)
                {
                    case Person kevin when (kevin.FirstName == "Kevin"):
                        //Give raise, because kevin
                        Assert.AreEqual("Bost", kevin.LastName);
                        break;
                    case Employee employee:
                        Assert.AreEqual("42", employee.ID);
                        break;
                    case null:

                        break;
                    default:
                        //Probably should put this at the end
                        break;
                }
            }
        }
    }

    
}
