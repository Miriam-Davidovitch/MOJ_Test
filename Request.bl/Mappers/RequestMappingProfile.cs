using AutoMapper;
using Reauests.dal;
using Requests.bl.DTOs;

namespace Requests.bl.Mappers
{
    public class RequestMappingProfile : Profile
    {
        public RequestMappingProfile()
        {
            // CreateRequestDto -> Request
            CreateMap<CreateRequestDto, Requests.dal.Models.Request>()
                .ForMember(dest => dest.RequestID, opt => opt.Ignore())
                .ForMember(dest => dest.RequestCreatedAt, opt => opt.Ignore());

            // Request -> RequestDto
            CreateMap<Requests.dal.Models.Request, RequestDto>();

            // RequestDto -> Request
            CreateMap<RequestDto, Requests.dal.Models.Request>();
        }
    }
}