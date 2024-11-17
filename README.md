# RoofNet
Building roof application in .Net 8

## MAC Setup Guide

1. **Ensure Docker is installed**: Make sure Docker is installed and running on your Mac.

2. **Docker Compose Configuration**: Ensure your `docker-compose.yml` is correctly set up. Here is an example based on your provided context:

```yaml
services:
  db:
    image: postgres:latest
    environment:
      - POSTGRES_DB=RoofToolDb
      - POSTGRES_USER=postgres
      - POSTGRES_PASSWORD=YourStrong!Passw0rd
    ports:
      - "5432:5432"
    networks:
      - rooftool-network
  api:
    build:
      context: .
      dockerfile: RoofTool.API/Dockerfile
    environment:
      - ASPNETCORE_ENVIRONMENT=Development
      - ConnectionStrings__DefaultConnection=Host=db;Database=RoofToolDb;Username=postgres;Password=YourStrong!Passw0rd;
      - Jwt__SecretKey=YourSuperSecretKeyIsNotQuiteLongEnoughForThis
      - Jwt__Issuer=RoofToolIssuer
      - Jwt__Audience=RoofToolAudience
      - Jwt__TokenExpiryHours=1
    depends_on:
      - db
    ports:
      - "5000:5000"
    networks:
      - rooftool-network
networks:
  rooftool-network:
    driver: bridge
```

3. **App Settings Configuration**: Ensure your `appsettings.json` and `appsettings.Development.json` are correctly configured. Here is an example:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Host=db;Database=RoofToolDb;Username=postgres;Password=YourStrong!Passw0rd;"
  },
  "Jwt": {
    "SecretKey": "YourSuperSecretKeyIsNotQuiteLongEnoughForThis",
    "Issuer": "RoofToolIssuer",
    "Audience": "RoofToolAudience",
    "TokenExpiryHours": "1"
  }
}
```

4. **Run Docker Compose**: Navigate to the root directory of your project and run the following command to start your services:

```bash
docker-compose up --build
```

5. **Run Migrations**: Once the services are up, you need to run the migrations to set up your database schema. You can do this by executing the following command inside the `api` service container:

```bash
docker-compose exec api dotnet ef database update --project RoofTool.Infrastructure --startup-project RoofTool.API
```

6. **Verify Setup**: Ensure that your application is running correctly by accessing the API at `http://localhost:5000`.

## Project Structure

The project is structured into several layers:

- **Domain**: Contains the core entities and value objects.
- **Application**: Contains the service interfaces and implementations.
- **Infrastructure**: Contains the database context, repositories, and migrations.
- **API**: Contains the controllers and API configuration.
- **Tests**: Contains the unit and integration tests.

## Key Files and Directories

- `RoofTool.Domain/Entities`: Contains the domain entities such as `Measurement`, `Opportunity`, `Owner`, `PolygonEdge`, `Property`, and `Report`.
- `RoofTool.Application/Interfaces`: Contains the service interfaces such as `IMeasurementService`, `IOpportunityService`, `IOwnerService`, and `IReportService`.
- `RoofTool.Application/Services`: Contains the service implementations.
- `RoofTool.Infrastructure`: Contains the database context (`RoofToolDbContext`), repositories, and migrations.
- `RoofTool.API/Controllers`: Contains the API controllers such as `MeasurementController` and `ReportController`.
- `RoofTool.Tests`: Contains the unit and integration tests.

## Running Tests

To run the tests, use the following command:

```bash
dotnet test
```

This will execute all the tests in the `RoofTool.Tests` project.

## Additional Notes

- Ensure that your PostgreSQL database is running and accessible.
- Update the connection strings in `appsettings.json` and `appsettings.Development.json` as needed.
- Use the provided Docker Compose configuration to simplify the setup process.
