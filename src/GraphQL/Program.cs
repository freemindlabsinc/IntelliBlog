[assembly: Module("Types")]
[assembly: DataLoaderDefaults(
    ServiceScope = DataLoaderServiceScope.DataLoaderScope,
    AccessModifier = DataLoaderAccessModifier.PublicInterface
    )]

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services
    .AddGraphQLServer()
    .AddTypes()
    .AddFiltering()
    .AddSorting();
    //.RegisterDbContext<AppDbContext>(DbContextKind.Resolver);

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
