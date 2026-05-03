
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
using HelloWorld.Models;
using HelloWorld.Data;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using AutoMapper;

namespace HelloWorld
{

    internal class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();

            DataContextDapper dapper = new DataContextDapper(config);

            DataContextEF entityFramework = new DataContextEF(config);



            DateTime rightNow = dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
            Console.WriteLine(rightNow);

            Computer myComputer = new Computer()
            {
                Motherboard = "203678",
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 945.34m,
                VideoCard = "RTX 2060"
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


            string sql = @"INSERT INTO TAppSchema.Computer (
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
            int result = dapper.ExecuteSqlWithRowCount(sql, myComputer);
            Console.WriteLine(result);

            string sqlSelect = @"SELECT 
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


            IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);

            // foreach(Computer singleComputer in computers)
            //     {
            //         Console.WriteLine("'"+ singleComputer.Motherboard
            //         +"','"+singleComputer.HasWifi
            //         +"','"+singleComputer.HasLTE
            //         +"','"+singleComputer.ReleaseDate
            //         +"','"+singleComputer.Price
            //         +"','"+singleComputer.VideoCard
            //         );
            //     }

            Console.WriteLine("'Motherboard','HasWifi','HasLTE','Releasedate','Price','Videocard'"

                    );

            IEnumerable<Computer> computersEf = entityFramework.Computer.ToList<Computer>();

            // foreach(Computer singleComputer in computersEf)
            //     {
            //         Console.WriteLine("'"+ singleComputer.Motherboard
            //         +"','"+singleComputer.HasWifi
            //         +"','"+singleComputer.HasLTE
            //         +"','"+singleComputer.ReleaseDate
            //         +"','"+singleComputer.Price
            //         +"','"+singleComputer.VideoCard
            //         );
            //     }

            //Reading from and writing to the file

            // File.WriteAllText("log.txt",sql);
            // using StreamWriter openFile=new("log.txt",append:true);

            // openFile.WriteLine("\n"+sql+"\n");

            // openFile.Close();
            // string fileText=File.ReadAllText("log.txt");
            // Console.WriteLine(fileText);

            string ComputerJson = File.ReadAllText("Computers.json");
            // Console.WriteLine(ComputerJson);

            // Deserialization using text.json below

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            IEnumerable<Computer>? computersSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(ComputerJson, options);

            if (computersSystem != null)
            {
                foreach (Computer computer in computersSystem)
                {
                    string sql1 = @"INSERT INTO TAppSchema.Computer (
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

                    dapper.ExecuteSqlWithRowCount(sql1, computer);
                }
            }


            // Deserialization using newtonsoft

            IEnumerable<Computer>? computersNewtonSoft = JsonConvert.DeserializeObject<IEnumerable<Computer>>(ComputerJson);

            // if (computersNewtonSoft != null)
            // {
            //     foreach (Computer computer in computersNewtonSoft)
            //     {
            //         Console.WriteLine(computer.Motherboard);
            //     }
            // }
            //serialization using NewtonSoft
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            string computerCopuNewtonSoft = JsonConvert.SerializeObject(computersNewtonSoft, settings);

            File.WriteAllText("computerCopyNewtonSoft.txt", computerCopuNewtonSoft);

            //serialization using system.text.json
            string computerCopySystem = System.Text.Json.JsonSerializer.Serialize(computersSystem, options);
            File.WriteAllText("computerCopySystem.txt", computerCopySystem);



            string ComputerJson2 = File.ReadAllText("ComputerSnake.json");

            var config1 = new AutoMapper.MapperConfiguration(cfg =>
     {
         cfg.CreateMap<ComputerSnake, Computer>()
             .ForMember(dest => dest.ComputerId, opt => opt.MapFrom(src => src.computer_id))
             .ForMember(dest => dest.CPUCores, opt => opt.MapFrom(src => src.cpu_cores))
             .ForMember(dest => dest.HasWifi, opt => opt.MapFrom(src => src.has_wifi))
             .ForMember(dest => dest.HasLTE, opt => opt.MapFrom(src => src.has_lte))
             .ForMember(dest => dest.Motherboard, opt => opt.MapFrom(src => src.motherboard))
             .ForMember(dest => dest.VideoCard, opt => opt.MapFrom(src => src.video_card))
             .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.release_date))
             .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.price));
     });
            IMapper mapper = config1.CreateMapper();

            IEnumerable<ComputerSnake>? computerSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<ComputerSnake>>(ComputerJson2,options);

            if (computerSystem != null)
            {

                IEnumerable<Computer> computerResult=mapper.Map<IEnumerable<Computer>>(computerSystem);

                foreach (Computer computer in computerResult)
                {
                   
                    Console.WriteLine(computer.Motherboard);
                }
            }









        }
        static string escapeSingleQuotes(string input)
        {
            string output = input.Replace("'", "''");
            return output;
        }


    }

}



