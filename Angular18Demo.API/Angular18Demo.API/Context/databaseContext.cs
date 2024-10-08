using Angular18Demo.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Angular18Demo.API.Context
{
    public class databaseContext : DbContext
    {
        public databaseContext(DbContextOptions<databaseContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Departments
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "Human Resources" },
                new Department { DepartmentId = 2, DepartmentName = "IT" },
                new Department { DepartmentId = 3, DepartmentName = "Finance" },
                new Department { DepartmentId = 4, DepartmentName = "Marketing" },
                new Department { DepartmentId = 5, DepartmentName = "Sales" }
            );

            // Seed Employees
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, EmployeeName = "John Doe", Email = "john.doe@example.com", Phone = "1234567890", DepartmentId = 1 },
                new Employee { EmployeeId = 2, EmployeeName = "Jane Smith", Email = "jane.smith@example.com", Phone = "0987654321", DepartmentId = 2 },
                new Employee { EmployeeId = 3, EmployeeName = "Michael Johnson", Email = "michael.johnson@example.com", Phone = "1112223333", DepartmentId = 3 },
                new Employee { EmployeeId = 4, EmployeeName = "Emily Davis", Email = "emily.davis@example.com", Phone = "2223334444", DepartmentId = 4 },
                new Employee { EmployeeId = 5, EmployeeName = "Daniel Brown", Email = "daniel.brown@example.com", Phone = "3334445555", DepartmentId = 5 },
                new Employee { EmployeeId = 6, EmployeeName = "Sarah Wilson", Email = "sarah.wilson@example.com", Phone = "4445556666", DepartmentId = 1 },
                new Employee { EmployeeId = 7, EmployeeName = "David Miller", Email = "david.miller@example.com", Phone = "5556667777", DepartmentId = 2 },
                new Employee { EmployeeId = 8, EmployeeName = "Jessica Taylor", Email = "jessica.taylor@example.com", Phone = "6667778888", DepartmentId = 3 },
                new Employee { EmployeeId = 9, EmployeeName = "James Anderson", Email = "james.anderson@example.com", Phone = "7778889999", DepartmentId = 4 },
                new Employee { EmployeeId = 10, EmployeeName = "Laura Martinez", Email = "laura.martinez@example.com", Phone = "8889990000", DepartmentId = 5 }
            );
        }
    }
}
