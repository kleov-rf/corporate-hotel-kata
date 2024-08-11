
# Corporate Hotel Booking Kata

This project is an implementation of the Corporate Hotel Booking Kata using a Web API in C#. The solution follows a Clean Architecture pattern, organizing the code into separate layers: Application, Domain, and Infrastructure. The project also includes unit and acceptance tests to ensure the correctness of the implementation.

## Table of Contents

- [Overview](#overview)
- [Architecture](#architecture)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Running the Application](#running-the-application)
- [Running Tests](#running-tests)
- [Continuous Integration](#continuous-integration)
- [MongoDB Integration](#mongodb-integration)
- [Contributing](#contributing)
- [License](#license)

## Overview

The Corporate Hotel Booking Kata is a coding exercise that involves implementing a system for booking hotel rooms for corporate clients. The system is designed to handle various booking scenarios while maintaining clean and maintainable code.

This solution implements a RESTful Web API in C# with a focus on Clean Architecture, ensuring that the core business logic is independent of external concerns like databases and UI frameworks. The project has been developed using Test-Driven Development (TDD) cycles, ensuring that all functionalities are backed by tests from the beginning and that the implementation strictly adheres to the defined requirements.

## Architecture

The project is structured according to Clean Architecture principles, with the following key layers:

- **Application**: Contains the application logic, including use cases, commands, and queries.
- **Domain**: Holds the core business logic and domain models. This layer is independent of any external dependencies.
- **Infrastructure**: Includes external dependencies such as data access (e.g., MongoDB repository) and other services required by the application.

This separation of concerns allows for easier testing, maintenance, and scalability of the system.

### Project Structure

```
CorporateHotel/
└── HotelManagement/
    ├── Application/
    ├── Domain/
    └── Infrastructure/

CorporateHotel.Tests/
├── Acceptance/
├── Helpers/
└── HotelManagement/
    ├── Application/
    ├── Domain/
    └── Infrastructure/
```

- `CorporateHotel/Application`: Contains the application layer code.
- `CorporateHotel/Domain`: Contains the core domain models and business logic.
- `CorporateHotel/Infrastructure`: Contains the infrastructure code, including database repositories.
- `CorporateHotel.Tests/Acceptance`: Contains acceptance tests that validate the overall behavior of the application.
- `CorporateHotel.Tests/HotelManagement`: Contains unit tests for the Hotel Management service.

## Technologies Used

- **.NET 8**: The base framework for the Web API.
- **MongoDB**: A NoSQL database used for storing booking data.
- **Moq**: A library for creating mock objects in unit tests.
- **xUnit**: The testing framework used for unit and acceptance tests.
- **Docker**: For setting up MongoDB locally if needed.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) installed on your machine.
- [MongoDB](https://www.mongodb.com/try/download/community) installed locally, or access to a MongoDB instance.
- [Docker](https://www.docker.com/get-started) if you prefer to run MongoDB in a container.

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/kleov-rf/corporate-hotel-kata.git
   cd corporate-hotel-kata
   ```

2. Restore the dependencies:
   ```bash
   dotnet restore
   ```

### Running the Application

1. Ensure that MongoDB is running locally or update the connection string in the `appsettings.json` file of the Web API project.

2. Build and run the application:
   ```bash
   dotnet build
   dotnet run --project src/WebApi/WebApi.csproj
   ```

3. The API will be accessible at `http://localhost:5000` by default.

## Running Tests

The solution includes both unit and acceptance tests to validate the implementation.

1. To run all tests, use the following command:
   ```bash
   dotnet test
   ```

2. To run tests for a specific project, navigate to the `tests` directory and run:
   ```bash
   dotnet test <ProjectName>.csproj
   ```

## Continuous Integration

This project includes a GitHub Actions CI workflow that automatically runs the tests whenever changes are pushed to the repository. The workflow is defined in the `.github/workflows/workflow.yml` file.

To customize or extend the CI pipeline, modify the `workflow.yml` file as needed.

## MongoDB Integration

We are in the process of implementing a `MongoDBRepository` to handle data persistence. The repository will provide CRUD operations for the booking data and will be integrated into the application through the Infrastructure layer.

### Configuration

Ensure that your MongoDB instance is correctly configured in the `appsettings.json` file:

```json
{
  "MongoDB": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "corporate_hotel"
  }
}
```

### Future Enhancements

- Implementing advanced query capabilities using MongoDB's aggregation framework.
- Adding indexes to optimize query performance.
- Integrating with MongoDB Atlas for production-ready cloud-based MongoDB instances.

## Contributing

We welcome contributions to this project! If you'd like to contribute, please follow these steps:

1. Fork the repository.
2. Create a feature branch (`git checkout -b feature/YourFeatureName`).
3. Commit your changes (`git commit -m 'Add some feature'`).
4. Push to the branch (`git push origin feature/YourFeatureName`).
5. Open a pull request.

Please ensure that your code follows the existing coding conventions and passes all tests before submitting a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE.md) file for details.
