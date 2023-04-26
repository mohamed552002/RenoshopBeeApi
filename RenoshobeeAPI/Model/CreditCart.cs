using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RenoshobeeAPI.Model
{
    public class CreditCart
    {
        public int Id { get; set; }
        [Required, MaxLength(12), MinLength(12)]

        public string CardNumber { get; set; }
        [Required, MaxLength(3), MinLength(3)]
        public string CCV { get; set; }
        [DataType(DataType.Date), Required]
        public DateTime ExpireDate { get; set; }
        [ForeignKey("ApplicationUser")]
        public int CustomerId { get; set; }
        [ValidateNever]
        public Customer Customer { get; set; }
    }
}
