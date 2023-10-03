using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningManagementSystem
{
    internal record CourseDto(int Id, string Name, List<int> StudentIds);
}
