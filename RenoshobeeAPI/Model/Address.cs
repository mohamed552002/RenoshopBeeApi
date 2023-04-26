using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RenoshobeeAPI.Model
{
    public class Address
    {
        public int Id { get; set; }
        [Required, MaxLength(50, ErrorMessage = "Country length Mustn't exceed 50 char "), MinLength(2, ErrorMessage = "Country length Mustn't be less than 2 char ")]
        public string Country { get; set; }
        [Required, MaxLength(50, ErrorMessage = "City length Mustn't exceed 50 char "), MinLength(2, ErrorMessage = "City length Mustn't be less than 2 char ")]
        public string City { get; set; }
        [Required, MaxLength(50, ErrorMessage = "Street length Mustn't exceed 50 char "), MinLength(2, ErrorMessage = "Street length Mustn't be less than 2 char ")]
        public string Street { get; set; }
        [ValidateNever]
        public int customerId { get; set; }
        [ValidateNever,JsonIgnore,NotMapped]
        public Customer customer { get; set; }
    }
}
