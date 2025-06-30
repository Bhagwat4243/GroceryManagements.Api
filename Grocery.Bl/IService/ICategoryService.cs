using Grocery.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Bl.IService
{
    public interface ICategoryService
    {
        Task CreateNewCategory(CategoryDto categoryDto);
        Task<List<CategoryDto>> GetCategories();
        Task<CategoryDto> GetCategoryById(int id);
        Task DeleteCategory(int id);
        Task UpdateCategory(CategoryDto categoryDto);
    }
}
