namespace LearningManagementSystem
{
    internal static class CourseSchedule
    {
        
        private static Dictionary<string, string> subjects = new Dictionary<string, string>()
        {
            { "C#","Monday; Thursday"},
            { "Java", "Tuesday; Friday" },
            { "Linux Administration", "Wednesday; Friday" },
            { "JavaScript", "Tuesday; Thursday" },
            { "QA", "Monday; Friday" }
        };

        public static string GetSchedule(this string subjectName)
        {
            return subjects.FirstOrDefault(s => s.Key == subjectName).Value;
        }
    }
}
