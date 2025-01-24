using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantPosMAUI.Application.DTOs;
using RestaurantPosMAUI.Application.Interfaces;
using System.Runtime.InteropServices;

namespace RestaurantPosMAUI.API.Controllers
{
    public class ApiMenuItemController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;
        private readonly ILogger<ApiMenuItemController> _logger;

        public ApiMenuItemController(IMenuItemService menuItemService, ILogger<ApiMenuItemController> logger)
        {
            _menuItemService = menuItemService;
            _logger = logger;
        }

        [HttpGet]
        [Route("api/GetAllMenuItem")]
        public async Task<ActionResult<IEnumerable<MenuItemDTO>>> GetAllMenuItem()
        {
            var data = await _menuItemService.GetAllMenuItemsAsync();
            return Ok(data);
        }
        [HttpGet]
        [Route("api/GetItemById")]
        public async Task<ActionResult<MenuItemDTO>> GetItemById(int Id)
        {
            var data = await _menuItemService.GetItemByIdAsync(Id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpDelete]
        [Route("api/DeleteItem")]
        public async Task<ActionResult> DeleteItem(int Id)
        {
            _menuItemService.DeleteItemAsync(Id);
            return NoContent();
        }

        [HttpPost]
        [Route("api/CreateItem")]
        public async Task<int> CreateItem(MenuItemDTO Item)
        {
            if (!ModelState.IsValid)
            {
                return 0;
            }

            var createdItem = await _menuItemService.CreateItemAsync(Item);
            return createdItem;
        }

        [HttpGet]
        [Route("api/GetItemsByCategoryId")]
        public async Task<ActionResult<IEnumerable<MenuItemDTO>>> GetItemsByCategoryId(int catergoryId)
        {
            var items = await _menuItemService.GetMenuItemsByMenuCategoryIdAsync(catergoryId);
            return Ok(items);
        }
    }
}
