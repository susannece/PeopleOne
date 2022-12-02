using System.ComponentModel.DataAnnotations;

namespace PeopleApp.Models.ViewModels
{
    public class CreatePersonViewModel
    {
        [Display(Name="Person")]
        [Required]
        public string? FullName { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        public City? City { get; set; }


    }
}
