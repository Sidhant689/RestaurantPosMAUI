using AutoMapper;
using Microsoft.Extensions.Logging;
using RestaurantPosMAUI.Application.DTOs;
using RestaurantPosMAUI.Application.Interfaces;
using RestaurantPosMAUI.Domain.Models;
using RestaurantPosMAUI.Infrastructure.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantPosMAUI.Application.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<MenuItemService> _logger;

        public MenuItemService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<MenuItemService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<MenuItemDTO>> GetAllMenuItemsAsync()
        {
            var items = await _unitOfWork.MenuItems.GetAllAsync();
            return _mapper.Map<IEnumerable<MenuItemDTO>>(items);
        }

        public async Task<MenuItemDTO> GetItemByIdAsync(int Id)
        {
            var item = await _unitOfWork.MenuItems.GetByIdAsync(Id);
            return _mapper.Map<MenuItemDTO>(item);
        }

        public async Task DeleteItemAsync(int Id)
        {
            var item = await _unitOfWork.MenuItems.GetByIdAsync(Id);
            if (item != null)
            {
                _unitOfWork.MenuItems.DeleteAsync(item);
                await _unitOfWork.CompleteAsync(Id.ToString(), "DeleteItemAsync");
            }
        }

        public async Task<int> CreateItemAsync(MenuItemDTO item)
        {
            _logger.LogInformation("Creating new Menu Item: {@MenuItemDTO}", item);
            var menuItem = _mapper.Map<MenuItem>(item);
            await _unitOfWork.MenuItems.AddAsync(menuItem);
            _logger.LogInformation("Item created successfully: {@MenuItemDTO}", item);
            await _unitOfWork.CompleteAsync(item.Id.ToString(), "CreateItemAsync");
            return item.Id;
        }

        public async Task<IEnumerable<MenuItemDTO>> GetMenuItemsByMenuCategoryIdAsync(int categoryId)
        {
            var menuItems = await _unitOfWork.MenuItemsRepository.GetMenuItemsByMenuCategoryIdAsync(categoryId);

            return menuItems.Select(item => new MenuItemDTO
            {
                Id = item.Id,
                Name = item.Name,
                Icon = item.Icon,
                Description = item.Description,
                Price = item.Price,
                // Map other properties as needed
            }).ToList();
        }
    }
}
