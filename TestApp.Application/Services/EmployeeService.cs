using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Application.Interfaces;
using TestApp.Domain.Entities;

namespace TestApp.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IApplicationDbContext dbContext;

        public EmployeeService(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async void Add(Employee value)
        {
            dbContext.Employees.Add(value);

            await dbContext.SaveChangesAsync();
        }

        public async void Delete(Guid id)
        {
            var employee = dbContext.Employees.SingleOrDefault(p => p.Id == id);

            employee.Deleted = true;

            await dbContext.SaveChangesAsync();
        }

        public async Task<Employee> Get(Guid id)
        {
            return await dbContext.Employees.FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await dbContext.Employees.ToListAsync();
        }

        public async void Update(Guid id, Employee value)
        {
            var employee = dbContext.Employees.SingleOrDefault(p => p.Id == id);

            employee.FirstName = value.FirstName;
            employee.LastName = value.LastName;

            await dbContext.SaveChangesAsync();
        }
    }
}
