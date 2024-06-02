using multilayer_architecture.Model;
using System.Collections.Generic;
using System.Linq;

namespace multilayer_architecture
{
    public class BusinessLayer
    {
        private readonly DataLayer _dataLayer;

        public BusinessLayer(DataLayer dataLayer)
        {
            _dataLayer = dataLayer;
        }

        private static EmployeeDTO ToEmployeeDTO(Employee employee) => new EmployeeDTO
        {
            employee_id_DTO = employee.employee_id,
            employee_name_DTO = employee.employee_name,
            employee_lastname_DTO = employee.employee_lastname,
            department_DTO = employee.department
        };

        public void PostEmployee(string name, string lastname, int identitycard, int department)
        {
            _dataLayer.EmployeeAdd(name, lastname, identitycard, department);
        }

        public void UpdateEmployee(string name, string lastname, int identitycard)
        {
            _dataLayer.EmployeeUpdate(name, lastname, identitycard);
        }

        public void DeleteEmployee(int identitycard)
        {
            _dataLayer.EmployeeDelete(identitycard);
        }

        public List<EmployeeDTO> GetAllEmployees()
        {
            var employees = _dataLayer.GetEmployeesList();
            return employees.Select(ToEmployeeDTO).ToList();
        }

        // Departman işlemleri için benzer yöntemler eklenebilir

        public void PostDepartment(string depName, short depStaff)
        {
            _dataLayer.DepartmentAdd(depName, depStaff);
        }

        public void UpdateDepartment(string depName, string newName, short newStaff)
        {
            _dataLayer.DepartmentUpdate(depName, newName, newStaff);
        }

        public void DeleteDepartment(string depName)
        {
            _dataLayer.DepartmentDelete(depName);
        }

        public List<Department> GetAllDepartments()
        {
            return _dataLayer.GetDepartmentsList();
        }
    }
}
