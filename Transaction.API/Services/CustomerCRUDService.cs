using Transaction.API.DataAccess;
using Transaction.API.DataAccess.Entities;
using Transaction.API.Models;

namespace Transaction.API.Services;

public class CustomerCRUDService : IGenericCRUDService<CustomerModel>
{
    private readonly IGenericRepository<Customer> _customerRepository;
    private readonly IGenericRepository<BankAccount> _bankAccountRepository;

    public CustomerCRUDService(
        IGenericRepository<Customer> customerRepository, 
        IGenericRepository<BankAccount> bankAccountRepository)
    {
        _customerRepository = customerRepository;
        _bankAccountRepository = bankAccountRepository;
    }

    public async Task<CustomerModel> Create(CustomerModel customerModel)
    {
        var existingBankAccount = 
            await _bankAccountRepository.Get(customerModel.Id);

        var customer = new Customer
        {
            FirstName = customerModel.FirstName,
            LastName = customerModel.LastName,
            Age = customerModel.Age,
            Phone = customerModel.Phone,
            Email = customerModel.Email,
            Gender = (DataAccess.Enums.GenderType)customerModel.Gender,
        };

        if (existingBankAccount != null) // ???????????????????????????????????????
        {
            customer.CustomerId = existingBankAccount.CustomerId;
        }

        var createdCustomer = await _customerRepository.Create(customer);

        var result = new CustomerModel
        {
            Id = createdCustomer.Id,
            FirstName = createdCustomer.FirstName,
            LastName = createdCustomer.LastName,
            Age = createdCustomer.Age,
            Phone = createdCustomer.Phone,
            Email = createdCustomer.Email,
            Gender = (Enums.GenderType)createdCustomer.Gender,
        };
        return result;
    }

    public async Task<bool> Delete(int id)
    {
        return await _customerRepository.Delete(id);
    }

    public async Task<CustomerModel> Get(int id)
    {
        var customer = 
            await _customerRepository.Get(id);

        var customerModel = new CustomerModel
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Age = customer.Age,
            Phone = customer.Phone,
            Email = customer.Email,
            Gender = (Enums.GenderType)customer.Gender
        };
        return customerModel;
    }

    public async Task<IEnumerable<CustomerModel>> GetAll()
    {
        var result = new List<CustomerModel>();
        var customers = 
            await _customerRepository.GetAll();

        foreach ( var customer in customers)
        {
            var customerModell = new CustomerModel
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Age= customer.Age,
                Phone = customer.Phone,
                Email = customer.Email,
                Gender = (Enums.GenderType)customer.Gender
            };
            result.Add(customerModell);
        }
        return result;
    }

    public async Task<CustomerModel> Update(int id, CustomerModel customerModel)
    {
        var customer = new Customer
        {
            Id = customerModel.Id,
            FirstName = customerModel.FirstName,
            LastName = customerModel.LastName,
            Age = customerModel.Age,
            Phone = customerModel.Phone,
            Email = customerModel.Email,
            Gender = (DataAccess.Enums.GenderType)customerModel.Gender
        };

        var updatedCustomer =
            await _customerRepository.Update(id, customer);

        var result = new CustomerModel
        {
            Id = updatedCustomer.Id,
            FirstName = updatedCustomer.FirstName,
            LastName = updatedCustomer.LastName,
            Age = updatedCustomer.Age,
            Phone = updatedCustomer.Phone,
            Email = updatedCustomer.Email,
            Gender = (Enums.GenderType)updatedCustomer.Gender
        };
        return result;
    }
}