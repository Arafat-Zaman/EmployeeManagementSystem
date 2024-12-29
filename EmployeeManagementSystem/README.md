
# Employee Management System

## Description
This project is an ASP.NET Core Web API for managing employees, departments, and designations using a modern architecture.

## Features

1. **Employees Module**:
   - Create, read, update, and delete (CRUD) employee records.
   - Store personal details, department, and designation.

2. **Departments Module**:
   - Manage organizational departments with CRUD operations.

3. **Designations Module**:
   - Manage employee designations with CRUD operations.

4. **Centralized Logging**:
   - Logs requests, responses, and exceptions using Serilog.

5. **Error Handling**:
   - Global exception handling with standardized error responses.

6. **Authentication and Authorization**:
   - JWT-based authentication for securing API endpoints.- 

7. **API Versioning**:
   - Support versioned APIs.

8. **Scalability and Modularity**:
   - Implements the CQRS pattern for separate command (write) and query (read) operations.

9. **Containerization**:
   - Docker support for seamless deployment.


## **Technology Stack**
- **Framework**: ASP.NET Core 8
- **Database**: Microsoft SQL Server
- **ORM**: Entity Framework Core
- **Authentication**: JSON Web Tokens (JWT)
- **Logging**: Serilog
- **Architecture**:
  - Vertical Slicing
  - CQRS Pattern
- **Deployment**: Docker


## Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Docker](https://www.docker.com/)



## **Project Structure**

EmployeeManagementSystem/
│
├── Controllers/                 # API Controllers for Employees, Departments, and Designations
├── DTOs/                        # Data Transfer Objects
├── Entities/                    # Entity classes for database modeling
├── Features/                    # Vertical slices for CQRS (Commands, Queries, Handlers)
│   ├── Employees/
│   ├── Departments/
│   ├── Designations/
│
├── Infrastructure/              # Services for Authentication, Logging, etc.
│   ├── Authentication/
│   ├── Logging/
│   ├── Extensions/
│
├── Middlewares/                 # Middleware for exception handling
├── Persistence/                 # Database context and migrations
├── appsettings.json             # Configuration for database and JWT
├── Program.cs                   # Application entry point
├── Dockerfile                   # Docker configuration for containerization
└── README.md                    # Documentation

- 



## Setup
1. Clone the repository:
   
   git clone https://github.com/Arafat-Zaman/EmployeeManagementSystem.git
   
2. Configure `appsettings.json`:
   - Set the `DefaultConnection` string for your SQL Server.
  

3. Run the application:
   
   dotnet run
   

4. Test the API using Swagger:
   - Navigate to `http://localhost:<port>/swagger`.




## Database 

-- Create Database
CREATE DATABASE EmployeeDB;
GO
USE EmployeeDB;
GO

-- Create Departments Table
CREATE TABLE Departments (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);

-- Create Designations Table
CREATE TABLE Designations (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL
);

-- Create Employees Table
CREATE TABLE Employees (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    DateOfBirth DATE NOT NULL,
    DepartmentId INT NOT NULL,
    DesignationId INT NOT NULL,
    FOREIGN KEY (DepartmentId) REFERENCES Departments(Id),
    FOREIGN KEY (DesignationId) REFERENCES Designations(Id)
);

-- Seed Data for Departments
INSERT INTO Departments (Name)
VALUES
('Human Resources'),
('IT'),
('Finance'),
('Marketing');

-- Seed Data for Designations
INSERT INTO Designations (Title)
VALUES
('Software Engineer'),
('Manager'),
('Analyst'),
('Team Lead');

-- Seed Data for Employees
INSERT INTO Employees (FirstName, LastName, DateOfBirth, DepartmentId, DesignationId)
VALUES
('A', 'A1', '1985-04-23', 2, 1), -- IT, Software Engineer
('B', 'B1', '1990-09-15', 1, 2), -- HR, Manager
('C', 'C1', '1988-12-10', 3, 3), -- Finance, Analyst
('D', 'D1', '1995-03-20', 4, 4); -- Marketing, Team Lead


## Docker Deployment

