using System;
using System.ComponentModel.DataAnnotations;

namespace restaurant.Models.Dto
{
	public class VillaDto
	{
        public int id { get; set; }
        [Required]
        [MaxLength(30)]
        public string name { get; set; }
    }
}

