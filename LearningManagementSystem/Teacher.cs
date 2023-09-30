namespace LearningManagementSystem
{
    internal class Teacher : Person
    {
        public const string SchoolName = "EduCenter";

        public int workingHours { get; set; }

        public Teacher(int id, string firstName, string lastName) : base(id, firstName, lastName)
        {
        }

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
            string estimate = "";

            switch (percentOfCorrectAnswers)
            {
                case >= 90:
                    estimate = "A";
                    break;
                case >= 82:
                    estimate = "B";
                    break;
                case >= 75:
                    estimate = "C";
                    break;
                case >= 67:
                    estimate = "D";
                    break;
                case >= 60:
                    estimate = "E";
                    break;
                default:
                    estimate = "F";
                    break;
            }

            return estimate;
        }
    }
}
