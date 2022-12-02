using System.ComponentModel.DataAnnotations.Schema;

namespace PeopleApp.Models
{
    public class Person : City
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public City? City { get; set; }
        [ForeignKey("CityId")]
        public int CityId { get; set; }
    }
}
