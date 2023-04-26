using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using RenoshopBee.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RenoshobeeAPI.Model
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        [MaxLength(50)]
        public string Size { get; set; }
        [MaxLength(50)]
        public string Color { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required, DataType(DataType.Currency)]
        public decimal TotalPrice { get; set; }
        [ValidateNever,JsonIgnore]
        public Product product { get; set; }
        [ValidateNever,JsonIgnore]
        public Order order { get; set; }
    }
}
