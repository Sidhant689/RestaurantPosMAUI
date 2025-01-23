using System.ComponentModel.DataAnnotations;

namespace RestaurantPosMAUI.Models
{
    public class Order
    {
        [Key]
        public long Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalItemsCount { get; set; }
        public decimal TotalAmountPaid { get; set; }
        public string PaymentMode { get; set; } //cash/online/card
    }
}
