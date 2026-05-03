using Newtonsoft.Json;

namespace HelloWorld.Models{

public class Computer
{
    // public string Motherboard { get; set; } = "";
    // default values could be set as above as well

    [JsonProperty("computer_id")]
    public int ComputerId{get;set;}

    [JsonProperty("motherboard")]
    public string Motherboard {get; set;}

    [JsonProperty("cpu_cores")]
    public int ?CPUCores {get; set;}

    [JsonProperty("has_wifi")]
    public bool HasWifi{get; set;}

    [JsonProperty("has_lte")]
    public bool HasLTE{get; set;}

    [JsonProperty("release_date")]
    public DateTime? ReleaseDate {get;set;}

    [JsonProperty("price")]
    public decimal Price{get;set;}
    [JsonProperty("video_card")]
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
    // created computer module
    
}}