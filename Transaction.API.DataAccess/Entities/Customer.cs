using Transaction.API.DataAccess.Enums;

namespace Transaction.API.DataAccess.Entities;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public GenderType Gender { get; set; }
    public int CustomerId { get; set; } 
}
