using System;
using System.ComponentModel.DataAnnotations;
using PeliculasAPI.Validator;

namespace PeliculasAPI.Entities
{
    public class Gender
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 50, MinimumLength = 5)]
        [FirstLetterUpperCaseAttribute]
        public string Name { get; set; }

       
    }
}

