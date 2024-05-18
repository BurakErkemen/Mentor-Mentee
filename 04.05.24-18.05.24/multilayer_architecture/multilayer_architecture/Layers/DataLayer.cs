using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multilayer_architecture.Model
{
    public class DataLayer
    {
        private readonly Context _context;

        public DataLayer(Context context)
        {
            _context = context;
        }

        public void EmployeeAdd(string name, string lastname, int card, int department)
        {
            Employee employee = new Employee()
            {
                employee_identity_card = card,
                employee_name = name,
                employee_lastname = lastname
            };

            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public int? GetEmployeeID(int identitycard)
        {
            // Select employee ID based on identity card number
            int? employeeID = _context.Employees
                .Where(i => i.employee_identity_card == identitycard)
                .Select(i => (int?)i.employee_id)
                .FirstOrDefault();
            return employeeID;
        }

        public void EmployeeUpdate(string name, string lastname, int identitycard)
        {
            var employeeID = GetEmployeeID(identitycard);
            Employee employee = new Employee()
            {
                employee_id = employeeID.GetValueOrDefault(),
                employee_name = name,
                employee_lastname = lastname,
            };
            
        }
        public void EmployeeDelete(int identitycard)
        {
            //Kartına göre Select
            var emplpyeId = GetEmployeeID(identitycard);

        }

        public List<Employee> EmployeesList { get; private set; }

        //Departman Adları
        public void DepartmenAdd(string depName, short depStaff)
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
            //Departman adına göre Select
            var departmentIds = _context.Departments
                                        .Where(d => d.department_name == depName)
                                        .Select(d => d.department_id)
                                        .ToList();

            Department department = new Department()
            {
                department_id = departmentIds.FirstOrDefault(),
                department_name = newName,
                department_staffs = newStaff
            };
            _context.Departments.AddOrUpdate(department);
            _context.SaveChanges();
        }

        public void DepartmentDelete(string depName)
        {
            //Departman adına göre Select
            var departmentsToDelete = _context.Departments
                                          .Where(d => d.department_name == depName)
                                          .ToList();

            // Seçilen departmanları sil
            foreach (var department in departmentsToDelete)
            {
                _context.Departments.Remove(department);
            }
            _context.SaveChanges();
        }
        public List<Department> DepartmensList { get; private set; }
    }
}
