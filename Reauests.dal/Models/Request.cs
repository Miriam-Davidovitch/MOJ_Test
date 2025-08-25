using System;
using System.Collections.Generic;

namespace Requests.dal.Models;

public partial class Request
{
    public int Code { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }
}
