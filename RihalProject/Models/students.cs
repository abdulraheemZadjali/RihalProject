using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RihalProject.Models
{
    public class students
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime? date_of_birth { get; set; }

        public int class_id { get; set; }
        public classes classes { get; set; }

        public int country_id { get; set; }

        public countries country { get; set; }

        [Display(Name = "Created At")]
        public DateTime? created_at { get; set; }

        [Display(Name = "Modified At")]
        public DateTime? modified_at { get; set; }

    }
}
