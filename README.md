# Transaction.API

**A RESTful Web API for Bank Account and Transaction Management**

This project is designed to manage bank accounts and their transactions. It supports user registration, login, account creation, viewing balances, and transferring funds securely using JWT authentication. Built with a layered architecture to ensure scalability and maintainability.

---

## 🔧 Technologies Used

- ASP.NET Core Web API  
- Entity Framework Core  
- MS SQL Server  
- XUnit (for unit testing)  
- JWT Authentication  
- Repository & Service Layer Architecture  

---

## 📁 Project Structure

Transaction.API/
│
├── Transaction.API/ # Main Web API - Controllers, Auth
├── Transaction.API.DataAccess/ # EF Core Context, Entities, Interfaces, Repositories
├── Transaction.API.Unit.Tests/ # Unit testing using XUnit
├── Transaction.API.sln # Visual Studio solution file
├── README.md # Project documentation
└── LICENSE.txt # MIT License
