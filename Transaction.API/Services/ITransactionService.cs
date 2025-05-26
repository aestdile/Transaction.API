namespace Transaction.API.Services.Interfaces;

using Transaction.API.Models;
using Transaction.API.DataAccess.Entities;

public interface ITransactionService
{
    Task<IEnumerable<BankTransaction>> GetAllAsync();
    Task<BankTransaction?> GetByIdAsync(int id);
    Task<BankTransaction> CreateAsync(TransactionModel model);
    Task<bool> DeleteAsync(int id);
}
