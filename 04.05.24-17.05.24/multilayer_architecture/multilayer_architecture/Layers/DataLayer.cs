using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace multilayer_architecture.Model
{
    public class DataLayer
    {
        private readonly Context _context;

        public DataLayer(Context context)
        {
            _context = context;
        }

        // Employee Operations
        public void EmployeeAdd(string name, string lastname, int card, int departmentId)
        {
            Employee employee = new Employee()
            {
                employee_name = name,
                employee_lastname = lastname,
                employee_identity_card = card,
                department = _context.Departments.Find(departmentId)
            };

            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public int? GetEmployeeID(int identitycard)
        {
            return _context.Employees
                           .Where(e => e.employee_identity_card == identitycard)
                           .Select(e => (int?)e.employee_id)
                           .FirstOrDefault();
        }

        public void EmployeeUpdate(string name, string lastname, int identitycard)
        {
            var employee = _context.Employees
                                   .FirstOrDefault(e => e.employee_identity_card == identitycard);

            if (employee != null)
            {
                employee.employee_name = name;
                employee.employee_lastname = lastname;
                _context.SaveChanges();
            }
        }

        public void EmployeeDelete(int identitycard)
        {
            var employee = _context.Employees
                                   .FirstOrDefault(e => e.employee_identity_card == identitycard);

            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }

        public List<Employee> GetEmployeesList()
        {
            return _context.Employees.Include(e => e.department).ToList();
        }

        // Department Operations
        public void DepartmentAdd(string depName, short depStaff)
        {
            Department department = new Department()
            {
                department_name = depName,
                department_staffs = depStaff
            };

            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public void DepartmentUpdate(string depName, string newName, short newStaff)
        {
            var department = _context.Departments
                                     .FirstOrDefault(d => d.department_name == depName);

            if (department != null)
            {
                department.department_name = newName;
                department.department_staffs = newStaff;
                _context.SaveChanges();
            }
        }

        public void DepartmentDelete(string depName)
        {
            var departmentsToDelete = _context.Departments
                                              .Where(d => d.department_name == depName)
                                              .ToList();

            foreach (var department in departmentsToDelete)
            {
                _context.Departments.Remove(department);
            }
            _context.SaveChanges();
        }

        public List<Department> GetDepartmentsList()
        {
            return _context.Departments.ToList();
        }
    }
}
