using Requests.dal.Models;

namespace Reauests.dal
{
    public interface IRequestRepository
    {
        Task<List<Request>> GetAllRequestsAsync();
        Task<Request> CreateRequestAsync(Request request);
    }
}