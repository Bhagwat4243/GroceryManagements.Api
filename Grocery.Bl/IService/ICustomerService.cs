using Grocery.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Bl.IService
{
    public interface ICustomerService
    {
        Task CreateNewCustomer(CustomerDto customerDto);
        Task<List<CustomerDto>> GetCustomerList();
        Task<CustomerDto> GetCustomerById(int id);
        Task DeleteCustomer(int id);
        Task UpdateCustomer(CustomerDto customerDto);
    }
}
