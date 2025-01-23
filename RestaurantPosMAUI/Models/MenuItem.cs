using System.ComponentModel.DataAnnotations;

namespace RestaurantPosMAUI.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
