# Work Order Management System

## Overview

This repository contains the code for a Work Order Management System built using ASP.NET Core with PostgreSQL. The system provides functionalities for managing work orders, including creating, editing, and viewing work orders, with role-based access control and user management.

## Prerequisites

- [.NET 7.0 SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Entity Framework Core Tools](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)

## Future Work (In Progress):

### User Roles and Permissions

- **Role Management**: Implement functionality for defining and managing user roles such as Managers, Engineers, Workers (Foremen), and Human Resources.
- **Role-Based Access Control**: Integrate role-based access control to ensure that users can only access features and data relevant to their role.

### Authentication and Authorization

- **User Registration and Login**: Develop user registration and login functionalities to authenticate and authorize users.
- **Password Management**: Implement password reset and recovery options to enhance security.
- **Session Management**: Manage user sessions and implement timeout mechanisms to protect user data.

### User Interface Enhancements

- **Modern UI Design**: Revamp the user interface using modern CSS frameworks such as Bootstrap or frontend libraries like Angular or React.
- **Responsive Design**: Ensure that the application is fully responsive and provides a seamless experience across different devices and screen sizes.
- **User Experience (UX) Improvements**: Conduct usability testing and incorporate feedback to improve the overall user experience.

### Additional Features

- **Advanced Reporting**: Integrate advanced reporting features to provide more comprehensive insights and analytics on work orders and user activities.
- **Notifications**: Implement notification systems to alert users about important events, such as task updates or deadlines.
- **Audit Trails**: Develop audit trails to track changes and activities within the application for accountability and transparency.

### Testing and Quality Assurance

- **Unit Testing**: Create and execute unit tests to ensure that individual components function correctly.
- **Integration Testing**: Conduct integration tests to verify that different parts of the application work together as expected.
- **User Acceptance Testing (UAT)**: Perform user acceptance testing to validate the application's functionality and performance from an end-user perspective.

### Documentation and Training

- **User Documentation**: Develop comprehensive user guides and documentation to help users navigate and utilize the application effectively.
- **Developer Documentation**: Create detailed developer documentation covering the architecture, codebase, and best practices for maintaining and extending the application.
- **Training Materials**: Prepare training materials and conduct sessions to onboard users and developers.

**Note:** These tasks are part of the ongoing development process and will be prioritized based on project needs and stakeholder feedback. The goal is to enhance the functionality, usability, and overall quality of the Work Order Management System.

## Getting Started

### Clone the Repository

```bash
git clone https://github.com/mustafakbaser/ManagementApp.git
cd ManagementApp
```

## Set Up Database

To set up and configure the database for the Work Order Management System, follow these detailed steps:

### 1. Create and Configure the Database

1. **Create a PostgreSQL Database**:
   - Use a PostgreSQL management tool (e.g., pgAdmin) or a command-line interface to create a new database.
   - Example command to create a database using `psql`:
     ```sql
     CREATE DATABASE workorderdb;
     ```

2. **Configure Connection String**:
   - Open `appsettings.json` and add or update the PostgreSQL connection string with your database details:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Database=workorderdb;Username=yourusername;Password=yourpassword"
     }
     ```

### 2. Set Up Entity Framework Core

1. **Install Entity Framework Core Packages**:
   - Ensure that you have the required NuGet packages installed for Entity Framework Core and PostgreSQL:
     ```bash
     dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
     dotnet add package Microsoft.EntityFrameworkCore.Design
     ```

2. **Configure DbContext**:
   - Create a `DbContext` class if not already present. Define your entities and configure the database connection:
     ```csharp
     using Microsoft.EntityFrameworkCore;
     using ManagementApp.Models;

     public class ApplicationDbContext : DbContext
     {
         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
         {
         }

         public DbSet<WorkOrder> WorkOrders { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             base.OnModelCreating(modelBuilder);
             // Additional configuration if needed
         }
     }
     ```

3. **Update Startup Configuration**:
   - Register the `DbContext` in the `Startup.cs` file:
     ```csharp
     public void ConfigureServices(IServiceCollection services)
     {
         services.AddDbContext<ApplicationDbContext>(options =>
             options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

         // Other service configurations
         services.AddRazorPages();
     }
     ```

### 3. Create and Apply Migrations

1. **Add Initial Migration**:
   - Use the Package Manager Console or a terminal to add a migration. This step generates a migration script based on the current model:
     ```bash
     dotnet ef migrations add InitialCreate
     ```

2. **Apply Migration to Database**:
   - Apply the migration to the database to create the necessary tables and schema:
     ```bash
     dotnet ef database update
     ```

## Run the Application

1. **Start the Application**: Run the application using the following command in your terminal or command prompt:

    ```bash
    dotnet run
    ```

2. **Access the Application**: Open your web browser and navigate to `http://localhost:5000` to access the Work Order Management System.

3. **Verify Functionality**: Check that the application is running correctly by using its features, such as creating, editing, and viewing work orders.

## Development

### Project Structure

- **Pages**: Contains Razor Pages for the application, including Create, Edit, Index, and Details pages for Work Orders.
- **Models**: Contains view models and data models used in the application.
- **Services**: Contains service interfaces and implementations for interacting with the database.

### Best Practices

- **Separation of Concerns**: Ensure that business logic is separated from the presentation layer.
- **Validation**: Implement server-side and client-side validation to ensure data integrity.
- **Exception Handling**: Use appropriate exception handling and logging mechanisms to track errors and issues.

### Adding New Features

1. **Update the Model**: Modify the data models and view models as needed.
2. **Create New Pages**: Add new Razor Pages for additional functionality.
3. **Update Services**: Implement additional services or update existing ones to support new features.

## Contributing

1. **Fork the Repository**: Create a personal copy of the repository.
2. **Create a Branch**: Develop features or fix issues in a separate branch.
3. **Submit a Pull Request**: Once changes are made, submit a pull request for review.

## Troubleshooting

- **Database Connection Issues**: Ensure that the PostgreSQL server is running and that the connection string in `appsettings.json` is correct.
- **Migration Errors**: Verify that Entity Framework Core tools are installed and that the database is accessible.
- **Application Errors**: Check the application logs for detailed error messages and consult the documentation for troubleshooting steps.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact

For questions or support, please contact [iletisim@mustafabaser.net](mailto:iletisim@mustafabaser.net).