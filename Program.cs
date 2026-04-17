
using HelloWorld.Models;

namespace HelloWorld{

    internal class Program
    {
        static void Main(string[] args)
        {
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
