using System;
using System.Collections.Generic;
using System.Text;

namespace Homework6
{
    public class Student : IStudent
    {
        public int Age { get; set; } 

        public struct StudentStruct 
        {
            public string Name { get; set; }
            public int ID { get; set; }
            public double GPA { get; set; }

            public StudentStruct(string name, int id, double gpa)
            {
                Name = name;
                ID = id;
                GPA = gpa;
            }
        }       
    }

   

}
