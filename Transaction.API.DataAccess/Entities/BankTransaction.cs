using Transaction.API.DataAccess.Enums;

namespace Transaction.API.DataAccess.Entities;

public class BankTransaction
{
    public int Id { get; set; }
    public int BankAccountId { get; set; }
    public decimal Amount { get; set; }
    public TransactionType TransactionType { get; set; }
    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    public string Description { get; set; }
    public BankAccount BankAccount { get; set; }
}
