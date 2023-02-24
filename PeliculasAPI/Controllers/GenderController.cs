using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PeliculasAPI.Entities;
using PeliculasAPI.Repositories;

namespace PeliculasAPI.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/genders")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IRepositorie repositorie;
        private readonly WeatherForecastController weatherForecastController;
        private readonly ILogger<GenderController> logger;

        public GenderController(IRepositorie repositorie,
            WeatherForecastController weatherForecastController,
            ILogger<GenderController> logger)
        {
            this.repositorie = repositorie;
            this.weatherForecastController = weatherForecastController;
            this.logger = logger;
        }

        [HttpGet] // https://localhost:7126/api/genders
        [HttpGet("list")] // https://localhost:7126/api/genders/list
        [HttpGet("/listGenders")] // https://localhost:7126/listGenders
        public ActionResult<List<Gender>> Get()
        {

            logger.LogInformation("Show all genders!");
            return repositorie.GetAllGenders();
        }


        //[HttpGet("guid")] // api/genders/guid
        //public ActionResult<Guid> GetGUID()
        //{
        //    //return repositorie.getGuid();
        //    return Ok(new
        //    {
        //        Guid_GenderCOntroller = repositorie.getGuid(),
        //        Guid_WeatherForecastController = weatherForecastController.getGUIDWeatherForecastControlller()
        //    });
        //}

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Gender>> Get(int Id, [BindRequired]string name)
        {

            //if (!ModelState.IsValid) {
            //    return BadRequest(ModelState);
            //}

            logger.LogDebug($"Get gender by ID {Id}");


            var gender = await repositorie.GetGenderById(Id);

            if (gender == null)
            {
                logger.LogWarning($"Not found gender from ID: {Id}");
                return NotFound();
            }

            //return Ok(gender);
            return  gender;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Gender gender)
        {
            repositorie.CreateGender(gender);
            return NoContent();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Gender gender)
        {
            return NoContent();
        }
        [HttpDelete]
        public ActionResult Delete()
        {
            return NoContent();
        }

    }
}

