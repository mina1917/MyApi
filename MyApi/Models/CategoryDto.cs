using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Models
{
    public class CategoryDto
    {
        [Required]
        [StringLength(100)]
        public string CatName { get; set; }

        [Required]
        [StringLength(100)]
        public string TagName { get; set; }


        [Required]
        [StringLength(100)]
        public string ParentName { get; set; }


    }
}
