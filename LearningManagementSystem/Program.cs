using Dapper;
using LearningManagementSystem;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

internal class Program
{
    private static void Main(string[] args)
    {
        Teacher teacherOne = new Teacher("Anton", "Grets", "C#");
        teacherOne.Working_Hours = 20;

        Teacher teacherSecond = new Teacher("Oleh", "Leros", "Java");
        teacherSecond.Working_Hours = 30;

        Teacher teacherThree = new Teacher("Olena", "Ilnyk", "QA");
        teacherThree.Working_Hours = 40;

        var builder = new ConfigurationBuilder();
        builder.SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        var connectionStr = builder.Build().GetConnectionString("Teacher");
        //using (IDbConnection connection = new SqlConnection(connectionStr))
        //{
        //    DynamicParameters firstTeacherParams = new DynamicParameters();
        //    firstTeacherParams.Add("TeacherId", 2);
        //    firstTeacherParams.Add("FirstName", teacherOne.FirstName);
        //    firstTeacherParams.Add("LastName", teacherOne.LastName);
        //    firstTeacherParams.Add("CourseName", teacherOne.Course);
        //    firstTeacherParams.Add("WorkingHours", teacherOne.Working_Hours);

        //    connection.Query<Teacher>("AddTeacher", param: firstTeacherParams, commandType: CommandType.StoredProcedure);

        //    DynamicParameters secTeacherParams = new DynamicParameters();
        //    secTeacherParams.Add("TeacherId", 3);
        //    secTeacherParams.Add("FirstName", teacherSecond.FirstName);
        //    secTeacherParams.Add("LastName", teacherSecond.LastName);
        //    secTeacherParams.Add("CourseName", teacherSecond.Course);
        //    secTeacherParams.Add("WorkingHours", teacherSecond.Working_Hours);

        //    connection.Query<Teacher>("AddTeacher", param: secTeacherParams, commandType: CommandType.StoredProcedure);
        //}

        //using (IDbConnection connection = new SqlConnection(connectionStr))
        //{
        //    DynamicParameters searchParams = new DynamicParameters();
        //    searchParams.Add("TeacherId", 2);

        //    var teacher = connection.Query<Teacher>("FindTeacher", param: searchParams, commandType: CommandType.StoredProcedure);
        //}

        //using (IDbConnection connection = new SqlConnection(connectionStr))
        //{
        //    DynamicParameters updateParams = new DynamicParameters();
        //    updateParams.Add("TeacherId", 2);
        //    updateParams.Add("FirstName", teacherSecond.FirstName);
        //    updateParams.Add("LastName", teacherSecond.LastName);

        //    connection.Query<Teacher>("UpdateTeacherData", param: updateParams, commandType: CommandType.StoredProcedure);
        //}

        using (IDbConnection connection = new SqlConnection(connectionStr))
        {
            DynamicParameters deleteFirstTeacher = new DynamicParameters();
            deleteFirstTeacher.Add("TeacherId", 2);

            connection.Query<Teacher>("DeleteTeacher", param: deleteFirstTeacher, commandType: CommandType.StoredProcedure);

            DynamicParameters deleteSecTecher = new DynamicParameters();
            deleteSecTecher.Add("TeacherId", 3);

            connection.Query<Teacher>("DeleteTeacher", param: deleteSecTecher, commandType: CommandType.StoredProcedure);
        }
    }
}