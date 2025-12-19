namespace ModeloServices.Entities;

public class User
{
    public int UserId { get; set; }
    public string UserName { get; set; } = null!;

    public string UserEmail { get; set; } = null!;
    public string Password { get; set; } = null!;

    public ICollection<Service>? Services { get; set; }
    public ICollection<Transaction>? Transactions { get; set; }
}