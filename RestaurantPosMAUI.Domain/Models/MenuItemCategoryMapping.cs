using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestaurantPosMAUI.Domain.Models
{
    [Table("tblMenuItemCategoryMapping")]
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
