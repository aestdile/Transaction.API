using System.ComponentModel.DataAnnotations;
using Transaction.API.Enums;

namespace Transaction.API.Models;

public class TransactionModel
{
    public int Id { get; set; }

    [Required]
    public int BankAccountId { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Enter the amount correctly.")]
    public decimal Amount { get; set; }

    [Required]
    public TransactionType TransactionType { get; set; }

    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

    public string Description { get; set; }
    public BankAccountModel BankAccount { get; set; }
}