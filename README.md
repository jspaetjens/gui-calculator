# Calculator GUI App

A simple GUI calculator application built with .NET Windows Forms.

## Building and Running

### Prerequisites
- .NET 10.0 SDK installed
- Windows operating system (required for Windows Forms)

### Build Steps
1. Navigate to the project directory:
   ```
   cd ConsoleApp1
   ```

2. Restore dependencies:
   ```
   dotnet restore
   ```

3. Build the project:
   ```
   dotnet build
   ```

4. Run the application:
   ```
   dotnet run
   ```

The calculator window will open, allowing you to perform basic arithmetic operations.

## Features
- Basic arithmetic operations: addition, subtraction, multiplication, division
- Clear function (C button)
- Simple GUI with buttons for numbers and operators

## Project Structure
- `Program.cs`: Main application code with the calculator form and logic
- `ConsoleApp1.csproj`: Project file configured for Windows Forms

## Future Changes
Keep a record of changes and updates here.

### Version 1.0.0 (Initial Release)
- Created basic GUI calculator with Windows Forms
- Supports basic arithmetic operations
- Fixed nullable reference warnings for C# nullable context