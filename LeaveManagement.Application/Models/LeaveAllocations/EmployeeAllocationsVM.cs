using LeaveManagementSystem.Models.LeaveAllocations;

namespace LeaveManagementSystem.Web.Models.LeaveAllocations;

public class EmployeeAllocationsVM : EmployeeListVM
{


    [Display(Name = "Date of Birth")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    [DataType(DataType.Date)]
    public DateOnly DateOfBirth { get; set; }
    public List<LeaveAllocationsVM> LeaveAllocations { get; set; }
    public bool IsCompletedAllocation { get; set; }
}
