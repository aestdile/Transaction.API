using Transaction.API.DataAccess.Enums;

namespace Transaction.API.DataAccess.Entities;

public class BankAccount
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string AccountNumber { get; set; }
    public decimal Balance { get; set; }
    public DateTime OpenedDate { get; set; } = DateTime.UtcNow;
    public AccountType AccountType { get; set; }
}
