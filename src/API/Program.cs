using Ardalis.ListStartupServices;
using Blogging.Application.Interfaces;
using Blogging.Infrastructure.Data;
using Blogging.Infrastructure.Email;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Extensions.Logging;

var logger = Log.Logger = new LoggerConfiguration()
  .Enrich.FromLogContext()
  .WriteTo.Console()
  .CreateLogger();

logger.Information("Starting web host");

var builder = WebApplication.CreateBuilder(args);

// Adds Aspire Telemetry and other common stuff
builder.AddServiceDefaults();

// Serilog
builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));
var microsoftLogger = new SerilogLoggerFactory(logger)
    .CreateLogger<Program>();

// Configure Web Behavior
builder.Services.Configure<CookiePolicyOptions>(options =>
{
  options.CheckConsentNeeded = context => true;
  options.MinimumSameSitePolicy = SameSiteMode.None;
});

// Adds FastEndpoints
builder.Services.AddFastEndpoints()
                .SwaggerDocument(o =>
                {
                  o.ShortSchemaNames = true;
                });

// Adds:FluentValidation, MediatR, IDomainEventDispatcher
builder.Services.AddApplicationServices();

// Adds: DbContext, repositories, mail server configuration
builder.Services.AddInfrastructureServices(builder.Configuration);

// Mail
if (builder.Environment.IsDevelopment())
{
    // See: https://ardalis.com/configuring-a-local-test-email-server/
    builder.Services.AddScoped<IEmailSender, MimeKitEmailSender>();
}
else
{
    builder.Services.AddScoped<IEmailSender, MimeKitEmailSender>();
}

//builder.AddSqlServerDbContext<AppDbContext>("IntelliBlogDb");

var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
  app.UseShowAllServicesMiddleware(); // see https://github.com/ardalis/AspNetCoreStartupServices
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
