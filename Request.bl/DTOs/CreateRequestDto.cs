namespace Requests.bl.DTOs
{
    public class CreateRequestDto
    {
        public string RequestorName { get; set; } = string.Empty;
        public string? RequestDescription { get; set; }
        public string? RequestTopic { get; set; }
    }
}
