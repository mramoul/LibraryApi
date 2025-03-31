# Gothic API

## Overview
Gothic API is a microservices-based application following the principles of Clean Architecture. It provides endpoints for managing authors, books, and loans in a library management system. The project is designed for scalability, separation of concerns, and maintainability.

## Architecture
The project adopts Clean Architecture, separating the application into distinct layers:
- **Domain Layer**: Contains business logic and entities.
- **Application Layer**: Implements use cases and application logic using MediatR for CQRS pattern.
- **Infrastructure Layer**: Handles database interaction, repositories, and external services.
- **API Layer**: Minimal API exposing endpoints using ASP.NET Core.

## Tech Stack
- **Tools & IDEs:** VS Code, Docker Desktop, Postgres, Git
- **Libraries:**
  - ASP.NET Core Minimal API
  - Swagger (for API documentation)
  - MediatR (for CQRS)
  - Entity Framework Core (for data access)

## API Endpoints
- `GET /authors` - Retrieves all authors with books and loans.
- `POST /authors` - Creates a new author.
- `DELETE /authors/{id}` - Deletes an author along with related books and loans.
- `GET /books` - Retrieves all books with loans.
- `POST /books` - Creates a new book.
- `DELETE /books/{id}` - Deletes a book and related loans.
- `GET /loans` - Retrieves all loans.
- `POST /loans` - Creates a new loan.

## Setup Instructions
1. **Clone the Repository**
```bash
git clone https://github.com/your-username/gothic-api.git
cd gothic-api
```

2. **Install PostgreSQL & Docker Desktop**
- Download PostgreSQL from [official website](https://www.postgresql.org/download/).
- Create a superuser:
```bash
psql -U postgres
CREATE ROLE gothic_user WITH LOGIN PASSWORD 'password';
ALTER ROLE gothic_user CREATEDB;
```
- Create the database:
```bash
CREATE DATABASE gothic_db OWNER gothic_user;
```

3. **Configure Database**
- Open `appsettings.Development.json` and update connection strings:
```json
"ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=gothic_db;Username=gothic_user;Password=password"
}
```

4. **Build and Run the Application**
```bash
docker-compose up --build -d
```
- Open Docker Desktop, locate the API container, and restart if needed.
- Access the application: [http://localhost:5000/swagger](http://localhost:5000/swagger)

## Known Issues
- API container might not start properly; manually restart the container in Docker Desktop if needed.

## Future Enhancements
- **Fluent Validation:** Implement request validation and data sanitization.
- **Unit and Integration Testing:** Improve test coverage.
- **Environment Variables:** Replace hardcoded configurations.
- **Authentication & Authorization:** Add access control to API routes.
