using LeaveManagementSystem.Models.LeaveTypes;
using LeaveManagementSystem.Services.LeaveTypes;
using Microsoft.EntityFrameworkCore;

[Authorize(Roles = Roles.Administrator)]
public class LeaveTypesController(ILeaveTypeService _leaveTypeService) : Controller
{

    public const string NameExistsValidationMessage = "Leave type already exists.";

    // GET: LEAVETYPES
    public async Task<IActionResult> Index()
    {
        var viewData = await _leaveTypeService.GetAll();
        return View(viewData);
    }

    // GET: LEAVETYPES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var leavetype = await _leaveTypeService.Get<LeaveTypeReadOnlyVM>(id);


        if (leavetype == null)
        {
            return NotFound();
        }
        return View(leavetype);
    }

    // GET: LEAVETYPES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: LEAVETYPES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(LeaveTypeCreateVM leaveTypeCreate)
    {
        if (await _leaveTypeService.CheckIfLeaveTypeNameExists(leaveTypeCreate.Name))
        {
            ModelState.AddModelError(nameof(leaveTypeCreate.Name), NameExistsValidationMessage);
        }
        ;
        if (ModelState.IsValid)
        {
            var leaveType = _leaveTypeService.Create(leaveTypeCreate);
            return RedirectToAction(nameof(Index));
        }
        return View(leaveTypeCreate);
    }

    // GET: LEAVETYPES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var leavetype = await _leaveTypeService.Get<LeaveTypeEditVM>(id);
        if (leavetype == null)
        {
            return NotFound();
        }
        return View(leavetype);
    }

    // POST: LEAVETYPES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, LeaveTypeEditVM leavetypeEdit)
    {
        if (id != leavetypeEdit.Id)
        {
            return NotFound();
        }
        if (await _leaveTypeService.CheckIfLeaveTypeNameExists(leavetypeEdit.Name, leavetypeEdit.Id))
        {
            ModelState.AddModelError(nameof(leavetypeEdit.Name), NameExistsValidationMessage);
        }
        ;
        if (ModelState.IsValid)
        {
            try
            {
                var leaveType = _leaveTypeService.Edit(leavetypeEdit);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_leaveTypeService.LeaveTypeExists(leavetypeEdit.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(leavetypeEdit);
    }

    // GET: LEAVETYPES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var leavetype = await _leaveTypeService.Get<LeaveTypeReadOnlyVM>(id);
        if (leavetype == null)
        {
            return NotFound();
        }
        return View(leavetype);
    }

    // POST: LEAVETYPES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _leaveTypeService.Remove(id);
        return RedirectToAction(nameof(Index));
    }


}
