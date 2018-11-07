using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework6;
using System;

namespace Homework6.Tests
{
    [TestClass]
    public class CourseTests
    {
        private Course course { get; set; }

        [TestInitialize]
        public void Setup()
        {
            course = new Homework6.Course("CSCD123", "JAVA class", "Fall 2018, M-F, 12:00pm - 1:00pm", "Stu.Steiner");
        }

        [TestCleanup]
        public void CleanupTest()
        {
            course = null;
        }


        [TestMethod]
        public void InstructorUserName_AssignTomDotCapal_Success()
        {
            course.InstructorUserName = "Tom.Capal";

            Assert.AreEqual("Tom", course.InstructorFirstName);
            Assert.AreEqual("Capal", course.InstructorLastName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow(".Capal")]
        [DataRow("Tom.")]
        [DataRow(".")]
        [DataRow("")]
        public void InstructorUserName_AssignEmptyLastName_Throw(string instructorUserName)
        {
            course.InstructorUserName = instructorUserName;
        }

        [TestMethod]
        public void StudentCount_33Students_Success()
        {
            course.StudentCount = 33;
            Assert.AreEqual(33, course.StudentCount);
        }

        [TestMethod]
        [DataRow(11)]
        [DataRow(37)]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentCount_11Students_Fail(int numOfStudents)
        {
            course.StudentCount = numOfStudents;
            //Assert.AreEqual(33, course.StudentCount);
        }

        [TestMethod]
        public void InstructorSalory_SalaryOf20000And33Students_Success()
        {
            int salary = 20000;
            int StudentCount = 33;
            int BonusBasedOnClassSize = (StudentCount / 10) * 1000;
            course.StudentCount = StudentCount;
            course.InstructorSalory = salary;

            Assert.AreEqual((salary + (StudentCount / 10) * 1000), course.InstructorSalory);
        }

        [TestMethod]
        public void incTotalCalendarItems_Add3CoursesAnd2Events_Success()
        {
            course.setTotalCalendarItems(0);
            course = new Course("CSCD123", "JAVA class", "Fall 2018, M-F, 12:00pm - 1:00pm", "Stu.Steiner");
            course = new Course("CSCD123", "JAVA class", "Fall 2018, M-F, 12:00pm - 1:00pm", "Stu.Steiner");
            course = new Course("CSCD321", "Python class", "Fall 2018, T-Th, 9:00am - 10:00am", "Guy.Snake");
            Event @event = new Event("C# programming club", "CEB372 class room", "10-13-2018 1:00pm - 3:30pm");
            @event = new Event("Extream Nerding club", "CEB301 AV room", "11-25-2018 4:00pm - 11:30pm");

            Assert.AreEqual(5, course.getTotalCalendarItems());
        }

    }
}
