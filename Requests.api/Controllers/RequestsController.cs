using Microsoft.AspNetCore.Mvc;
using Requests.bl;
using Requests.bl.DTOs;

namespace Requests.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestService _requestService;
        private readonly ILogger<RequestsController> _logger;

        public RequestsController(IRequestService requestService, ILogger<RequestsController> logger)
        {
            _requestService = requestService;
            _logger = logger;
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<RequestDto>>> GetAllRequests()
        {
            try
            {
                var requests = await _requestService.GetAllRequestsAsync();
                return Ok(requests);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting requests");
                return StatusCode(500, new { Success = false, Message = "שגיאה בקבלת הבקשות" });
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateRequest([FromBody] CreateRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return BadRequest(new { Success = false, Message = string.Join(", ", errors) });
            }

            try
            {
                var request = await _requestService.CreateRequestAsync(dto);
                
                if (request != null && request.RequestID > 0)
                    return Ok(new { Success = true, Message = "בקשה נוצרה בהצלחה", RequestId = request.RequestID });
                else
                    return BadRequest(new { Success = false, Message = "שגיאה ביצירת הבקשה" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating request for {RequestorName}", dto.RequestorName);
                return StatusCode(500, new { Success = false, Message = "שגיאה פנימית בשרת" });
            }
        }
    }

  
}