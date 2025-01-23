using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RestaurantPosMAUI.Models
{
    public partial class MenuCategory : ObservableObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }

        [ObservableProperty]
        private bool isSelected;
    }
}
