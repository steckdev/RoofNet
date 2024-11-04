# RoofNet

RoofNet is a .NET 8 application designed to assist with roofing-related tasks.

## Features

- **Roofing Calculations**: Perform various calculations pertinent to roofing projects.
- **Material Estimation**: Estimate the quantity of materials required for roofing jobs.
- **Project Management**: Manage and track roofing projects efficiently.

## Getting Started

### Prerequisites

- .NET 8 SDK

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/steckdev/RoofNet.git
   ```

2. Navigate to the project directory:

   ```bash
   cd RoofNet
   ```

3. Restore dependencies:

   ```bash
   dotnet restore
   ```

4. Build the project:

   ```bash
   dotnet build
   ```

## Usage

To run the application:

```bash
dotnet run
```

Follow the on-screen instructions to utilize the features of RoofNet.

## Testing and Code Coverage

Testing is a crucial aspect of RoofNet's development process to ensure reliability and maintainability. The project utilizes xUnit as the testing framework and integrates code coverage analysis to monitor the effectiveness of the tests.

### Running Tests

To execute the test suite:

```bash
dotnet test
```

This command will build the test project and run all tests, providing a summary of the results.

### Code Coverage

RoofNet employs Coverlet for code coverage analysis. To collect code coverage data:

```bash
dotnet test --collect:"XPlat Code Coverage"
```

After running this command, a coverage report will be generated in the `TestResults` directory. To convert this report into a human-readable format, you can use tools like ReportGenerator. For more information on using Coverlet and ReportGenerator, refer to the [Coverlet documentation](https://github.com/coverlet-coverage/coverlet) and [ReportGenerator documentation](https://github.com/danielpalme/ReportGenerator).

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contact

For questions or support, please open an issue in this repository. 