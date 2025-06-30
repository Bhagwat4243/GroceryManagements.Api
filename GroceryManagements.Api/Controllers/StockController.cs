using Grocery.Bl.IService;
using Grocery.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroceryManagements.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;
        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }
        [HttpPost]
        public async Task<IActionResult>CreateNewStock(StockDto stockDto)
        {
            await _stockService.CreateNewStock(stockDto);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStock()
        {
            var result=await _stockService.GetAllStocks();
            return Ok(result);
        }
    }
}
