using EmployeeInfo.Data;
using EmployeeInfo.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeInfo.Controllers
{
    //TODO: Replace fat controller with interface-based service and repository layer.
    //TODO: Implements DTOs.
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public EmployeeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllEmployees()
        {
            var empl = await _dataContext.Employees.ToListAsync();
            return empl;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var empl = await _dataContext.Employees.FindAsync(id);
            if (empl is null)
            {
                return BadRequest("Employee not found");
            }
            return Ok(empl);
        }


        [HttpPost]
        public async Task<ActionResult<List<Employee>>> AddEmployee(Employee emp)
        {

            _dataContext.Employees.Add(emp);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Employees.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(Employee updatedEmpl)
        {
            var dbEmpl = await _dataContext.Employees.FindAsync(updatedEmpl.PersonId);
            if (dbEmpl is null)
            {
                return NotFound("Employee not found");
            }
            dbEmpl.FirstName = updatedEmpl.FirstName;
            dbEmpl.LastName = updatedEmpl.LastName;
            dbEmpl.BirthDate = updatedEmpl.BirthDate;
            dbEmpl.EmployedDate = updatedEmpl.EmployedDate;
            dbEmpl.TerminatedDate = updatedEmpl.TerminatedDate;
            dbEmpl.EmployeeNum = updatedEmpl.EmployeeNum;

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Employees.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Employee>>> DeleteEmployee(int id)
        {
            var dbEmpl = await _dataContext.Employees.FindAsync(id);
            if (dbEmpl is null)
            {
                return NotFound("Employee not found");
            }
            _dataContext.Remove(dbEmpl);

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.Employees.ToListAsync());
        }
    }
}
