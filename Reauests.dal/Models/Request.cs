using System;
using System.Collections.Generic;

namespace Requests.dal.Models;

public partial class Request
{
    public int RequestID { get; set; }

    public string RequestorName { get; set; } = null!;

    public string? RequestDescription { get; set; }

    public string? RequestTopic { get; set; }

    public DateTime? RequestCreatedAt { get; set; }
}
