
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using HelloWorld.Models;
using HelloWorld.Data;
using Microsoft.Extensions.Configuration;

namespace HelloWorld{

    internal class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config=new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();

            DataContextDapper dapper=new DataContextDapper(config);

            DataContextEF entityFramework=new DataContextEF(config);

            

            DateTime rightNow=dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
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

    //Inserting using entityframework is done without using the sql query
    entityFramework.Add(myComputer);
    entityFramework.SaveChanges();

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
        
        // Console.WriteLine(sql);
        int result = dapper.ExecuteSqlWithRowCount(sql,myComputer);
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


        IEnumerable<Computer> computers=dapper.LoadData<Computer>(sqlSelect);

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

        Console.WriteLine("'Motherboard','HasWifi','HasLTE','Releasedate','Price','Videocard'"

                );

        IEnumerable<Computer> computersEf=entityFramework.Computer.ToList<Computer>();

        foreach(Computer singleComputer in computersEf)
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
