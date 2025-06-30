using AutoMapper;
using Grocery.Bl.IService;
using Grocery.Db.ContextFolder;
using Grocery.Db.Model;
using Grocery.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Bl.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly CollectionContext _context;
        private readonly IMapper _mapper;
        public CustomerService(CollectionContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task CreateNewCustomer(CustomerDto customerDto)
        {
            try
            {
                if (customerDto == null)
                {
                    throw new ArgumentNullException();
                }
                var result = _mapper.Map<Customer>(customerDto);
                result.ModifiedDate = null;
                await _context.CustomerTbl.AddAsync(result);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteCustomer(int id)
        {
            try
            {
                var result = await _context.CustomerTbl.FindAsync(id);
                if (result == null)
                {
                    throw new ArgumentException();
                }
                _context.Remove(result);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CustomerDto> GetCustomerById(int id)
        {
            try
            {
                var result = await _context.CustomerTbl.FindAsync(id);
                if (result == null)
                {
                    throw new ArgumentException();
                }
                var data = _mapper.Map<CustomerDto>(result);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<CustomerDto>> GetCustomerList()
        {
            try
            {
                var result = await _context.CustomerTbl.ToListAsync();
                if (result == null)
                {
                    throw new ArgumentException();
                }
                var data = _mapper.Map<List<CustomerDto>>(result);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateCustomer(CustomerDto customerDto)
        {

            try
            {
                if (customerDto == null)
                {
                    throw new ArgumentNullException();
                }
                var result = await _context.CustomerTbl.FirstOrDefaultAsync(x => x.Id == customerDto.Id);
                if (result == null)
                {
                    throw new ArgumentException();
                }
                _mapper.Map(customerDto, result);
                result.ModifiedDate = null;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
