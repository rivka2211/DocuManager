using DocuManager.Core.DTOs;
using DocuManager.Core.Interfaces;
using DocuManager.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocuManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService,IUserService userService)
        {
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFiles()
        {
            var files = await _fileService.GetAllFilesAsync();
            return Ok(files);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFileById(int id)
        {
            var file = await _fileService.GetFileByIdAsync(id);
            if (file == null) return NotFound();
            return Ok(file);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetFilesByUserId()
        {
            int userId = int.Parse(HttpContext.Items["UserId"]?.ToString());
            var files = await _fileService.GetFilesByUserIdAsync(userId);
            return Ok(files);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetFilesByCategoryId(int categoryId)
        {
            var userId = int.Parse(HttpContext.Items["UserId"]?.ToString());
            var files = await _fileService.GetFilesByCategoryIdAsync(userId,categoryId);
            return Ok(files);
        }

        [HttpPost]
        public async Task<IActionResult> AddFile([FromBody] FileCreateDTO file)
        {
            var userId= int.Parse(HttpContext.Items["UserId"]?.ToString());
            var fileDTO = new FileDTO() {FileName= file.FileName,FileUrl= file.FileUrl, OwnerId = userId, CategoryId= file.CategoryId };
            var newFile = await _fileService.AddFileAsync(fileDTO);
            return CreatedAtAction(nameof(GetFileById), new { id = newFile.Id }, newFile);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFile(int id)
        {
            var result = await _fileService.DeleteFileAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
