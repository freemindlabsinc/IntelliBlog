var builder = DistributedApplication.CreateBuilder(args);

// SQL Server
var pwd = builder.AddParameter("blogging-db-password", secret: true);

var sql = builder.AddSqlServer("sql", pwd, port: 12000)
    //.WithImage("mcr.microsoft.com/mssql/server:2022-latest")
    .WithDataVolume();

var sqldb = sql.AddDatabase("IntelliBlogDb");

// REDIS
var cache = builder.AddRedis("cache", port: 12001);

// Projects
var api = builder.AddProject<Projects.API>("api")
       .WithReference(cache)
       .WithReference(sqldb);

//builder.AddProject<Projects.Frontend>("frontend")
//    .WithExternalHttpEndpoints()
//    .WithReference(cache)
//    .WithReference(api);

builder.AddProject<Projects.Frontend2>("frontend2")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(api);

builder.Build().Run();
