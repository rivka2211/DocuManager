using AutoMapper;
using DocuManager.Core.DTOs;
using DocuManager.Core.Entities;
using DocuManager.Core.Repositories;
using DocuManager.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = DocuManager.Core.Entities.File;

namespace DocuManager.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDTO>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            return _mapper.Map<List<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<CategoryDTO> AddCategoryAsync(int userId,string name)
        {
            Category category = new Category { Name = name, UserId = userId, Files = new List<File>(),IsDeleted=false };
            category = await _categoryRepository.AddCategoryAsync(category);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<CategoryDTO> UpdateCategoryAsync(CategoryDTO categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            var updatedCategory = await _categoryRepository.UpdateCategoryAsync(category);
            return _mapper.Map<CategoryDTO>(updatedCategory);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if (category == null)
                return false;
            category.Files.ForEach(file => file.CategoryId = 0);
            await _categoryRepository.SaveChangesAsync();
            return await _categoryRepository.DeleteCategoryAsync(id);
        }
    }
}
