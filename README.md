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


---

## ✅ Main Features

- [x] User Registration  
- [x] User Login with JWT Token  
- [x] Create Bank Accounts  
- [x] View Account List  
- [x] Transfer Funds Between Accounts  
- [x] Unit Testing with XUnit  

---

## 🔐 Authentication

The API uses **JWT (JSON Web Token)** based authentication. After logging in, users receive a token that must be included in the header of subsequent API requests.

---

## 🧪 Unit Testing

Unit tests are written using **XUnit** and located in the `Transaction.API.Unit.Tests` folder.

---

## 🗃️ Database

- The project uses **Entity Framework Core**.
- SQL Server is used as the database.
- Main entities:  
  - `Customer`  
  - `BankAccount`  
  - `BankTransaction`  

---

## 🚀 Getting Started

### 1. Clone the repository:

```bash
git clone https://github.com/aestdile/Transaction.API.git
```
##📄 License
This project is licensed under the MIT License.
You are free to use, modify, and distribute this project.


## Let me know if you want to add:
- API endpoint documentation
- Postman collection
- Docker support instructions

I'd be happy to help!

