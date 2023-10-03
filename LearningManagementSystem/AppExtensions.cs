using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningManagementSystem
{
    internal static class AppExtensions
    {
        public static bool HasStudent(this Course course, int studentId)
        {
            return course is not null && course.StudentsIds.Contains(studentId);
        }
    }
}
