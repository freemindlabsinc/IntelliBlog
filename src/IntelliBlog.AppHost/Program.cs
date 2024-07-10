var builder = DistributedApplication.CreateBuilder(args);

//var dbPassword = builder.AddParameter("blogging-db-password", secret: true);

var pwd = builder.AddParameter("blogging-db-password", secret: true);
var sql = builder.AddSqlServer("sql", pwd, 12000)
                 .WithDataVolume("sql-data");
var sqldb = sql.AddDatabase("IntelliBlogDb");

builder.AddProject<Projects.API>("api")
    .WithReference(sqldb);

builder.Build().Run();
