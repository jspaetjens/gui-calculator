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
- Advanced functions: sin, cos, tan, log, ln, sqrt, power (^)
- Support for constants: pi, e
- Expression-based input with parentheses
- Clear function (C button)

## Project Structure
- `Program.cs`: Main application code with the calculator form and logic
- `ConsoleApp1.csproj`: Project file configured for Windows Forms

## Future Changes
Keep a record of changes and updates here.

### Version 1.1.0 (Advanced Calculator)
- Upgraded to advanced calculator with expression evaluation
- Added buttons for trigonometric functions, logarithms, square root, power
- Added support for constants pi and e
- Changed to expression-based input instead of sequential operations
- Removed graphing feature due to assembly issues (to be added later)

### Version 1.0.0 (Initial Release)
- Created basic GUI calculator with Windows Forms
- Supports basic arithmetic operations
- Fixed nullable reference warnings for C# nullable context