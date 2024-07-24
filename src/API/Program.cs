var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.AddServiceDefaults(); // Aspire

builder.Services
  .AddGraphQLServer()
  .AddTypes()  
  .AddProjections()
  .AddFiltering()
  .AddSorting()    
  .RegisterDbContext<BloggingDbContext>(DbContextKind.Resolver);

builder
    .EnrichSqlServerDbContext<BloggingDbContext>(configureSettings: (settings) => { }); // Aspire 


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
