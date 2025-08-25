using Requests.bl.DTOs;
using Requests.dal.Models;

namespace Requests.bl
{
    public interface IRequestService
    {
        Task<List<RequestResponseDto>> GetAllRequestsAsync();
        Task<RequestResponseDto> CreateRequestAsync(CreateRequestDto requestDto);
    }
}