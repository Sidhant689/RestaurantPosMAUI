using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RestaurantPosMAUI.Domain.Models;

namespace Infrastructure.Data
{
    [Table("tblOrderItem")]
    public class OrderItem
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey("Order")]
        public long OrderId { get; set; }
        [ForeignKey("MenuItem")]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        [NotMapped]
        public decimal Amount => Quantity * Price;

        public virtual Order Order { get; set; }
        public virtual MenuItem MenuItem { get; set; }
    }
}
