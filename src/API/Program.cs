using API.Types;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services
  .AddGraphQLServer()
  .AddTypes()
  //.AddProjections()
  .AddFiltering()
  .AddSorting()    
  .RegisterDbContext<BloggingDbContext>(DbContextKind.Resolver);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    await app.SeedDataAsync();
}

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.MapGraphQL();

app.Run();
