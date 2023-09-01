<div align="center">
  <h1>🎞️ Films API 🎞️</h1>
  <p><i>An API for managing film information using .NET 6.0, MVC, and ASP.NET.</i></p>
</div>

---

<div align="left">
  <h2>🚀 Project Overview</h2>
</div>

The Films API project aims to provide a robust solution for registering and managing film information. Built on .NET 6.0, it utilizes the MVC pattern within ASP.NET, offering JWT-based authorization for secure access. Exception handling is seamlessly managed through a dedicated middleware. The data access layer is powered by Entity Framework and follows the Repository Pattern, ensuring efficient communication with a Postgresql database. AutoMapper facilitates smooth mapping between Models and Entities, while Fluent Validation ensures data integrity. Additionally, the API is documented and consumable via Swagger, and thorough unit tests are in place.

<br>

<div align="left">
  <h2>🛠️ Technologies Used</h2>
</div>

- **.NET 6.0**
- **C#**
- **Entity Framework**
- **AutoMapper**
- **Fluent Validation**
- **ASP.NET**
- **Postgresql**

<br>

<div align="left">
  <h2>⚙️ Design Patterns Used</h2>
</div>

- **Repository**
- **Services**
- **Clean Code**
- **S.O.L.I.D**

<br>

<div align="left">
  <h2>🔧 Installation and Setup</h2>
</div>

To get started with the Films API, follow these straightforward installation and setup steps:

1. **Clone the Repository**: Clone this repository to your local machine.

   ```bash
   git clone https://github.com/guilhermebernava/FilmsAPI.git
   ```

2. **Configuration**: Configure the application settings, including database connection details, in the appsettings.json file.

3. **Database Setup**: Use Entity Framework migrations to create and set up the database schema.

   ```bash
   dotnet ef database update
   ```

4. **Launch the API**: Start the API and begin managing film information.

   ```bash
   dotnet run
   ```

<br>

<div align="left">
  <h2>📖 Usage</h2>
</div>

With the Films API, you can efficiently manage film information:

- Register films.
- Authorize and secure access with JWT-based authentication.
- Ensure data integrity with Fluent Validation.
- Seamlessly map data between Models and Entities using AutoMapper.
- Access project documentation and endpoints through Swagger.
- Execute unit tests for code quality assurance.

<br>

---
