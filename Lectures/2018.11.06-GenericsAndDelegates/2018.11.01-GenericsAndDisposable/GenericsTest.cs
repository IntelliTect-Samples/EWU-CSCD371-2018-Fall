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

        [TestMethod]
        public void NullableValueType()
        {
            int? number1 = null;
            Nullable<int> number2 = null;
        }


        struct Pair<TFirst, TComparer>
            where TComparer:IComparable<TComparer>
        {
            TFirst First { get; set; }
            TComparer Secton { get; set; }
        }

        class MyComparer
        {
            (T, V) IsGreater<T,V>(T left, V right)
                where T:class,IComparable<T>
                where V : class, IComparable<T>
            {
                if(left is null && right is null)
                {
                    return (left,right);
                }

                return (left, right);
            }
        }

        public interface IMyCollection<T>
        {
            //T GetItem(int index);
            bool SetItem(T item, int index);
        }
        class MyCollection<T> : IMyCollection<T>
        {
            public T GetItem(int index)
            {
                throw new NotImplementedException();
            }
            public bool SetItem(T item, int index)
            {
                return true;
            }
        }

        [TestMethod]
        public void MyTestMethod()
        {
            IMyCollection<Person> items = new MyCollection<Person>();
            //Person person = items.GetItem(42);

            items.SetItem(new Employee("Inigo"), 42);
        }


        struct MyNullable<T>
            where T: struct
        {

        }


        public void TestFactory()
        {
            IFactory<Guid> guidFactory = new GuidFactory();

            Guid guid = guidFactory.Create();

            //IFactory<Employee> employeeFactory = new Factory<Employee>();
            //Employee employee = employeeFactory.Create();

            // guidFactory = new Factory<Guid>();
        }
    }

    class Employee : Person
    {
        public Employee(string name)
        {
            
        }
    }

    class Factory<T> : IFactory<T>
         where T: class, new()
    {
        public T Create()
        {
            T t = new T();
            return t;
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