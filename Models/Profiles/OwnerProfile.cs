using AutoMapper;
using Common.Functions;
using Models.Dtos;
using Models.Entities;
using System.Text;

namespace Models.Profiles
{
    /// <summary>
    /// Owner profiles
    /// </summary>
    public class OwnerProfile: Profile
    {
        public OwnerProfile()
        {
            CreateMap<OwnerDTO, Owner>().ForMember(dto => dto.Photo, e => e.MapFrom(o => Utilities.Convert(o.Photo)));
            CreateMap<Owner, OwnerDTO> ().ForMember(dto => dto.Photo, e => e.MapFrom(o => Utilities.Convert(o.Photo)));
        }
    }
}
