using Microsoft.EntityFrameworkCore;
using Transaction.API.DataAcces;
using Transaction.API.DataAccess.Entities;

namespace Transaction.API.DataAccess
{
    public class BankAccountRepository : IGenericRepository<BankAccount>
    {
        private readonly AppDbContext _appDbContext;

        public BankAccountRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<BankAccount> Create(BankAccount bankAccount)
        {
            await _appDbContext.BankAccounts.AddAsync(bankAccount);
            await _appDbContext.SaveChangesAsync();
            return bankAccount;
        }

        public async Task<bool> Delete(int id)
        {
            var bankAccount = await _appDbContext.BankAccounts.FindAsync(id);
            if (bankAccount != null)
            {
                _appDbContext.BankAccounts.Remove(bankAccount);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<BankAccount> Get(int id)
        {
            return await _appDbContext.BankAccounts.FindAsync(id);
        }

        public async Task<IEnumerable<BankAccount>> GetAll()
        {
            return await _appDbContext.BankAccounts.ToListAsync();
        }

        public async Task<BankAccount> Update(int id, BankAccount bankAccount)
        {
            var updateBankAccount = _appDbContext.BankAccounts.Attach(bankAccount);    
            updateBankAccount.State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return bankAccount;
        }
    }
}
