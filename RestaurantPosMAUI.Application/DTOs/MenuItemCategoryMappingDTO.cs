namespace RestaurantPosMAUI.Application.DTOs
{
    public class MenuItemCategoryMappingDTO
    {
        public int Id { get; set; }
        public int MenuCategoryId { get; set; }
        public int MenuId { get; set; }
        public MenuItemDTO MenuItem { get; set; }
        public MenuCategoryDTO MenuCategory { get; set; }
    }

}
