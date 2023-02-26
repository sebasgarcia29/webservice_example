using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PeliculasAPI.Entities;
using PeliculasAPI.Filters;

namespace PeliculasAPI.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/genders")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GenderController : ControllerBase
    {
        private readonly ILogger<GenderController> logger;

        public GenderController(ILogger<GenderController> logger)
        {
            this.logger = logger;
        }

        [HttpGet] // https://localhost:7126/api/genders
        public ActionResult<List<Gender>> Get()
        {
            return new List<Gender>()
            {
                new Gender()
                {
                    Id = 1,
                    Name = "Sebas"

                }
            };
        }

        [HttpGet("{id:int}")]
        public Task<ActionResult<Gender>> Get(int Id)
        {

            throw new NotImplementedException();
        
        }

        [HttpPost]
        public ActionResult Post([FromBody] Gender gender)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Gender gender)
        {
            throw new NotImplementedException();
        }
        [HttpDelete]
        public ActionResult Delete()
        {
            throw new NotImplementedException();
        }

    }
}

