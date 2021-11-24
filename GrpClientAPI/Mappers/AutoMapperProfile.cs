using AutoMapper;
using Google.Protobuf;

namespace GrpClientAPI.Mappers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TestModel, Models.FromProto.TestModel>().
                ForMember(dest => dest.ByteArrayTest, opt => opt.MapFrom(src => src.ByteArrayTest.ToByteArray())); 
            CreateMap<Models.FromProto.TestModel, TestModel>().
                ForMember(dest => dest.ByteArrayTest, opt =>opt.MapFrom(src => ByteString.CopyFrom(src.ByteArrayTest)));
        }
    }
}
