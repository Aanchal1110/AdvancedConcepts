
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
            Motherboard="203678",
            HasWifi=true,
            HasLTE=false,
            ReleaseDate =DateTime.Now,
            Price=945.34m,
            VideoCard="RTX 2060"
        };
        // myComputer.HasWifi=false;
        // myComputer.Price=333.3m;
        // Console.WriteLine(myComputer.Motherboard);
        // Console.WriteLine(myComputer.HasWifi);
        // Console.WriteLine(myComputer.ReleasDate);
        // Console.WriteLine(myComputer.VideoCard);


        string sql =@"INSERT INTO TAppSchema.Computer (
        [MotherBoard],
       [CPUCoreS],
       [HasWifi],
       [HasLTE],
       [Price],
       [VideoCard],
       [ReleaseDate]
        ) VALUES(@MotherBoard,
    @CPUCoreS,
    @HasWifi,
    @HasLTE,
    @Price,
    @VideoCard,
    @ReleaseDate)";
        
        Console.WriteLine(sql);
        int result = dbConnection.Execute(sql, myComputer);
        Console.WriteLine(result);

        string sqlSelect=@"SELECT 
        Computer.MotherBoard,
       Computer.CPUCoreS,
       Computer.HasWifi,
       Computer.HasLTE,
       Computer.Price,
       Computer.VideoCard,
       Computer.ReleaseDate
        FROM TAppSchema.Computer";

        Console.WriteLine("'Motherboard','HasWifi','HasLTE','Releasedate','Price','Videocard'"

                );


        IEnumerable<Computer> computers=dbConnection.Query<Computer>(sqlSelect);

        foreach(Computer singleComputer in computers)
            {
                Console.WriteLine("'"+ singleComputer.Motherboard
                +"','"+singleComputer.HasWifi
                +"','"+singleComputer.HasLTE
                +"','"+singleComputer.ReleaseDate
                +"','"+singleComputer.Price
                +"','"+singleComputer.VideoCard
                );
            }
       
        }
       
    }


}
