using System;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                    new Employee
                    {
                        Id = 1,
                        Name = "New Test",
                        Department = "Dev",
                        Email = "newtest@test.com"
                    },
                    new Employee
                    {
                        Id = 2,
                        Name = "New Test 2",
                        Department = "Dev 2",
                        Email = "newtest2@test.com"
                    }
                );

        }
    }
}
