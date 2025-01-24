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
    public class MenuCategoryservice : IMenuCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<MenuCategoryservice> _logger;

        public MenuCategoryservice(IUnitOfWork unitOfWork, IMapper mapper, ILogger<MenuCategoryservice> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<MenuCategoryDTO>> GetAllMenuCategoryasync()
        {
            var data = await _unitOfWork.MenuCategories.GetAllAsync();
            return _mapper.Map<IEnumerable<MenuCategoryDTO>>(data);
        }

        public async Task<MenuCategoryDTO> GetCategoryByIdAsync(int Id)
        {
            var item = await _unitOfWork.MenuCategories.GetByIdAsync(Id);
            return _mapper.Map<MenuCategoryDTO>(item);
        }

        public async Task DeleteCategoryAsync(int Id)
        {
            var item = await _unitOfWork.MenuCategories.GetByIdAsync(Id);
            if (item != null)
            {
                _unitOfWork.MenuCategories.DeleteAsync(item);
                await _unitOfWork.CompleteAsync(Id.ToString(), "DeleteItemAsync");
            }
        }

        public async Task<int> CreateCategoryAsync(MenuCategoryDTO category)
        {
            _logger.LogInformation("Creating new Menu Item: {@MenuCategoryDTO}", category);

            var menuCategory = _mapper.Map<MenuCategory>(category);
            await _unitOfWork.MenuCategories.AddAsync(menuCategory);

            _logger.LogInformation("Category created successfully: {@MenuCategoryDTO}", category);

            await _unitOfWork.CompleteAsync(category.Id.ToString(), "CreateCategoryAsync");
            return category.Id;
        }
    }
}
