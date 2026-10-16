# Blazor DataGrid CRUD Application Using Dapper

## Overview

This sample demonstrates how to integrate the Syncfusion [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) with SQL Server using the Dapper micro-ORM to perform Create, Read, Update, and Delete (CRUD) operations. The application uses a Bug Tracker database where records are retrieved from and persisted to SQL Server through Dapper data-access methods. The sample illustrates a practical database-driven DataGrid workflow that enables users to manage bug records directly from the grid interface while keeping data synchronized with the underlying database.

## Key Features

- Integrates Syncfusion Blazor DataGrid with SQL Server using Dapper.
- Demonstrates complete CRUD operations against the `Bugs` database table.
- Retrieves records from SQL Server using Dapper query execution.
- Inserts new bug records into the database through Dapper-based data access methods.
- Updates existing bug records and persists changes to SQL Server.
- Deletes records directly from the database through DataGrid actions.
- Uses a database named `BugTracker` as the primary data source.
- Includes SQL scripts for creating the database schema and required table structure.
- Provides separate project implementations for .NET 5 and .NET 6 environments.
- Demonstrates database-driven DataGrid operations instead of in-memory data binding.

## Prerequisites

- SQL Server
- Visual Studio 2022 or Visual Studio Code
- .NET SDK compatible with the project's target framework

## How to Run the Project

**Visual Studio 2022**

1. Clone or download the repository.
2. Create a SQL Server database named `BugTracker`.
3. Execute the SQL scripts available in the `SQL Script` folder to create the required `Bugs` table.
4. Open the appropriate solution/project from:
   - `NET5/Dapper.CRUD`
   - `NET6/Dapper.CRUD`
   - `BlazorWebApp`
5. Update `appsettings.json` with your SQL Server connection string.
6. Restore all NuGet packages.
7. Set the appropriate server project as the startup project.
8. Build the solution.
9. Run the application using `Ctrl+F5`.

**Visual Studio Code**

1. Open the repository folder in Visual Studio Code.
2. Open the integrated terminal.
3. Navigate to the desired project directory.

```bash
cd NET6/Dapper.CRUD
dotnet restore
dotnet run
```

4. Open the local URL displayed in the terminal after application startup.

## Project Structure

- `NET5/Dapper.CRUD/` — contains the .NET 5 implementation of the DataGrid CRUD application using Dapper.
- `NET6/Dapper.CRUD/` — contains the .NET 6 implementation of the DataGrid CRUD application using Dapper.
- `BlazorWebApp/` — Blazor application variant included in the repository.
- `SQL Script/` — SQL scripts used to create the `BugTracker` database and `Bugs` table.
- `appsettings.json` — contains the SQL Server connection string configuration used by Dapper.
- `Pages/` — contains the Blazor pages that host the Syncfusion DataGrid and perform CRUD operations.

## Support and Feedback

- For general product questions, visit the [Syncfusion Community Forum](https://www.syncfusion.com/forums) or [Syncfusion Support](https://www.syncfusion.com/support).
- To report an issue specific to this sample, open a GitHub issue in this repository.
- For feature documentation, see the Syncfusion Blazor DataGrid with Dapper documentation: https://help.syncfusion.com/grid-sdk/blazor/data-grid/connecting-to-orm/dapper

## License

This is a Syncfusion sample project provided to demonstrate product usage. Review the [Syncfusion license terms](https://www.syncfusion.com/sales/pricing?category=ui-components) before using Syncfusion components in your own applications.
