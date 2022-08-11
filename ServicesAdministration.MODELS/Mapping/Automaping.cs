using AutoMapper;
using ServicesAdministration.MODELS.Entities;
using ServicesAdministration.MODELS.Models;
using ServicesAdministration.MODELS.Request;

namespace ServicesAdministration.MODELS.Mapping
{
    public class Automaping : Profile
    {
        public Automaping()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<User, UserRequest>().ReverseMap();
            CreateMap<UserRequest, User>().ReverseMap();
            CreateMap<UserModel, User>().ReverseMap();
            CreateMap<ClientModel, Client>().ReverseMap();
            CreateMap<Client, ClientModel>().ReverseMap();
            CreateMap<ClientRequest, Client>().ReverseMap();
            CreateMap<Client, ClientRequest>().ReverseMap();
            CreateMap<Server, ServerModel>().ReverseMap();
            CreateMap<ServerModel, Server>().ReverseMap();
            CreateMap<ServerRequest, Server>().ReverseMap();
            CreateMap<Service, ServiceModel>().ReverseMap();
            CreateMap<ServiceModel, Service>().ReverseMap(); 
            CreateMap<ServiceRequest, Service>().ReverseMap();
            CreateMap<HomologationClientServiceModel, HomologationClientService>().ReverseMap();
        }
    }
}
