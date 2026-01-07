using System.Runtime.CompilerServices;

namespace server.Models;

public class Game
{
    public int Id {get; set;}
    public string Title {get; set;}
    public string Platform {get; set;}
    public string Region {get; set;}
    public string Price {get; set;}
    public int CashbackPercent { get; set;}
    public string ImgUrl {get;set;}
    public int Likes {get; set;}

}