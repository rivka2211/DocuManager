using DocuManager.Core.DTOs;
using DocuManager.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DocuManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
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

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetFilesByUserId(int userId)
        {
            var files = await _fileService.GetFilesByUserIdAsync(userId);
            return Ok(files);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetFilesByCategoryId(int categoryId)
        {
            var files = await _fileService.GetFilesByCategoryIdAsync(categoryId);
            return Ok(files);
        }

        [HttpPost("tags")]
        public async Task<IActionResult> GetFilesByTags([FromBody] List<int> tagIds)
        {
            var files = await _fileService.GetFilesByTagsAsync(tagIds);
            return Ok(files);
        }

        [HttpPost]
        public async Task<IActionResult> AddFile([FromBody] FileDTO fileDTO)
        {
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
