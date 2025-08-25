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
            CreateMap<CreateRequestDto, Requests.dal.Models.Request>();

            // Request -> RequestResponseDto
            CreateMap<Requests.dal.Models.Request, RequestResponseDto>();


        }
    }
}