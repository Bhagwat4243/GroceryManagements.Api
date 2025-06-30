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
    public class StockService : IStockService
    {
        private readonly CollectionContext _context;
        private readonly IMapper _mapper;
        public StockService(CollectionContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task CreateNewStock(StockDto stockDto)
        {
            try
            {
                if (stockDto == null)
                {
                    throw new ArgumentNullException();
                }
                var result = _mapper.Map<Stock>(stockDto);
                result.ModifiedDate = null;
                result.TotalCost = result.Quantity * result.CostPerQuantity;
                await _context.StockTbl.AddAsync(result);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<StockDto>> GetAllStocks()
        {
            try
            {
                var result=await _context.StockTbl.ToListAsync();
                if (result == null)
                {
                    throw new ArgumentNullException();
                }
                var data=_mapper.Map<List<StockDto>>(result);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
