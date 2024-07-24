bool IsAspireApp = true;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration, registerDbContext: !IsAspireApp);
builder.AddServiceDefaults(); // Aspire

builder.Services
  .AddGraphQLServer()
  .AddTypes()  
  .AddProjections()
  .AddFiltering()
  .AddSorting()    
  .RegisterDbContext<BloggingDbContext>(DbContextKind.Resolver);

if (IsAspireApp)
{
    builder.AddSqlServerDbContext<BloggingDbContext>("IntelliBlogDb");
}

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
