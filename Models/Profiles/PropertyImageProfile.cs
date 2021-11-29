using AutoMapper;
using Common.Functions;
using Models.Dtos;
using Models.Entities;

namespace Models.Profiles
{
    /// <summary>
    /// Profile class for PropertyImages
    /// </summary>
    public class PropertyImageProfile: Profile
    {
        public PropertyImageProfile()
        {
            CreateMap<PropertyImageDTO, PropertyImage>().ForMember(dto => dto.File, e => e.MapFrom(o => Utilities.Convert(o.File)));
            CreateMap<PropertyImage, PropertyImageDTO>().ForMember(dto => dto.File, e => e.MapFrom(o => Utilities.Convert(o.File)));
        }
    }
}
