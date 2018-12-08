using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace tests
{
    [TestClass]
    public class TestCourse
    {        
        private static Assignment5.Course Course { get; set; }

        [TestInitialize]
        public void SetupUnivCourse()
        {
            Course = new Assignment5.Course("Computer Science", ".net", 208, 21, 2, 4);
            Course.resetCourseTotal();
        }

        [TestMethod]
        public void TestValid_SetSubject()
        {
            Course.Subject = "Chemistry";
            Assert.AreEqual("Chemistry", Course.Subject);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void TestInvalid_SetSubjectEmpty()
        {
            Course.Subject = "";
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestInvalid_SetSubjectNull()
        {
            Course.Subject = null;
            Assert.Fail();
        }
 
        [TestMethod]
        public void TestValid_ReadNumTeacher()
        {
            int actual = Course.NumTeachers;
            Assert.AreEqual(1, actual);
        }
 
        [TestMethod]
        public void TestValid_NumStudentGet()
        {
            int actual = Course.NumStudents;
            Assert.AreEqual(21, actual);
        }

        [TestMethod]
        public void TestValid_NumStudentSet()
        {
            Course.NumStudents = 42;
            Assert.AreEqual(42, Course.NumStudents);
        }

        [TestMethod]
        public void TestValid_GetRoomNum()
        {
            int actual = Course.RoomNum;
            Assert.AreEqual(208, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestInvalid_SetRoomNum()
        {
            Course.RoomNum = 42;
            Assert.Fail();
        }

        [TestMethod]
        public void TestValid_SetRoomNum()
        {
            Course.RoomNum = 123;
            int actual = Course.RoomNum;
            Assert.AreEqual(123, actual);
        }

        [TestMethod]
        public void TestValid_ReadOnlyFloorNum()
        {
            int actual = Course.FloorNum;
            Assert.AreEqual(2, actual);
        }

        [TestMethod]
        public void TestValid_GetCourseTotalInitial()
        {
            int actual = Course.CourseTotal;
            Assert.AreEqual(0, actual);
        }


        [TestMethod]
        public void TestValid_GetCourseTotalMultipleCourse()
        {
            Assignment5.Course t = new Assignment5.Course("cs", "c and unix", 204, 2, 3, 4);
            Assignment5.Course t2 = new Assignment5.Course("cs", "c and unix", 204, 2, 3, 4);
            Assert.AreEqual(2, Course.CourseTotal);
        }


        [TestMethod]
        public void TestValid_SummaryOutput()
        {
            
Assert.AreEqual( $@"Title: {Course.Title}{Environment.NewLine}
                    Start Hour: {Course.StartHour}{Environment.NewLine}
                    End Hour: {Course.EndHour}{Environment.NewLine}
                    Subject: {Course.Subject}{Environment.NewLine}
                    Room Number: {Course.RoomNum}{Environment.NewLine}
                    Floor Number: {Course.FloorNum}{Environment.NewLine}
                    Number of Teachers: {Course.NumTeachers}{Environment.NewLine}
                    Number of Students: {Course.NumStudents}{Environment.NewLine}",Course.GetSummaryInformation());
        }
        
    }
}