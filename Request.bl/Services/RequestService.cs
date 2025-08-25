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

        public async Task<List<RequestResponseDto>> GetAllRequestsAsync()
        {
            var requests = await _repository.GetAllRequestsAsync();
            return _mapper.Map<List<RequestResponseDto>>(requests);
        }

        public async Task<RequestResponseDto> CreateRequestAsync(CreateRequestDto requestDto)
        {
            try
            {
                var request = _mapper.Map<Request>(requestDto);
                var createdRequest = await _repository.CreateRequestAsync(request);
                return _mapper.Map<RequestResponseDto>(createdRequest);
            }
            catch (Exception ex)
            {
                throw new Exception("שגיאה בשירות יצירת הבקשה", ex);
            }
        }
    }
}