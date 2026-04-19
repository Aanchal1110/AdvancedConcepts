using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace HelloWorld.Data
{
    public class DataContextDapper
    {

        private string _connectionString;
        
        public DataContextDapper(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection")
        ?? throw new Exception("Connection string not found");
        }

        // private string _connectionString="Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true;";

        public IEnumerable<T> LoadData<T>(string sql)
        {
            IDbConnection dbConnection=new SqlConnection(_connectionString);

            return dbConnection.Query<T>(sql);
        }

        public T LoadDataSingle<T>(String sql)
        {
            IDbConnection dbConnection=new SqlConnection(_connectionString);
            return dbConnection.QuerySingle<T>(sql);
        }

        public bool ExecuteSql(string sql)
        {
            IDbConnection dbConnection=new SqlConnection(_connectionString);
            return (dbConnection.Execute(sql)>0);
        }

        public int ExecuteSqlWithRowCount(string sql, object parameters)
        {
            IDbConnection dbConnection=new SqlConnection(_connectionString);
            return dbConnection.Execute(sql, parameters);
        }


    }
}