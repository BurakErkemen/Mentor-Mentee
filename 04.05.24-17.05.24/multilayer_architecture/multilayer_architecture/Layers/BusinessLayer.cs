using multilayer_architecture.Model;
using System;
namespace multilayer_architecture
{
    public class BusinessLayer
    {
        private readonly DataLayer DataLayer;

        public BusinessLayer(DataLayer dataLayer)
        {
            dataLayer = DataLayer;
        }
        private static EmployeeDTO EmployeeDTO(Employee employee) =>
      new EmployeeDTO
      {
          employee_id_DTO = employee.employee_id,
          employee_name_DTO = employee.employee_name,
          employee_lastname_DTO = employee.employee_lastname,
          department_DTO = employee.department      };

        public async void PostEmployee(string name,string lastname, int identitycard, int department)
        {
            DataLayer.EmployeeAdd(name, lastname, identitycard, department);
            
        }

    } 
}
