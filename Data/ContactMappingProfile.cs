using AutoMapper;
using ContactManager.Data.Entities;
using ContactManager.ViewModels;

namespace ContactManager.Data
{
    public class ContactMappingProfile : Profile
    {
        public ContactMappingProfile()
        {
            CreateMap<Client, ClientViewModel>()
                .ForMember(c => c.ClientId, ex => ex.MapFrom(a => a.Id))
                .ReverseMap();

            CreateMap<Address, AddressViewModel>()
                .ReverseMap();
        }
    }
}
