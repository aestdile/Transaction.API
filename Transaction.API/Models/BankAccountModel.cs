using System.ComponentModel.DataAnnotations;
using Transaction.API.Enums;

namespace Transaction.API.Models;

public class BankAccountModel
{
    public int Id { get; set; }

    [Required]
    public int CustomerId { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 5)]
    public string AccountNumber { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Balance can not be negative.")]
    public decimal Balance { get; set; }

    public DateTime OpenedDate { get; set; } = DateTime.UtcNow;

    [Required]
    public AccountType AccountType { get; set; }
}