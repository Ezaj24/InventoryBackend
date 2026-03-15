# InventoryCore API

A production-style ASP.NET Core Web API for managing products and categories with secure authentication, role-based authorization, and scalable architecture.

## 🚀 Features

- JWT Authentication & Role-Based Authorization
- Secure password hashing
- Layered architecture (Controller → Service → Data)
- DTO pattern for data protection
- Global exception handling middleware
- Pagination, filtering & search
- Entity Framework Core with PostgreSQL
- Database seeding
- Docker container support

## 🛠 Tech Stack

- ASP.NET Core Web API (.NET 8)
- Entity Framework Core
- PostgreSQL
- JWT Authentication
- Docker
- RESTful API Design

## 🏗 Architecture

The API follows clean layered architecture:

Controller → Service Layer → DbContext → Database

This ensures separation of concerns, maintainability, and scalability.

## 🔐 Authentication & Authorization

- JWT-based authentication
- Role-based access control
- Admin-only endpoints for protected operations

## 📦 Key Modules

### Auth
- User registration & login
- Secure password hashing
- JWT token generation

### Categories
- Create & manage product categories

### Products
- CRUD operations
- Pagination & filtering
- Search functionality

## ▶️ Running the Project

### 1. Clone repository
``bash
git clone <your-repo-url>

2. Configure database

Update connection string in:

appsettings.Development.json

3. Apply migrations
dotnet ef database update

4. Run application
dotnet run

Swagger will open at:

http://localhost:xxxx/swagger

🐳 Docker Support

The project includes Docker configuration for containerized deployment.

📈 Future Improvements

Integration testing

Caching for performance

Cloud deployment (Azure)

CI/CD pipeline setup

👨‍💻 Author

Ezaj Shaikh.

-----
