namespace Transaction.API.Services
{
    public interface IAccountNumberValidationService
    {
        bool IsValid(string bankAccountId);
    }
}
