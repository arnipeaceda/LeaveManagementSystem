using LeaveManagementSystem.Models.LeaveAllocations;
using LeaveManagementSystem.Web.Models.LeaveAllocations;

namespace LeaveManagementSystem.Services.LeaveAllocations
{
    public interface ILeaveAllocationsService
    {
        Task AllocateLeave(string employeedId);
        Task EditAllocation(LeaveAllocationsEditVM allocationEditVm);
        Task<EmployeeAllocationsVM> GetEmployeeAllocations(string? userId);
        Task<LeaveAllocationsEditVM> GetEmployeeAllocation(int allocationId);
        Task<List<EmployeeListVM>> GetEmployees();
        Task<LeaveAllocation> GetCurrentAllocation(int leaveTypeId, string employeeId);
    }
}
