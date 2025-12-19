namespace ModeloServices.Entities;

public class Transaction
{
    public int TransactionId { get; set; }

    public int ServiceId { get; set; }

    public int UserId { get; set; }

    public string Comment { get; set; } = null!;

    public DateOnly Date { get; set; }

    public decimal TotalAmount { get; set; }

    public User User { get; set; } = null!;
    public Service Service { get; set; } = null!;
}