using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Application.Interfaces;
using TestApp.Domain.Entities;

namespace TestAppWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService service;

        public EmployeeController(IEmployeeService service)
        {
            this.service = service;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {
            return await service.GetAll();
        }

        // GET api/<EmployeeController>/{GUID}
        [HttpGet("{id}")]
        public async Task<Employee> Get(Guid id)
        {
            return await service.Get(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async void Post([FromBody] Employee value)
        {
            await Task.Run(() => service.Add(value));   //Mediator will clean this dirty code
        }

        // PUT api/<EmployeeController>/{GUID}
        [HttpPut("{id}")]
        public async void Put(Guid id, [FromBody] Employee value)
        {
            await Task.Run(() => service.Update(id, value)); //Mediator will clean this dirty code
        }

        // DELETE api/<EmployeeController>/{GUID}
        [HttpDelete("{id}")]
        public async void Delete(Guid id)
        {
            await Task.Run(() => service.Delete(id)); //Mediator will clean this dirty code
        }
    }
}
