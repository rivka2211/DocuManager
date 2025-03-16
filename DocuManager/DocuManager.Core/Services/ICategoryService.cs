using DocuManager.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuManager.Core.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetAllCategoriesAsync();
        Task<CategoryDTO> GetCategoryByIdAsync(int id);
        Task<CategoryDTO> AddCategoryAsync(CategoryDTO categoryDto);
        Task<CategoryDTO> UpdateCategoryAsync(CategoryDTO categoryDto);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
