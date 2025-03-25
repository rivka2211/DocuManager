using DocuManager.Core.DTOs;
using DocuManager.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocuManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        private bool IsAdmin() => HttpContext.Items["UserRole"]?.ToString() == "admin";
        private int UserId() => int.Parse(HttpContext.Items["UserId"]?.ToString());

        [HttpGet]
        public async Task<ActionResult<List<CategoryDTO>>> GetAll()
        {
            if (!IsAdmin())
                return Forbid();
            return Ok(await _categoryService.GetAllCategoriesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> AddCategory(string name)
        {
            var newCategory = await _categoryService.AddCategoryAsync(UserId(),name);
            return CreatedAtAction(nameof(GetById), newCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryDTO categoryDto)
        {
            await _categoryService.UpdateCategoryAsync(categoryDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var success = await _categoryService.DeleteCategoryAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
