using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RestaurantPosMAUI.Models;
using RestaurantPosMAUI.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MenuItem = RestaurantPosMAUI.Models.MenuItem;

namespace RestaurantPosMAUI.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly MenuCategoryService _menuCategoryService;
        private readonly MenuItemService _menuItemService;

        [ObservableProperty]
        private MenuCategory[] categories = [];

        [ObservableProperty]
        private MenuItem[] _menuItems = [];

        [ObservableProperty]
        private MenuCategory? _selectedCategory = null;

        [ObservableProperty]
        private bool _isLoading;

        public HomeViewModel()
        {
            _menuCategoryService = new MenuCategoryService();
            _menuItemService = new MenuItemService();
            //InitializeAsync();
        }

        [ObservableProperty]
        private bool _isInitialized;

        public async ValueTask InitializeAsync()
        {
            if (_isInitialized) return;// Already Initialized

            _isInitialized = true;

            IsLoading = true;

            Categories = await _menuCategoryService.GetMenuCategoriesAsync();

            Categories[0].IsSelected = true;
            
            SelectedCategory = Categories[0];

            MenuItems = await _menuItemService.GetMenuItemsBycategoryId(SelectedCategory.Id);

            IsLoading = false;

        }

        [RelayCommand]
        private async Task SelectCategoryAsync(int categoryId)
        {
            if (SelectedCategory.Id == categoryId)
                return; // The current category is already selected

            IsLoading = true;

            var existingSelectedCategory = Categories.First(c => c.IsSelected);
            existingSelectedCategory.IsSelected = false;

            var newSelectedCategory = Categories.First(c=> c.Id == categoryId);
            newSelectedCategory.IsSelected = true;

            SelectedCategory = newSelectedCategory;

            MenuItems = await _menuItemService.GetMenuItemsBycategoryId(SelectedCategory.Id);

            IsLoading = false;

            // Force UI update
            //OnPropertyChanged(nameof(Categories));
        }
    }
}
