using AutoMapper;
using ContactManager.Data.Entities;
using ContactManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
