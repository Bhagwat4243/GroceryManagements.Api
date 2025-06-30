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
    public class CategoryService : ICategoryService
    {
        private readonly CollectionContext _context;
        private readonly IMapper _mapper;
        public CategoryService(CollectionContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task CreateNewCategory(CategoryDto categoryDto)
        {
            try
            {
                if (categoryDto == null)
                {
                    throw new ArgumentNullException(nameof(categoryDto));
                }
                var result=_mapper.Map<Category>(categoryDto);
                result.ModifiedDate = null;
                await _context.CategoryTbl.AddAsync(result);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteCategory(int id)
        {
            try
            {
                var result = await _context.CategoryTbl.FindAsync(id);
                if (result == null)
                {
                    throw new InvalidOperationException();
                }
                _context.Remove(result);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<CategoryDto>> GetCategories()
        {
            try
            {
                var result = await _context.CategoryTbl.ToListAsync();
                if (result == null)
                {
                    throw new ArgumentException();
                }
                var data = _mapper.Map<List<CategoryDto>>(result);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CategoryDto> GetCategoryById(int id)
        {
            try
            {
                var result = await _context.CategoryTbl.FindAsync(id);
                if (result == null)
                {
                    throw new InvalidOperationException();
                }
                var data = _mapper.Map<CategoryDto>(result);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateCategory(CategoryDto categoryDto)
        {
            try
            {
                if (categoryDto == null)
                {
                    throw new InvalidOperationException();
                }

                var result = await _context.CategoryTbl.FirstOrDefaultAsync(x => x.Id == categoryDto.Id);
                if (result == null)
                {
                    throw new InvalidOperationException();
                }
                _mapper.Map(categoryDto, result);
                result.CreatedDate = null;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
