using LeaveManagementSystem.Services.Email;
using LeaveManagementSystem.Services.LeaveTypes;
using LeaveManagementSystem.Services.LeaveAllocations;
using LeaveManagementSystem.Services.LeaveRequests;
using LeaveManagementSystem.Services.Periods;
using LeaveManagementSystem.Services.Users;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LeaveManagementSystem.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => cfg.AddMaps(Assembly.GetExecutingAssembly()));
            services.AddScoped<ILeaveTypeService, LeaveTypeService>();
            services.AddScoped<ILeaveAllocationsService, LeaveAllocationsService>();
            services.AddScoped<ILeaveRequestsService, LeaveRequestsService>();
            services.AddScoped<IPeriodsService, PeriodsService>();
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<IEmailSender<ApplicationUser>, EmailSender>();
            return services;
        }
    }
}