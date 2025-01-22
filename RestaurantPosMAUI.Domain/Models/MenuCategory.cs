using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestaurantPosMAUI.Domain.Models
{
    [Table("tblMenuCategory")]
    public class MenuCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}
