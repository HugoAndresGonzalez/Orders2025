namespace ModeloServices.Entities;

public class Service
{
    public int ServiceId { get; set; }
    public int UserId { get; set; }
    public string name { get; set; } = null!;

    public string type { get; set; } = null!;

    public User User { get; set; } = null!;
}