using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace LearningManagementSystem
{
    public class Database
    {
        private readonly DatabaseContext _context;

        public Database(DatabaseContext context)
        {
            _context = context;
        }

        public void CreateDatabase(string dataBase)
        {
            var query = "SELECT * FROM sys.databases WHERE name = @name";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("name", dataBase);

            using (var connection =  _context.GreateMasterConnection())
            {
                var records = connection.Query(query, parameters);

                if (!records.Any())
                {
                    connection.Execute($"CREATE DATABASE {dataBase}");
                }
            }
       }

        public void CreateTeacher(Teacher teacher)
        {
            using (var connection = _context.CreateLMSConnection())
            {
                DynamicParameters firstTeacherParams = new DynamicParameters();
                firstTeacherParams.Add("TeacherId", teacher.TeacherId);
                firstTeacherParams.Add("FirstName", teacher.FirstName);
                firstTeacherParams.Add("LastName", teacher.LastName);
                firstTeacherParams.Add("CourseName", teacher.CourseName);
                firstTeacherParams.Add("WorkingHours", teacher.WorkingHours);

                connection.Query<Teacher>("AddTeacher", param: firstTeacherParams, commandType: CommandType.StoredProcedure);
            }
        }

        public Teacher SelectTeacher(int teacherId)
        {
            using (var connection = _context.CreateLMSConnection())
            {
                DynamicParameters searchParams = new DynamicParameters();
                searchParams.Add("TeacherId", teacherId);

                return connection.Query<Teacher>("FindTeacher", param: searchParams, commandType: CommandType.StoredProcedure)
                                 .FirstOrDefault();

            }
        }

        public void UpdateTeacher(Teacher teacher, Teacher newTeacherData)
        {
            using (var connection = _context.CreateLMSConnection())
            {
                DynamicParameters updateParams = new DynamicParameters();
                updateParams.Add("TeacherId", teacher.TeacherId);
                updateParams.Add("FirstName", newTeacherData.FirstName);
                updateParams.Add("LastName", newTeacherData.LastName);

                connection.Query<Teacher>("UpdateTeacherData", param: updateParams, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteTeacher(int teacherId)
        {
            using (var connection = _context.CreateLMSConnection())
            {
                DynamicParameters deleteFirstTeacher = new DynamicParameters();
                deleteFirstTeacher.Add("TeacherId", teacherId);

                connection.Query<Teacher>("DeleteTeacher", param: deleteFirstTeacher, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
