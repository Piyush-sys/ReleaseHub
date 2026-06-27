using Microsoft.EntityFrameworkCore;
using ReleaseHub.Application.Interfaces;
using ReleaseHub.Application.Interfaces;
using ReleaseHub.Application.Services;
using ReleaseHub.Application.Services;
using ReleaseHub.Infrastructure.Persistence;
using ReleaseHub.Infrastructure.Repositories;
using ReleaseHub.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddScoped<IEmailSubjectParser, EmailSubjectParser>();
builder.Services.AddScoped<IReleaseRepository, ReleaseRepository>();
builder.Services.AddDbContext<ReleaseHubDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ReleaseHubConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapGet("/", () => "ReleaseHub API is Running...");
app.MapControllers();
app.Run();


