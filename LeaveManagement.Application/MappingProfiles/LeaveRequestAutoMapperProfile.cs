using LeaveManagementSystem.Models.LeaveRequests;

namespace LeaveManagementSystem.MappingProfiles
{
    public class LeaveRequestAutoMapperProfile : AutoMapper.Profile
    {
        public LeaveRequestAutoMapperProfile()
        {
            CreateMap<LeaveRequestCreateVM, LeaveRequest>();

        }

    }
}
