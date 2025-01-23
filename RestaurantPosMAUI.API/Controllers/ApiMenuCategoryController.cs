using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantPosMAUI.Application.DTOs;
using RestaurantPosMAUI.Application.Interfaces;
using RestaurantPosMAUI.Domain.Models;

namespace RestaurantPosMAUI.API.Controllers
{
    [Log]
    public class ApiMenuCategoryController : ControllerBase
    {
        private readonly IMenuCategoryService _menuCategoryService;
        private readonly ILogger<ApiMenuCategoryController> _logger;

        public ApiMenuCategoryController(IMenuCategoryService menuCategoryService, ILogger<ApiMenuCategoryController> logger)
        {
            _menuCategoryService = menuCategoryService;
            _logger = logger;
        }

        [HttpGet]
        [Route("api/GetAllMenuCategory")]
        public async Task<ActionResult<IEnumerable<MenuCategoryDTO>>> GetAllMenuCategory()
        {
            var data = await _menuCategoryService.GetAllMenuCategoryasync();
            return Ok (data);
        }
    }
}
