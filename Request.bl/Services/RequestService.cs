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

        public async Task<Request> CreateRequestAsync(CreateRequestDto dto)
        {
            var request = _mapper.Map<Request>(dto);

            return await _repository.CreateRequestAsync(request);
        }
    }
}