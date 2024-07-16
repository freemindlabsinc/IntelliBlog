using Blogging.Infrastructure.Data;
using TestGQL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services
    .AddGraphQLServer()
    .AddTestGQLTypes()
    //.AddQueryType<Query>()
    .RegisterDbContext<AppDbContext>()
    //.AddTestGQLTypes()
    ;

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGraphQL();

app.Run();
