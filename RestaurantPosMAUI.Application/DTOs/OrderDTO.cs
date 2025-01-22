namespace RestaurantPosMAUI.Application.DTOs
{
    public class OrderDTO
    {
        public long Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalItemsCount { get; set; }
        public decimal TotalAmountPaid { get; set; }
        public string PaymentMode { get; set; } // cash/online/card
        public List<OrderItemDTO> OrderItems { get; set; }
    }

}
