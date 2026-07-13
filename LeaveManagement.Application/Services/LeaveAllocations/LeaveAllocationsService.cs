using AutoMapper;
using LeaveManagementSystem.Models.LeaveAllocations;
using LeaveManagementSystem.Services.Periods;
using LeaveManagementSystem.Services.Users;
using LeaveManagementSystem.Web.Models.LeaveAllocations;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Services.LeaveAllocations
{
    public class LeaveAllocationsService(ApplicationDbContext _context, IUserService _userService, IMapper _mapper, IPeriodsService _periodService) : ILeaveAllocationsService
    {
        public async Task AllocateLeave(string employeeId)
        {
            // get all the leave types
            var leaveTypes = await _context.LeaveTypes
                .Where(q => !q.LeaveAllocations.Any(x => x.EmployeeId == employeeId))
                .ToListAsync();

            // get the current period based on the year
            var currentDate = DateTime.Now;
            var period = await _context.Periods.SingleAsync(q => q.EndDate.Year == currentDate.Year);
            var monthsRemaining = period.EndDate.Month - currentDate.Month;

            // foreach leave type, create an allocation entry
            foreach (var leaveType in leaveTypes)
            {
                var accuralRate = decimal.Divide(leaveType.NumberOfDays, 12);
                var leaveAllocation = new LeaveAllocation
                {
                    EmployeeId = employeeId,
                    LeaveTypeId = leaveType.Id,
                    PeriodId = period.Id,
                    Days = (int)Math.Ceiling(accuralRate * monthsRemaining)
                };

                _context.Add(leaveAllocation);
            }

            await _context.SaveChangesAsync();
        }
        public async Task EditAllocation(LeaveAllocationsEditVM allocationEditVm)
        {

            await _context.LeaveAllocations
                .Where(q => q.Id == allocationEditVm.Id)
                .ExecuteUpdateAsync(s => s.SetProperty(e => e.Days, allocationEditVm.Days));
        }


        public async Task<EmployeeAllocationsVM> GetEmployeeAllocations(string? userId)
        {
            var user = string.IsNullOrEmpty(userId)
                ? await _userService.GetLoggedInUser()
                : await _userService.GetUserById(userId);
            var allocations = await GetAllocations(user.Id);
            var allocationVmList = _mapper.Map<List<LeaveAllocation>, List<LeaveAllocationsVM>>(allocations);
            var leaveTypesCount = await _context.LeaveTypes.CountAsync();
            var employeeVm = new EmployeeAllocationsVM
            {
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                LeaveAllocations = allocationVmList,
                IsCompletedAllocation = leaveTypesCount == allocationVmList.Count
            };
            return employeeVm;
        }
        public async Task<List<EmployeeListVM>> GetEmployees()
        {
            var user = await _userService.GetEmployees();
            var employess = _mapper.Map<List<ApplicationUser>, List<EmployeeListVM>>(user.ToList());
            return employess;
        }
        public async Task<LeaveAllocationsEditVM> GetEmployeeAllocation(int allocationId)
        {
            var allocation = await _context.LeaveAllocations
                   .Include(q => q.LeaveType)
                   .Include(q => q.Employee)
                   .FirstOrDefaultAsync(q => q.Id == allocationId);

            var model = _mapper.Map<LeaveAllocationsEditVM>(allocation);

            return model;
        }
        public async Task<LeaveAllocation> GetCurrentAllocation(int leaveTypeId, string employeeId)
        {
            var period = await _periodService.GetCurrentPeriod();
            var allocation = await _context.LeaveAllocations
                .FirstAsync(q => q.LeaveTypeId == leaveTypeId
                && q.EmployeeId == employeeId
                && q.PeriodId == period.Id);
            return allocation;
        }
        private async Task<List<LeaveAllocation>> GetAllocations(string? userId)
        {

            var currentDate = DateTime.Now;

            var leaveAllocations = await _context.LeaveAllocations
                .Include(q => q.LeaveType)
                .Include(q => q.Employee)
                .Include(q => q.Period)
                .Where(l => l.EmployeeId == userId && l.Period.EndDate.Year == currentDate.Year)
                .ToListAsync();

            return leaveAllocations;
        }
        private async Task<bool> AllocationExists(string userId, int periodId, int leaveTypeId)
        {
            var exists = await _context.LeaveAllocations.AnyAsync(q => q.EmployeeId == userId && q.PeriodId == periodId && q.LeaveTypeId == leaveTypeId);
            return exists;
        }
    }

}
