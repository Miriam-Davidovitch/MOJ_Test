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

        public RequestsController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RequestDto>>> GetAllRequests()
        {
            try
            {
                var requests = await _requestService.GetAllRequestsAsync();
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = "שגיאה בקבלת הבקשות" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest([FromBody] CreateRequestDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.RequestorName))
                return BadRequest(new { Success = false, Message = "שם המבקש חובה" });

            if (dto.RequestDescription.Length > 255)
                return BadRequest(new { Success = false, Message = "התאור ארוך מדי" });

            try
            {
                var request = await _requestService.CreateRequestAsync(dto.RequestorName, dto.RequestDescription, dto.RequestTopic);
                
                if (request != null && request.RequestID > 0)
                    return Ok(new { Success = true, Message = "בקשה נוצרה בהצלחה", RequestId = request.RequestID });
                else
                    return BadRequest(new { Success = false, Message = "שגיאה ביצירת הבקשה" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = "שגיאה פנימית בשרת" });
            }
        }
    }

  
}