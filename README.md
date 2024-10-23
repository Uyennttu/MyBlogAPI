# Blog API

This project is a simple Blog API built with ASP.NET Core. The project demonstrates key features such as database connectivity, DTO (Data Transfer Objects) usage to hide certain data from the user, and dependency injection using interfaces and services.

## Features

- **Database Connectivity**: The project connects to a SQL Server database using Entity Framework Core. It uses `BlogDbContext` to manage database operations.
- **DTO (Data Transfer Objects)**: The project uses DTOs to return limited information to the user, hiding sensitive data fields from the API responses.
- **Dependency Injection**: The project implements dependency injection (DI) to inject services (e.g., `BlogService`) that manage the business logic. Interfaces like `IBlog` are used to define contracts for the services.

## Project Structure

- **Controllers**: Handles HTTP requests and responses.
  - `BlogController`: This controller handles CRUD operations for the blog posts.
  
- **Models**: Represents the structure of the data used in the application.
  - `Blog`: The main model representing a blog post.
  - `BlogDTO`: The Data Transfer Object used to limit what data is exposed to the API consumers.

- **Services**: Contains the business logic.
  - `BlogService`: Implements the business logic and interacts with the database through `BlogDbContext`.

- **Dependency Injection**: `IBlog` is an interface that defines the contract for the blog service. `BlogService` implements this interface and is registered in the service container for DI.



