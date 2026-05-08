# Blazor DataGrid CRUD Application

A comprehensive example showcasing how to build a full-stack Blazor CRUD application using the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) for rich, real-time data operations, integrated with [Dapper](https://github.com/DapperLib/Dapper) ORM and SQL Server. This repository includes multiple implementations targeting various .NET versions.

### Features

- **CRUD Operations** - Create, Read, Update, and Delete bug records
- **DataGrid** - Interactive table with real-time updates
- **Type-Safe Data Access** - Dapper with strongly-typed entities
- **Responsive UI** - Bootstrap-based responsive design
- **Data Validation** - Server-side validation for data integrity

## Prerequisites

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or later
- [Visual Studio Code](https://code.visualstudio.com/)
- **SQL Server** 2016 or later (Express edition supported)

## Getting Started

1. **Clone the repository**

   ```bash
   git clone https://github.com/SyncfusionExamples/blazor-datagrid-dapper-crud.git
   cd blazor-datagrid-dapper-crud
   ```

2. **Create the database**

   - Open SQL Server Management Studio (or your preferred SQL client)
   - Execute the script in `SQL Script/bug-table.sql` to create the **BugTracker** database and **Bugs** table
   
   Alternatively, use PowerShell:
   ```powershell
   sqlcmd -S <ServerName> -i "SQL Script\bug-table.sql"
   ```

3. **Configure the connection string**

   Edit the connection string in `appsettings.json` under the `BugTrackerDatabase` property:
   ```json
   {
     "ConnectionStrings": {
       "BugTrackerDatabase": "Server=<YOUR_SERVER>;Database=BugTracker;Trusted_Connection=true;Encrypt=false;"
     }
   }
   ```
   > Replace `<YOUR_SERVER>` with your SQL Server instance name (e.g., `localhost` or `.`)

4. **Restore and run**

   ```bash
   cd BlazorWebApp
   dotnet restore
   dotnet build
   dotnet run
   ```

## References

- [Dapper GitHub reference link](https://github.com/DapperLib/Dapper)
- [SQL Server documentation](https://learn.microsoft.com/en-us/sql/sql-server)
- [Blog: Build a Blazor CRUD Application with Dapper](https://www.syncfusion.com/blogs/post/build-blazor-crud-application-with-dapper.aspx)
