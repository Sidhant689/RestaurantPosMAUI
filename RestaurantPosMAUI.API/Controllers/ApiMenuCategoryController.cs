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
        [HttpGet]
        [Route("api/GetCategoryById")]
        public async Task<ActionResult<MenuCategoryDTO>> GetCategoryById(int Id)
        {
            var data = await _menuCategoryService.GetCategoryByIdAsync(Id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok (data);
        }

        [HttpDelete]
        [Route("api/DeleteCategory")]
        public async Task<ActionResult> DeleteCategory(int Id)
        {
            _menuCategoryService.DeleteCategoryAsync(Id);
            return NoContent();
        }

        [HttpPost]
        [Route("api/CreateCategory")]
        public async Task<int> CreateCategory(MenuCategoryDTO category)
        {
            if (!ModelState.IsValid)
            {
                return 0;
            }

            var createdCategory = await _menuCategoryService.CreateCategoryAsync(category);
            return createdCategory;
        }
    }
}
