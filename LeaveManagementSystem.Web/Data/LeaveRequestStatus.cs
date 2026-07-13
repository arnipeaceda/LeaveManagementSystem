using LeaveManagementSystem.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Data
{
    public class LeaveRequestStatus : BaseEntity
    {
        [StringLength(100)]
        public string StatusName { get; set; } = string.Empty;

    }
}