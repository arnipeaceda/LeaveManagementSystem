using LeaveManagementSystem.Models.LeaveTypes;
using LeaveManagementSystem.Models.Periods;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace LeaveManagementSystem.Models.LeaveAllocations
{
    public class LeaveAllocationsVM
    {
        public int Id { get; set; }

        [Display(Name = "Number Of Days")]
        public int Days { get; set; }

        [Display(Name = "Allocation Period")]
        public PeriodVM Period { get; set; } = new PeriodVM();

        public LeaveTypeReadOnlyVM LeaveType { get; set; } = new LeaveTypeReadOnlyVM();
    }
}
