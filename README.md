# Employee Management System

![employee-list](https://github.com/BatyaWail/PracticumProject/assets/149001923/50048c27-2f22-4df9-8bad-d35557d1de4b)

## Project Overview

Welcome to the Employee Management System project! This web application is designed to facilitate efficient management of employee data within an organization. Built using Angular 17 for the frontend and .NET Core for the backend, the system follows a layered architecture approach with seamless database integration.

## Installation

1. Clone the repository from [GitHub](https://github.com/BatyaWail/PracticumProject).
2. Navigate to the project directory.

### Frontend

1. Navigate to the frontend directory (`/EmployeeClient`).
2. Run `npm install` to install dependencies.
3. Start the development server with `ng serve`.
4. Access the application at http://localhost:4200.

### Backend

1. Navigate to the backend directory (`/EmployeeServer`).
2. Open the solution file in Visual Studio.
3. Ensure all necessary NuGet packages are installed.
4. Open the "Package Manager Console."
5. Initialize the database by executing `update-database`.
6. Build and run the backend application by `dotnet run`

## Project Structure

The project is structured as follows:

- **Frontend (Angular 17):** Implements user interface features for efficient employee management.
- **Backend (.NET Core):** Provides RESTful APIs to interact with the database and manage employee data effectively.

## Usage

The Employee Management System offers the following features:

1. **Employee List Page:** Displaying partial information about employees.
2. **Adding a New Employee and Editing Employee Details:** Enables adding and editing an employee through an expanding dynamic form, which can include multiple roles per employee (for example, an employee can be both a Designer and a Developer). Strong emphasis is placed on input validation in both cases, for example, the birth date must be at least 18 years prior to the current date to ensure no underage employment.
3. **Search Functionality:** Filters employees based on entered text for ease of navigation.
4. **Export to Excel:** Allows exporting the employee list to an Excel file for further analysis.


## Authentication and Company Management

### Authentication

- Users are required to enter the company name and password to log in.
- Upon clicking the login button, the frontend sends an API request to the server.
- The server verifies the entered company name and password against the database records.
- If authentication is successful, the server issues a JWT token as a response for further authentication and identification.
- If authentication fails, the server returns an error message to the frontend.

### Company Management

- After successful authentication, the user is directed to a dashboard focused on the associated company.
- Only employees belonging to the user's company are displayed in the interface.
- There is a search filter for employees, allowing to display only those matching the entered text.
- Users can download a list of employees to an Excel file, including their data.
- There is a component for adding a new employee. When adding a new employee, users can dynamically assign roles.
- There is also a component for editing an employee, allowing users to edit employee details and roles.
- Users can log out of the system using the logout button.

## Company Information

To access the system, use the following company credentials:

- **Company Name:** company1
- **Password:** 123456

  ![login](https://github.com/BatyaWail/PracticumProject/assets/149001923/eb1a339b-9e4c-4e66-8c53-d79e68eb5f32)
  
- **Note:** This is one of the companies in the system. You can add more companies and set passwords for them!                          
Please make sure to use the provided company name and password for authentication. Without proper authentication, access to the system will be denied.       
Additionally, the system is filtered based on the company ID. Users can only view and manage employees associated with their respective company.        

## Notes

- All fields are mandatory with implemented input validation to ensure data integrity.
- Proper data validation and error handling are implemented to enhance user experience.
- Deleted employees are logically removed by changing their status to inactive, preserving historical data.

## Conclusion

The Employee Management System provides a user-friendly interface for organizations to efficiently manage employee data. For further assistance or queries, refer to the project documentation or contact the development team on batya4119712@gmail.com or on phone 0504119712

Enjoy using the Employee Management System!
