## Configuration

## Prerequisites

- .NET 8
- Docker
- Visual Studio 2022 or equivalent IDE.

### How to configure and run IntelliBlog

There are two ways to run IntelliBlog:

1. By starting the project IntelliBlog.AppHost:
    - :thumbsup: This is the most common way to run IntelliBlog and it will be also used in staging, production and presumably in functional tests. 
    - :thumbsup: It is the simplest way to get everything up and running and it requires just a few configuration entries.
    - :thumbsdown: It adds overhead because of containers startup and that can cause loss of productivity and annoyance when debugging.
    - :question: It seems hot reload for the frontend does not work reliably.

1. By starting the two projects API and Frontend:
    - :thumbsup: The classic ASP.Net core debug experience. 
    - :thumbsup: Useful if you want to debug the API and the frontend without the overhead of the Aspire runtime.
    - :thumbsdown: Requires a running SQL Server instance.
        > I use a local SQL Server instance running in a Docker container on port 12000.    

The next two sections will cover the two scenarios.

### How to start IntelliBlog.AppHost

As with every .NET Aspire application, the means of [configuration](https://learn.microsoft.com/en-us/dotnet/aspire/fundamentals/external-parameters) are declared in the AppHost. 

The appSettings.json file in the project IntelliBlog.AppHost lists all the parameters that can be configured in the `Parameters` section:

```json
{
  // Standard logging configuration
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning",
      "Aspire.Hosting.Dcp": "Warning"
    }
  },

  // Aspire Hosting Configuration
  "Parameters": {
    // The password for the database admin.
    "blogging-db-password": "[ SECRETS ]"
  }
}
```

#### Parameters

`blogging-db-password` The password for the database admin. It is a secret and [should be protected](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-8.0&tabs=windows). Additionally, it should be complex enough to be accepted by SQL Server. You can read more about [SQL Server Linux containers here](https://learn.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker?view=sql-server-ver16&tabs=cli&pivots=cs1-bash).

The entry in the secrets file can be created by running the following command in the directory of the project IntelliBlog.AppHost. 

```bash
dotnet user-secrets set "Parameters:blogging-db-password" "your-complex-password"
```

> **Important note**: when the Aspire host starts there will be a docker container that runs SQL Server and has a database called 'IntelliblogDb' stored on a mounted volume. From the perspective of our code, there will also be a connection string named 'IntelliBlogDb' as it was declared in Program.cs. The API project will look for such connection string to connect to the database. The next section will show how to configure the connection string in the API project.

---

After this you should be ready to run IntelliBlog.

[ :boom: put nice image here]

### How to start the API and the Frontend

This is how the appSettings.json file of the API project looks:

```json
{
  "ConnectionStrings": {
    "IntelliBlogDb": "[ SECRETS ]"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

As you can see, the API project expects a connection string named 'IntelliBlogDb'. This connection string should be configured in the secrets file and should be a SQL server connection string such as:

```
Server=127.0.0.1;Database=IntelliBlog_GQL;User Id=sa;Password=[SECRET];TrustServerCertificate=True;Connection Timeout=5;"
```

The entry in the secrets file can be created by running the following command in the directory of the project IntelliBlog.Api:

```bash
dotnet user-secrets set "ConnectionStrings:IntelliBlogDb" "[your connection string here]"
```

---

At this point you should be able to launch the API project and the Frontend project. 

[ :boom: put nice image here]