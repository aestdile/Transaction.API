using Microsoft.EntityFrameworkCore;
using Transaction.API.DataAcces;
using Transaction.API.DataAccess.Entities;
using Transaction.API.Models;
using Transaction.API.Services.Interfaces;

namespace Transaction.API.Services;

public class TransactionService : ITransactionService
{
    private readonly AppDbContext _context;

    public TransactionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BankTransaction>> GetAllAsync()
    {
        var transactions = await _context.Transactions
            .Include(t => t.BankAccount)
            .ToListAsync();

        if(transactions is not null )
             return transactions;

        return new List<BankTransaction>();
    }

    public async Task<BankTransaction?> GetByIdAsync(int id)
    {
        return await _context.Transactions
            .Include(t => t.BankAccount)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<BankTransaction> CreateAsync(TransactionModel model)
    {
        var transaction = new BankTransaction
        {
            BankAccountId = model.BankAccountId,
            Amount = model.Amount,
            TransactionType = (DataAccess.Enums.TransactionType)model.TransactionType,
            TransactionDate = model.TransactionDate,
            Description = model.Description
        };

        _context.Transactions.Add(transaction);

        var account = await _context.BankAccounts.FindAsync(model.BankAccountId);
        if (account != null)
        {
            if (model.TransactionType == Enums.TransactionType.Deposit)
                account.Balance += model.Amount;
            else if (model.TransactionType == Enums.TransactionType.Withdraw)
                account.Balance -= model.Amount;
        }

        await _context.SaveChangesAsync();
        return transaction;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var transaction = await _context.Transactions.FindAsync(id);
        if (transaction == null)
            return false;

        _context.Transactions.Remove(transaction);
        await _context.SaveChangesAsync();
        return true;
    }
}
