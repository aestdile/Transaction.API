using Microsoft.EntityFrameworkCore;
using Transaction.API.DataAcces;
using Transaction.API.DataAccess.Entities;

namespace Transaction.API.DataAccess
{
    public class CustomerRepository : IGenericRepository<Customer>
    {
        private readonly AppDbContext _appDbContext;

        public CustomerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Customer> Create(Customer customer)
        {
            await _appDbContext.Customers.AddAsync(customer);
            await _appDbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> Delete(int id)
        {
            var customer = await _appDbContext.Customers.FindAsync(id);
            if (customer != null)
            {
                _appDbContext.Customers.Remove(customer);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Customer> Get(int id)
        {
            return await _appDbContext.Customers.FindAsync(id);
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _appDbContext.Customers.ToListAsync();
        }

        public async Task<Customer> Update(int id, Customer customer)
        {
            var updateCustomer = _appDbContext.Customers.Attach(customer);
            updateCustomer.State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return customer;
        }
    }
}
