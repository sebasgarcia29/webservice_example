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

        public GenderController(IRepositorie repositorie)
        {
            this.repositorie = repositorie;
        }

        [HttpGet] // https://localhost:7126/api/genders
        [HttpGet("list")] // https://localhost:7126/api/genders/list
        [HttpGet("/listGenders")] // https://localhost:7126/listGenders
        public ActionResult<List<Gender>> Get()
        {
            return repositorie.GetAllGenders();
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Gender>> Get(int Id, [BindRequired]string name)
        {

            //if (!ModelState.IsValid) {
            //    return BadRequest(ModelState);
            //}


            var gender = await repositorie.GetGenderById(Id);

            if (gender == null)
            {
                return NotFound();
            }

            //return Ok(gender);
            return  gender;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Gender gender)
        {

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

