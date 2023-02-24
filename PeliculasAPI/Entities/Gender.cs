using System;
using System.ComponentModel.DataAnnotations;
using PeliculasAPI.Validator;

namespace PeliculasAPI.Entities
{
    public class Gender : IValidatableObject
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 10, MinimumLength = 5)]
        //[FirstLetterUpperCaseAttribute]
        public string Name { get; set; }

        [Range(18, 60)]
        public int Age { get; set; }

        [CreditCard]
        public string CreditCard { get; set; }

        [Url]
        public string URL { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {


            if (!string.IsNullOrEmpty(Name))
            {
                var firstWord = Name[0].ToString();

                if (firstWord != firstWord.ToUpper())
                {   
                    yield return new ValidationResult("The first word should be Upper",
                        new string[] { nameof(Name) });
                }
            }

        }
    }
}

