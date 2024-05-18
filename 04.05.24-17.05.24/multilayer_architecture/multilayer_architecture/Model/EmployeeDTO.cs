using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multilayer_architecture.Model
{
    public class EmployeeDTO
    {
        public int employee_id_DTO { get; set; }
        public string employee_name_DTO { get; set; }
        public string employee_lastname_DTO { get; set; }
        public Department department_DTO { get; set; }
    }
}
