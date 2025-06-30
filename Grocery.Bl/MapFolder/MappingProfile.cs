using AutoMapper;
using Grocery.Db.Model;
using Grocery.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Bl.MapFolder
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<ItemDto, Item>().ReverseMap();

            CreateMap<StockDto, Stock>().ReverseMap();

            CreateMap<CustomerDto, Customer>().ReverseMap();

            CreateMap<Order, OrderDto>()
                  .ForMember(dest => dest.OrderDetailsDto, opt => opt.MapFrom(src => src.OrderDetail))
                  .ReverseMap();

            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
        }
    }
}
