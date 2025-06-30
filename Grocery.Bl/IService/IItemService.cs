using Grocery.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Bl.IService
{
    public interface IItemService
    {
        Task CreateNewItem(ItemDto itemDto);
        Task<List<ItemDto>> GetItems();
        Task<ItemDto> GetItemById(int id);
        Task DeleteItem(int id);
        Task UpdateItem(ItemDto itemDto);
    }
}
