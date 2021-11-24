using AutoMapper;
using Models.Dtos;
using Models.Entities;
using System.Text;

namespace Models.Profiles
{
    public class OwnerProfile: Profile
    {
        public byte[] Convert(string source) => Encoding.ASCII.GetBytes(source);
        public string Convert(byte[] source) => Encoding.ASCII.GetString(source);

        public OwnerProfile()
        {
            CreateMap<OwnerDTO, Owner>().ForMember(dto => dto.Photo, e => e.MapFrom(o => Convert(o.Photo)));
            CreateMap<Owner, OwnerDTO> ().ForMember(dto => dto.Photo, e => e.MapFrom(o => Convert(o.Photo)));
        }

    }
}
