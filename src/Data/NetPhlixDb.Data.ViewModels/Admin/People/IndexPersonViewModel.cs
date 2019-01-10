using System;
using System.ComponentModel.DataAnnotations;
using NetPhlixDB.Data.Models.Enums;

namespace NetPhlixDb.Data.ViewModels.Admin.People
{
    public class IndexPersonViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        [Display(Name = "Birth Place")]
        public string BirthPlace { get; set; }

        [Required]
        [Display(Name = "Person Role")]
        public PersonRole PersonRole { get; set; }
    }
}
