using System.Runtime.CompilerServices;

namespace server.Models;

public class Game
{
    public int Id {get; set;}
    public string Title {get; set;} = string.Empty;
    public string Platform {get; set;} = string.Empty;
    public string Region {get; set;} = string.Empty;
    public string Price {get; set;} = string.Empty;
    public int CashbackPercent { get; set;} 
    public string ImgUrl {get;set;} = string.Empty;
    public int Likes {get; set;}

}