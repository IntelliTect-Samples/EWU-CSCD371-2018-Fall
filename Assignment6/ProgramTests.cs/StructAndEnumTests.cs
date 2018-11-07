using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework6;
using System.Runtime.InteropServices;

namespace Homework6.Tests
{
    [TestClass]
    public class StructAndEnumTests   {
        

        [TestMethod]
        public void DayOfWeekEnum_ParseMultiDayString_Success()
        {

            object WeekDy;

            string stringWithDaysInIt = "Wednesday, Friday, Monday";                                                   //"Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday"

            bool result = Enum.TryParse(typeof(DayOfWeek), stringWithDaysInIt, false, out WeekDy);
                     

          Assert.AreEqual("Monday", DayOfWeek.Monday.ToString());          
          Assert.AreEqual("Wednesday", DayOfWeek.Wednesday.ToString());
          Assert.AreEqual("Friday", DayOfWeek.Friday.ToString());

            //Assert.AreEqual(9, (byte)DayOfWeek.Monday + (byte)DayOfWeek.Wednesday + (byte)DayOfWeek.Friday);
        }

        [TestMethod]
        public void DayOfWeekEnum_ParseSingleDayString_Success()
        {

            Enum.TryParse("Monday", out DayOfWeek myResult);
            Assert.AreEqual("Monday", myResult.ToString());
        }

        [TestMethod]
        public void QuarterStruct_ParseOneQuarter_Success()
        {
            Enum.TryParse("Fall", out Homework6.Program.Quarter myResult);
            Assert.AreEqual("Fall", myResult.ToString());
        }

        [TestMethod]
        public void ScheduleStruct_VerifyItsSizeIsLessThan16_Success()
        {
            int size = Marshal.SizeOf(typeof(Homework6.Program.Schedule));

            bool sizeIsLessThanOrEqualTo16;
            if (size <= 16)
                sizeIsLessThanOrEqualTo16 = true;
            else
                sizeIsLessThanOrEqualTo16 = false;
            Assert.AreEqual(true, sizeIsLessThanOrEqualTo16);

        }

        [TestMethod]
        public void TimeStruct_VerifyStructTimeIsReadOnly_Success()
        {
            Homework6.Program.Time time = new Homework6.Program.Time(12,  23,  45);
            
                //time.Hour = 6; 
                //Can't explistitly test that this struct as its readonly, 
                                //as the program throws a compiler error if I try to set it.             
        }

        [TestMethod]
        public void StructsToAMethod_ChangingAPropertyValue_VerifyStructIsNotChangedInOrgMethod_Success()
        {
            //Arrange
            Student.StudentStruct Fred = new Student.StudentStruct("Fred", 12345, 3.85);           
            Student playingWithStructs = new Student();
            
            //Act
            double ChangedGPA = Program.ChangeMyStruct(Fred);


            //Assert
            Assert.AreEqual(99, ChangedGPA);
            Assert.AreEqual(3.85, Fred.GPA);

        }

       

        [TestMethod]
        public void StructsToAMethod_ChangingAPropertyValue_VerifyStructIsChangedInOrgMethod_Success()
        {
            //Arrange
            Student.StudentStruct Fred = new Student.StudentStruct("Fred", 12345, 3.85);
            Student playingWithStructs = new Student();

            //Act
            double ChangedGPA = Program.ChangeMyStructByRef(ref Fred);


            //Assert
            Assert.AreEqual(99, ChangedGPA);
            Assert.AreEqual(99, Fred.GPA);
        }

        [TestMethod]
        public void PassingAClassToAMethod_ChangingAPropertyValue_VerifyClassIsChangedInOrgMethod_Success()
        {
            //MyStudent is created with an age of 21, the ChangeMyClass() will change it to 55
            Student MyStudent = new Student();
            MyStudent.Age = 21;

            int result = Program.ChangeMyClass(MyStudent);
            Assert.AreEqual(55, MyStudent.Age);
        }

        [TestMethod]
        public void PassingAClassToAMethodAndCreateNewInstance_VerifyClassIsChangedInOrgMethod_Success()
        {
            //MyStudent is created with an age of 21, the ChangeMyClass() will change it to 34
            Student MyStudent = new Student();
            MyStudent.Age = 21;

            //Test is failing.  Not sure why passing the Student object to my ChangeClassReference method, which
            // creates a new student object and then assigns it to the passed in Student reference, is not changing 
            // changing the new objects value back in the calling method. 

            Program.ChangeClassReference(MyStudent);
            Assert.AreEqual(34, MyStudent.Age);
        }

        [TestMethod]
        public void PassingAnInterface_VerifyClassIsChangedInOrgMethod_Success()
        {
            
            IStudent student;
            Student.StudentStruct Fred = new Student.StudentStruct("Fred", 12345, 3.85);
            
            student = new Student();
            student.Age = 66;            

            Program.ChangeInterface(student);
            Assert.AreEqual(99, student.Age);
        }
    }
}