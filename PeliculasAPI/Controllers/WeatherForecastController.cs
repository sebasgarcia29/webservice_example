﻿using Microsoft.AspNetCore.Mvc;
using PeliculasAPI.Repositories;

namespace PeliculasAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IRepositorie repository;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IRepositorie repository)
    {
        _logger = logger;
        this.repository = repository;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {

        repository.GetAllGenders();

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }


    //public Guid getGUIDWeatherForecastControlller()
    //{
    //    return repository.getGuid();
    //}

}

