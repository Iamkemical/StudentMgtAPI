# Student Management API- Summary
This dockerized microservice was designed using CRUD style. Its a student database management microservice  that allows the client to create, read, update and delete student from the database.

# Code editor used
VSCode

# Development technologies used
C# - For performing CRUD (Create, Read, Update, and Delete) operations on the database.
EntityFrameworkCore - For handling SQL queries from the internal representation of the data (Model) to the database.

MSSQL- Relational Database used for storing data from the Model.

SWAGGERUI - For documenting the CRUD operation of the API.

JWT - For issuing authentication tokens from the server to the client.

AutoMapper - For creating source and destination maps for the DTOs (Data Transfer Objects)

DOCKER - Docker is used for containerizing the microservice

# Dependencies installed via the CLI on VSCode
Automapper.Extensions.Microsoft.DependencyInjection

Microsoft.AspNetCore.Authentication.JwtBearer

Microsoft.AspNetCore.JsonPatch

Microsoft.AspNetCore.Mvc.NewtonsoftJson

Microsoft.EntityFrameworkCore.Design

Microsoft.EntityFrameworkCore.SqlServer

Microsoft.EntityFrameworkCore.Tools

Swashbuckle.AspNetCore

# Architectural pattern
DTOs- Data Transfer Objects was employed in the building of this microservice. What DTOs basically does is it allows the adminstrator of the microservice to hide certain data stored in the database by showing the client only what is intended for them to see.
For Example
If the database contains Id, Date of birth, email, gender etc and we dont't want the client to see the id when they make a Get request DTOs help you perform that function.

Repositories - Repositories allow for decoupling of the microservice making it seemless and flexible. Declared as interface with methods with implementation.

Services - Implements the methods contained in the repositories.

Profiles - Maps the model to the to the DTOs for different CRUD operations.

DatabaseContext - Data access layer that connects the Model to the Database.

# Running the microservice
Dotnet - If you have a .NET SDK installed on your local machine you can use the command - dotnet run.

Docker - If you are using a Linux box and you have docker installed you can run the microservice using the following command.

docker-compose up -d --build(if you and running for the first time)

docker-compose up -d

SwaggerUI - go to this URL - http://localhost:5000/swagger/index

# Configure the bearer token to access the microservice
Without an authorization header having the bearer token the client would get a 401 unauthorized call.

To resolve this enter http://localhost:5000/authstudent and send a post request with the following dummy username and password as JSON

    {
        "UserName" = "Iamkemical",
        "Password" = "Stron9pa55word",
    }

A successful response:

    {
        "userId": 1,
        "firstName": "Gabriel",
        "lastName": "Isaac",
        "password": null,
        "userName": "Iamkemical",
        "token": "token"
    }


