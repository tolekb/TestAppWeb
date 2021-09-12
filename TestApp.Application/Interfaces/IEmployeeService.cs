using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.Entities;

namespace TestApp.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAll();
        void Delete(Guid id);
        void Update(Guid id, Employee value);
        void Add(Employee value);
        Task<Employee> Get(Guid id);
    }
}
