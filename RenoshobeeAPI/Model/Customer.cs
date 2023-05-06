using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RenoshobeeAPI.Model
{
    public class Customer
    {
        public int Id { get; set; }
        [Required, MaxLength(50, ErrorMessage = "FirstName length Mustn't exceed 50 char "), MinLength(2, ErrorMessage = "FirstName length Mustn't be less than 2 char ")]
        public string FirstName { get; set; }
        [Required, MaxLength(50, ErrorMessage = "Lastname length Mustn't exceed 50 char "), MinLength(2, ErrorMessage = "Lastname length Mustn't be less than 2 char ")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Birth Date is required")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public char Gender { get; set; }
        [Required(ErrorMessage = "Email is required"),
        MaxLength(50, ErrorMessage = "Email length Mustn't exceed 50 char "),
        MinLength(3, ErrorMessage = "Email length Mustn't be less than 3 char ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required"),
        MaxLength(50, ErrorMessage = "Password length Mustn't exceed 50 char "),
        MinLength(8, ErrorMessage = "Password length Mustn't be less than 8 char ")]
        public string Password { get; set; }
        public bool EmailReceiveable { get; set; }
        [ValidateNever]
        public Address address { get; set; }
        [ValidateNever]
        public string Img_Url { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastUpdatedAt { get; set; }
        [ValidateNever,NotMapped,JsonIgnore]
        public IFormFile Imgfile { get; set; }
        [ValidateNever]
        public List<Order> Orders { get; set; }

    }
}
