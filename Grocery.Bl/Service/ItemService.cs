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
    public class ItemService : IItemService
    { 
        private readonly CollectionContext _collectionContext;
        private readonly IMapper _mapper;
        public ItemService(CollectionContext collectionContext,IMapper mapper)
        {
            _collectionContext = collectionContext;
            _mapper = mapper;
        }
        public async Task CreateNewItem(ItemDto itemDto)
        {
            try
            {
                if (itemDto == null)
                {
                    throw new ArgumentNullException(nameof(itemDto));
                }
                var result = _mapper.Map<Item>(itemDto);
                result.ModifiedDate = null;
                await _collectionContext.ItemTbl.AddAsync(result);
                await _collectionContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteItem(int id)
        {
            try
            {
                var result = await _collectionContext.ItemTbl.FindAsync(id);
                if (result == null)
                {
                    throw new InvalidOperationException();
                }
                _collectionContext.Remove(result);
                await _collectionContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ItemDto> GetItemById(int id)
        {
            try
            {
                var result = await _collectionContext.ItemTbl.FindAsync(id);
                if (result == null)
                {
                    throw new InvalidOperationException();
                }
                var data = _mapper.Map<ItemDto>(result);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ItemDto>> GetItems()
        {
            try
            {
                var result = await _collectionContext.ItemTbl.ToListAsync();
                if (result == null)
                {
                    throw new InvalidOperationException();
                }
                var data = _mapper.Map<List<ItemDto>>(result);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateItem(ItemDto itemDto)
        {

            try
            {
                if (itemDto == null)
                {
                    throw new InvalidOperationException();
                }
                var result = await _collectionContext.ItemTbl.FirstOrDefaultAsync(x => x.Id == itemDto.Id);
                if (result == null)
                {
                    throw new InvalidOperationException();
                }
                _mapper.Map(itemDto, result);
                result.CreatedDate = null;
                await _collectionContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
