using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningManagementSystem
{
    internal class Course
    {
        public const int MAX_CAPACITY = 30;
        public string Name { get; }
        public required int Id { get; init; }
        private readonly List<int> _studentsIds = new();
        public IReadOnlyCollection<int> StudentsIds => _studentsIds.AsReadOnly();
        public int StudentsCount => _studentsIds.Count;

        [SetsRequiredMembers]
        public Course(int id, string name)
        {
            (Id, Name) = (id, name);
        }

        public void EnrollStudent(int studentId)
        {
            if (StudentsCount + 1 > MAX_CAPACITY)
            {
                Console.WriteLine($"Cannot enroll student {studentId} on {Name}: course is already full!");
            }
            else if (_studentsIds.Contains(studentId))
            {
                Console.WriteLine($"Student {studentId} is already enrolled on {Name}!");
            }
            else
            {
                _studentsIds.Add(studentId);
                Console.WriteLine($"Successfully enrolled student {studentId} on {Name}.");
            }
        }

        public void EnrollStudent(List<int> studentIds)
        {
            studentIds.ForEach(EnrollStudent);
        }
    }
}
