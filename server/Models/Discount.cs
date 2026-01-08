namespace server.Models;

public class Discount
{
    public int Id {get; set;}
    public int GameListingId {get; set;}
    public decimal Amount {get; set;}
    public string Type {get; set;}
    public DateTime EndsAt {get; set;}
}