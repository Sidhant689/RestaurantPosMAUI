
using CommunityToolkit.Mvvm.Input;
using RestaurantPosMAUI.Models;
using RestaurantPosMAUI.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace RestaurantPosMAUI.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly MenuCategoryService _menuCategoryService;
        private ObservableCollection<MenuCategory> _menuCategories;

        private MenuCategory? SelectedCategory = null;

        public ObservableCollection<MenuCategory> MenuCategories
        {
            get => _menuCategories;
            set
            {
                _menuCategories = value;
                OnPropertyChanged();
            }
        }

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

                MenuCategories[0].IsSelected = true;
                SelectedCategory = MenuCategories[0];
            }
        }

        
        private void SelectCategory(int categoryId)
        {
            if(SelectedCategory.Id == categoryId)
            {
                return;// the current category is already selected
            }

            var existingSelectedCategory = MenuCategories.First(c => c.Id == categoryId);
            existingSelectedCategory.IsSelected = false;

            var newlySelectedCategory = MenuCategories.First(c => c.Id == categoryId);
            newlySelectedCategory.IsSelected = true;

            SelectedCategory = newlySelectedCategory;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    //public class HomeViewModel : BaseViewModel
    //{
    //    private readonly MenuCategoryService _menuCategoryService;
    //    private ObservableCollection<MenuCategory> _menuCategories = new();

    //    public ObservableCollection<MenuCategory> MenuCategories
    //    {
    //        get => _menuCategories;
    //        set => SetProperty(ref _menuCategories, value);
    //    }

    //    public ICommand LoadDataCommand { get; }

    //    public HomeViewModel()
    //    {
    //        _menuCategoryService = new MenuCategoryService();
    //        LoadDataCommand = new AsyncRelayCommand(LoadDataAsync);
    //    }

    //    private async Task LoadDataAsync()
    //    {
    //        var data = await _menuCategoryService.GetMenuCategoriesAsync();
    //        if (data?.Any() == true)
    //        {
    //            MenuCategories = new ObservableCollection<MenuCategory>(data);
    //        }
    //    }
    //}

}
