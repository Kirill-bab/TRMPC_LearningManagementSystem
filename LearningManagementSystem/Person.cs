using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningManagementSystem
{
    abstract class Person
    {
        public required int Id { get; init; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public readonly string Course;

        public Person(int id, string firstName, string lastName, string courseName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Course = courseName;
        }
    }
}
