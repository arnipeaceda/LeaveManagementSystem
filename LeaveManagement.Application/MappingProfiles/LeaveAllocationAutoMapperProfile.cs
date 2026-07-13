using LeaveManagementSystem.Models.LeaveAllocations;
using LeaveManagementSystem.Models.Periods;
using LeaveManagementSystem.Web.Models.LeaveAllocations;

namespace LeaveManagementSystem.MappingProfiles
{
    public class LeaveAllocationAutoMapperProfile : AutoMapper.Profile
    {
        public LeaveAllocationAutoMapperProfile()
        {
            CreateMap<LeaveAllocation, LeaveAllocationsVM>();
            CreateMap<Period, PeriodVM>();
            CreateMap<ApplicationUser, EmployeeListVM>();
            CreateMap<LeaveAllocation, LeaveAllocationsEditVM>();
        }

    }
}
