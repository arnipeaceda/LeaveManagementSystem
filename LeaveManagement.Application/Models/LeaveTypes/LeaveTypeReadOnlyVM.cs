namespace LeaveManagementSystem.Models.LeaveTypes
{
    public class LeaveTypeReadOnlyVM : BaseLeaveTypeVM
    {
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Maximum Allocation Days")]
        public int NumberOfDays { get; set; }
    }
}
