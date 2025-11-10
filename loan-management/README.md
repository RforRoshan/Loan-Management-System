# Loan Management API

A comprehensive .NET Core Web API for managing loan applications, approvals, and payments.

## Features

- User Management
  - User registration and authentication
  - JWT token-based authentication
  - User profile management

- Loan Management
  - Multiple loan type support
  - Loan application submission
  - Application status tracking
  - Payment processing
  - Loan history

- Admin Features
  - Loan approval/rejection workflow
  - User management
  - Payment tracking
  - Application review system

## Technology Stack

- .NET
- Entity Framework Core
- SQL Server
- JWT Authentication

## Project Structure

```
├── Controllers/          # API endpoints
├── Model/               # Data models
├── Repository/          # Data access layer
├── Service/            # Business logic
├── Context/            # Database context
├── Exceptions/         # Custom exceptions
├── Migrations/         # Database migrations
└── SRP/                # Single Responsibility Pattern implementations
```

## Setup Instructions

1. Clone the repository
2. Update the connection string in `appsettings.json`
3. Run the following commands:
   ```
   dotnet restore
   dotnet ef database update
   dotnet run
   ```

## API Endpoints

### User Endpoints
- POST /api/User/register - Register new user
- POST /api/User/login - User login
- GET /api/User/profile - Get user profile

### Loan Endpoints
- POST /api/Loan/apply - Apply for a loan
- GET /api/Loan/status - Check loan status
- POST /api/Loan/payment - Make loan payment

### Admin Endpoints
- GET /api/Admin/pending - Get pending loans
- POST /api/Admin/approve - Approve loan
- POST /api/Admin/reject - Reject loan

## Configuration

The application can be configured through `appsettings.json`. Key configurations include:
- Database connection string
- JWT settings
- Logging preferences

## Security

- JWT token authentication
- Password hashing
- Role-based authorization
- Input validation
- Exception handling
