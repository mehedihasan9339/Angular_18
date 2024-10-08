using Angular18Demo.API.Context;
using Angular18Demo.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Angular18Demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly databaseContext _context;

        public DepartmentsController(databaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var departments = await _context.Departments.ToListAsync();
            return Ok(departments);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return Ok(department);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] Department department)
        {
            var existingDepartment = await _context.Departments.FindAsync(id);
            if (existingDepartment == null) return NotFound();

            existingDepartment.DepartmentName = department.DepartmentName;
            await _context.SaveChangesAsync();

            return Ok(existingDepartment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null) return NotFound();

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
