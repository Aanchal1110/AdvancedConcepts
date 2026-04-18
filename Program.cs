
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using HelloWorld.Models;

namespace HelloWorld{

    internal class Program
    {
        static void Main(string[] args)
        {
            string ConString="Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true;";

            IDbConnection dbConnection=new SqlConnection(ConString);

            string sqlCommand="SELECT GETDATE()";

            DateTime rightNow=dbConnection.QuerySingle<DateTime>(sqlCommand);
            Console.WriteLine(rightNow);

             Computer myComputer=new Computer()
        {
            Motherboard="2035",
            HasWifi=true,
            HasLTE=false,
            ReleasDate=DateTime.Now,
            Price=945.34m,
            VideoCard="RTX 2060"
        };
        myComputer.HasWifi=false;
        myComputer.Price=333.3m;
        Console.WriteLine(myComputer.Motherboard);
        Console.WriteLine(myComputer.HasWifi);
        Console.WriteLine(myComputer.ReleasDate);
        Console.WriteLine(myComputer.VideoCard);
        }
       
    }


}
