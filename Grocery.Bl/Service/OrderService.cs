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
    public class OrderService : IOrderService
    {
        private readonly CollectionContext _context;
        private readonly IMapper _mapper;
        public OrderService(CollectionContext collectionContext,IMapper mapper)
        {
            _context = collectionContext;
            _mapper = mapper;
        }
        public async Task CreateNewOrder(OrderDto orderDto)
        {

            try
            {
                if (orderDto == null)
                {
                    throw new ArgumentNullException("Parameters can not be null");
                }
                var orderModel = _mapper.Map<Order>(orderDto);
                orderModel.CreatedDate = DateTime.Now;
                orderModel.ModifiedDate = null;
                orderModel.OrderDetail = new List<OrderDetail>();

                foreach (var orderDetailsDto in orderDto.OrderDetailsDto)
                {
                    var stock = await _context.StockTbl.FirstOrDefaultAsync(x => x.Id == orderDetailsDto.ItemId);
                    if (stock != null)
                    {
                        var orderDetailsModel = _mapper.Map<OrderDetail>(orderDetailsDto);
                        orderDetailsModel.CreatedDate = DateTime.Now;
                        orderDetailsModel.ModifiedDate = null;
                        orderDetailsModel.Total = stock.CostPerQuantity
                            * orderDetailsModel.Quantity;
                        orderDetailsModel.CategoryId = stock.CategoryId;
                        orderModel.OrderDetail.Add(orderDetailsModel);
                    }
                }
                await _context.OrderTbl.AddAsync(orderModel);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
