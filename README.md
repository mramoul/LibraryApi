# Library API

## Overview
Library API is a microservices-based application following the principles of Clean Architecture. It provides endpoints for managing authors, books, and loans in a library management system. The project is designed for scalability, separation of concerns, and maintainability.

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
- `POST /author` - Creates a new author.
- `GET /author-list` - Retrieves all authors.
- `GET /author/{id}` - Retrieves an author by ID, includes books.
- `DELETE /author/{id}` - Deletes an author along with related books and loans.
- `POST /book` - Creates a new book.
- `GET /book/{id}` - Retrieves a book by ID, includes loans.
- `GET /book-list` - Retrieves all books.
- `DELETE /book/{id}` - Deletes a book and related loans.
- `POST /loan` - Creates a new loan.
- `GET /loan` - Retrieves a loan by ID, includes the related book.
- `GET /loan-list` - Retrieves all loans.


## Setup Instructions
1. **Clone the Repository**
```bash
git clone https://github.com/mramoul/LibraryApi.git
cd LibraryApi
```

2. **Install PostgreSQL & Docker Desktop**
- Download PostgreSQL from [official website](https://www.postgresql.org/download/).
- Create a superuser:
```bash
psql -U postgres
CREATE ROLE your_user WITH LOGIN PASSWORD 'your_password';
ALTER ROLE your_user CREATEDB;
```

3. **Configure Database**
- Open `appsettings.Development.json` and update connection strings:
```json
"ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=library;Username=your_user;Password=your_password"
}
```

4. **Build and Run the Application**
```bash
docker-compose up --build -d
```
- Open Docker Desktop, locate the API container, and restart if needed.
- Access the application: [http://localhost:5001/swagger](http://localhost:5001/swagger/index.html)

## Known Issues
- API container might not start properly; manually restart the container in Docker Desktop if needed.

## Future Enhancements
- **Fluent Validation:** Implement request validation and data sanitization.
- **Unit and Integration Testing:** Improve test coverage.
- **Environment Variables:** Replace hardcoded configurations.
- **Authentication & Authorization:** Add access control to API routes.
