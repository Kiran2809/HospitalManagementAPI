# Hospital Management API

A RESTful **Hospital Management System API** built using **ASP.NET Core Web API**.

This project provides APIs for managing hospital-related information such as doctors, patients, appointments, and administrative operations. The application follows a layered architecture using Controllers, Services, Repositories, DTOs, Entity Framework Core, JWT authentication, middleware, and AutoMapper.

## 🚀 Features

* Doctor management
* Patient management
* Appointment management
* Admin operations
* JWT-based authentication and authorization
* Role-based access control
* Swagger API documentation
* Entity Framework Core
* Database migrations
* Repository pattern
* Service layer
* DTOs for API requests and responses
* AutoMapper for object mapping
* Global exception handling middleware
* Custom exception handling
* RESTful API architecture

## 🛠️ Technologies Used

* C#
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* JWT Authentication
* AutoMapper
* Swagger / OpenAPI
* Git
* GitHub
* Visual Studio

## 📁 Project Structure

```text
HospitalManagementAPI
│
├── Controllers
│   └── API Controllers
│
├── Data
│   └── Database Context and data-related classes
│
├── DTOs
│   └── Data Transfer Objects
│
├── Exceptions
│   └── Custom exception classes
│
├── MappingProfiles
│   └── AutoMapper configuration
│
├── Middleware
│   └── Exception handling middleware
│
├── Migrations
│   └── Entity Framework Core database migrations
│
├── Models
│   └── Application entities
│
├── Repositories
│   └── Repository implementations and interfaces
│
├── Services
│   └── Business logic
│
├── Program.cs
│   └── Application configuration and dependency injection
│
├── appsettings.json
│   └── Application configuration
│
└── HospitalManagementAPI.http
    └── HTTP request examples
```

## 🏗️ Architecture

The project follows a layered architecture:

```text
Client
   │
   ▼
Controllers
   │
   ▼
Services
   │
   ▼
Repositories
   │
   ▼
Entity Framework Core
   │
   ▼
SQL Server
```

### Controllers

Controllers receive HTTP requests from clients and return appropriate HTTP responses.

### Services

The Services layer contains the application's business logic.

### Repositories

Repositories handle database-related operations and provide an abstraction between the Services layer and Entity Framework Core.

### DTOs

DTOs are used to transfer data between the client and the API without directly exposing database entities.

### Middleware

Middleware is used for centralized exception handling and consistent API error responses.

### MappingProfiles

AutoMapper profiles are used to map between entities and DTOs.

## 🔐 Authentication & Authorization

The API uses **JWT (JSON Web Token)** authentication.

Users must authenticate before accessing protected endpoints.

Example authentication flow:

```text
User
  │
  │ Login
  ▼
Authentication API
  │
  │ JWT Token
  ▼
Client
  │
  │ Authorization: Bearer <token>
  ▼
Protected API Endpoint
```

Different roles can be used to control access to protected operations, such as administrative operations.

## 📚 Swagger

Swagger/OpenAPI is integrated into the project to test and explore the API endpoints.

After running the application, open:

```text
https://localhost:7105/swagger
```

The exact port depends on the application's local configuration.

Swagger allows you to:

* View API endpoints
* Send GET requests
* Send POST requests
* Send PUT requests
* Send DELETE requests
* Test authentication
* Test request and response models

## ⚙️ Prerequisites

Before running the project, install:

* .NET SDK
* SQL Server
* Visual Studio or Visual Studio Code
* Git

## ▶️ How to Run the Project

### 1. Clone the repository

```bash
git clone https://github.com/Kiran2809/HospitalManagementAPI.git
```

### 2. Open the project

Open the solution/project in Visual Studio.

### 3. Configure the database

Update the database connection string in:

```text
appsettings.json
```

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "YOUR_CONNECTION_STRING"
  }
}
```

Do not commit passwords or other sensitive credentials to GitHub.

### 4. Apply database migrations

Run:

```bash
dotnet ef database update
```

If Entity Framework CLI is not installed, install it using:

```bash
dotnet tool install --global dotnet-ef
```

### 5. Run the application

Using Visual Studio:

```text
Press F5
```

Or using the terminal:

```bash
dotnet run
```

### 6. Open Swagger

After the application starts, open the Swagger URL shown in the application output.

Example:

```text
https://localhost:7105/swagger
```

## 🔄 API Request Flow

A typical request follows this flow:

```text
HTTP Request
     │
     ▼
Controller
     │
     ▼
DTO
     │
     ▼
Service
     │
     ▼
Repository
     │
     ▼
Entity Framework Core
     │
     ▼
SQL Server
     │
     ▼
HTTP Response
```

## 🧪 Testing

The APIs can be tested using:

* Swagger
* Postman
* `.http` requests
* Browser for GET endpoints

For protected endpoints, provide the JWT token using:

```text
Authorization: Bearer <your-token>
```

## 📌 Error Handling

The project includes centralized exception handling through middleware.

This helps the API return consistent HTTP responses when errors occur.

Examples include:

```text
400 Bad Request
401 Unauthorized
403 Forbidden
404 Not Found
500 Internal Server Error
```

## 🌐 GitHub Repository

**Repository:**

https://github.com/Kiran2809/HospitalManagementAPI

## Project Status

// CI/CD pipeline configured with Jenkins.

## 🚧 Future Enhancements

Possible future improvements include:

* Frontend application
* Appointment scheduling improvements
* Doctor availability management
* Patient medical history
* Email notifications
* Improved logging
* Unit and integration testing
* CI/CD pipeline
* Cloud deployment

## 👨‍💻 Author

**Kiran**

This project was developed as a learning and demonstration project for building a real-world ASP.NET Core Web API using layered architecture, authentication, database access, and API documentation.
