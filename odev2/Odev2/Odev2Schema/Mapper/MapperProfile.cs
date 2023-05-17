using AutoMapper;
using Odev2Schema.Staff;
using OdevData.Domain;

namespace Odev2Schema;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<OdevData.Domain.Staff, StaffResponse>();
        CreateMap<StaffRequest, OdevData.Domain.Staff>();
    }
}
