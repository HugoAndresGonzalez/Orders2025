namespace ModeloServices.Models;

public class ServiceVM
{
    public int ServiceId { get; set; }
    public int UserId { get; set; }
    public string name { get; set; } = null!;

    public string type { get; set; } = null!;
}