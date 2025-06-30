using Grocery.Bl.IService;
using Grocery.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroceryManagements.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewCustomer(CustomerDto customerDto)
        {
            await _customerService.CreateNewCustomer(customerDto);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            var data = await _customerService.GetCustomerList();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var data = await _customerService.GetCustomerById(id);
            return Ok(data);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _customerService.DeleteCustomer(id);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(CustomerDto customerDto)
        {
            await _customerService.UpdateCustomer(customerDto);
            return Ok();
        }
    }
}
