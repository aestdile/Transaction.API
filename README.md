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

<pre><code>
  ``` 
  Transaction.API/ │ 
  ├── Transaction.API/ # Main Web API - Controllers, Auth 
  ├── Transaction.API.DataAccess/ # EF Core Context, Entities, Interfaces, Repositories 
  ├── Transaction.API.Unit.Tests/ # Unit testing using XUnit 
  ├── Transaction.API.sln # Visual Studio solution file 
  ├── README.md # Project documentation 
  └── LICENSE.txt # MIT License 
  ``` 
</code></pre>


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

## ✍️ Author
👤 Mukhtor Eshboyev\
🔗 GitHub: [@aestdile](https://github.com/aestdile)\
📌 "When you finish this project, upload it to GitHub and send me the repository link, I'll wait for it!"

## 📫 To Connect:
<div align="center">
  <a href="https://t.me/aestdile"><img src="https://img.shields.io/badge/Telegram-2CA5E0?style=for-the-badge&logo=telegram&logoColor=white" /></a>
  <a href="https://github.com/aestdile"><img src="https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white" /></a>
  <a href="https://leetcode.com/aestdile"><img src="https://img.shields.io/badge/LeetCode-FFA116?style=for-the-badge&logo=leetcode&logoColor=black" /></a>
  <a href="https://linkedin.com/in/aestdile"><img src="https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white" /></a>
  <a href="https://youtube.com/@aestdile"><img src="https://img.shields.io/badge/YouTube-FF0000?style=for-the-badge&logo=youtube&logoColor=white" /></a>
  <a href="https://instagram.com/aestdile"><img src="https://img.shields.io/badge/Instagram-E4405F?style=for-the-badge&logo=instagram&logoColor=white" /></a>
  <a href="https://facebook.com/aestdile"><img src="https://img.shields.io/badge/Facebook-1877F2?style=for-the-badge&logo=facebook&logoColor=white" /></a>
  <a href="mailto:aestdile@gmail.com"><img src="https://img.shields.io/badge/Gmail-D14836?style=for-the-badge&logo=gmail&logoColor=white" /></a>
  <a href="https://twitter.com/aestdile"><img src="https://img.shields.io/badge/Twitter-1DA1F2?style=for-the-badge&logo=twitter&logoColor=white" /></a>
  <a href="tel:+998772672774"><img src="https://img.shields.io/badge/Phone-25D366?style=for-the-badge&logo=whatsapp&logoColor=white" /></a>
</div>

