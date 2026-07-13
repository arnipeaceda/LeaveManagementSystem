namespace LeaveManagementSystem.Data
{
    public class LeaveRequestStatus : BaseEntity
    {
        [StringLength(100)]
        public string StatusName { get; set; } = string.Empty;

    }
}