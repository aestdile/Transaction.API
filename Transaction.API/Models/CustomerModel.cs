using System.ComponentModel.DataAnnotations;
using Transaction.API.Enums;

namespace Transaction.API.Models;

public class CustomerModel
{
    public int Id { get; set; }

    [Required]
    [StringLength(50), MinLength(2)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(50), MinLength(2)]
    public string LastName { get; set; }

    [Required]
    public int Age { get; set; }

    [Required]
    public string Phone { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public GenderType Gender { get; set; }
}
