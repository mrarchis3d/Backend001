using AutoMapper;
using Models.Dtos;
using Models.Entities;

namespace Models.Profiles
{
    /// <summary>
    /// Property ´profiles
    /// </summary>
    class PropertyProfile: Profile
    {
        public PropertyProfile()
        {
            CreateMap<PropertyDTO, Property>();
            CreateMap<Property, PropertyDTO>();
        }

    }
}
