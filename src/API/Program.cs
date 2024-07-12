using Application.Interfaces;
using Blogging.Infrastructure.Data;
using Blogging.Infrastructure.Email;
using FastEndpoints.Swagger;
//using Serilog;

//var logger = Log.Logger = new LoggerConfiguration()
//  .Enrich.FromLogContext()
//  .WriteTo.Console()
//  .CreateLogger();

//logger.Information("Starting web host");

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Adds Aspire Telemetry and other common stuff
builder.AddServiceDefaults();

// Serilog
// To integrate right look at https://stackoverflow.com/questions/78369387/how-to-wire-up-serilog-to-net-aspire
//builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));

// Configure Web Behavior
builder.Services.Configure<CookiePolicyOptions>(options =>
{
  options.CheckConsentNeeded = context => true;
  options.MinimumSameSitePolicy = SameSiteMode.None;
});

// Adds:FluentValidation, MediatR, IDomainEventDispatcher
builder.Services.AddApplicationServices();
// Adds: AppDbContext, IRepository, IUnitOfWork, MailserverConfiguration
//builder.Services.AddInfrastructureServices(builder.Configuration);
builder.AddInfrastructureServices();

// Adds FastEndpoints
builder.Services.AddFastEndpoints(
    xx =>
    { 
        xx.IncludeAbstractValidators = true;        
    })
    .SwaggerDocument(o =>
    {
        o.ShortSchemaNames = true;
    });


if (builder.Environment.IsDevelopment())
{
    // Mail: we don't send real emails in development
    builder.Services.AddScoped<IEmailSender, FakeEmailSender>();
}

var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();  
}
else
{
  app.UseDefaultExceptionHandler(); // from FastEndpoints
  app.UseHsts();
}

app.UseFastEndpoints()
    .UseSwaggerGen(); // Includes AddFileServer and static files middleware

app.UseHttpsRedirection();

await SeedDatabase(app);

app.Run();

static async Task SeedDatabase(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;

    try
    {
      var context = services.GetRequiredService<AppDbContext>();
        //          context.Database.Migrate();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
      await SeedData.PopulateTestData(context);
    }
    catch (Exception ex)
    {
      var logger = services.GetRequiredService<ILogger<Program>>();
      logger.LogError(ex, "An error occurred seeding the DB. {exceptionMessage}", ex.Message);
    }
}

// Make the implicit Program.cs class public, so integration tests can reference the correct assembly for host building
public partial class Program
{
}
