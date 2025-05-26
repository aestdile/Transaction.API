using Transaction.API.DataAccess;
using Transaction.API.DataAccess.Entities;
using Transaction.API.Models;

namespace Transaction.API.Services;

public class BankAccounCRUDService : IGenericCRUDService<BankAccountModel>
{
    private readonly IGenericRepository<BankAccount> _bankAccountRepository;
    private readonly IAccountNumberValidationService _accountNumberValidationService;

    public BankAccounCRUDService(
        IGenericRepository<BankAccount> bankAccountRepository, 
        IAccountNumberValidationService accountNumberValidationService)
    {
        _bankAccountRepository = bankAccountRepository;
        _accountNumberValidationService = accountNumberValidationService;
    }

    public async Task<BankAccountModel> Create(BankAccountModel bankAccountModel)
    {
        if (!string.IsNullOrWhiteSpace(bankAccountModel.AccountNumber)
            && !_accountNumberValidationService.IsValid(bankAccountModel.AccountNumber))
        {
            throw new Exception("Invalid Account Number!");
        }

        var bankAccount = new BankAccount
        {
            CustomerId = bankAccountModel.CustomerId,
            AccountNumber = bankAccountModel.AccountNumber,
            Balance = bankAccountModel.Balance,
            OpenedDate = bankAccountModel.OpenedDate,
            AccountType = (DataAccess.Enums.AccountType)bankAccountModel.AccountType,
        };

        var createdBankAccount = await _bankAccountRepository.Create(bankAccount);
        var result = new BankAccountModel
        {
            Id = createdBankAccount.Id,
            CustomerId = createdBankAccount.CustomerId,
            AccountNumber = createdBankAccount.AccountNumber,
            Balance = createdBankAccount.Balance,
            OpenedDate = createdBankAccount.OpenedDate,
            AccountType = (Enums.AccountType)createdBankAccount.AccountType
        };
        return result;
    }

    public async Task<bool> Delete(int id)
    {
        return await _bankAccountRepository.Delete(id);
    }

    public async Task<BankAccountModel> Get(int id)
    {
        var bankAccount = await _bankAccountRepository.Get(id);
        var bankAccountModel = new BankAccountModel
        {
            Id = bankAccount.Id,
            CustomerId = bankAccount.CustomerId,
            AccountNumber = bankAccount.AccountNumber,
            Balance = bankAccount.Balance,
            OpenedDate = bankAccount.OpenedDate,
            AccountType = (Enums.AccountType)bankAccount.AccountType
        };
        return bankAccountModel;
    }

    public async Task<IEnumerable<BankAccountModel>> GetAll()
    {
        var result = new List<BankAccountModel>();
        var bankAccounts = await _bankAccountRepository.GetAll();
        foreach ( var bankAccount in bankAccounts )
        {
            var bankAccountModel = new BankAccountModel
            {
                Id = bankAccount.Id,
                CustomerId = bankAccount.CustomerId,
                AccountNumber = bankAccount.AccountNumber,
                Balance = bankAccount.Balance,
                OpenedDate = bankAccount.OpenedDate,
                AccountType = (Enums.AccountType)bankAccount.AccountType
            };
            result.Add(bankAccountModel);
        }
        return result;
    }

    public async Task<BankAccountModel> Update(int id, BankAccountModel bankAccountModel)
    {
        var bankAccount = new BankAccount
        {
            Id = bankAccountModel.Id,
            CustomerId = bankAccountModel.CustomerId,
            AccountNumber = bankAccountModel.AccountNumber,
            Balance = bankAccountModel.Balance,
            OpenedDate = bankAccountModel.OpenedDate,
            AccountType = (DataAccess.Enums.AccountType)bankAccountModel.AccountType
        };

        var updateBankAccount = await _bankAccountRepository.Update(id, bankAccount);
        var result = new BankAccountModel
        {
            Id = bankAccount.Id,
            CustomerId = bankAccount.CustomerId,
            AccountNumber = bankAccount.AccountNumber,
            Balance = bankAccount.Balance,
            OpenedDate = bankAccount.OpenedDate,
            AccountType = (Enums.AccountType)bankAccount.AccountType
        };
        return result;
    }
}