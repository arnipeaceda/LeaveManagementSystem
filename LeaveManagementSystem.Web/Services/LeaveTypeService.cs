using AutoMapper;
using LeaveManagementSystem.Data;
using LeaveManagementSystem.Models.LeaveTypes;
using LeaveManagementSystem.Web.Data;
using Microsoft.EntityFrameworkCore;


namespace LeaveManagementSystem.Services
{
    public class LeaveTypeService(ApplicationDbContext _context, IMapper _mapper) : ILeaveTypeService
    {
        public async Task<List<LeaveTypeReadOnlyVM>> GetAll()
        {
            var data = await _context.LeaveTypes.ToListAsync();
            var viewData = _mapper.Map<List<LeaveTypeReadOnlyVM>>(data);
            return viewData;
        }
        public async Task<T?> Get<T>(int? id) where T : class
        {
            var data = await _context.LeaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (data == null)
            {
                return null;
            }
            var viewData = _mapper.Map<T>(data);
            return viewData;
        }
        public async Task Remove(int id)
        {
            var data = await _context.LeaveTypes.FirstOrDefaultAsync(m => m.Id == id);
            if (data != null)
            {
                _context.Remove(data);
                await _context.SaveChangesAsync();
            }
        }
        public async Task Edit(LeaveTypeEditVM model)
        {
            var leaveType = _mapper.Map<LeaveType>(model);
            _context.Update(leaveType);
            await _context.SaveChangesAsync();
        }
        public async Task Create(LeaveTypeCreateVM model)
        {
            var leaveType = _mapper.Map<LeaveType>(model);
            _context.Add(leaveType);
            await _context.SaveChangesAsync();
        }
        public bool LeaveTypeExists(int? id)
        {
            return _context.LeaveTypes.Any(e => e.Id == id);
        }
        public async Task<bool> CheckIfLeaveTypeNameExists(string name, int? id = null)
        {
            return await _context.LeaveTypes.AnyAsync(q => q.Name.ToLower().Equals(name.ToLower()) && (!id.HasValue || q.Id != id));
        }
    }
}
