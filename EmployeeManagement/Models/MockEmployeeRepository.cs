using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {

        private List<Employee> _employeeList;

        public  MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() {Id = 1, Name = "Test 1", Email = "Test@test.com", Department = "Dev" },
                new Employee() {Id = 2, Name = "Test 2", Email = "Test@test.com", Department = "QA" },
                new Employee() {Id = 3, Name = "Test 3", Email = "Test@test.com", Department = "UAT" }
            };
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }
    }
}
