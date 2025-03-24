using DocuManager.Core.DTOs;
using DocuManager.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocuManager.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/History")]
    public class ActivityHistoryController : ControllerBase
    {
        private readonly IActivityHistoryService _historyService;

        public ActivityHistoryController(IActivityHistoryService historyService)
        {
            _historyService = historyService;
        }

        private int UserId() => int.Parse(HttpContext.Items["UserId"]?.ToString());

        private bool IsAdmin() => HttpContext.Items["UserRole"]?.ToString() == "admin";

        [HttpGet("user")]
        public async Task<IActionResult> GetUserHistory()
        {
            var history = await _historyService.GetUserHistoryAsync(UserId());
            return Ok(history);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsersHistory()
        {
            if(!IsAdmin())
                return Forbid();
            var history = await _historyService.GetAllUsersHistoryAsync();
            return Ok(history);
        }

        [HttpGet]
        public async Task<IActionResult> GetActiveUsersHistory()
        {
            if (!IsAdmin())
                return Forbid();
            var history = await _historyService.GetActiveUsersHistoryAsync();
            return Ok(history);
        }

        [HttpGet("by-date")]
        public async Task<IActionResult> GetUserHistoryByDate([FromQuery]DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            var history = await _historyService.GetUserHistoryByDateAsync(UserId(), startDate, endDate);
            return Ok(history);
        }

        [HttpGet("all/by-date")]
        public async Task<IActionResult> GetAllUsersHistoryByDate([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            if (!IsAdmin())
                return Forbid();
            var history = await _historyService.GetAllUsersHistoryByDateAsync(startDate, endDate);
            return Ok(history);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHistoryRecord([FromBody] ActivityHisotiryDTO historyDto)
        {
            var createdRecord = await _historyService.CreateHistoryRecordAsync(historyDto);
            return CreatedAtAction(nameof(GetUserHistory), new { userId = createdRecord.UserId }, createdRecord);
        }
    }
 
}
