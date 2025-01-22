using AutoMapper;
using Infrastructure.Data;
using RestaurantPosMAUI.Application.DTOs;
using RestaurantPosMAUI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantPosMAUI.Application
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<User,UserDto>().ReverseMap();
            CreateMap<MenuCategory,MenuCategoryDTO>().ReverseMap();
            CreateMap<MenuItem,MenuItemDTO>().ReverseMap();
            CreateMap<MenuItemCategoryMapping,MenuItemCategoryMappingDTO>().ReverseMap();
            CreateMap<Order,OrderDTO>().ReverseMap();
            CreateMap<OrderItem,OrderItemDTO>().ReverseMap();
        }
    }
}
