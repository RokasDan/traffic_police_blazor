# Traffic Police Blazor

Traffic Police Blazor is a Blazor WebAssembly project with a separate client and server backend. This project emulates a police database that allows you to view and create reports as a real police officer.

## Installation

1. To run Traffic Police Blazor on your system, you first need to have a MySQL server. Please install the database from my `Database_Installation.sql` file.
2. Once you have done so, please open the project. Within the solution, find the `appsettings.json` file.
3. Open the file and find the connection string. Please enter all of your MySQL server details and the schema name.

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
    "Default": "Server=localhost;Database=police;Uid=root;Pwd=;ConvertZeroDateTime=True"
  }
}

Once you've done this, you are ready to launch your MySQL server and the project.

## Login

To login, you can use the following three user accounts:

- Username: Rokas, Password: 108
- Username: haskins, Password: copper99
- Username: Poopty, Password: droopt

Alternatively, you can add your own username and password straight to the admins table.

## Disclaimer

Please note that this project does not contain any actual statistical data, and is intended for educational purposes only. 

