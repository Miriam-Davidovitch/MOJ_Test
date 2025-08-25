using System.ComponentModel.DataAnnotations;

namespace Requests.bl.DTOs
{
    public class CreateRequestDto
    {
        [Required(ErrorMessage = "שם המבקש חובה")]
        [StringLength(100, ErrorMessage = "שם המבקש לא יכול להיות ארוך מ-100 תווים")]
        public string RequestorName { get; set; } = string.Empty;

        [StringLength(255, ErrorMessage = "התיאור לא יכול להיות ארוך מ-255 תווים")]
        public string? RequestDescription { get; set; }

        [StringLength(200, MinimumLength = 5, ErrorMessage = "נושא הפנייה חייב להיות בין 5-200 תווים")]
        public string? RequestTopic { get; set; }
    }
}
