using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requests.bl.DTOs
{
    public class RequestResponseDto
    {
        public int RequestID { get; set; }
        public string RequestorName { get; set; } = string.Empty;
        public string? RequestDescription { get; set; }
        public string? RequestTopic { get; set; }
        public DateTime? RequestCreatedAt { get; set; }
    }
}
