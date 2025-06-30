using Grocery.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Bl.IService
{
    public interface IStockService
    {
        Task CreateNewStock(StockDto stockDto);
        Task<List<StockDto>> GetAllStocks();
    }
}
