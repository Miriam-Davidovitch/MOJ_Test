using AutoMapper;
using Reauests.dal;
using Requests.bl.DTOs;
using Requests.dal.Models;

namespace Requests.bl
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _repository;
        private readonly IMapper _mapper;

        public RequestService(IRequestRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<RequestDto>> GetAllRequestsAsync()
        {
            var requests = await _repository.GetAllRequestsAsync();
            return _mapper.Map<List<RequestDto>>(requests);
        }

        public async Task<RequestDto> CreateRequestAsync(string requestorName, string? requestDescription, string? requestTopic)
        {
            try
            {
                var createDto = new CreateRequestDto
                {
                    RequestorName = requestorName,
                    RequestDescription = requestDescription,
                    RequestTopic = requestTopic
                };

                var request = _mapper.Map<Request>(createDto);
                var createdRequest = await _repository.CreateRequestAsync(request);
                return _mapper.Map<RequestDto>(createdRequest);
            }
            catch (Exception ex)
            {
                throw new Exception("שגיאה בשירות יצירת הבקשה", ex);
            }
        }
    }
}