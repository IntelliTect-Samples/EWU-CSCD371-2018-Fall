using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Assignment4.Tests
{
    [TestClass]
    public class UniversityCourseTester
    {
        private static UniversityCourse course;
        [TestInitialize]
        public void Get_Name_Constructed_Success()
        {
            course = new UniversityCourse("Android Development", "CEB 228",
                new DateTime(2018, 9, 18, 12, 0, 0, 0), new DateTime(2018, 12, 10, 14, 0, 0, 0),
                "CSCD272", "Paul Shimpf", "mwf");
        }

/*Course ID*/
        [DataRow("CSCD272")]
        [DataRow("CSCD100")]
        [DataRow("CSCD200")]
        [DataRow("CSCD921")]
        [DataTestMethod]
        public void Set_CourseID__Success(string courseID)
        {
            course.CourseID = courseID;
            Assert.AreEqual(course.CourseID, courseID);
        }

        [DataRow("no")]
        [DataRow("w")]
        [DataRow("654")]
        [DataRow("a")]
        [ExpectedException(typeof(ArgumentException))]
        [DataTestMethod]
        public void Set_CourseId_ArgumentOutOfRangeException(string courseID)
        {
            course.CourseID = courseID;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Set_CourseId_ArgumentNullException()
        {
            course.CourseID = null;
            Assert.Fail();
        }


/*Instructor*/
        [DataRow("Casey White")]
        [DataRow("Tom Capaul")]
        [DataRow("Stu Steiner")]
        [DataRow("Kevin Bost")]
        [DataTestMethod]
        public void Set_Instructor_Success(string instructor)
        {
            course.Instructor = instructor;
            Assert.AreEqual(course.Instructor, instructor);
        }

        [DataRow("")]
        [DataRow(" ")]
        [DataRow("a")]
        [DataTestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Set_Instructor_ArgumentOutOfRangeException(string instructor)
        {
            course.Instructor = instructor;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Set_Instructor_ArgumentNullException()
        {
            course.Instructor = null;
            Assert.Fail();
        }

/*Schedule*/
        [DataRow("m")]
        [DataRow("mtw")]
        [DataRow("mtwrf")]
        [DataRow("mtwrfsS")]
        [DataTestMethod]
        public void Set_Schedule_Success(string schedule)
        {
            course.Schedule = schedule;
            Assert.AreEqual(course.Schedule, schedule);
        }

        [DataRow("")]
        [DataRow(" ")]
        [DataRow("mtwrfsSw")]
        [DataTestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Set_Schedule_ArgumentOutOfRangeException(string schedule)
        {
            course.Schedule = schedule;
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Set_Schedule_ArgumentNullException()
        {
            course.Schedule = null;
            Assert.Fail();
        }

        /*Number of courses*/
        [TestMethod]
        public void Get_Number_of_Constructed_Courses_Success()
        {
            var numberOfCoursesBefore = UniversityCourse.NumberOfCourses;
            UniversityCourse myCourse = new UniversityCourse("Web Development", "CEB 228",
                new DateTime(2018, 9, 18, 12, 0, 0, 0), new DateTime(2018, 12, 10, 14, 0, 0, 0),
                "CSCD272", "Casey White", "mtwrf");
            Assert.AreEqual(numberOfCoursesBefore + 1, UniversityCourse.NumberOfCourses);
        }


        /*Credits*/
        [TestMethod]
        public void Get_Credits_6_Success()
        {
            Assert.AreEqual(6, course.NumberOfCredits);
        }

        [TestMethod]
        public void Get_Credits_4_Success()
        {
            course.Schedule = "mw";
            Assert.AreEqual(4, course.NumberOfCredits);
        }


        /*Get Summary Information*/
        [TestMethod]
        public void Get_Summary_Information_Success()
        {
            var output = course.GetSummaryInformation();
            var expectedOutput =
@"Event Name: Android Development
Location: CEB 228
Start Date: 9/18/2018 12:00:00 PM
End Date: 12/10/2018 2:00:00 PM
Course ID: CSCD272
Instructor: Paul Shimpf
Schedule: mwf
Number of Credits: 6";
            Assert.AreEqual(expectedOutput, output);
        }
    }
}
