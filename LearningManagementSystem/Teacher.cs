namespace LearningManagementSystem
{
    internal class Teacher : Person
    {
        public const string SchoolName = "EduCenter";

        public int workingHours { get; set; }

        public Teacher(int id, string firstName, string lastName) : base(id, firstName, lastName)
        {
        }

        public string SetEstimation(double percentOfCorrectAnswers)
        {
            string estimate = "";

            switch (percentOfCorrectAnswers)
            {
                case >= 90:
                    estimate = "A - perfect";
                    break;
                case >= 82:
                    estimate = "B - very well";
                    break;
                case >= 75:
                    estimate = "C - good";
                    break;
                case >= 67:
                    estimate = "D - satisfactorily";
                    break;
                case >= 60:
                    estimate = "E - enough satisfactorily";
                    break;
                case >= 35:
                    estimate = "FX - not enough, with possibility to retake";
                    break;
                default:
                    estimate = "F - retake the course";
                    break;
            }

            return estimate;
        }
    }
}
