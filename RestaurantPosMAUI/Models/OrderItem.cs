using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantPosMAUI.Models
{
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
