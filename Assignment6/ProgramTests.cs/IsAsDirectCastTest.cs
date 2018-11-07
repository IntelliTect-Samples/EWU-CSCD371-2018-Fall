using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework6;
using System;

namespace Homework6.Tests
{
    [TestClass]
    public class ProgramTests
    {


        [TestMethod]
        public void SelfContainedTestOfTheIsOperator_Success()
        {
            string str1 = "This is only a test";

            string result = null; 
           if (str1 is string)
                result = str1.ToUpper();

            Assert.AreEqual("THIS IS ONLY A TEST", result);
        }

        [TestMethod]
        public void SelfContainedTestOfTheIsOperator_DiffObjects_Failure()
        {
            var str1 = "This is only a test";            
            object str2 = str1; 

            string result = null;
            if (str2 is Course)
                result = str1.ToUpper();
            else
                result = "Object type did NOT match";

            Assert.AreEqual("Object type did NOT match", result);
        }

        [TestMethod]
        public void SelfContainedTestOfDirectCastOperator_Success()
        {
            int tempNum = 4;
            //convert a int to a double
            double convertedInt = (double)tempNum;

            Assert.AreEqual(4.0, convertedInt);
        }

        [TestMethod]
        public void SelfContainedTestOfTheAsOperator_Success()
        {
            Course course = new Course("CSCD371", ".NET class", "Fall 2018, M-F, 2:00pm - 4:30pm", "Tom.Capaul");
            object @event = new Event("Extream Nerding club", "CEB301 AV room", "11-25-2018 4:00pm - 11:30pm");

            string result;

            Course tempCourse = course as Course;
            if (tempCourse == null)
                result = "null";
            else
                result = "Is a course object";

            Assert.AreEqual("Is a course object", result);
        }

        [TestMethod]
        public void SelfContainedTestOfTheAsOperator_DiffTypes_ReturnsNull_Success()
        {
            
            Course course = new Course("CSCD371", ".NET class", "Fall 2018, M-F, 2:00pm - 4:30pm", "Tom.Capaul");
            object @event = new Event("Extream Nerding club", "CEB301 AV room", "11-25-2018 4:00pm - 11:30pm"); 

            string result;

            Course tempCourse = @event as Course;
            if (tempCourse == null)
                result = "null";
            else
                result = "Is a course object";

            Assert.AreEqual("null", result);
        }
    }
}

