using AutoMapper;
using Models.Dtos;
using Models.Entities;

namespace Models.Profiles
{
    class PropertyProfile: Profile
    {
        public PropertyProfile()
        {
            CreateMap<PropertyDTO, Property>();
            CreateMap<Property, PropertyDTO>();
        }

    }
}
