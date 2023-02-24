using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using PeliculasAPI.Controllers;
using PeliculasAPI.Filters;
using PeliculasAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
builder.Services.AddResponseCaching();
builder.Services.AddScoped<IRepositorie, RepositoryInMemory>();
builder.Services.AddScoped<WeatherForecastController>();
builder.Services.AddTransient<MyFilterAction>();
builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(MyFilterException));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();
var logger = app.Services.GetService(typeof(ILogger<IStartup>)) as ILogger<IStartup>;

// Configure the HTTP request pipeline.

app.Use(async (context, next) =>
{

    using (var swapStream = new MemoryStream())
    {
        var originalResponse = context.Response.Body;
        context.Response.Body = swapStream;

        await next.Invoke();

        swapStream.Seek(0, SeekOrigin.Begin);
        string response = new StreamReader(swapStream).ReadToEnd();
        swapStream.Seek(0, SeekOrigin.Begin);

        await swapStream.CopyToAsync(originalResponse);
        context.Response.Body = originalResponse;

        logger.LogInformation(response);

    }
});

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseResponseCaching();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
