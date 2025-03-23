using DocuManager.Core.DTOs;
using DocuManager.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace DocuManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityHistoryController : ControllerBase
    {
        private readonly IActivityHistoryService _historyService;

        public ActivityHistoryController(IActivityHistoryService historyService)
        {
            _historyService = historyService;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserHistory(int userId)
        {
            var history = await _historyService.GetUserHistoryAsync(userId);
            return Ok(history);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsersHistory()
        {
            var history = await _historyService.GetAllUsersHistoryAsync();
            return Ok(history);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActiveUsersHistory()
        {
            var history = await _historyService.GetActiveUsersHistoryAsync();
            return Ok(history);
        }

        [HttpGet("user/{userId}/by-date")]
        public async Task<IActionResult> GetUserHistoryByDate(int userId, DateTime? startDate, DateTime? endDate)
        {
            var history = await _historyService.GetUserHistoryByDateAsync(userId, startDate, endDate);
            return Ok(history);
        }

        [HttpGet("all/by-date")]
        public async Task<IActionResult> GetAllUsersHistoryByDate(DateTime? startDate, DateTime? endDate)
        {
            var history = await _historyService.GetAllUsersHistoryByDateAsync(startDate, endDate);
            return Ok(history);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateHistoryRecord([FromBody] ActivityHisotiryDTO historyDto)
        {
            var createdRecord = await _historyService.CreateHistoryRecordAsync(historyDto);
            return CreatedAtAction(nameof(GetUserHistory), new { userId = createdRecord.UserId }, createdRecord);
        }
    }
 
}
