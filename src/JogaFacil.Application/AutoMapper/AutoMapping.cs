using AutoMapper;
using JogaFacil.Comunication.Requests.Users;
using JogaFacil.Comunication.Responses;
using JogaFacil.Domain.Entities;

namespace JogaFacil.Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToEntity();
            EntityToResponse();
        }

        private void RequestToEntity()
        {
            CreateMap<RequestUpdateUserJson, User>();
            CreateMap<RequestRegisterUserJson, User>()
                .ForMember(dest => dest.Password, config => config.Ignore());
        }

        private void EntityToResponse()
        {
            CreateMap<User, ResponseRegisterUserJson>();
            CreateMap<User, ResponseUserJson>();
            CreateMap<User, ResponseUsersJson>();
        }
    }
}
