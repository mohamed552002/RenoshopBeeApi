using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RenoshobeeAPI.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        [Required, DataType(DataType.Currency)]
        public decimal? ShippingPrice { get; set; }
        [Required, DataType(DataType.Currency)]
        public decimal SubTotalPrice { get; set; }
        [Required, DataType(DataType.Currency)]
        public decimal TotalPrice { get; set; }
        [Required]
        public int TotalQuantity { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [ValidateNever,JsonIgnore]
        public Customer Customer { get; set; }
        [ValidateNever]
        public List<OrderItem> orderItems { get; set; }
    }
}
