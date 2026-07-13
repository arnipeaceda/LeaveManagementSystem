using LeaveManagementSystem.Models.LeaveAllocations;
using LeaveManagementSystem.Models.LeaveRequests;
using LeaveManagementSystem.Models.Periods;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models.LeaveAllocations;

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
