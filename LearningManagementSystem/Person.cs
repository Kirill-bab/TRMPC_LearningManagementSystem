using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningManagementSystem
{
    public abstract class Person
    {
        public int Id { get; init; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public readonly string Course;

        public Person(string firstName, string lastName, string courseName)
        {
            FirstName = firstName;
            LastName = lastName;
            Course = courseName;
        }
    }
}
