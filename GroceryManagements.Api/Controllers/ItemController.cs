using Grocery.Bl.IService;
using Grocery.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroceryManagements.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemController : ControllerBase
    { 
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewItem(ItemDto itemDto)
        {
            await _itemService.CreateNewItem(itemDto);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllItem()
        {
            var data = await _itemService.GetItems();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            var data = await _itemService.GetItemById(id);
            return Ok(data);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            await _itemService.DeleteItem(id);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateItem(ItemDto itemDto)
        {
            await _itemService.UpdateItem(itemDto);
            return Ok();
        }
    }
}
