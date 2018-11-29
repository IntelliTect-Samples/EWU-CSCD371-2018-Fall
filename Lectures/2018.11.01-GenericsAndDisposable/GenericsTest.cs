using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class GenericsTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            NonNullable<string> myNonNullable = new NonNullable<string>();
            Assert.IsNotNull(myNonNullable.Value);
        }

        public void TestFactory()
        {
            IFactory<Guid> guidFactory = new GuidFactory();

            Guid guid = guidFactory.Create();

            IFactory<Employee> employeeFactory = new Factory<Employee>();
            Employee employee = employeeFactory.Create();
        }
    }

    class Employee
    {
        Employee(string name)
        {
            
        }
    }

    class Factory<T> : IFactory<T>
         where T: new()
    {
        public T Create()
        {
            return new T();
        }
    }

    class StringBuilderFactory : IFactory<StringBuilder>
    {
        public StringBuilder Create()
        {
            return new StringBuilder();
        }
    }
    class GuidFactory : IFactory<Guid>
    {
        public Guid Create()
        {
            return Guid.NewGuid();
        }
    }

    interface IFactory<T>
    {
        T Create();
    }

    class NonNullable<T>
    {
        // NonNullable()
        public T Value { get; internal set; }
    }
}