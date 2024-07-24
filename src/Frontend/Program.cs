using Frontend.Components;
using Microsoft.FluentUI.AspNetCore.Components;

// SETS ASPIRE OR NOT
//bool IsAspireApp = false;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults(); // Aspire

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddFluentUIComponents();

builder.Services.AddHttpClient();

// Aspire options
//string url = IsAspireApp ? "http+https://api/graphql" : "https://localhost:6001/graphql";
string url = "https://localhost:6001/graphql";
builder.Services
    .AddBloggingClient()        
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(url));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// asa
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
