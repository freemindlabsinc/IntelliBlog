using API.Types;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services
    .AddGraphQLServer()
    .AddTypes()
    .AddFiltering()
    .AddSorting()
    //.AddDataLoader<BlogDataLoader>()
    //.AddDataLoader<BlogDataLoader>()
    //.AddDataLoader<BlogDataLoader>()
    .RegisterDbContext<BloggingDbContext>(DbContextKind.Resolver)
    .AddProjections();

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
