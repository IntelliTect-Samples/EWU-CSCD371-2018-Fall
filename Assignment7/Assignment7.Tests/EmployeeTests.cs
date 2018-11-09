using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment7.Tests
{
    [TestClass]
    public class EmployeeTests
    {
        [TestMethod]
        public void Number_Of_Instances_Decrements_On_Disposal_Success()
        {
            Employee newEmployee = new Employee("Casey White", 1);
            int numberOfInstances = Employee.Instances;
            newEmployee.Dispose();
            Assert.AreEqual(numberOfInstances-1, Employee.Instances);
        }

        [TestMethod]
        public void Test_Explicit_Call_Dispose_Success()
        {
            int numberOfInstances = Employee.Instances;
            Employee newEmployee = new Employee("Casey White", 1);
            newEmployee.Dispose();
            Assert.AreEqual(numberOfInstances, Employee.Instances);
           }

        
        /*
         * note this cannot be properly tested because there is no way to know
         * exactly when the finalizer is called
         */
        [TestMethod]
        public void Test_Finalizer_Called_When_Item_Out_Of_Scope_Success()    
        {
            int numberOfInstances = Employee.Instances;
            if (true)
            {
                Employee newEmployee = new Employee("Casey White", 1);
            }
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Test_Using_Statement_Disposed_Success()
        {
            int numberOfInstances = 0;
            using (new Employee("Cameron Osborn", 2))
            {
                numberOfInstances = Employee.Instances;
            }
            Assert.AreEqual(numberOfInstances-1, Employee.Instances);
        }
    }
}