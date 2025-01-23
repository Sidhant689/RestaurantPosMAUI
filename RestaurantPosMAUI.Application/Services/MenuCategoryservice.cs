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
    }
}
