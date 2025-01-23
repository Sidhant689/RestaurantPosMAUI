using System.ComponentModel.DataAnnotations;

namespace RestaurantPosMAUI.Models
{
    public partial class MenuCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public bool IsSelected { get; set; }
    }
}
