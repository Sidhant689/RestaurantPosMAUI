using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantPosMAUI.Models
{
    public class MenuItemCategoryMapping
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("MenuCategory")]
        public int MenuCategoryId { get; set; }
        [ForeignKey("MenuItem")]
        public int MenuId { get; set; }

        public virtual MenuItem MenuItem { get; set; }
        public virtual MenuCategory MenuCategory { get; set; }
    }
}
