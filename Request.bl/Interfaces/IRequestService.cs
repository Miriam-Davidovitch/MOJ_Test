using Requests.bl.DTOs;
using Requests.dal.Models;

namespace Requests.bl
{
    public interface IRequestService
    {
        Task<List<RequestDto>> GetAllRequestsAsync();
        Task<RequestDto> CreateRequestAsync(string requestorName, string? requestDescription, string? requestTopic);
    }
}