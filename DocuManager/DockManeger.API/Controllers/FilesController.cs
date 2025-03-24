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

        public FileController(IFileService fileService, IUserService userService)
        {
            _fileService = fileService;
        }

        private int UserId() => int.Parse(HttpContext.Items["UserId"]?.ToString());

        private bool IsAdmin() => HttpContext.Items["Role"]?.ToString() == "admin";

        //admin
        [HttpGet]
        public async Task<IActionResult> GetAllFiles()
        {
            if (!IsAdmin())
                return Forbid();
            var files = await _fileService.GetAllFilesAsync();
            return Ok(files);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllActivityFiles()
        {
            if (!IsAdmin())
                return Forbid();
            var files = await _fileService.GetAllActivityFilesAsync();
            return Ok(files);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFile(int id)
        {
            if (!IsAdmin())
                return Forbid();
            var result = await _fileService.DeleteFileAsync(id);
            if (!result)
                return NotFound();
            return NoContent();
        }

        //user
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFileById(int id)
        {
            var file = await _fileService.GetFileByIdAsync(id);
            if (file == null) return NotFound();
            return Ok(file);
        }

        [HttpGet("user/all")]
        public async Task<IActionResult> GetAllFilesByUserId()
        {
            var files = await _fileService.GetAllUserFilesAsync(UserId());
            if (files == null) return NotFound();
            return Ok(files);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetFilesByUserId()
        {
            var files = await _fileService.GetAllActivityUserFilesAsync(UserId());
            if (files == null) return NotFound();
            return Ok(files);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetFilesByCategoryId(int categoryId)
        {
            var files = await _fileService.GetFilesByCategoryIdAsync(categoryId);
            if (files == null) return NotFound();
            return Ok(files);
        }

        [HttpPost]
        public async Task<IActionResult> AddFile([FromBody] FileCreateDTO file)
        {
            var newFile = await _fileService.AddFileAsync(UserId(),file);
            if (newFile == null) return BadRequest();
            return CreatedAtAction(nameof(GetFileById), new { id = newFile.Id }, newFile);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateFile(int id, [FromBody] FileUpdateDTO fileUpdate)
        {
            var file = await _fileService.UpdateFileAsync(UserId(), id, fileUpdate);
            if (file == null)
                return BadRequest(fileUpdate);
            return Ok(file);
        }
        
        [HttpPatch]
        public async Task<IActionResult> SoftDeleteFile(int id)
        {
            var file = await _fileService.GetFileByIdAsync(id);
            if (file == null)
                return NotFound(id);
            var isDeleted = await _fileService.SoftDeleteFileAsync(UserId(), id);
            if (isDeleted)
                return NoContent();
            return BadRequest($"did not sucsses to delete file number {id}");
        }

        //delete user fills
        [HttpPatch]
        public async Task<IActionResult> DeleteUserFiles()
        {
            int num = await _fileService.DeleteUserFilesAsync(UserId());
            return Ok($"{num} rows deleted");
        }

    }
}
