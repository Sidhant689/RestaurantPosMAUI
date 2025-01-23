using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RestaurantPosMAUI.Models;
using RestaurantPosMAUI.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantPosMAUI.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly MenuCategoryService _menuCategoryService;

        [ObservableProperty]
        private ObservableCollection<MenuCategory> menuCategories;

        [ObservableProperty]
        private MenuCategory? selectedCategory;

        public HomeViewModel()
        {
            _menuCategoryService = new MenuCategoryService();
            MenuCategories = new ObservableCollection<MenuCategory>();
            LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var data = await _menuCategoryService.GetMenuCategoriesAsync();
            if (data != null)
            {
                foreach (var category in data)
                {
                    MenuCategories.Add(category);
                }

                // Select first category
                if (MenuCategories.Any())
                {
                    SelectCategory(MenuCategories[0].Id);
                }
            }
        }

        [RelayCommand]
        private void SelectCategory(int categoryId)
        {
            // Deselect all categories
            foreach (var category in MenuCategories)
            {
                category.IsSelected = false;
            }

            // Find and select new category
            var newSelectedCategory = MenuCategories.FirstOrDefault(c => c.Id == categoryId);
            if (newSelectedCategory != null)
            {
                newSelectedCategory.IsSelected = true;
                SelectedCategory = newSelectedCategory;

                // Force UI update
                OnPropertyChanged(nameof(MenuCategories));
            }
        }
    }
}
