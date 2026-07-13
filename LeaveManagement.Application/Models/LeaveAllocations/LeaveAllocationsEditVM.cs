using LeaveManagementSystem.Web.Models.LeaveAllocations;

namespace LeaveManagementSystem.Models.LeaveAllocations
{
    public class LeaveAllocationsEditVM : LeaveAllocationsVM
    {
        public EmployeeListVM? Employee { get; set; }
    }
}
