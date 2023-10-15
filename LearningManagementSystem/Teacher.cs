namespace LearningManagementSystem
{
    internal class Teacher : Person
    {
        public const string School_Name = "EduCenter";

        public int Working_Hours { get; set; }

        public Teacher(int id, string firstName, string lastName, string courseName) : base(id, firstName, lastName, courseName)
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

        public void SetWorkingHours()
        {
            try
            {
                Console.WriteLine("Enter working hours: ");
                int workingHours = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("System error! Please try again later!");
            }
            finally
            {
                Console.WriteLine("Working hours have not been set.");
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
    }
}
