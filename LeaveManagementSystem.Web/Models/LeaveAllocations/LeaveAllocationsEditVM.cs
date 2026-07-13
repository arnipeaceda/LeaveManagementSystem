using LeaveManagementSystem.Web.Models.LeaveAllocations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LeaveManagementSystem.Models.LeaveAllocations
{
    public class LeaveAllocationsEditVM : LeaveAllocationsVM
    {
        public EmployeeListVM? Employee { get; set; }
    }
}
