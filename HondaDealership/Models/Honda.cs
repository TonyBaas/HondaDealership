using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Security.Claims;


namespace HondaDealership.Models
{
    public class Honda
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a year.")]
        [Range(1962, 2999, ErrorMessage = "Year must be after 1962.")]
        public int? VehYear { get; set; }

        [Required(ErrorMessage = "Please enter a model.")]
        public string VehModel { get; set; }

        [Required(ErrorMessage = "Please enter a body style.")]
        public string VehBodyType { get; set; }

        [Required(ErrorMessage = "Please enter a Price.")]
        [Range(0, 1000000, ErrorMessage = "Price must be between 0 and 1000000.")]
        public int VehPrice { get; set; }


    }
}
