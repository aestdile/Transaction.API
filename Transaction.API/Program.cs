using Microsoft.EntityFrameworkCore;
using Transaction.API.DataAcces;
using Transaction.API.DataAccess;
using Transaction.API.DataAccess.Entities;
using Transaction.API.Models;
using Transaction.API.Services;
using Transaction.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextPool<AppDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("TransactionDb")));

builder.Services.AddScoped<IGenericCRUDService<BankAccountModel>, BankAccounCRUDService>();
builder.Services.AddScoped<IGenericCRUDService<CustomerModel>, CustomerCRUDService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IGenericRepository<BankAccount>, BankAccountRepository>();
builder.Services.AddScoped<IGenericRepository<Customer>, CustomerRepository>();
builder.Services.AddScoped<IAccountNumberValidationService, AccountNumberValidationService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
