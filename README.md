
# CarFactory Sales API

This project is a **.NET 8 Web API** developed as part of a backend technical challenge.  
It implements a clean and modular architecture following **Clean Architecture** and **SOLID principles**.

---

## 🚗 Overview

CarFactory Sales API simulates a car manufacturing company with multiple car models, prices, and a sales management system.  
The main goal is to provide a scalable and testable architecture that separates concerns across layers.

---

## 🧱 Architecture

The project follows **Clean Architecture**, divided into the following layers:

- **Domain** → Contains entities, value objects, and domain logic.  
- **Application** → Contains use cases, DTOs, and interfaces for persistence.  
- **Infrastructure** → Handles data persistence, external services, and repository implementations.  
- **API** → Presentation layer exposing REST endpoints.

This architecture ensures high **maintainability**, **testability**, and **separation of concerns**.

---

## 🧪 Tests

Unit tests are located under the `tests/` directory.  
They verify core business logic independently from the infrastructure.

Run tests using:

```bash
dotnet test
```

---

## ⚙️ Build & Run

To build and run the project locally:

```bash
dotnet restore
dotnet build
dotnet run --project ./src/CarFactory.Sales.Api
```

Alternatively, you can run it using Docker:

```bash
docker build -t carfactory.sales.api .
docker run -p 8080:8080 carfactory.sales.api
```

---

## 🚀 Continuous Integration

A **GitHub Actions workflow** is configured to automatically:

1. Restore dependencies  
2. Build the solution  
3. Run unit tests  

The workflow triggers on:
- Pull requests targeting `master`
- Direct pushes to `master`

---

## 🧾 Documentation & Comments

The codebase is **self-documented** using clear naming conventions and structured logic.  
Additionally, explanatory comments are included throughout the code to clarify the main design decisions and business rules.

---

## 👨‍💻 Author

Developed by **Manuel Achenapure**  
📧 Contact: [machenapure@gmail.com](mailto:machenapure@gmail.com)