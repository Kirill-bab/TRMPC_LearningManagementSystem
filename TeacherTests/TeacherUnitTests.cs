using LearningManagementSystem;

namespace TeacherTests
{
    [TestFixture]
    public class Tests
    {
        Teacher teacher;

        [SetUp]
        public void Setup()
        {
            teacher = new Teacher();
        }

        [TestCase(90)]
        [TestCase(82)]
        [TestCase(75)]
        [TestCase(67)]
        [TestCase(60)]
        public void TestPassedSubjectExamResultRate(int rate)
        {
            var estimation = teacher.GetSubjectExamResult(rate);
            Assert.AreEqual(estimation, "passed");
        }

        [Test]
        public void TestFiledSubjectExamResultRate()
        {
            var estimation = teacher.GetSubjectExamResult(59.9);
            Assert.AreEqual(estimation, "failed");
        }

        [TestCase("A", 5)]
        [TestCase("B", 5)]
        [TestCase("C", 4)]
        [TestCase("D", 3)]
        [TestCase("E", 3)]
        [TestCase("F", 2)]
        public void TestStringSubjectExamResult(string rate, int result)
        {
            var estimation = teacher.GetSubjectExamResult(rate);
            Assert.AreEqual(estimation, result);
        }
    }
}