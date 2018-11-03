using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            StringBuilder myBuilder = new StringBuilder("Inigo Montoya");
            string myThirdString = "";
            string myFirstString = myBuilder.ToString(); // "Inigo Montoya"; // + myThirdString.ToString();
            string mySecondString = "Inigo Montoya";

            Assert.IsTrue(myFirstString == mySecondString);
            Assert.IsTrue(myFirstString.Equals(mySecondString));
            // Assert.IsTrue(string.ReferenceEquals(myFirstString, mySecondString));
        }
        // [TestMethod]
        // public void TestPerson()
        // {
        //     var person1 = new Person { SSN = "123-45-6789", FirstName = "Inigo", LastName = "Montoya" };
        //     var person2 = new Person { SSN = "123-45-6789", FirstName = "Princess", LastName = "Buttercup" };

        //     Assert.IsTrue(person1 == person2);
        // }

        [TestMethod]
        public void ExceptionStuff()
        {
            try
            {

            }
            catch (Exception e) when (e.Message == "I'm having a really bad day")
            {

            }
            catch (NullReferenceException nre)
            {

            }
            catch (Exception e)
            {
                //Log.Debug($"we did something bad: {e}");
                // throw e; not good
                throw new Exception("Something bad happened", innerException: e);
            }
            finally
            {
                // always runs
            }
            // catch
            // {
            //     throw;
            // }
        }

        [TestMethod]
        public void UsingExample()
        {
            // {
            //     using (Parser myParser = new Parser(@"C:\course\Testing\myFile.txt"))
            //     using (Parser mySecondParser = new Parser(@"C:\course\Testing\secondFile.txt"))
            //     {
            //         int i = 0;
            //         int bad = 5 / i;
            //     }
            // }
            {
                Parser myParser = null;
                try
                {
                    // do stuff
                    myParser = new Parser(@"C:\course\Testing\myFile.txt");

                    
                    // something bad happens here and throws an exception
                }
                finally
                {
                    myParser?.Dispose();
                }
                
            }
            Console.WriteLine("hello world");
        }
    }

    class Parser : IDisposable
    {
        private StreamReader FileReader { get; }
        public Parser(string fileName)
        {
            // 
            FileReader = new StreamReader(fileName);
        }

        ~Parser()
        {
            Dispose();
        }

        public void Dispose()
        {
            FileReader?.Dispose();
        }
    }

    class Person
    {
        public string SSN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
