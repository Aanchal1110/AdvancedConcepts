public class Computer
{
    // public string Motherboard { get; set; } = "";
    // default values could be set as above as well


    public string Motherboard {get; set;}
    public int CPUCores {get; set;}

    public bool HasWifi{get; set;}

    public bool HasLTE{get; set;}
    public DateTime ReleasDate{get;set;}

    public decimal Price{get;set;}
    public string VideoCard{get;set;}

    public Computer()
    {
        if (VideoCard == null)
        {
            VideoCard="";
        }
        if (Motherboard == null)
        {
            Motherboard="";
        }
    }
    
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
