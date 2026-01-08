namespace server.Models;

public class GameListing
{
    public int Id {get; set;}
    public int GameId {get; set;}
    public string Platform {get; set;} = string.Empty;
    public string Region {get; set;} = string.Empty;
    public decimal Price {get; set;}
    public int CashbackPercent { get; set;} 
    public string ImgUrl {get;set;} = string.Empty;
    public int Likes {get; set;}

}