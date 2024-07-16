using Blogging.Infrastructure.Data;
using TestGQL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services
    .AddGraphQLServer()
    .AddFiltering()
    .AddSorting()
    //.AddQueryType<Query>()
    .RegisterDbContext<AppDbContext>(DbContextKind.Resolver)
    .AddTestGQLTypes()

    //.AddTestGQLTypes()
    ;

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGraphQL();

app.Run();
