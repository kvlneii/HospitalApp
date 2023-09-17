# Medical API
This project I have developed during APBD (Database Application) course at PJATK.

## Project Description
This is a project for creating a medical API using ASP.NET Core, Entity Framework with a Code First approach. Additionally, the project implements an authentication system using JWT (JSON Web Tokens) to ensure secure user access to the API.

## Project Requirements: 
1. Create a New API Project:
    * Start by creating a new ASP.NET Core API project.
2. Entity Framework and Code-First:
    * Set up Entity Framework (EF) and use the Code-First approach to define your data models and generate migrations.
3. Database Migration:
    * Generate migrations based on your data models and apply them to create the database structure.
4. Data Seeding:
    * Implement a method to seed the database with sample data. This can be done using EF's seeding functionality.
5. API Endpoints:
    * Create API endpoints for various functionalities:
      * Retrieving doctors.
      * Adding a new doctor.
      * Modifying doctor data.
      * Deleting a doctor.
      * Retrieving a specific prescription.
6. Implement proper naming conventions and DTOs (Data Transfer Objects).
7. Authentication and JWT Tokens:
    * Implement JWT (JSON Web Token) authentication for your API. You'll need to:
      * Create JWT tokens for user authentication.
      * Secure your API endpoints to require valid tokens for access.
      * Implement a login endpoint to issue tokens to users.
8. User Data Storage:
    * Store user data securely in the database, considering security measures like SALT and PBKDF2 for password hashing.
9. Refresh Tokens:
    * Implement an endpoint to obtain a new access token using a refresh token.
10. Custom Middleware for Error Logging:
    * Create custom middleware to log errors to a text file (e.g., "logs.txt").
## Database model
![hospitalDB](https://github.com/kvlneii/HospitalApp/assets/95699279/98beb0d9-03fc-40d6-8973-32c41d12c8fc)
