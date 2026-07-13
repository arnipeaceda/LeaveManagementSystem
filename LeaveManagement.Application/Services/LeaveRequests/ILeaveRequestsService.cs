using LeaveManagementSystem.Models.LeaveRequests;

namespace LeaveManagementSystem.Services.LeaveRequests
{
    public interface ILeaveRequestsService
    {
        Task CreateLeaveRequest(LeaveRequestCreateVM model);
        Task<List<LeaveRequestReadOnlyVM>> GetEmployeeLeaveRequests();
        Task<EmployeeLeaveRequestListVM> GetAllLeaveReports();
        Task CancelLeaveRequest(int leaveRequestId);
        Task<bool> RequestDatesExccedAllocation(LeaveRequestCreateVM model);
        Task<ReviewLeaveRequestVM> GetLeaveRequestForReview(int id);
        Task ReviewLeaveRequest(int id, bool approved);
    }
}