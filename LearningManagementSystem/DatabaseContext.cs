using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace LearningManagementSystem
{
    public class DatabaseContext
    {
        private readonly IConfiguration _configuration;

        public DatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection CreateTeacherConnection()
            => new SqlConnection(_configuration.GetConnectionString("Teacher"));

        public IDbConnection GreateMasterConnection()
            => new SqlConnection(_configuration.GetConnectionString("Master"));

        public IDbConnection CreateLMSConnection()
            => new SqlConnection(_configuration.GetConnectionString("LearningManagementSystem"));
    }
}
