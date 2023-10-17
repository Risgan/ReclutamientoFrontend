using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using ReclutamientoFrontend.Data;
using ReclutamientoFrontend.Data.Services.Candidate;
using ReclutamientoFrontend.Data.Services.CandidateExperience;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();

var endPointBackEnd = builder.Configuration.GetValue<string>("Endpoints:BackendApi");

builder.Services.AddScoped(sp =>
{
    // Puedes establecer la BaseAddress aquí
    var httpClient = new HttpClient
    {
        Timeout = TimeSpan.FromMinutes(10)
    };

    // Configura la dirección base
    httpClient.BaseAddress = new Uri(endPointBackEnd);

    return httpClient;
});

builder.Services.AddScoped<CandidatoService>();
builder.Services.AddScoped<CandidateExperienceService>();
builder.Services.AddScoped<Radzen.NotificationService>();
builder.Services.AddRadzenComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
