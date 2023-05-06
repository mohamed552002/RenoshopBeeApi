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
        [Required, DataType(DataType.Currency), Range(0, double.MaxValue)]
        public decimal SubTotalPrice { get; set; }
        [Required, DataType(DataType.Currency),Range(0,double.MaxValue)]
        public decimal TotalPrice { get; set; }
        [Required,Range(0,int.MaxValue)]
        public int TotalQuantity { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [ValidateNever,JsonIgnore]
        public Customer Customer { get; set; }
        [Required]
        public List<OrderItem> orderItems { get; set; }
    }
}
