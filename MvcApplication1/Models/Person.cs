using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Person
    {
        public int ID { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        [StringLength(20,MinimumLength=3)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Surname")]
        [StringLength(20, MinimumLength = 3)]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }
    }
    public class PersonDBContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
    }
}