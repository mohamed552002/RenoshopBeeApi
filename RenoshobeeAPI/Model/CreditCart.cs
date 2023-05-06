using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RenoshobeeAPI.Model
{
    public class CreditCart
    {
        public int Id { get; set; }
        [Required, MaxLength(16), MinLength(16)]

        public string CardNumber { get; set; }
        [Required, MaxLength(3), MinLength(3)]
        public string CCV { get; set; }
        [DataType(DataType.Date), Required]
        public DateTime ExpireDate { get; set; }
        [Required, Range(0,Double.MaxValue)]
        public decimal Balance { get; set; }
        public int CustomerId { get; set; }
        [Required]
        public int OrderId { get; set; }
        [ValidateNever, JsonIgnore]
        public Customer Customer { get; set; }
        [ValidateNever, JsonIgnore]
        public Order Order { get; set; }
    }
}
