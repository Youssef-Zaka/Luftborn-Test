using Bookmarted.Application;
using Bookmarted.Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Application and Infrastructure layers
builder.Services.AddApplicationServices();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");
}
builder.Services.AddInfrastructure(connectionString);

var app = builder.Build();

// Global Exception Handling
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";

        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
        if (exceptionHandlerPathFeature?.Error is InvalidOperationException invalidOpEx)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsJsonAsync(new { Error = invalidOpEx.Message });
        }
        else
        {
            await context.Response.WriteAsJsonAsync(new { Error = "An unexpected error occurred." });
        }
    });
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
