using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RihalProject.Models
{
    public class classes
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Class Name")]
        public string class_name { get; set; }

        public List<students> students { get; set; }

        [Display(Name = "Created At")]
        public DateTime? created_at { get; set; }

        [Display(Name = "Modified At")]
        public DateTime? modified_at { get; set; }

    }
}
