using LeaveManagementSystem.Models.LeaveAllocations;
using LeaveManagementSystem.Services.LeaveAllocations;
using LeaveManagementSystem.Services.LeaveTypes;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Controllers
{
    [Authorize]
    public class LeaveAllocationController(ILeaveAllocationsService _leaveAllocationService, ILeaveTypeService _leaveTypesService) : Controller
    {
        [Authorize(Roles = Roles.Administrator)]
        public async Task<IActionResult> Index()
        {
            var employeeVm = await _leaveAllocationService.GetEmployees();
            return View(employeeVm);
        }
        [Authorize(Roles = Roles.Administrator)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AllocateLeave(string? userId)
        {
            await _leaveAllocationService.AllocateLeave(userId);
            return RedirectToAction(nameof(Details), new { userId });
        }
        [HttpGet]
        [Authorize(Roles = Roles.Administrator)]
        public async Task<IActionResult> EditAllocation(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocation = await _leaveAllocationService.GetEmployeeAllocation(id.Value);
            if (allocation == null)
            {
                return NotFound();
            }
            return View(allocation);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAllocation(LeaveAllocationsEditVM allocation)
        {

            if (await _leaveTypesService.DaysExceedMaximum(allocation.LeaveType.Id, allocation.Days))
            {
                ModelState.AddModelError("Days", "The allocation exceeds the maximum leave type value");
            }

            if (ModelState.IsValid)
            {
                await _leaveAllocationService.EditAllocation(allocation);
                return RedirectToAction(nameof(Details), new { userId = allocation.Employee.Id });
            }

            var days = allocation.Days;
            allocation = await _leaveAllocationService.GetEmployeeAllocation(allocation.Id);
            allocation.Days = days;
            return View(allocation);
        }
        public async Task<IActionResult> Details(string? userId)
        {     
            var employeeVm = await _leaveAllocationService.GetEmployeeAllocations(userId);
            return View(employeeVm);
        }
    }
}
