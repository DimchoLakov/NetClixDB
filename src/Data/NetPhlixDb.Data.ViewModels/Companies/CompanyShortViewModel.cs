using System;
using System.ComponentModel.DataAnnotations;

namespace NetPhlixDb.Data.ViewModels.Companies
{
    public class CompanyShortViewModel
    {
        private string _details;

        [Required]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Created On")]
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }

        [Required]
        [Display(Name = "Details")]
        [DataType(DataType.Text)]
        public string Details
        {
            get => this._details.Length >= 70 ? this._details.Substring(0, 50) + "..." : this._details;
            set => this._details = value;
        }

        [Required]
        [Display(Name = "Logo")]
        [DataType(DataType.Text)]
        public string Logo { get; set; }
    }
}
