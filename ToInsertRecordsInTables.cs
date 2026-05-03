using HelloWorld.Data;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace HelloWorld
{

    internal class ToInsertRecordsInTables
    {
        static void Main(string[] args)
        {
            string userJson = File.ReadAllText(@"C:\Users\aanch\Downloads\AdvancedConcept\AdvancedConcepts\DotNetAPICourse\SQLSeed\Users.json");

            IConfiguration config = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();
            DataContextDapper dapper = new DataContextDapper(config);

            IEnumerable<User>? users = JsonConvert.DeserializeObject<IEnumerable<User>>(userJson);

        //     if (users != null)
        //     {
        //         foreach (var user in users)
        //         {
        //             string sql = @"INSERT INTO TAppSchema.Users
        // (FirstName, LastName, Email, Gender, Active)
        // VALUES (@FirstName, @LastName, @Email, @Gender, @Active)";

        //             dapper.ExecuteSqlWithRowCount(sql, user);
        //         }
        //     }

            string salaryJson=File.ReadAllText(@"c:\Users\aanch\downloads\advancedconcept\advancedconcepts\dotnetapicourse\sqlseed\usersalary.json");
            IEnumerable<UserSalary>?userSalaries=JsonConvert.DeserializeObject<IEnumerable<UserSalary>>(salaryJson);

            // if (userSalaries != null)
            // {
            //     foreach(var userSalary in userSalaries)
            //     {
            //         string sql=@"INSERT INTO TAppSchema.UserSalary(UserId,Salary) Values(@UserId,@Salary)";
            //         dapper.ExecuteSqlWithRowCount(sql, userSalary);
            //     }
            // }


            string userJobInfoJson=File.ReadAllText(@"c:\Users\aanch\downloads\advancedconcept\advancedconcepts\dotnetapicourse\sqlseed\userjobinfo.json");
            IEnumerable<UserJobInfo>? userJobInfos=JsonConvert.DeserializeObject<IEnumerable<UserJobInfo>>(userJobInfoJson);

            // if(userJobInfos != null)
            // {
            //     foreach(var userJobInfo in userJobInfos)
            //     {
            //         string sql=@"INSERT INTO TAppSchema.UserJobInfo(UserId, JobTitle) Values(@UserId, @JobTitle)";
            //         dapper.ExecuteSqlWithRowCount(sql, userJobInfo);
            //     }
            // }

            //forgot to insert department data into the table, so I am inserting it now
            if(userJobInfos != null)
            {
                
                    string sql=@"Update TAppSchema.UserJobInfo set Department=@Department where UserId=@UserId";
                    foreach(var userJobInfo in userJobInfos)
                    {
                        dapper.ExecuteSqlWithRowCount(sql, userJobInfo);
                    }
                
            }
        }
    }
}