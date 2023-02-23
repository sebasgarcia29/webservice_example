using System;
using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.Entities
{
	public class Gender
	{

		public int Id { get; set; }

		[Required(ErrorMessage ="El campo {0} es requerido")]
		[StringLength(maximumLength:10, MinimumLength = 5)]
        public string Name { get; set; }

		[Range(18, 60)]
		public int Age { get; set; }

		[CreditCard]
		public string CreditCard { get; set; }

		[Url]
		public string URL { get; set; }

	}
}

