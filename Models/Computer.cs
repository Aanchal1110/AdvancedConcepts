namespace HelloWorld.Models{

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
    
}}