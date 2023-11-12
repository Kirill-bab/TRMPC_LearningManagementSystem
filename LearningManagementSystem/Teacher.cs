namespace LearningManagementSystem
{
    public class Teacher 
    {
        public const string School_Name = "EduCenter";

        public int WorkingHours { get; set; }

        public int TeacherId { get; init; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CourseName;


        public string GetSubjectExamResult(double percentOfCorrectAnswers)
        {
            var passed = "ABCDE";
            return passed.Contains(SetEstimation(percentOfCorrectAnswers)) ? "passed" : "failed";
        }

        public int GetSubjectExamResult(string rate)
        {
            switch (rate)
            {
                case "A":
                    return 5;
                case "B":
                    return 5;
                case "C":
                    return 4;
                case "D":
                    return 3;
                case "E":
                    return 3;
                default:
                    return 2;
            }
        }

        private string SetEstimation(double percentOfCorrectAnswers)
        {
            switch (percentOfCorrectAnswers)
            {
                case >= 90:
                    return "A";
                case >= 82:
                    return "B";
                case >= 75:
                    return "C";
                case >= 67:
                    return "D";
                case >= 60:
                    return "E";
                default:
                    return "F";
            }
        }

        public override string ToString()
        {
           return $"{TeacherId}\n{FirstName}\n{LastName}\n{CourseName}\n{WorkingHours}";
        }
    }
}
