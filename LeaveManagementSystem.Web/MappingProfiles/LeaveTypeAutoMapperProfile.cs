using LeaveManagementSystem.Data;
using LeaveManagementSystem.Models.LeaveTypes;

namespace LeaveManagementSystem.MappingProfiles
{
    public class LeaveTypeAutoMapperProfile : AutoMapper.Profile
    {
        public LeaveTypeAutoMapperProfile() 
        {
            CreateMap<LeaveType, LeaveTypeReadOnlyVM>();
            //.ForMember(dest => dest.Days, opt => opt.MapFrom(src => src.NumberOfDays));
            CreateMap<LeaveTypeCreateVM, LeaveType>();
                //.ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<LeaveTypeEditVM, LeaveType>().ReverseMap();

        }

    }
}
