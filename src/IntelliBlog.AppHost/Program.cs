var builder = DistributedApplication.CreateBuilder(args);

// SQL Server
var pwd = builder.AddParameter("blogging-db-password", secret: true);

var sql = builder.AddSqlServer("sql", pwd, port: 12000)
                 .WithDataVolume("sql-data");

var sqldb = sql.AddDatabase("IntelliBlogDb");

// REDIS
var cache = builder.AddRedis("cache", port: 12001);

// References
builder.AddProject<Projects.API>("api")
       .WithReference(cache)
       .WithReference(sqldb);

builder.Build().Run();
